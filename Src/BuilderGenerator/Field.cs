namespace BuilderGenerator;

internal class Field
{
    public string Name { get; set; }
    public Type Type { get; set; }

    public string TypeName()
    {
        if (Type.IsPrimitive || Type == typeof(string))
        {
            return Type.Name;
        }
        throw new NotSupportedException();
    }
}
