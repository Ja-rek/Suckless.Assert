using System;
using NUnit.Framework;
using Suckless.Asserts.Tests.Base;

namespace Suckless.Asserts.Tests.ExtensionMethods
{
    internal partial class CountLessTest : AssertBaseTest<ArgumentOutOfRangeException> 
    {
        [Test]
        public void CountLess_WhenStringIsNull_DoNotThrowException()
        {
            StubMetadata<string>(null).CountLess(2);
        }

        [Test]
        public void CountLess_WhenStringIsLessThanExpectedCharacters_DoNotThrowException()
        {
            StubMetadata("1").CountLess(2);
        }

        [TestCase(null), TestCase("AnyName")]
        public void CountLess_WhenStringIsNotLessThanExpectedCharacters_ThrowsExceptionWithCorrectMessage(string fieldName)
        {
            var expectedMessagePart = "contains 2 character/s but should contain less than 1.";

            AssertExceptionMessage<string>(() => StubMetadata("12", fieldName).CountLess(1), 
                expecteddName: fieldName, 
                expectedMessagePart);
        }

        [TestCase(null), TestCase("AnyName")]
        public void CountLess_WhenStringIsNotLessThanExpectedCharactersAdnCustomMessageWasSpecyfied_ThrowsExceptionWithCorrectMessage(string fieldName)
        {
            AssertCustomExceptionMessage(() => StubMetadata("12", fieldName).CountLess(1, CUSTOM_MESSAGE), 
                expected: CUSTOM_MESSAGE);
        }
    }
}
