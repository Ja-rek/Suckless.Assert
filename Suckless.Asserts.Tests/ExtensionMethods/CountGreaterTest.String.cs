using System;
using NUnit.Framework;
using Suckless.Asserts.Tests.Base;

namespace Suckless.Asserts.Tests.ExtensionMethods
{
    internal partial class CountGreaterTest : AssertBaseTest<ArgumentOutOfRangeException> 
    {
        [Test]
        public void CountGreater_WhenStringIsGreaterThan1_DoesNotThrowException()
        {
            StubMetadata("12").CountGreater(1);
        }

        [TestCase(null), TestCase("AnyName")]
        public void CountGreater_WhenStringIsNotGreaterThanExpectedCount_ThrowsExceptionWithCorrectMessage(string fieldName)
        {
            var expectedMessagePart = "contains 1 character/s but should contain more than 2.";

            AssertExceptionMessage<string>(() => StubMetadata("1", fieldName).CountGreater(2), 
                expectedName: fieldName, 
                expectedMessagePart);
        }

        [TestCase(null), TestCase("AnyName")]
        public void CountGreater_WhenStringIsNotGreaterThan2AdnCustomMessageWasSpecyfied_ThrowsExceptionWithCorrectMessage(string fieldName)
        {
            AssertCustomExceptionMessage(() => StubMetadata("1", fieldName).CountGreater(2, CUSTOM_MESSAGE), 
                expected: CUSTOM_MESSAGE);
        }
    }
}
