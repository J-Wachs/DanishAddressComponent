using System.Runtime.Serialization;

namespace DanishAddressComponent.Utils;

/// <summary>
/// Class that handles convertion from enum to string value and vise versa.
/// </summary>
public static class EnumDAWAAddressTypeConverter
{
    /// <summary>
    /// Converts from a address type string value to the enum value.
    /// </summary>
    /// <param name="value">The string value to lookup in the enum</param>
    /// <returns>Enum value</returns>
    public static DAWAAddressType FromEnumMemberValue(string value)
    {
        var type = typeof(DAWAAddressType);

        foreach (var field in type.GetFields())
        {
            var attribute = field.GetCustomAttributes(typeof(EnumMemberAttribute), false).FirstOrDefault() as EnumMemberAttribute;
            if (attribute is not null && attribute.Value == value)
            {
                var enumEntry = field.GetValue(null);
                if (enumEntry is not null)
                {
                    return (DAWAAddressType)enumEntry;
                }
            }
        }
        return DAWAAddressType.Unknown;
    }

    /// <summary>
    /// Converts from an enum value to the string value.
    /// </summary>
    /// <param name="enumValue">Enum value to look up in the enum</param>
    /// <returns>String value</returns>
    public static string ToEnumMemberValue(DAWAAddressType enumValue)
    {
        var type = typeof(DAWAAddressType);
        var field = type.GetField(enumValue.ToString());
        var attribute = field?.GetCustomAttributes(typeof(EnumMemberAttribute), false).FirstOrDefault() as EnumMemberAttribute;
        if (attribute is not null && attribute.Value is not null)
        {
            return attribute.Value;
        }
        return string.Empty; // Unknown
    }
}
