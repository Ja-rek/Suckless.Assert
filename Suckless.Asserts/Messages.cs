namespace Suckless.Asserts
{
    internal class Messages
    {
        public const string MUST_BE_EMPTY = "must be empty.";
        public const string CANNOT_BE_NULL = "cannot be null.";

        public static string CountGreaterThan(int expected, int actual) => 
            $"contains {actual} but should contain greater than {expected}.";

        public static string CountLessThan(int expected, int actual) => 
            $"contains {actual} but should contain less than {expected}.";
    }
}
