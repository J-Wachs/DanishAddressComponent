using System.Runtime.Serialization;

public enum DAWAAutoCompleteType
{
    Unknown,

    [EnumMember(Value = "vejnavn")]
    RoadName,

    [EnumMember(Value = "adgangsadresse")]
    AccessAddress,

    [EnumMember(Value = "adresse")]
    Address
}

