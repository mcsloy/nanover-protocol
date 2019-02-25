// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: narupa/protocol/instance/SetTopology.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Narupa.Protocol.Instance {

  /// <summary>Holder for reflection information generated from narupa/protocol/instance/SetTopology.proto</summary>
  public static partial class SetTopologyReflection {

    #region Descriptor
    /// <summary>File descriptor for narupa/protocol/instance/SetTopology.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static SetTopologyReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "CipuYXJ1cGEvcHJvdG9jb2wvaW5zdGFuY2UvU2V0VG9wb2xvZ3kucHJvdG8S",
            "GG5hcnVwYS5wcm90b2NvbC5pbnN0YW5jZRorbmFydXBhL3Byb3RvY29sL3Rv",
            "cG9sb2d5L1RvcG9sb2d5SW5mby5wcm90byJ1ChJTZXRUb3BvbG9neVJlcXVl",
            "c3QSEwoLaW5zdGFuY2VfaWQYASABKAkSEAoIZnJhbWVfaWQYAiABKA0SOAoI",
            "dG9wb2xvZ3kYAyABKAsyJi5uYXJ1cGEucHJvdG9jb2wudG9wb2xvZ3kuVG9w",
            "b2xvZ3lJbmZvIhUKE1NldFRvcG9sb2d5UmVzcG9uc2VQAGIGcHJvdG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::Narupa.Protocol.Topology.TopologyInfoReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Narupa.Protocol.Instance.SetTopologyRequest), global::Narupa.Protocol.Instance.SetTopologyRequest.Parser, new[]{ "InstanceId", "FrameId", "Topology" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Narupa.Protocol.Instance.SetTopologyResponse), global::Narupa.Protocol.Instance.SetTopologyResponse.Parser, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class SetTopologyRequest : pb::IMessage<SetTopologyRequest> {
    private static readonly pb::MessageParser<SetTopologyRequest> _parser = new pb::MessageParser<SetTopologyRequest>(() => new SetTopologyRequest());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<SetTopologyRequest> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Narupa.Protocol.Instance.SetTopologyReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SetTopologyRequest() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SetTopologyRequest(SetTopologyRequest other) : this() {
      instanceId_ = other.instanceId_;
      frameId_ = other.frameId_;
      topology_ = other.topology_ != null ? other.topology_.Clone() : null;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SetTopologyRequest Clone() {
      return new SetTopologyRequest(this);
    }

    /// <summary>Field number for the "instance_id" field.</summary>
    public const int InstanceIdFieldNumber = 1;
    private string instanceId_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string InstanceId {
      get { return instanceId_; }
      set {
        instanceId_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "frame_id" field.</summary>
    public const int FrameIdFieldNumber = 2;
    private uint frameId_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public uint FrameId {
      get { return frameId_; }
      set {
        frameId_ = value;
      }
    }

    /// <summary>Field number for the "topology" field.</summary>
    public const int TopologyFieldNumber = 3;
    private global::Narupa.Protocol.Topology.TopologyInfo topology_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Narupa.Protocol.Topology.TopologyInfo Topology {
      get { return topology_; }
      set {
        topology_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as SetTopologyRequest);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(SetTopologyRequest other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (InstanceId != other.InstanceId) return false;
      if (FrameId != other.FrameId) return false;
      if (!object.Equals(Topology, other.Topology)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (InstanceId.Length != 0) hash ^= InstanceId.GetHashCode();
      if (FrameId != 0) hash ^= FrameId.GetHashCode();
      if (topology_ != null) hash ^= Topology.GetHashCode();
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
      if (InstanceId.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(InstanceId);
      }
      if (FrameId != 0) {
        output.WriteRawTag(16);
        output.WriteUInt32(FrameId);
      }
      if (topology_ != null) {
        output.WriteRawTag(26);
        output.WriteMessage(Topology);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (InstanceId.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(InstanceId);
      }
      if (FrameId != 0) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(FrameId);
      }
      if (topology_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Topology);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(SetTopologyRequest other) {
      if (other == null) {
        return;
      }
      if (other.InstanceId.Length != 0) {
        InstanceId = other.InstanceId;
      }
      if (other.FrameId != 0) {
        FrameId = other.FrameId;
      }
      if (other.topology_ != null) {
        if (topology_ == null) {
          topology_ = new global::Narupa.Protocol.Topology.TopologyInfo();
        }
        Topology.MergeFrom(other.Topology);
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
          case 10: {
            InstanceId = input.ReadString();
            break;
          }
          case 16: {
            FrameId = input.ReadUInt32();
            break;
          }
          case 26: {
            if (topology_ == null) {
              topology_ = new global::Narupa.Protocol.Topology.TopologyInfo();
            }
            input.ReadMessage(topology_);
            break;
          }
        }
      }
    }

  }

  public sealed partial class SetTopologyResponse : pb::IMessage<SetTopologyResponse> {
    private static readonly pb::MessageParser<SetTopologyResponse> _parser = new pb::MessageParser<SetTopologyResponse>(() => new SetTopologyResponse());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<SetTopologyResponse> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Narupa.Protocol.Instance.SetTopologyReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SetTopologyResponse() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SetTopologyResponse(SetTopologyResponse other) : this() {
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SetTopologyResponse Clone() {
      return new SetTopologyResponse(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as SetTopologyResponse);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(SetTopologyResponse other) {
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
    public void MergeFrom(SetTopologyResponse other) {
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

  #endregion

}

#endregion Designer generated code
