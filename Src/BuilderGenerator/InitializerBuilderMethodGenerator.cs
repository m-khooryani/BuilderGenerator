namespace BuilderGenerator;

internal class InitializerBuilderMethodGenerator : IBuilderMethodGenerator
{
    private const string Assignments = "@Assignments@";
    private const string FieldName = "@FieldName@";
    private const string MethodTemplate = $@"
    public {Constants.ClassName} Build()
    {{
        return new {Constants.ClassName}()
        {{
            {Assignments}
        }};
    }}";
    private const string FieldAssignmentTemplate = 
$@"            {FieldName} = this.{FieldName}";

    public string Generate(Type type)
    {
        return MethodTemplate
                    .Replace(Constants.ClassName, type.Name)
                    .Replace(Assignments, GenerateAssignments(type))
                    .TrimStart();
    }

    internal static string GenerateAssignments(Type type)
    {
        var fields = FieldsResolver.GetFields(type);

        return string
            .Join("," + Environment.NewLine, fields
                .Select(field =>
                    FieldAssignmentTemplate
                        .Replace(FieldName, field.Name)))
            .Trim();
    }
}
