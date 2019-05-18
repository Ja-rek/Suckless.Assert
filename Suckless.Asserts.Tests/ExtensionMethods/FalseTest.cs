using System;
using NUnit.Framework;
using Suckless.Asserts.Tests.Base;

namespace Suckless.Asserts.Tests.ExtensionMethods
{
    internal class FalseTest : AssertBaseTest<ArgumentException> 
    {
        [Test]
        public void False_WhenValueIsEqualToExpectedValue_DoesNotThrowException()
        {
            StubMetadata(false).False();
        }

        [TestCase(null), TestCase("AnyName")]
        public void False_WhenValueIsNotEqualToExpectedValue_ThrowsExceptionWithCorrectMessage(string fieldName)
        {
            var expectedMessagePart = "must be false.";

            AssertExceptionMessage<bool>(() => StubMetadata(true, fieldName).False(), 
                expecteddName: fieldName, 
                expectedMessagePart);
        }

        [TestCase(null), TestCase("AnyName")]
        public void False_WhenValueIsNotEqualToExpectedValueAdnCustomMessageWasSpecyfied_ThrowsExceptionWithCorrectMessage(string fieldName)
        {
            AssertCustomExceptionMessage(() => StubMetadata(true, fieldName).False(CUSTOM_MESSAGE), 
                expected: CUSTOM_MESSAGE);
        }
    }
}
