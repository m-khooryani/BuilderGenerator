namespace BuilderGenerator;

internal static class FieldsGenerator
{
    private const string FieldType = "@FieldType";
    private const string FieldName = "@FieldName";
    private const string FieldDefinitionTemplate = 
$@"    private {FieldType} {FieldName};";

    internal static string Generate(Type type)
    {
        var fields = FieldsResolver.GetFields(type);

        return string
            .Join(Environment.NewLine, fields
                .Select(field =>
                    FieldDefinitionTemplate
                        .Replace(FieldType, field.TypeName())
                        .Replace(FieldName, field.Name)));
    }
}
