// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Narupa/Protocol/array.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Narupa.Protocol {

  /// <summary>Holder for reflection information generated from Narupa/Protocol/array.proto</summary>
  public static partial class ArrayReflection {

    #region Descriptor
    /// <summary>File descriptor for Narupa/Protocol/array.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static ArrayReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChtOYXJ1cGEvUHJvdG9jb2wvYXJyYXkucHJvdG8SD25hcnVwYS5wcm90b2Nv",
            "bCIcCgpGbG9hdEFycmF5Eg4KBnZhbHVlcxgBIAMoAiIcCgpJbmRleEFycmF5",
            "Eg4KBnZhbHVlcxgBIAMoDSIdCgtTdHJpbmdBcnJheRIOCgZ2YWx1ZXMYASAD",
            "KAkitwEKClZhbHVlQXJyYXkSMwoMZmxvYXRfdmFsdWVzGAEgASgLMhsubmFy",
            "dXBhLnByb3RvY29sLkZsb2F0QXJyYXlIABIzCgxpbmRleF92YWx1ZXMYAiAB",
            "KAsyGy5uYXJ1cGEucHJvdG9jb2wuSW5kZXhBcnJheUgAEjUKDXN0cmluZ192",
            "YWx1ZXMYAyABKAsyHC5uYXJ1cGEucHJvdG9jb2wuU3RyaW5nQXJyYXlIAEII",
            "CgZ2YWx1ZXNiBnByb3RvMw=="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Narupa.Protocol.FloatArray), global::Narupa.Protocol.FloatArray.Parser, new[]{ "Values" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Narupa.Protocol.IndexArray), global::Narupa.Protocol.IndexArray.Parser, new[]{ "Values" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Narupa.Protocol.StringArray), global::Narupa.Protocol.StringArray.Parser, new[]{ "Values" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Narupa.Protocol.ValueArray), global::Narupa.Protocol.ValueArray.Parser, new[]{ "FloatValues", "IndexValues", "StringValues" }, new[]{ "Values" }, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class FloatArray : pb::IMessage<FloatArray> {
    private static readonly pb::MessageParser<FloatArray> _parser = new pb::MessageParser<FloatArray>(() => new FloatArray());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<FloatArray> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Narupa.Protocol.ArrayReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public FloatArray() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public FloatArray(FloatArray other) : this() {
      values_ = other.values_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public FloatArray Clone() {
      return new FloatArray(this);
    }

    /// <summary>Field number for the "values" field.</summary>
    public const int ValuesFieldNumber = 1;
    private static readonly pb::FieldCodec<float> _repeated_values_codec
        = pb::FieldCodec.ForFloat(10);
    private readonly pbc::RepeatedField<float> values_ = new pbc::RepeatedField<float>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<float> Values {
      get { return values_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as FloatArray);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(FloatArray other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if(!values_.Equals(other.values_)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      hash ^= values_.GetHashCode();
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
      values_.WriteTo(output, _repeated_values_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      size += values_.CalculateSize(_repeated_values_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(FloatArray other) {
      if (other == null) {
        return;
      }
      values_.Add(other.values_);
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
          case 10:
          case 13: {
            values_.AddEntriesFrom(input, _repeated_values_codec);
            break;
          }
        }
      }
    }

  }

  public sealed partial class IndexArray : pb::IMessage<IndexArray> {
    private static readonly pb::MessageParser<IndexArray> _parser = new pb::MessageParser<IndexArray>(() => new IndexArray());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<IndexArray> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Narupa.Protocol.ArrayReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public IndexArray() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public IndexArray(IndexArray other) : this() {
      values_ = other.values_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public IndexArray Clone() {
      return new IndexArray(this);
    }

    /// <summary>Field number for the "values" field.</summary>
    public const int ValuesFieldNumber = 1;
    private static readonly pb::FieldCodec<uint> _repeated_values_codec
        = pb::FieldCodec.ForUInt32(10);
    private readonly pbc::RepeatedField<uint> values_ = new pbc::RepeatedField<uint>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<uint> Values {
      get { return values_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as IndexArray);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(IndexArray other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if(!values_.Equals(other.values_)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      hash ^= values_.GetHashCode();
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
      values_.WriteTo(output, _repeated_values_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      size += values_.CalculateSize(_repeated_values_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(IndexArray other) {
      if (other == null) {
        return;
      }
      values_.Add(other.values_);
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
          case 10:
          case 8: {
            values_.AddEntriesFrom(input, _repeated_values_codec);
            break;
          }
        }
      }
    }

  }

  public sealed partial class StringArray : pb::IMessage<StringArray> {
    private static readonly pb::MessageParser<StringArray> _parser = new pb::MessageParser<StringArray>(() => new StringArray());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<StringArray> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Narupa.Protocol.ArrayReflection.Descriptor.MessageTypes[2]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public StringArray() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public StringArray(StringArray other) : this() {
      values_ = other.values_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public StringArray Clone() {
      return new StringArray(this);
    }

    /// <summary>Field number for the "values" field.</summary>
    public const int ValuesFieldNumber = 1;
    private static readonly pb::FieldCodec<string> _repeated_values_codec
        = pb::FieldCodec.ForString(10);
    private readonly pbc::RepeatedField<string> values_ = new pbc::RepeatedField<string>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<string> Values {
      get { return values_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as StringArray);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(StringArray other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if(!values_.Equals(other.values_)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      hash ^= values_.GetHashCode();
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
      values_.WriteTo(output, _repeated_values_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      size += values_.CalculateSize(_repeated_values_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(StringArray other) {
      if (other == null) {
        return;
      }
      values_.Add(other.values_);
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
            values_.AddEntriesFrom(input, _repeated_values_codec);
            break;
          }
        }
      }
    }

  }

  public sealed partial class ValueArray : pb::IMessage<ValueArray> {
    private static readonly pb::MessageParser<ValueArray> _parser = new pb::MessageParser<ValueArray>(() => new ValueArray());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<ValueArray> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Narupa.Protocol.ArrayReflection.Descriptor.MessageTypes[3]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ValueArray() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ValueArray(ValueArray other) : this() {
      switch (other.ValuesCase) {
        case ValuesOneofCase.FloatValues:
          FloatValues = other.FloatValues.Clone();
          break;
        case ValuesOneofCase.IndexValues:
          IndexValues = other.IndexValues.Clone();
          break;
        case ValuesOneofCase.StringValues:
          StringValues = other.StringValues.Clone();
          break;
      }

      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ValueArray Clone() {
      return new ValueArray(this);
    }

    /// <summary>Field number for the "float_values" field.</summary>
    public const int FloatValuesFieldNumber = 1;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Narupa.Protocol.FloatArray FloatValues {
      get { return valuesCase_ == ValuesOneofCase.FloatValues ? (global::Narupa.Protocol.FloatArray) values_ : null; }
      set {
        values_ = value;
        valuesCase_ = value == null ? ValuesOneofCase.None : ValuesOneofCase.FloatValues;
      }
    }

    /// <summary>Field number for the "index_values" field.</summary>
    public const int IndexValuesFieldNumber = 2;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Narupa.Protocol.IndexArray IndexValues {
      get { return valuesCase_ == ValuesOneofCase.IndexValues ? (global::Narupa.Protocol.IndexArray) values_ : null; }
      set {
        values_ = value;
        valuesCase_ = value == null ? ValuesOneofCase.None : ValuesOneofCase.IndexValues;
      }
    }

    /// <summary>Field number for the "string_values" field.</summary>
    public const int StringValuesFieldNumber = 3;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Narupa.Protocol.StringArray StringValues {
      get { return valuesCase_ == ValuesOneofCase.StringValues ? (global::Narupa.Protocol.StringArray) values_ : null; }
      set {
        values_ = value;
        valuesCase_ = value == null ? ValuesOneofCase.None : ValuesOneofCase.StringValues;
      }
    }

    private object values_;
    /// <summary>Enum of possible cases for the "values" oneof.</summary>
    public enum ValuesOneofCase {
      None = 0,
      FloatValues = 1,
      IndexValues = 2,
      StringValues = 3,
    }
    private ValuesOneofCase valuesCase_ = ValuesOneofCase.None;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ValuesOneofCase ValuesCase {
      get { return valuesCase_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void ClearValues() {
      valuesCase_ = ValuesOneofCase.None;
      values_ = null;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as ValueArray);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(ValueArray other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (!object.Equals(FloatValues, other.FloatValues)) return false;
      if (!object.Equals(IndexValues, other.IndexValues)) return false;
      if (!object.Equals(StringValues, other.StringValues)) return false;
      if (ValuesCase != other.ValuesCase) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (valuesCase_ == ValuesOneofCase.FloatValues) hash ^= FloatValues.GetHashCode();
      if (valuesCase_ == ValuesOneofCase.IndexValues) hash ^= IndexValues.GetHashCode();
      if (valuesCase_ == ValuesOneofCase.StringValues) hash ^= StringValues.GetHashCode();
      hash ^= (int) valuesCase_;
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
      if (valuesCase_ == ValuesOneofCase.FloatValues) {
        output.WriteRawTag(10);
        output.WriteMessage(FloatValues);
      }
      if (valuesCase_ == ValuesOneofCase.IndexValues) {
        output.WriteRawTag(18);
        output.WriteMessage(IndexValues);
      }
      if (valuesCase_ == ValuesOneofCase.StringValues) {
        output.WriteRawTag(26);
        output.WriteMessage(StringValues);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (valuesCase_ == ValuesOneofCase.FloatValues) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(FloatValues);
      }
      if (valuesCase_ == ValuesOneofCase.IndexValues) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(IndexValues);
      }
      if (valuesCase_ == ValuesOneofCase.StringValues) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(StringValues);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(ValueArray other) {
      if (other == null) {
        return;
      }
      switch (other.ValuesCase) {
        case ValuesOneofCase.FloatValues:
          if (FloatValues == null) {
            FloatValues = new global::Narupa.Protocol.FloatArray();
          }
          FloatValues.MergeFrom(other.FloatValues);
          break;
        case ValuesOneofCase.IndexValues:
          if (IndexValues == null) {
            IndexValues = new global::Narupa.Protocol.IndexArray();
          }
          IndexValues.MergeFrom(other.IndexValues);
          break;
        case ValuesOneofCase.StringValues:
          if (StringValues == null) {
            StringValues = new global::Narupa.Protocol.StringArray();
          }
          StringValues.MergeFrom(other.StringValues);
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
            global::Narupa.Protocol.FloatArray subBuilder = new global::Narupa.Protocol.FloatArray();
            if (valuesCase_ == ValuesOneofCase.FloatValues) {
              subBuilder.MergeFrom(FloatValues);
            }
            input.ReadMessage(subBuilder);
            FloatValues = subBuilder;
            break;
          }
          case 18: {
            global::Narupa.Protocol.IndexArray subBuilder = new global::Narupa.Protocol.IndexArray();
            if (valuesCase_ == ValuesOneofCase.IndexValues) {
              subBuilder.MergeFrom(IndexValues);
            }
            input.ReadMessage(subBuilder);
            IndexValues = subBuilder;
            break;
          }
          case 26: {
            global::Narupa.Protocol.StringArray subBuilder = new global::Narupa.Protocol.StringArray();
            if (valuesCase_ == ValuesOneofCase.StringValues) {
              subBuilder.MergeFrom(StringValues);
            }
            input.ReadMessage(subBuilder);
            StringValues = subBuilder;
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
