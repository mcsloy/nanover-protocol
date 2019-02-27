// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Narupa/Protocol/Selection/SetSelection.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Narupa.Protocol.Selection {

  /// <summary>Holder for reflection information generated from Narupa/Protocol/Selection/SetSelection.proto</summary>
  public static partial class SetSelectionReflection {

    #region Descriptor
    /// <summary>File descriptor for Narupa/Protocol/Selection/SetSelection.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static SetSelectionReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "CixOYXJ1cGEvUHJvdG9jb2wvU2VsZWN0aW9uL1NldFNlbGVjdGlvbi5wcm90",
            "bxIZbmFydXBhLnByb3RvY29sLnNlbGVjdGlvbhotbmFydXBhL3Byb3RvY29s",
            "L3NlbGVjdGlvbi9BdG9tU2VsZWN0aW9uLnByb3RvIn0KE1NldFNlbGVjdGlv",
            "blJlcXVlc3QSEwoLaW5zdGFuY2VfaWQYASABKAkSFAoMc2VsZWN0aW9uX2lk",
            "GAIgASgJEjsKCXNlbGVjdGlvbhgDIAEoCzIoLm5hcnVwYS5wcm90b2NvbC5z",
            "ZWxlY3Rpb24uQXRvbVNlbGVjdGlvbiIWChRTZXRTZWxlY3Rpb25SZXNwb25z",
            "ZWIGcHJvdG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::Narupa.Protocol.Selection.AtomSelectionReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Narupa.Protocol.Selection.SetSelectionRequest), global::Narupa.Protocol.Selection.SetSelectionRequest.Parser, new[]{ "InstanceId", "SelectionId", "Selection" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Narupa.Protocol.Selection.SetSelectionResponse), global::Narupa.Protocol.Selection.SetSelectionResponse.Parser, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class SetSelectionRequest : pb::IMessage<SetSelectionRequest> {
    private static readonly pb::MessageParser<SetSelectionRequest> _parser = new pb::MessageParser<SetSelectionRequest>(() => new SetSelectionRequest());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<SetSelectionRequest> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Narupa.Protocol.Selection.SetSelectionReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SetSelectionRequest() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SetSelectionRequest(SetSelectionRequest other) : this() {
      instanceId_ = other.instanceId_;
      selectionId_ = other.selectionId_;
      selection_ = other.selection_ != null ? other.selection_.Clone() : null;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SetSelectionRequest Clone() {
      return new SetSelectionRequest(this);
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

    /// <summary>Field number for the "selection_id" field.</summary>
    public const int SelectionIdFieldNumber = 2;
    private string selectionId_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string SelectionId {
      get { return selectionId_; }
      set {
        selectionId_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "selection" field.</summary>
    public const int SelectionFieldNumber = 3;
    private global::Narupa.Protocol.Selection.AtomSelection selection_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Narupa.Protocol.Selection.AtomSelection Selection {
      get { return selection_; }
      set {
        selection_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as SetSelectionRequest);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(SetSelectionRequest other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (InstanceId != other.InstanceId) return false;
      if (SelectionId != other.SelectionId) return false;
      if (!object.Equals(Selection, other.Selection)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (InstanceId.Length != 0) hash ^= InstanceId.GetHashCode();
      if (SelectionId.Length != 0) hash ^= SelectionId.GetHashCode();
      if (selection_ != null) hash ^= Selection.GetHashCode();
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
      if (SelectionId.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(SelectionId);
      }
      if (selection_ != null) {
        output.WriteRawTag(26);
        output.WriteMessage(Selection);
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
      if (SelectionId.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(SelectionId);
      }
      if (selection_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Selection);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(SetSelectionRequest other) {
      if (other == null) {
        return;
      }
      if (other.InstanceId.Length != 0) {
        InstanceId = other.InstanceId;
      }
      if (other.SelectionId.Length != 0) {
        SelectionId = other.SelectionId;
      }
      if (other.selection_ != null) {
        if (selection_ == null) {
          selection_ = new global::Narupa.Protocol.Selection.AtomSelection();
        }
        Selection.MergeFrom(other.Selection);
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
          case 18: {
            SelectionId = input.ReadString();
            break;
          }
          case 26: {
            if (selection_ == null) {
              selection_ = new global::Narupa.Protocol.Selection.AtomSelection();
            }
            input.ReadMessage(selection_);
            break;
          }
        }
      }
    }

  }

  public sealed partial class SetSelectionResponse : pb::IMessage<SetSelectionResponse> {
    private static readonly pb::MessageParser<SetSelectionResponse> _parser = new pb::MessageParser<SetSelectionResponse>(() => new SetSelectionResponse());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<SetSelectionResponse> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Narupa.Protocol.Selection.SetSelectionReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SetSelectionResponse() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SetSelectionResponse(SetSelectionResponse other) : this() {
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SetSelectionResponse Clone() {
      return new SetSelectionResponse(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as SetSelectionResponse);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(SetSelectionResponse other) {
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
    public void MergeFrom(SetSelectionResponse other) {
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