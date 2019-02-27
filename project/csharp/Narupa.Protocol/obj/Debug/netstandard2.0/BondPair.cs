// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Narupa/Protocol/topology/BondPair.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Narupa.Protocol.Topology {

  /// <summary>Holder for reflection information generated from Narupa/Protocol/topology/BondPair.proto</summary>
  public static partial class BondPairReflection {

    #region Descriptor
    /// <summary>File descriptor for Narupa/Protocol/topology/BondPair.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static BondPairReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "CidOYXJ1cGEvUHJvdG9jb2wvdG9wb2xvZ3kvQm9uZFBhaXIucHJvdG8SGG5h",
            "cnVwYS5wcm90b2NvbC50b3BvbG9neSIgCghCb25kUGFpchIJCgFBGAEgASgN",
            "EgkKAUIYAiABKA1iBnByb3RvMw=="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Narupa.Protocol.Topology.BondPair), global::Narupa.Protocol.Topology.BondPair.Parser, new[]{ "A", "B" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class BondPair : pb::IMessage<BondPair> {
    private static readonly pb::MessageParser<BondPair> _parser = new pb::MessageParser<BondPair>(() => new BondPair());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<BondPair> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Narupa.Protocol.Topology.BondPairReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public BondPair() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public BondPair(BondPair other) : this() {
      a_ = other.a_;
      b_ = other.b_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public BondPair Clone() {
      return new BondPair(this);
    }

    /// <summary>Field number for the "A" field.</summary>
    public const int AFieldNumber = 1;
    private uint a_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public uint A {
      get { return a_; }
      set {
        a_ = value;
      }
    }

    /// <summary>Field number for the "B" field.</summary>
    public const int BFieldNumber = 2;
    private uint b_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public uint B {
      get { return b_; }
      set {
        b_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as BondPair);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(BondPair other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (A != other.A) return false;
      if (B != other.B) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (A != 0) hash ^= A.GetHashCode();
      if (B != 0) hash ^= B.GetHashCode();
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
      if (A != 0) {
        output.WriteRawTag(8);
        output.WriteUInt32(A);
      }
      if (B != 0) {
        output.WriteRawTag(16);
        output.WriteUInt32(B);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (A != 0) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(A);
      }
      if (B != 0) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(B);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(BondPair other) {
      if (other == null) {
        return;
      }
      if (other.A != 0) {
        A = other.A;
      }
      if (other.B != 0) {
        B = other.B;
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
          case 8: {
            A = input.ReadUInt32();
            break;
          }
          case 16: {
            B = input.ReadUInt32();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
