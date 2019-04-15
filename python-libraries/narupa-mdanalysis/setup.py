#!/usr/bin/env python

from distutils.core import setup
from setuptools import find_namespace_packages

setup(name='narupa-mdanalysis',
      version='0.1.0',
      description='MDAnalysis integration for Narupa',
      author='Intangible Realities Lab',
      author_email='m.oconnor@bristol.ac.uk',
      url='https://gitlab.com/intangiblerealities/',
      packages=find_namespace_packages('src', include='narupa.*'),
      package_dir={'': 'src'},
      requires=(
            'narupa',
            'MDAnalysis',
      ),
     )