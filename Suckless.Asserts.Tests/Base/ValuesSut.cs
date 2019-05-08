namespace Suckless.Asserts.Tests.Base
{
    internal class ValuesSut
    {
        public const string ANY_VALUE = "any value";
        public string variable = ANY_VALUE;
        public static string staticVariable = ANY_VALUE;
        public string Property { get; set; } = ANY_VALUE;
        public static string StaticProperty { get; set; } = ANY_VALUE;
        public string Method() => ANY_VALUE;
        public static string StaticMethod() => ANY_VALUE;
    }
}
