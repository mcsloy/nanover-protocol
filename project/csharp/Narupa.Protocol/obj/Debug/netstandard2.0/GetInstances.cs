// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Narupa/Protocol/instance/GetInstances.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Narupa.Protocol.Instance {

  /// <summary>Holder for reflection information generated from Narupa/Protocol/instance/GetInstances.proto</summary>
  public static partial class GetInstancesReflection {

    #region Descriptor
    /// <summary>File descriptor for Narupa/Protocol/instance/GetInstances.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static GetInstancesReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "CitOYXJ1cGEvUHJvdG9jb2wvaW5zdGFuY2UvR2V0SW5zdGFuY2VzLnByb3Rv",
            "EhhuYXJ1cGEucHJvdG9jb2wuaW5zdGFuY2UaK25hcnVwYS9wcm90b2NvbC9p",
            "bnN0YW5jZS9JbnN0YW5jZUluZm8ucHJvdG8iFQoTR2V0SW5zdGFuY2VzUmVx",
            "dWVzdCJRChRHZXRJbnN0YW5jZXNSZXNwb25zZRI5CglpbnN0YW5jZXMYASAD",
            "KAsyJi5uYXJ1cGEucHJvdG9jb2wuaW5zdGFuY2UuSW5zdGFuY2VJbmZvYgZw",
            "cm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::Narupa.Protocol.Instance.InstanceInfoReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Narupa.Protocol.Instance.GetInstancesRequest), global::Narupa.Protocol.Instance.GetInstancesRequest.Parser, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Narupa.Protocol.Instance.GetInstancesResponse), global::Narupa.Protocol.Instance.GetInstancesResponse.Parser, new[]{ "Instances" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class GetInstancesRequest : pb::IMessage<GetInstancesRequest> {
    private static readonly pb::MessageParser<GetInstancesRequest> _parser = new pb::MessageParser<GetInstancesRequest>(() => new GetInstancesRequest());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<GetInstancesRequest> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Narupa.Protocol.Instance.GetInstancesReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GetInstancesRequest() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GetInstancesRequest(GetInstancesRequest other) : this() {
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GetInstancesRequest Clone() {
      return new GetInstancesRequest(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as GetInstancesRequest);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(GetInstancesRequest other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(GetInstancesRequest other) {
      if (other == null) {
        return;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
        }
      }
    }

  }

  public sealed partial class GetInstancesResponse : pb::IMessage<GetInstancesResponse> {
    private static readonly pb::MessageParser<GetInstancesResponse> _parser = new pb::MessageParser<GetInstancesResponse>(() => new GetInstancesResponse());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<GetInstancesResponse> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Narupa.Protocol.Instance.GetInstancesReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GetInstancesResponse() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GetInstancesResponse(GetInstancesResponse other) : this() {
      instances_ = other.instances_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GetInstancesResponse Clone() {
      return new GetInstancesResponse(this);
    }

    /// <summary>Field number for the "instances" field.</summary>
    public const int InstancesFieldNumber = 1;
    private static readonly pb::FieldCodec<global::Narupa.Protocol.Instance.InstanceInfo> _repeated_instances_codec
        = pb::FieldCodec.ForMessage(10, global::Narupa.Protocol.Instance.InstanceInfo.Parser);
    private readonly pbc::RepeatedField<global::Narupa.Protocol.Instance.InstanceInfo> instances_ = new pbc::RepeatedField<global::Narupa.Protocol.Instance.InstanceInfo>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::Narupa.Protocol.Instance.InstanceInfo> Instances {
      get { return instances_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as GetInstancesResponse);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(GetInstancesResponse other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if(!instances_.Equals(other.instances_)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      hash ^= instances_.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      instances_.WriteTo(output, _repeated_instances_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      size += instances_.CalculateSize(_repeated_instances_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(GetInstancesResponse other) {
      if (other == null) {
        return;
      }
      instances_.Add(other.instances_);
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            instances_.AddEntriesFrom(input, _repeated_instances_codec);
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
