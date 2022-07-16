namespace BuilderGenerator;

internal static class FieldsResolver
{
    public static IReadOnlyList<Field> GetFields(Type type)
    {
        if (type.HasSingleParamLessConstructor())
        {
            var props = type.GetProperties();
            return props
                .Select(propertyInfo => new Field()
                {
                    Name = propertyInfo.Name,
                    Type = propertyInfo.PropertyType,
                })
                .ToList()
                .AsReadOnly();
        }
        throw new NotSupportedException();
    }
}

internal class Field
{
    public string Name { get; set; }
    public Type Type { get; set; }
}
