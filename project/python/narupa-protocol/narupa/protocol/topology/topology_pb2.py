# Generated by the protocol buffer compiler.  DO NOT EDIT!
# source: narupa/protocol/topology/topology.proto

import sys
_b=sys.version_info[0]<3 and (lambda x:x) or (lambda x:x.encode('latin1'))
from google.protobuf import descriptor as _descriptor
from google.protobuf import message as _message
from google.protobuf import reflection as _reflection
from google.protobuf import symbol_database as _symbol_database
# @@protoc_insertion_point(imports)

_sym_db = _symbol_database.Default()


from narupa.protocol import array_pb2 as narupa_dot_protocol_dot_array__pb2
from google.protobuf import struct_pb2 as google_dot_protobuf_dot_struct__pb2


DESCRIPTOR = _descriptor.FileDescriptor(
  name='narupa/protocol/topology/topology.proto',
  package='narupa.protocol.topology',
  syntax='proto3',
  serialized_options=None,
  serialized_pb=_b('\n\'narupa/protocol/topology/topology.proto\x12\x18narupa.protocol.topology\x1a\x1bnarupa/protocol/array.proto\x1a\x1cgoogle/protobuf/struct.proto\"\xa9\x02\n\x0cTopologyData\x12\x42\n\x06values\x18\x01 \x03(\x0b\x32\x32.narupa.protocol.topology.TopologyData.ValuesEntry\x12\x42\n\x06\x61rrays\x18\x02 \x03(\x0b\x32\x32.narupa.protocol.topology.TopologyData.ArraysEntry\x1a\x45\n\x0bValuesEntry\x12\x0b\n\x03key\x18\x01 \x01(\t\x12%\n\x05value\x18\x02 \x01(\x0b\x32\x16.google.protobuf.Value:\x02\x38\x01\x1aJ\n\x0b\x41rraysEntry\x12\x0b\n\x03key\x18\x01 \x01(\t\x12*\n\x05value\x18\x02 \x01(\x0b\x32\x1b.narupa.protocol.ValueArray:\x02\x38\x01\x62\x06proto3')
  ,
  dependencies=[narupa_dot_protocol_dot_array__pb2.DESCRIPTOR,google_dot_protobuf_dot_struct__pb2.DESCRIPTOR,])




_TOPOLOGYDATA_VALUESENTRY = _descriptor.Descriptor(
  name='ValuesEntry',
  full_name='narupa.protocol.topology.TopologyData.ValuesEntry',
  filename=None,
  file=DESCRIPTOR,
  containing_type=None,
  fields=[
    _descriptor.FieldDescriptor(
      name='key', full_name='narupa.protocol.topology.TopologyData.ValuesEntry.key', index=0,
      number=1, type=9, cpp_type=9, label=1,
      has_default_value=False, default_value=_b("").decode('utf-8'),
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='value', full_name='narupa.protocol.topology.TopologyData.ValuesEntry.value', index=1,
      number=2, type=11, cpp_type=10, label=1,
      has_default_value=False, default_value=None,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
  ],
  extensions=[
  ],
  nested_types=[],
  enum_types=[
  ],
  serialized_options=_b('8\001'),
  is_extendable=False,
  syntax='proto3',
  extension_ranges=[],
  oneofs=[
  ],
  serialized_start=281,
  serialized_end=350,
)

_TOPOLOGYDATA_ARRAYSENTRY = _descriptor.Descriptor(
  name='ArraysEntry',
  full_name='narupa.protocol.topology.TopologyData.ArraysEntry',
  filename=None,
  file=DESCRIPTOR,
  containing_type=None,
  fields=[
    _descriptor.FieldDescriptor(
      name='key', full_name='narupa.protocol.topology.TopologyData.ArraysEntry.key', index=0,
      number=1, type=9, cpp_type=9, label=1,
      has_default_value=False, default_value=_b("").decode('utf-8'),
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='value', full_name='narupa.protocol.topology.TopologyData.ArraysEntry.value', index=1,
      number=2, type=11, cpp_type=10, label=1,
      has_default_value=False, default_value=None,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
  ],
  extensions=[
  ],
  nested_types=[],
  enum_types=[
  ],
  serialized_options=_b('8\001'),
  is_extendable=False,
  syntax='proto3',
  extension_ranges=[],
  oneofs=[
  ],
  serialized_start=352,
  serialized_end=426,
)

_TOPOLOGYDATA = _descriptor.Descriptor(
  name='TopologyData',
  full_name='narupa.protocol.topology.TopologyData',
  filename=None,
  file=DESCRIPTOR,
  containing_type=None,
  fields=[
    _descriptor.FieldDescriptor(
      name='values', full_name='narupa.protocol.topology.TopologyData.values', index=0,
      number=1, type=11, cpp_type=10, label=3,
      has_default_value=False, default_value=[],
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='arrays', full_name='narupa.protocol.topology.TopologyData.arrays', index=1,
      number=2, type=11, cpp_type=10, label=3,
      has_default_value=False, default_value=[],
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
  ],
  extensions=[
  ],
  nested_types=[_TOPOLOGYDATA_VALUESENTRY, _TOPOLOGYDATA_ARRAYSENTRY, ],
  enum_types=[
  ],
  serialized_options=None,
  is_extendable=False,
  syntax='proto3',
  extension_ranges=[],
  oneofs=[
  ],
  serialized_start=129,
  serialized_end=426,
)

_TOPOLOGYDATA_VALUESENTRY.fields_by_name['value'].message_type = google_dot_protobuf_dot_struct__pb2._VALUE
_TOPOLOGYDATA_VALUESENTRY.containing_type = _TOPOLOGYDATA
_TOPOLOGYDATA_ARRAYSENTRY.fields_by_name['value'].message_type = narupa_dot_protocol_dot_array__pb2._VALUEARRAY
_TOPOLOGYDATA_ARRAYSENTRY.containing_type = _TOPOLOGYDATA
_TOPOLOGYDATA.fields_by_name['values'].message_type = _TOPOLOGYDATA_VALUESENTRY
_TOPOLOGYDATA.fields_by_name['arrays'].message_type = _TOPOLOGYDATA_ARRAYSENTRY
DESCRIPTOR.message_types_by_name['TopologyData'] = _TOPOLOGYDATA
_sym_db.RegisterFileDescriptor(DESCRIPTOR)

TopologyData = _reflection.GeneratedProtocolMessageType('TopologyData', (_message.Message,), dict(

  ValuesEntry = _reflection.GeneratedProtocolMessageType('ValuesEntry', (_message.Message,), dict(
    DESCRIPTOR = _TOPOLOGYDATA_VALUESENTRY,
    __module__ = 'narupa.protocol.topology.topology_pb2'
    # @@protoc_insertion_point(class_scope:narupa.protocol.topology.TopologyData.ValuesEntry)
    ))
  ,

  ArraysEntry = _reflection.GeneratedProtocolMessageType('ArraysEntry', (_message.Message,), dict(
    DESCRIPTOR = _TOPOLOGYDATA_ARRAYSENTRY,
    __module__ = 'narupa.protocol.topology.topology_pb2'
    # @@protoc_insertion_point(class_scope:narupa.protocol.topology.TopologyData.ArraysEntry)
    ))
  ,
  DESCRIPTOR = _TOPOLOGYDATA,
  __module__ = 'narupa.protocol.topology.topology_pb2'
  # @@protoc_insertion_point(class_scope:narupa.protocol.topology.TopologyData)
  ))
_sym_db.RegisterMessage(TopologyData)
_sym_db.RegisterMessage(TopologyData.ValuesEntry)
_sym_db.RegisterMessage(TopologyData.ArraysEntry)


_TOPOLOGYDATA_VALUESENTRY._options = None
_TOPOLOGYDATA_ARRAYSENTRY._options = None
# @@protoc_insertion_point(module_scope)