# Generated by the protocol buffer compiler.  DO NOT EDIT!
# source: narupa/protocol/topology/ResidueInfo.proto

import sys
_b=sys.version_info[0]<3 and (lambda x:x) or (lambda x:x.encode('latin1'))
from google.protobuf import descriptor as _descriptor
from google.protobuf import message as _message
from google.protobuf import reflection as _reflection
from google.protobuf import symbol_database as _symbol_database
# @@protoc_insertion_point(imports)

_sym_db = _symbol_database.Default()




DESCRIPTOR = _descriptor.FileDescriptor(
  name='narupa/protocol/topology/ResidueInfo.proto',
  package='narupa.protocol.topology',
  syntax='proto3',
  serialized_options=None,
  serialized_pb=_b('\n*narupa/protocol/topology/ResidueInfo.proto\x12\x18narupa.protocol.topology\"B\n\x0bResidueInfo\x12\x15\n\rresidue_index\x18\x01 \x01(\r\x12\x0e\n\x06res_id\x18\x02 \x01(\t\x12\x0c\n\x04name\x18\x03 \x01(\tb\x06proto3')
)




_RESIDUEINFO = _descriptor.Descriptor(
  name='ResidueInfo',
  full_name='narupa.protocol.topology.ResidueInfo',
  filename=None,
  file=DESCRIPTOR,
  containing_type=None,
  fields=[
    _descriptor.FieldDescriptor(
      name='residue_index', full_name='narupa.protocol.topology.ResidueInfo.residue_index', index=0,
      number=1, type=13, cpp_type=3, label=1,
      has_default_value=False, default_value=0,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='res_id', full_name='narupa.protocol.topology.ResidueInfo.res_id', index=1,
      number=2, type=9, cpp_type=9, label=1,
      has_default_value=False, default_value=_b("").decode('utf-8'),
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='name', full_name='narupa.protocol.topology.ResidueInfo.name', index=2,
      number=3, type=9, cpp_type=9, label=1,
      has_default_value=False, default_value=_b("").decode('utf-8'),
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
  ],
  extensions=[
  ],
  nested_types=[],
  enum_types=[
  ],
  serialized_options=None,
  is_extendable=False,
  syntax='proto3',
  extension_ranges=[],
  oneofs=[
  ],
  serialized_start=72,
  serialized_end=138,
)

DESCRIPTOR.message_types_by_name['ResidueInfo'] = _RESIDUEINFO
_sym_db.RegisterFileDescriptor(DESCRIPTOR)

ResidueInfo = _reflection.GeneratedProtocolMessageType('ResidueInfo', (_message.Message,), dict(
  DESCRIPTOR = _RESIDUEINFO,
  __module__ = 'narupa.protocol.topology.ResidueInfo_pb2'
  # @@protoc_insertion_point(class_scope:narupa.protocol.topology.ResidueInfo)
  ))
_sym_db.RegisterMessage(ResidueInfo)


# @@protoc_insertion_point(module_scope)