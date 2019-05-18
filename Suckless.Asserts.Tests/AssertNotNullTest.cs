using Unit = NUnit.Framework;
using static Suckless.Asserts.Assertions;
using System;
using NUnit.Framework;
using Suckless.Asserts.Tests.Base;

namespace Suckless.Asserts.Tests
{
    internal class AssertNotNullTest : AssertBaseTest<ArgumentNullException>
    {
        [Test]
        public void AssertNotNull_WhenValueIsEqualToExpectedValue_DoNotThrowException()
        {
            AssertNotNull("not null");
        }

        [Test, TestCase(null), TestCase("AnyName")]
        public void AssertNotNull_WhenValueIsNotEqualToExpectedValue_ThrowsExceptionWithCorrectMessage(string fieldName)
        {
            var expectedMessagePart = "cannot be null.";
            string value = null;

            AssertExceptionMessage<string>(() => AssertNotNull(value, fieldName), 
                expecteddName: fieldName,
                expectedMessagePart);
        }

        [TestCase(null), TestCase("AnyName")]
        public void AssertNotNull_WhenValueIsNotEqualToExpectedValueAdnCustomMessageWasSpecyfied_ThrowsExceptionWithCorrectMessage(string fieldName)
        {
            string value = null;

            AssertCustomExceptionMessage(() => AssertNotNull(value, message: CUSTOM_MESSAGE), 
                expected: CUSTOM_MESSAGE);
        }
    }
}
