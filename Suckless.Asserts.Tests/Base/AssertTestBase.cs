namespace Suckless.Asserts.Tests.Base
{
    internal abstract class AssertBaseTest
    {
        public Metadata<TValue> Metadata<TValue>(TValue value)
        {
            return new Metadata<TValue>(value, null);
        }
    }
}
