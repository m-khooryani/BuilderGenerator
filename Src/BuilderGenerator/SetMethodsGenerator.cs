namespace BuilderGenerator;

internal static class SetMethodsGenerator
{
    private const string FieldName = "@FieldName";
    private const string FieldType = "@FieldType";
    private const string SetMethodTemplate = $@"
    public {Constants.ClassName} Set{FieldName}({FieldType} {FieldName})
    {{
        this.{FieldName} = {FieldName};
        return this;
    }}";

    internal static string Generate(Type type)
    {
        var fields = FieldsResolver.GetFields(type);

        return string
            .Join(Environment.NewLine, fields
                .Select(field =>
                    SetMethodTemplate
                        .Replace(FieldName, field.Name)
                        .Replace(Constants.ClassName, type.Name + Constants.BuilderPostfix)
                        .Replace(FieldType, field.Type.Name)))
            .Trim();
    }
}
