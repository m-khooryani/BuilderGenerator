using System.Collections;

namespace BuilderGenerator;

internal static class TypeExtensions
{
    public static bool HasSingleParamLessConstructor(this Type type)
    {
        var constructors = type.GetConstructors();

        return constructors.Length == 1 &&
            constructors.First().GetParameters().Length == 0;
    }

    public static string ToCompilableName(this Type type)
    {
        if (type.IsPrimitive || type == typeof(string))
        {
            return type.Name;
        }

        if (type.IsArray)
        {
            return type.GetElementType().ToCompilableName() + ArraySignPostfix(type);
        }
        if (type.IsGenericType && (typeof(IList<>) == type.GetGenericTypeDefinition() ||
            typeof(IList).IsAssignableFrom(type.GetGenericTypeDefinition())))
        {
            return "List<" + type.GetGenericArguments().First().ToCompilableName() + ">";
        }
        if (type.IsGenericType && (typeof(IReadOnlyList<>) == type.GetGenericTypeDefinition()))
        {
            return "List<" + type.GetGenericArguments().First().ToCompilableName() + ">";
        }
        if (type.IsGenericType && (typeof(IDictionary<,>) == type.GetGenericTypeDefinition() ||
            typeof(IDictionary).IsAssignableFrom(type.GetGenericTypeDefinition())))
        {
            return $"Dictionary<{type.GetGenericArguments().First().ToCompilableName()}, {type.GetGenericArguments()[1].ToCompilableName()}>";
        }
        throw new NotSupportedException();
    }

    private static string ArraySignPostfix(Type type)
    {
        return new string(type
            .FullName[type.FullName.LastIndexOf('[')..]
            .ToArray());
    }
}
