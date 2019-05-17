using System;
using System.Linq;
using NUnit.Framework;
using Suckless.Asserts.Tests.Base;

namespace Suckless.Asserts.Tests.ExtensionMethods
{
    internal partial class CountTest : AssertBaseTest<ArgumentOutOfRangeException> 
    {
        [Test]
        public void Count_WhenAllowNullAndStringIsNull_DoNotThrowException()
        {
            StubMetadata<string>(null).Count(1);
        }

        [Test]
        public void Count_WhenCountIsExactAsExpedtedNumber_DoNotThrowException()
        {
            StubMetadata("123").Count(3);
        }

        [Test]
        public void Count_WhenCountIsBetweenExpectedCharacters_DoNotThrowException()
        {
            StubMetadata("12345").Count(1, 5);
        }

        [Test, TestCase(null), TestCase("AnyName")]
        public void Count_WhenCountIsNotAsExpecptedNumber_ThrowsExceptionWithCorrectMessage(string fieldName)
        {
            string value = "123";
            var expectedMessagePart = "contains 3 character/s but should contain exact 5.";

            AssertExceptionMessage<string>(() => StubMetadata(value, fieldName).Count(5), 
                expecteddName: fieldName, 
                expectedMessagePart);
        }

        [Test] 
        [TestCase(null, "12"), 
        TestCase(null, "121232"), 
        TestCase("AnyName", "12"), 
        TestCase("AnyName", "1212121")]
        public void Count_WhenCountIsNotBetweenExpectedCharacters_ThrowsException(string fieldName, string value)
        {
            var expectedMessagePart = $"contains {value.Count()} character/s but should contain between 3 - 4.";

            AssertExceptionMessage<string>(() => StubMetadata(value, fieldName).Count(3, 4), 
                expecteddName: fieldName, 
                expectedMessagePart);
        }

        [TestCase(null, "12"), 
        TestCase(null, "121232"), 
        TestCase("AnyName", "12"), 
        TestCase("AnyName", "1212121")]
        public void CountCharacters_WhenAssertionFailedAdnCustomMessageWasSpecyfied_ThrowsExceptionWithCorrectMessage(string fieldName, string value)
        {
            AssertCustomExceptionMessage(() => StubMetadata(value, fieldName).Count(3, 5, CUSTOM_MESSAGE), 
                expected: CUSTOM_MESSAGE);
        }
    }
}
