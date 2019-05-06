namespace Suckless.Asserts.Tests.AssertExpressionAsArgumentTests
{
    internal abstract class MetadataFactoryTestBase
    {
        protected string Name(string name) => $"The {name}: {typeof(string)} ";
    }
}
