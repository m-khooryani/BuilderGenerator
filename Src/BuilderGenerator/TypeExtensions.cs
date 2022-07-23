﻿namespace BuilderGenerator;

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
            return type.FullName;
        }
        throw new NotSupportedException();
    }
}
