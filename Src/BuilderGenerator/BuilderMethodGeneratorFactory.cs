namespace BuilderGenerator;

internal static class BuilderMethodGeneratorFactory
{
    public static IBuilderMethodGenerator GetGenerator(Type type)
    {
        if (type.HasSingleParamLessConstructor())
        {
            return new InitializerBuilderMethodGenerator();
        }
        throw new NotSupportedException();
    }
}
