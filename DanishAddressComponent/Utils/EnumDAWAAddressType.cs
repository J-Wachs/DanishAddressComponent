using System.Runtime.Serialization;

/// <summary>
/// Danish Web Addresses types.
/// </summary>
public enum DAWAAddressType
{
    Unknown,

    [EnumMember(Value = "vejnavn")]
    RoadName,

    [EnumMember(Value = "adgangsadresse")]
    AccessAddress,

    [EnumMember(Value = "adresse")]
    Address
}

