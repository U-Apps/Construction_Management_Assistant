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

}
