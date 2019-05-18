using System;
using NUnit.Framework;
using Suckless.Asserts.Tests.Base;

namespace Suckless.Asserts.Tests.ExtensionMethods
{
    internal partial class NotEqualToTest : AssertBaseTest<ArgumentException> 
    {
        [Test]
        public void NotEqualTo_WhenValuesIsNull_DoesNotThrowException()
        {
            StubMetadata<string>(null).NotEqualTo(1);
        }

        [Test]
        public void NotEqualTo_WhenValueIsEqualToExpectedValue_DoesNotThrowException()
        {
            StubMetadata(1).NotEqualTo(2);
        }

        [TestCase(null), TestCase("AnyName")]
        public void NotEqualTo_WhenValueIsNotEqualToExpectedValue_ThrowsExceptionWithCorrectMessage(string fieldName)
        {
            var messagePart = "that contain 1 cannot be equal to 1.";

            AssertExceptionMessage<int>(() => StubMetadata(1, fieldName).NotEqualTo(1), 
                expectedName: fieldName,
                messagePart);
        }

        [TestCase(null), TestCase("AnyName")]
        public void NotEqualTo_WhenValueIsNotEqualToExpectedValueAdnCustomMessageWasSpecyfied_ThrowsExceptionWithCorrectMessage(string fieldName)
        {
            AssertCustomExceptionMessage(() => StubMetadata(1, fieldName).NotEqualTo(1, CUSTOM_MESSAGE), 
                expected: CUSTOM_MESSAGE);
        }
    }
}
