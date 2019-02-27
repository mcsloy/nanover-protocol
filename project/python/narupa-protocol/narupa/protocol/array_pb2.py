# Generated by the protocol buffer compiler.  DO NOT EDIT!
# source: narupa/protocol/array.proto

import sys
_b=sys.version_info[0]<3 and (lambda x:x) or (lambda x:x.encode('latin1'))
from google.protobuf import descriptor as _descriptor
from google.protobuf import message as _message
from google.protobuf import reflection as _reflection
from google.protobuf import symbol_database as _symbol_database
# @@protoc_insertion_point(imports)

_sym_db = _symbol_database.Default()




DESCRIPTOR = _descriptor.FileDescriptor(
  name='narupa/protocol/array.proto',
  package='narupa.protocol',
  syntax='proto3',
  serialized_options=None,
  serialized_pb=_b('\n\x1bnarupa/protocol/array.proto\x12\x0fnarupa.protocol\"\x1c\n\nFloatArray\x12\x0e\n\x06values\x18\x01 \x03(\x02\"\x1c\n\nIndexArray\x12\x0e\n\x06values\x18\x01 \x03(\r\"\x1d\n\x0bStringArray\x12\x0e\n\x06values\x18\x01 \x03(\t\"\xb7\x01\n\nValueArray\x12\x33\n\x0c\x66loat_values\x18\x01 \x01(\x0b\x32\x1b.narupa.protocol.FloatArrayH\x00\x12\x33\n\x0cindex_values\x18\x02 \x01(\x0b\x32\x1b.narupa.protocol.IndexArrayH\x00\x12\x35\n\rstring_values\x18\x03 \x01(\x0b\x32\x1c.narupa.protocol.StringArrayH\x00\x42\x08\n\x06valuesb\x06proto3')
)




_FLOATARRAY = _descriptor.Descriptor(
  name='FloatArray',
  full_name='narupa.protocol.FloatArray',
  filename=None,
  file=DESCRIPTOR,
  containing_type=None,
  fields=[
    _descriptor.FieldDescriptor(
      name='values', full_name='narupa.protocol.FloatArray.values', index=0,
      number=1, type=2, cpp_type=6, label=3,
      has_default_value=False, default_value=[],
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
  serialized_start=48,
  serialized_end=76,
)


_INDEXARRAY = _descriptor.Descriptor(
  name='IndexArray',
  full_name='narupa.protocol.IndexArray',
  filename=None,
  file=DESCRIPTOR,
  containing_type=None,
  fields=[
    _descriptor.FieldDescriptor(
      name='values', full_name='narupa.protocol.IndexArray.values', index=0,
      number=1, type=13, cpp_type=3, label=3,
      has_default_value=False, default_value=[],
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
  serialized_start=78,
  serialized_end=106,
)


_STRINGARRAY = _descriptor.Descriptor(
  name='StringArray',
  full_name='narupa.protocol.StringArray',
  filename=None,
  file=DESCRIPTOR,
  containing_type=None,
  fields=[
    _descriptor.FieldDescriptor(
      name='values', full_name='narupa.protocol.StringArray.values', index=0,
      number=1, type=9, cpp_type=9, label=3,
      has_default_value=False, default_value=[],
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
  serialized_start=108,
  serialized_end=137,
)


_VALUEARRAY = _descriptor.Descriptor(
  name='ValueArray',
  full_name='narupa.protocol.ValueArray',
  filename=None,
  file=DESCRIPTOR,
  containing_type=None,
  fields=[
    _descriptor.FieldDescriptor(
      name='float_values', full_name='narupa.protocol.ValueArray.float_values', index=0,
      number=1, type=11, cpp_type=10, label=1,
      has_default_value=False, default_value=None,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='index_values', full_name='narupa.protocol.ValueArray.index_values', index=1,
      number=2, type=11, cpp_type=10, label=1,
      has_default_value=False, default_value=None,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='string_values', full_name='narupa.protocol.ValueArray.string_values', index=2,
      number=3, type=11, cpp_type=10, label=1,
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
  serialized_options=None,
  is_extendable=False,
  syntax='proto3',
  extension_ranges=[],
  oneofs=[
    _descriptor.OneofDescriptor(
      name='values', full_name='narupa.protocol.ValueArray.values',
      index=0, containing_type=None, fields=[]),
  ],
  serialized_start=140,
  serialized_end=323,
)

_VALUEARRAY.fields_by_name['float_values'].message_type = _FLOATARRAY
_VALUEARRAY.fields_by_name['index_values'].message_type = _INDEXARRAY
_VALUEARRAY.fields_by_name['string_values'].message_type = _STRINGARRAY
_VALUEARRAY.oneofs_by_name['values'].fields.append(
  _VALUEARRAY.fields_by_name['float_values'])
_VALUEARRAY.fields_by_name['float_values'].containing_oneof = _VALUEARRAY.oneofs_by_name['values']
_VALUEARRAY.oneofs_by_name['values'].fields.append(
  _VALUEARRAY.fields_by_name['index_values'])
_VALUEARRAY.fields_by_name['index_values'].containing_oneof = _VALUEARRAY.oneofs_by_name['values']
_VALUEARRAY.oneofs_by_name['values'].fields.append(
  _VALUEARRAY.fields_by_name['string_values'])
_VALUEARRAY.fields_by_name['string_values'].containing_oneof = _VALUEARRAY.oneofs_by_name['values']
DESCRIPTOR.message_types_by_name['FloatArray'] = _FLOATARRAY
DESCRIPTOR.message_types_by_name['IndexArray'] = _INDEXARRAY
DESCRIPTOR.message_types_by_name['StringArray'] = _STRINGARRAY
DESCRIPTOR.message_types_by_name['ValueArray'] = _VALUEARRAY
_sym_db.RegisterFileDescriptor(DESCRIPTOR)

FloatArray = _reflection.GeneratedProtocolMessageType('FloatArray', (_message.Message,), dict(
  DESCRIPTOR = _FLOATARRAY,
  __module__ = 'narupa.protocol.array_pb2'
  # @@protoc_insertion_point(class_scope:narupa.protocol.FloatArray)
  ))
_sym_db.RegisterMessage(FloatArray)

IndexArray = _reflection.GeneratedProtocolMessageType('IndexArray', (_message.Message,), dict(
  DESCRIPTOR = _INDEXARRAY,
  __module__ = 'narupa.protocol.array_pb2'
  # @@protoc_insertion_point(class_scope:narupa.protocol.IndexArray)
  ))
_sym_db.RegisterMessage(IndexArray)

StringArray = _reflection.GeneratedProtocolMessageType('StringArray', (_message.Message,), dict(
  DESCRIPTOR = _STRINGARRAY,
  __module__ = 'narupa.protocol.array_pb2'
  # @@protoc_insertion_point(class_scope:narupa.protocol.StringArray)
  ))
_sym_db.RegisterMessage(StringArray)

ValueArray = _reflection.GeneratedProtocolMessageType('ValueArray', (_message.Message,), dict(
  DESCRIPTOR = _VALUEARRAY,
  __module__ = 'narupa.protocol.array_pb2'
  # @@protoc_insertion_point(class_scope:narupa.protocol.ValueArray)
  ))
_sym_db.RegisterMessage(ValueArray)


# @@protoc_insertion_point(module_scope)