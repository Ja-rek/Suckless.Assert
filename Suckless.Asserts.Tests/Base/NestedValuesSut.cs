namespace Suckless.Asserts.Tests.Base
{
    internal class NestedValuesSut
    {
        public ValuesSut variable = new ValuesSut();
        public static ValuesSut staticVariable = new ValuesSut();
        public ValuesSut Property { get; set; } = new ValuesSut();
        public static ValuesSut StaticProperty { get; set; } = new ValuesSut(); 
        public ValuesSut Method() => new ValuesSut(); 
        public static ValuesSut StaticMethod() => new ValuesSut(); 
    }
}
