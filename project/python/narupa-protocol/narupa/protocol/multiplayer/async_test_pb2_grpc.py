# Generated by the gRPC Python protocol compiler plugin. DO NOT EDIT!
import grpc

from narupa.protocol.multiplayer import async_test_pb2 as narupa_dot_protocol_dot_multiplayer_dot_async__test__pb2


class TestStub(object):
  # missing associated documentation comment in .proto file
  pass

  def __init__(self, channel):
    """Constructor.

    Args:
      channel: A grpc.Channel.
    """
    self.DoSomething = channel.unary_stream(
        '/narupa.multiplayer.Test/DoSomething',
        request_serializer=narupa_dot_protocol_dot_multiplayer_dot_async__test__pb2.Request.SerializeToString,
        response_deserializer=narupa_dot_protocol_dot_multiplayer_dot_async__test__pb2.Response.FromString,
        )


class TestServicer(object):
  # missing associated documentation comment in .proto file
  pass

  def DoSomething(self, request, context):
    """Represents an avatar stream.
    """
    context.set_code(grpc.StatusCode.UNIMPLEMENTED)
    context.set_details('Method not implemented!')
    raise NotImplementedError('Method not implemented!')


def add_TestServicer_to_server(servicer, server):
  rpc_method_handlers = {
      'DoSomething': grpc.unary_stream_rpc_method_handler(
          servicer.DoSomething,
          request_deserializer=narupa_dot_protocol_dot_multiplayer_dot_async__test__pb2.Request.FromString,
          response_serializer=narupa_dot_protocol_dot_multiplayer_dot_async__test__pb2.Response.SerializeToString,
      ),
  }
  generic_handler = grpc.method_handlers_generic_handler(
      'narupa.multiplayer.Test', rpc_method_handlers)
  server.add_generic_rpc_handlers((generic_handler,))