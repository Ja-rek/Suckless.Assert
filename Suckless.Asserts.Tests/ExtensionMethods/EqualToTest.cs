using System;
using NUnit.Framework;
using Suckless.Asserts.Tests.Base;

namespace Suckless.Asserts.Tests.ExtensionMethods
{
    internal partial class EqualToTest : AssertBaseTest<ArgumentException> 
    {
        [Test]
        public void EqualTo_WhenValuesIsNull_DoNotThrowException()
        {
            StubMetadata<string>(null).EqualTo(1);
        }

        [Test]
        public void EqualTo_WhenValueIsEqualToExpectedValue_DoNotThrowException()
        {
            StubMetadata(1).EqualTo(1);
        }

        [Test, TestCase(null), TestCase("AnyName")]
        public void EqualTo_WhenValueIsNotEqualToExpectedValue_ThrowsExceptionWithCorrectMessage(string fieldName)
        {
            var messagePart = "that contain 1 should be equal to 2.";

            AssertExceptionMessage<int>(() => StubMetadata(1, fieldName).EqualTo(2), 
                expecteddName: fieldName,
                messagePart);
        }

        [Test, TestCase(null), TestCase("AnyName")]
        public void EqualTo_WhenValueIsNotEqualToExpectedValueAdnCustomMessageWasSpecyfied_ThrowsExceptionWithCorrectMessage(string fieldName)
        {
            AssertCustomExceptionMessage(() => StubMetadata(1, fieldName).EqualTo(2, CUSTOM_MESSAGE), 
                expected: CUSTOM_MESSAGE);
        }
    }
}
