using System;
using NUnit.Framework;
using Suckless.Asserts.Tests.Base;

namespace Suckless.Asserts.Tests.ExtensionMethods
{
    internal partial class NotDefaultTest : AssertBaseTest<ArgumentException> 
    {
        [Test]
        public void NotDefault_WhenValueIsNotDefaultExpectedValue_DoesNotThrowException()
        {
            StubMetadata<int>(1).NotDefault();
        }

        [TestCase(null), TestCase("AnyName")]
        public void NotDefault_WhenValueIsNotNotDefaultExpectedValue_ThrowsExceptionWithCorrectMessage(string fieldName)
        {
            var messagePart = "that contain 0 cannot be default.";

            AssertExceptionMessage<int>(() => StubMetadata<int>(default, fieldName).NotDefault(), 
                expectedName: fieldName,
                messagePart);
        }

        [TestCase(null), TestCase("AnyName")]
        public void NotDefault_WhenValueIsNotNotDefaultExpectedValueAdnCustomMessageWasSpecyfied_ThrowsExceptionWithCorrectMessage(string fieldName)
        {
            AssertCustomExceptionMessage(() => StubMetadata<int>(default, fieldName).NotDefault(CUSTOM_MESSAGE), 
                expected: CUSTOM_MESSAGE);
        }
    }
}
