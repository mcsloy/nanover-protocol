"""
Narupa frame client that renders atoms to a curses display in the terminal.

The client connects to a Narupa Frame server, and renders the frames it receives
into the terminal.
"""
import argparse

import math
import numpy as np
import curses
import colorsys
import time

from narupa.trajectory import FrameClient

from transformations import rotation_matrix, scale_matrix

character_sets = {
    "boxes": [" ", "░", "▒", "▓", "█"],
    "blobs": [" ", ".", "o", "O", "@"],
    "extended-blobs": [" ", "◦", "·", "◌", "○", "●"],
}

class UserQuitException(Exception):
    pass

class Camera:
    def __init__(self):
        self.angle = 0
        self.pitch = math.pi / 2
        self.scale = 5
        self.origin = None

    def get_matrix(self):
        return (scale_matrix(self.scale, origin=self.origin)
              @ rotation_matrix(self.angle, [0, 0, 1], point=self.origin)
              @ rotation_matrix(self.pitch, [1, 0, 0], point=self.origin))

class Timer:
    def __init__(self):
        self.last_time = time.time()

    def get_delta(self):
        return time.time() - self.last_time

    def reset(self):
        delta_time = self.get_delta()
        self.last_time = time.time()
        return delta_time

class Renderer:
    def __init__(self, characters, colors):
        self.set_characters(characters)
        self.set_colors(colors)

    def set_characters(self, characters):
        self.characters = characters
        self.character_lookup = np.array(self.characters + [self.characters[-1]])

    def set_colors(self, colors):
        self.colors = colors
        self.color_lookup = np.array(self.colors + [self.colors[-1]])

element_colors = {
    #1: curses.COLOR_WHITE,
    6: curses.COLOR_CYAN,
    7: curses.COLOR_BLUE,
    8: curses.COLOR_RED,
    16: curses.COLOR_YELLOW,
}

def render_positions_to_window(window, positions: np.ndarray, renderer, elements=None):
    h, w = window.getmaxyx()

    positions[:,0] += (w / 2)
    positions[:,1] += (h / 2)
    positions[:,2] *= 1000
    np.round(positions, out=positions)
    positions = positions.astype(int)

    depth_buffer = np.full((w, h), 0, dtype=np.float32)
    color_buffer = {}

    color_count = len(renderer.colors) - 1

    min_depth = max_depth = positions[0][2]

    def record_color(index, x, y, z):
        nonlocal min_depth, max_depth

        coord = (x, y)

        prev_depth = depth_buffer[x, y] if coord in color_buffer else min_depth
        this_depth = z

        min_depth = min(min_depth, this_depth)
        max_depth = max(max_depth, this_depth)

        if this_depth >= prev_depth:
            if elements:
                element = elements[index]
                if element not in element_colors:
                    return

                color_index = element_colors[element]
            else:
                color_index = int((index * .1) % color_count)

            color_buffer[coord] = renderer.colors[color_index]
            depth_buffer[x, y] = this_depth

    for index, position in enumerate(positions):
        x, y, z = position[0], position[1], position[2]

        if x < 0 or x >= w or y < 0 or y >= h:
            continue
        if x == w - 1 and y == h - 1:
            continue

        record_color(index, x, y, z)

    char_count = len(renderer.characters)

    # transform depths into cell indexes
    depth_buffer -= min_depth
    depth_buffer *= char_count / (max_depth - min_depth)
    depth_buffer = depth_buffer.astype(int)

    char_buffer = renderer.character_lookup[depth_buffer]

    for (x, y), color in color_buffer.items():
        window.addch(y, x, char_buffer[x, y], color)

def generate_colors(custom_colors=False):
    max_colors = 8

    if curses.can_change_color() and custom_colors:
        max_colors = 16
        curses.init_color(0, 0, 0, 0)
        for i in range(1, max_colors):
            r, g, b = colorsys.hsv_to_rgb(i / max_colors, .5, 1)
            curses.init_color(i, int(r * 1000), int(g * 1000), int(b * 1000))

    for i in range(1, max_colors):
        curses.init_pair(i, i, curses.COLOR_BLACK)

    colors = [curses.color_pair(i) for i in range(max_colors)]

    return colors

def run_curses_client(stdscr, *, address: str, port: int, custom_colors=False, skin="boxes", cpk=False):
    """
    Connect to a Narupa frame server and render the received frames to a curses 
    window.

    :param stdscr: Curses window to render to.
    :param address: Host name to connect to.
    :param port: Port to connect to on the host.
    :param custom_colors: Whether to modify the terminal colors.
    :param skin: Name of character set to use.
    """

    colors = generate_colors(custom_colors=custom_colors)
    renderer = Renderer(character_sets[skin], colors)
    renderer2 = Renderer(character_sets["blobs"], colors)

    camera = Camera()
    fps_timer = Timer()
    render_timer = Timer()

    curses.curs_set(False)
    stdscr.clear()
    stdscr.nodelay(True)
    stdscr.addstr(0, 0, "Connecting...")
    stdscr.refresh()

    client = FrameClient(address=address, port=port)

    stdscr.clear()
    stdscr.addstr(0, 0, "Connected.")

    latest_frame = None
    latest_elements = None

    def get_frame(frame_index, frame):
        nonlocal latest_frame, latest_elements
        latest_frame = frame

        if 'particle.element' in frame:
            latest_elements = frame.particle_elements

    client.subscribe_frames_async(get_frame)

    def show_controls(window):
        window.addstr(0, 0, "arrow keys -- rotate camera")
        window.addstr(1, 0, " < >  keys -- zoom")

    def rotate_plus():
        camera.angle += .1
    def rotate_minus():
        camera.angle -= .1
    def pitch_plus():
        camera.pitch += .1
    def pitch_minus():
        camera.pitch -= .1
    def zoom_in():
        camera.scale *= .9
    def zoom_out():
        camera.scale /= .9
    def toggle_cpk():
        nonlocal cpk
        cpk = not cpk
    def quit():
        raise UserQuitException()

    bindings = {
        curses.KEY_LEFT:  rotate_plus,
        curses.KEY_RIGHT: rotate_minus,
        curses.KEY_UP:    pitch_plus,
        curses.KEY_DOWN:  pitch_minus,
        ord(","):         zoom_in,
        ord("."):         zoom_out,
        ord("q"):         quit,
        ord("x"):         toggle_cpk,
    }

    def check_input():
        char = stdscr.getch()

        if char in bindings:
            bindings[char]()

        curses.flushinp()

    def process_frame(frame):
        # convert positions from frame
        positions = np.array(frame.particle_positions, dtype=np.float32).reshape((-1, 3))

        # center the camera
        camera.origin = np.sum(positions, axis=0) / len(positions)

        # add w component to positions then multiply by camera matrix
        positions = np.append(positions, np.ones((len(positions), 1)), axis=-1)
        positions = positions @ camera.get_matrix()

        return positions

    h, w = stdscr.getmaxyx()
    win1 = curses.newwin(h, w // 2, 0, 0)
    win2 = curses.newwin(h, w // 2, 0, w // 2)

    def render(frame):
        positions = process_frame(frame)
        #camera.angle += math.pi
        #positions2 = process_frame(frame)
        #camera.angle -= math.pi

        stdscr.clear()

        #win1.clear()
        render_positions_to_window(stdscr, positions, renderer, latest_elements if cpk else None)
        #win2.clear()
        #render_positions_to_window(win2, positions2, renderer2)
        
        #win1.refresh()
        #win2.refresh()

        show_controls(stdscr)

        stdscr.addstr(h - 1, 0, "{0:.3} fps".format(1.0 / fps_timer.reset()))
        stdscr.refresh()

    def loop():
        check_input()

        if render_timer.get_delta() < 0.05 or latest_frame is None:
            return

        render_timer.reset()

        render(latest_frame)

    try:
        while True:
            loop()
            time.sleep(.01)
    except UserQuitException:
        pass
    finally:
        stdscr.clear()
        stdscr.addstr(0, 0, "Closing...")
        stdscr.refresh()
        client.close()


def handle_user_args() -> argparse.Namespace:
    """
    Parse the arguments from the command line.

    :return: The namespace of arguments read from the command line.
    """
    description = "Connect to a Narupa trajectory server and render the atoms live in a curses display."
    parser = argparse.ArgumentParser(description=description)
    parser.add_argument('--host', default='localhost')
    parser.add_argument('--port', type=int, default=8000)
    parser.add_argument('--rainbow', action="store_true")
    parser.add_argument('--skin', default="boxes")
    parser.add_argument('--cpk', action="store_true")
    arguments = parser.parse_args()
    return arguments


def main(stdscr):
    arguments = handle_user_args()
    run_curses_client(
        stdscr,
        address=arguments.host,
        port=arguments.port,
        custom_colors=arguments.rainbow,
        skin=arguments.skin,
        cpk=arguments.cpk,
    )


if __name__ == '__main__':
    curses.wrapper(main)
