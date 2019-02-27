// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Narupa/Protocol/Selection/Indices.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Narupa.Protocol.Selection {

  /// <summary>Holder for reflection information generated from Narupa/Protocol/Selection/Indices.proto</summary>
  public static partial class IndicesReflection {

    #region Descriptor
    /// <summary>File descriptor for Narupa/Protocol/Selection/Indices.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static IndicesReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "CidOYXJ1cGEvUHJvdG9jb2wvU2VsZWN0aW9uL0luZGljZXMucHJvdG8SGW5h",
            "cnVwYS5wcm90b2NvbC5zZWxlY3Rpb24aKW5hcnVwYS9wcm90b2NvbC9zZWxl",
            "Y3Rpb24vSW5kZXhMaXN0LnByb3RvGipuYXJ1cGEvcHJvdG9jb2wvc2VsZWN0",
            "aW9uL0luZGV4UmFuZ2UucHJvdG8ijgEKB0luZGljZXMSOgoKaW5kZXhfbGlz",
            "dBgBIAEoCzIkLm5hcnVwYS5wcm90b2NvbC5zZWxlY3Rpb24uSW5kZXhMaXN0",
            "SAASPAoLaW5kZXhfcmFuZ2UYAiABKAsyJS5uYXJ1cGEucHJvdG9jb2wuc2Vs",
            "ZWN0aW9uLkluZGV4UmFuZ2VIAEIJCgdpbmRpY2VzYgZwcm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::Narupa.Protocol.Selection.IndexListReflection.Descriptor, global::Narupa.Protocol.Selection.IndexRangeReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Narupa.Protocol.Selection.Indices), global::Narupa.Protocol.Selection.Indices.Parser, new[]{ "IndexList", "IndexRange" }, new[]{ "Indices" }, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class Indices : pb::IMessage<Indices> {
    private static readonly pb::MessageParser<Indices> _parser = new pb::MessageParser<Indices>(() => new Indices());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<Indices> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Narupa.Protocol.Selection.IndicesReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Indices() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Indices(Indices other) : this() {
      switch (other.IndicesCase) {
        case IndicesOneofCase.IndexList:
          IndexList = other.IndexList.Clone();
          break;
        case IndicesOneofCase.IndexRange:
          IndexRange = other.IndexRange.Clone();
          break;
      }

      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Indices Clone() {
      return new Indices(this);
    }

    /// <summary>Field number for the "index_list" field.</summary>
    public const int IndexListFieldNumber = 1;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Narupa.Protocol.Selection.IndexList IndexList {
      get { return indicesCase_ == IndicesOneofCase.IndexList ? (global::Narupa.Protocol.Selection.IndexList) indices_ : null; }
      set {
        indices_ = value;
        indicesCase_ = value == null ? IndicesOneofCase.None : IndicesOneofCase.IndexList;
      }
    }

    /// <summary>Field number for the "index_range" field.</summary>
    public const int IndexRangeFieldNumber = 2;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Narupa.Protocol.Selection.IndexRange IndexRange {
      get { return indicesCase_ == IndicesOneofCase.IndexRange ? (global::Narupa.Protocol.Selection.IndexRange) indices_ : null; }
      set {
        indices_ = value;
        indicesCase_ = value == null ? IndicesOneofCase.None : IndicesOneofCase.IndexRange;
      }
    }

    private object indices_;
    /// <summary>Enum of possible cases for the "indices" oneof.</summary>
    public enum IndicesOneofCase {
      None = 0,
      IndexList = 1,
      IndexRange = 2,
    }
    private IndicesOneofCase indicesCase_ = IndicesOneofCase.None;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public IndicesOneofCase IndicesCase {
      get { return indicesCase_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void ClearIndices() {
      indicesCase_ = IndicesOneofCase.None;
      indices_ = null;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as Indices);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(Indices other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (!object.Equals(IndexList, other.IndexList)) return false;
      if (!object.Equals(IndexRange, other.IndexRange)) return false;
      if (IndicesCase != other.IndicesCase) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (indicesCase_ == IndicesOneofCase.IndexList) hash ^= IndexList.GetHashCode();
      if (indicesCase_ == IndicesOneofCase.IndexRange) hash ^= IndexRange.GetHashCode();
      hash ^= (int) indicesCase_;
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
      if (indicesCase_ == IndicesOneofCase.IndexList) {
        output.WriteRawTag(10);
        output.WriteMessage(IndexList);
      }
      if (indicesCase_ == IndicesOneofCase.IndexRange) {
        output.WriteRawTag(18);
        output.WriteMessage(IndexRange);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (indicesCase_ == IndicesOneofCase.IndexList) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(IndexList);
      }
      if (indicesCase_ == IndicesOneofCase.IndexRange) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(IndexRange);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(Indices other) {
      if (other == null) {
        return;
      }
      switch (other.IndicesCase) {
        case IndicesOneofCase.IndexList:
          if (IndexList == null) {
            IndexList = new global::Narupa.Protocol.Selection.IndexList();
          }
          IndexList.MergeFrom(other.IndexList);
          break;
        case IndicesOneofCase.IndexRange:
          if (IndexRange == null) {
            IndexRange = new global::Narupa.Protocol.Selection.IndexRange();
          }
          IndexRange.MergeFrom(other.IndexRange);
          break;
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
            global::Narupa.Protocol.Selection.IndexList subBuilder = new global::Narupa.Protocol.Selection.IndexList();
            if (indicesCase_ == IndicesOneofCase.IndexList) {
              subBuilder.MergeFrom(IndexList);
            }
            input.ReadMessage(subBuilder);
            IndexList = subBuilder;
            break;
          }
          case 18: {
            global::Narupa.Protocol.Selection.IndexRange subBuilder = new global::Narupa.Protocol.Selection.IndexRange();
            if (indicesCase_ == IndicesOneofCase.IndexRange) {
              subBuilder.MergeFrom(IndexRange);
            }
            input.ReadMessage(subBuilder);
            IndexRange = subBuilder;
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code