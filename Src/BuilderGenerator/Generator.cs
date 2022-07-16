using System.Text;

namespace BuilderGenerator;

public static class Generator
{
    public static (Type type, string builder)[] Generate(IEnumerable<Type> types)
    {
        types = types.Distinct();
        return types
            .Select(type => (type, Generate(type)))
            .ToArray();
    }

    private const string BuilderTemplate = $@"
using System;
using System.Collections.Generic;

namespace @namespace;
@usings

public class {Constants.ClassName}
{{
    {Constants.Fields}

    {Constants.Constructor}

    {Constants.SetMethods}
}}";

    internal static string Generate(Type type)
    {
        var stringBuilder = new StringBuilder();

        stringBuilder.AppendLine(BuilderTemplate
            .Replace(Constants.ClassName, type.Name + Constants.BuilderPostfix)
            .Replace(Constants.Fields, FieldsGenerator.Generate(type))
            .Replace(Constants.Constructor, ConstructorGenerator.Generate(type))
            .Replace(Constants.SetMethods, SetMethodsGenerator.Generate(type)));
        return stringBuilder.ToString().TrimStart();
    }
}
