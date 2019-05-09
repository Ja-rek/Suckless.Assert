namespace Suckless.Asserts
{
    internal class Messages
    {
        public const string MUST_BE_EMPTY = "must be empty.";
        public const string CANNOT_BE_NULL = "cannot be null.";

        public static string NumberRange(string expectedMin, string expectedMax, string actual) => 
            $"is {actual} but should be in range {expectedMin}-{expectedMax}.";

        public static string EnumerableRange(string expectedMin, string expectedMax, string actual) => 
            $"contains {actual} items but should contain items in range {expectedMin}-{expectedMax}.";

        public static string GreaterThan(string expected, string actual) => 
            $"is {actual} but should be greater than {expected}.";

        public static string LessThan(string expected, string actual) => 
            $"is {actual} but should be less than {expected}.";

        public static string CountGreaterThan(int expected, int actual) => 
            $"contains {actual} items but should contain greater than {expected}.";

        public static string CountLessThan(int expected, int actual) => 
            $"contains {actual} items but should contain less than {expected}.";

        public static string Length(int expected, int actual) => 
            $"contains {actual} characters but should contain exact {expected}.";

        public static string Length(int min, int max, int actual) => 
            $"contains {actual} characters but should be between {min} and {max}.";
    }
}
