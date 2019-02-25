# Generated by the protocol buffer compiler.  DO NOT EDIT!
# source: narupa/protocol/instance/molecule_provider.proto

import sys
_b=sys.version_info[0]<3 and (lambda x:x) or (lambda x:x.encode('latin1'))
from google.protobuf import descriptor as _descriptor
from google.protobuf import message as _message
from google.protobuf import reflection as _reflection
from google.protobuf import symbol_database as _symbol_database
# @@protoc_insertion_point(imports)

_sym_db = _symbol_database.Default()


from narupa.protocol.instance import get_topology_pb2 as narupa_dot_protocol_dot_instance_dot_get__topology__pb2
from narupa.protocol.instance import get_frame_pb2 as narupa_dot_protocol_dot_instance_dot_get__frame__pb2


DESCRIPTOR = _descriptor.FileDescriptor(
  name='narupa/protocol/instance/molecule_provider.proto',
  package='narupa.protocol.instance',
  syntax='proto3',
  serialized_options=None,
  serialized_pb=_b('\n0narupa/protocol/instance/molecule_provider.proto\x12\x18narupa.protocol.instance\x1a+narupa/protocol/instance/get_topology.proto\x1a(narupa/protocol/instance/get_frame.proto2\xf1\x01\n\x10MoleculeProvider\x12r\n\x11SubscribeTopology\x12,.narupa.protocol.instance.GetTopologyRequest\x1a-.narupa.protocol.instance.GetTopologyResponse0\x01\x12i\n\x0eSubscribeFrame\x12).narupa.protocol.instance.GetFrameRequest\x1a*.narupa.protocol.instance.GetFrameResponse0\x01\x62\x06proto3')
  ,
  dependencies=[narupa_dot_protocol_dot_instance_dot_get__topology__pb2.DESCRIPTOR,narupa_dot_protocol_dot_instance_dot_get__frame__pb2.DESCRIPTOR,])



_sym_db.RegisterFileDescriptor(DESCRIPTOR)



_MOLECULEPROVIDER = _descriptor.ServiceDescriptor(
  name='MoleculeProvider',
  full_name='narupa.protocol.instance.MoleculeProvider',
  file=DESCRIPTOR,
  index=0,
  serialized_options=None,
  serialized_start=166,
  serialized_end=407,
  methods=[
  _descriptor.MethodDescriptor(
    name='SubscribeTopology',
    full_name='narupa.protocol.instance.MoleculeProvider.SubscribeTopology',
    index=0,
    containing_service=None,
    input_type=narupa_dot_protocol_dot_instance_dot_get__topology__pb2._GETTOPOLOGYREQUEST,
    output_type=narupa_dot_protocol_dot_instance_dot_get__topology__pb2._GETTOPOLOGYRESPONSE,
    serialized_options=None,
  ),
  _descriptor.MethodDescriptor(
    name='SubscribeFrame',
    full_name='narupa.protocol.instance.MoleculeProvider.SubscribeFrame',
    index=1,
    containing_service=None,
    input_type=narupa_dot_protocol_dot_instance_dot_get__frame__pb2._GETFRAMEREQUEST,
    output_type=narupa_dot_protocol_dot_instance_dot_get__frame__pb2._GETFRAMERESPONSE,
    serialized_options=None,
  ),
])
_sym_db.RegisterServiceDescriptor(_MOLECULEPROVIDER)

DESCRIPTOR.services_by_name['MoleculeProvider'] = _MOLECULEPROVIDER

# @@protoc_insertion_point(module_scope)
