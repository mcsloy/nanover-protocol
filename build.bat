protoc.exe -I protocol/ --csharp_out=build/csharp --grpc_out=build/csharp --plugin=protoc-gen-grpc=grpc_csharp_plugin.exe protocol/trajectory.proto
python -m grpc_tools.protoc -I protocol/ --python_out=build/python --grpc_python_out=build/python protocol/trajectory.proto
