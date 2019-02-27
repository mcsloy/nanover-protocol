// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Narupa/Protocol/trajectory/frame.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Narupa.Protocol.Trajectory {

  /// <summary>Holder for reflection information generated from Narupa/Protocol/trajectory/frame.proto</summary>
  public static partial class FrameReflection {

    #region Descriptor
    /// <summary>File descriptor for Narupa/Protocol/trajectory/frame.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static FrameReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "CiZOYXJ1cGEvUHJvdG9jb2wvdHJhamVjdG9yeS9mcmFtZS5wcm90bxIabmFy",
            "dXBhLnByb3RvY29sLnRyYWplY3RvcnkaG25hcnVwYS9wcm90b2NvbC9hcnJh",
            "eS5wcm90bxocZ29vZ2xlL3Byb3RvYnVmL3N0cnVjdC5wcm90byKkAgoJRnJh",
            "bWVEYXRhEkEKBnZhbHVlcxgBIAMoCzIxLm5hcnVwYS5wcm90b2NvbC50cmFq",
            "ZWN0b3J5LkZyYW1lRGF0YS5WYWx1ZXNFbnRyeRJBCgZhcnJheXMYAiADKAsy",
            "MS5uYXJ1cGEucHJvdG9jb2wudHJhamVjdG9yeS5GcmFtZURhdGEuQXJyYXlz",
            "RW50cnkaRQoLVmFsdWVzRW50cnkSCwoDa2V5GAEgASgJEiUKBXZhbHVlGAIg",
            "ASgLMhYuZ29vZ2xlLnByb3RvYnVmLlZhbHVlOgI4ARpKCgtBcnJheXNFbnRy",
            "eRILCgNrZXkYASABKAkSKgoFdmFsdWUYAiABKAsyGy5uYXJ1cGEucHJvdG9j",
            "b2wuVmFsdWVBcnJheToCOAFiBnByb3RvMw=="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::Narupa.Protocol.ArrayReflection.Descriptor, global::Google.Protobuf.WellKnownTypes.StructReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Narupa.Protocol.Trajectory.FrameData), global::Narupa.Protocol.Trajectory.FrameData.Parser, new[]{ "Values", "Arrays" }, null, null, new pbr::GeneratedClrTypeInfo[] { null, null, })
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class FrameData : pb::IMessage<FrameData> {
    private static readonly pb::MessageParser<FrameData> _parser = new pb::MessageParser<FrameData>(() => new FrameData());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<FrameData> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Narupa.Protocol.Trajectory.FrameReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public FrameData() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public FrameData(FrameData other) : this() {
      values_ = other.values_.Clone();
      arrays_ = other.arrays_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public FrameData Clone() {
      return new FrameData(this);
    }

    /// <summary>Field number for the "values" field.</summary>
    public const int ValuesFieldNumber = 1;
    private static readonly pbc::MapField<string, global::Google.Protobuf.WellKnownTypes.Value>.Codec _map_values_codec
        = new pbc::MapField<string, global::Google.Protobuf.WellKnownTypes.Value>.Codec(pb::FieldCodec.ForString(10), pb::FieldCodec.ForMessage(18, global::Google.Protobuf.WellKnownTypes.Value.Parser), 10);
    private readonly pbc::MapField<string, global::Google.Protobuf.WellKnownTypes.Value> values_ = new pbc::MapField<string, global::Google.Protobuf.WellKnownTypes.Value>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::MapField<string, global::Google.Protobuf.WellKnownTypes.Value> Values {
      get { return values_; }
    }

    /// <summary>Field number for the "arrays" field.</summary>
    public const int ArraysFieldNumber = 2;
    private static readonly pbc::MapField<string, global::Narupa.Protocol.ValueArray>.Codec _map_arrays_codec
        = new pbc::MapField<string, global::Narupa.Protocol.ValueArray>.Codec(pb::FieldCodec.ForString(10), pb::FieldCodec.ForMessage(18, global::Narupa.Protocol.ValueArray.Parser), 18);
    private readonly pbc::MapField<string, global::Narupa.Protocol.ValueArray> arrays_ = new pbc::MapField<string, global::Narupa.Protocol.ValueArray>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::MapField<string, global::Narupa.Protocol.ValueArray> Arrays {
      get { return arrays_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as FrameData);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(FrameData other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (!Values.Equals(other.Values)) return false;
      if (!Arrays.Equals(other.Arrays)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      hash ^= Values.GetHashCode();
      hash ^= Arrays.GetHashCode();
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
      values_.WriteTo(output, _map_values_codec);
      arrays_.WriteTo(output, _map_arrays_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      size += values_.CalculateSize(_map_values_codec);
      size += arrays_.CalculateSize(_map_arrays_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(FrameData other) {
      if (other == null) {
        return;
      }
      values_.Add(other.values_);
      arrays_.Add(other.arrays_);
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
            values_.AddEntriesFrom(input, _map_values_codec);
            break;
          }
          case 18: {
            arrays_.AddEntriesFrom(input, _map_arrays_codec);
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
