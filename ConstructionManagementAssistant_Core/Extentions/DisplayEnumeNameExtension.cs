namespace ConstructionManagementAssistant_Core.Extentions;

public static class DisplayEnumeNameExtension
{
    public static string GetDisplayName(this Enum? enumValue)
    {
        try
        {
            if (enumValue is null)
            {
                return "";
            }
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<DisplayAttribute>()
                            ?.GetName() ?? enumValue.ToString();
        }
        catch
        {
            return enumValue.ToString();
        }
    }
    public static T? ToEnumByDisplayName<T>(this string displayName) where T : struct, Enum
    {
        foreach (var field in typeof(T).GetFields())
        {
            var attribute = Attribute.GetCustomAttribute(field, typeof(DisplayAttribute)) as DisplayAttribute;
            if (attribute != null && attribute.Name == displayName)
            {
                return (T)field.GetValue(null);
            }
        }
        return null;
    }


}
