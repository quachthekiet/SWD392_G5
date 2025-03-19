using System.ComponentModel;
using System.Reflection;

public static class EnumHelper
{
    public static List<string> GetEnumDescriptions<T>() where T : Enum
    {
        return Enum.GetValues(typeof(T))
                   .Cast<T>()
                   .Select(value => GetEnumDescription(value))
                   .ToList();
    }

    public static string GetEnumDescription<T>(T value) where T : Enum
    {
        FieldInfo field = value.GetType().GetField(value.ToString());
        DescriptionAttribute attribute = field.GetCustomAttribute<DescriptionAttribute>();
        return attribute != null ? attribute.Description : value.ToString();
    }
}
