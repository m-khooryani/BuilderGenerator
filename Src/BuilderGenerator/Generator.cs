using System.Text;

namespace BuilderGenerator;

/// <summary>
/// Generator facade
/// </summary>
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

public class {Constants.ClassName}
{{
{Constants.Fields}

    {Constants.Constructor}

    {Constants.BuilderMethod}

    {Constants.SetMethods}
}}";

    internal static string Generate(Type type)
    {
        var stringBuilder = new StringBuilder();

        var builderMethodGenerator = BuilderMethodGeneratorFactory.GetGenerator(type);
        stringBuilder.AppendLine(BuilderTemplate
            .Replace(Constants.ClassName, type.Name + Constants.BuilderPostfix)
            .Replace(Constants.Fields, FieldsGenerator.Generate(type))
            .Replace(Constants.Constructor, ConstructorGenerator.Generate(type))
            .Replace(Constants.BuilderMethod, builderMethodGenerator.Generate(type))
            .Replace(Constants.SetMethods, SetMethodsGenerator.Generate(type)));
        return stringBuilder.ToString().TrimStart();
    }
}
