using System;
using NUnit.Framework;
using Suckless.Asserts.Tests.Base;

namespace Suckless.Asserts.Tests.ExtensionMethods
{
    internal partial class DefaultTest : AssertBaseTest<ArgumentException> 
    {
        [Test]
        public void Default_WhenValueIsDefaultExpectedValue_DoesNotThrowException()
        {
            StubMetadata<string>(default).Default();
        }

        [TestCase(null), TestCase("AnyName")]
        public void Default_WhenValueIsNotDefaultExpectedValue_ThrowsExceptionWithCorrectMessage(string fieldName)
        {
            var messagePart = "that contain 1 must be default.";

            AssertExceptionMessage<int>(() => StubMetadata(1, fieldName).Default(), 
                expecteddName: fieldName,
                messagePart);
        }

        [TestCase(null), TestCase("AnyName")]
        public void Default_WhenValueIsNotDefaultExpectedValueAdnCustomMessageWasSpecyfied_ThrowsExceptionWithCorrectMessage(string fieldName)
        {
            AssertCustomExceptionMessage(() => StubMetadata(1, fieldName).Default(CUSTOM_MESSAGE), 
                expected: CUSTOM_MESSAGE);
        }
    }
}
