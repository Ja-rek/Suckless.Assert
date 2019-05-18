using System;
using NUnit.Framework;
using Suckless.Asserts.Tests.Base;

namespace Suckless.Asserts.Tests.ExtensionMethods
{
    internal class TrueTest : AssertBaseTest<ArgumentException> 
    {
        [Test]
        public void True_WhenValueIsEqualToExpectedValue_DoesNotThrowException()
        {
            StubMetadata(true).True();
        }

        [Test, TestCase(null), TestCase("AnyName")]
        public void True_WhenValueIsNotEqualToExpectedValue_ThrowsExceptionWithCorrectMessage(string fieldName)
        {
            var expectedMessagePart = "must be true.";

            AssertExceptionMessage<bool>(() => StubMetadata(false, fieldName).True(), 
                expectedName: fieldName,
                expectedMessagePart);
        }

        [TestCase(null), TestCase("AnyName")]
        public void True_WhenValueIsNotEqualToExpectedValueAdnCustomMessageWasSpecyfied_ThrowsExceptionWithCorrectMessage(string fieldName)
        {
            AssertCustomExceptionMessage(() => StubMetadata(false, fieldName).True(CUSTOM_MESSAGE), 
                expected: CUSTOM_MESSAGE);
        }
    }
}
