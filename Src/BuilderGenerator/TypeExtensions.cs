namespace BuilderGenerator;

internal static class TypeExtensions
{
    public static bool HasSingleParamLessConstructor(this Type type)
    {
        var constructors = type.GetConstructors();

        return constructors.Length == 1 && 
            constructors.First().GetParameters().Length == 0;
    }
}
