namespace Suckless.Asserts.Tests.Base
{
    internal abstract class AssertByExpressionTestBase
    {
        protected string Name(string name) => $"The {name}: {typeof(string)} ";
    }
}
