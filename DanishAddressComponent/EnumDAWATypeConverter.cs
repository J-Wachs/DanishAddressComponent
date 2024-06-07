using System.Runtime.Serialization;

namespace DanishAddressComponent;

public static class EnumDAWATypeConverter
{
    public static DAWAAutoCompleteType FromEnumMemberValue(string value)
    {
        var type = typeof(DAWAAutoCompleteType);

        foreach (var field in type.GetFields())
        {
            var attribute = field.GetCustomAttributes(typeof(EnumMemberAttribute), false).FirstOrDefault() as EnumMemberAttribute;
            if (attribute is not null && attribute.Value == value)
            {
                var enumEntry = field.GetValue(null);
                if (enumEntry is not null)
                {
                    return (DAWAAutoCompleteType)enumEntry;
                }
            }
        }
        return DAWAAutoCompleteType.Unknown;
    }

    public static string ToEnumMemberValue(DAWAAutoCompleteType enumValue)
    {
        var type = typeof(DAWAAutoCompleteType);
        var field = type.GetField(enumValue.ToString());
        var attribute = field?.GetCustomAttributes(typeof(EnumMemberAttribute), false).FirstOrDefault() as EnumMemberAttribute;
        if (attribute is not null && attribute.Value is not null)
        {
            return attribute.Value;
        }
        return string.Empty; // Unknown
    }
}
