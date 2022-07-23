namespace BuilderGenerator;

internal class Field
{
    public string Name { get; set; }
    public Type Type { get; set; }

    public string TypeName()
    {
        return Type.ToCompilableName();
    }
}
