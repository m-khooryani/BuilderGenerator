namespace BuilderGenerator;

internal static class ConstructorGenerator
{
    private const string FieldName = "@FieldName@";
    private const string FieldDefaultValue = "@FieldDefaultValue@";
    private const string FieldInitialization = "@FieldInitialization@";
    private const string ConstructorTemplate = $@"
    public {Constants.ClassName}()
    {{
        {FieldInitialization}
    }}";
    private const string FieldInitializationTemplate = $@"
        {FieldName} = {FieldDefaultValue};";

    internal static string Generate(Type type)
    {
        return ConstructorTemplate
                    .Replace(Constants.ClassName, type.Name + Constants.BuilderPostfix)
                    .Replace(FieldInitialization, GenerateFieldInitializations(type))
                    .TrimStart();
    }

    internal static string GenerateFieldInitializations(Type type)
    {
        var fields = FieldsResolver.GetFields(type);

        return string
            .Join(Environment.NewLine, fields
                .Select(field =>
                    FieldInitializationTemplate
                        .Replace(FieldName, field.Name)
                        .Replace(FieldDefaultValue, "null")))
            .Trim();
    }
}
