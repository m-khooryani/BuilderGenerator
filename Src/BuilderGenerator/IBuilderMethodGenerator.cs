namespace BuilderGenerator;

internal interface IBuilderMethodGenerator
{
    string Generate(Type type);
}