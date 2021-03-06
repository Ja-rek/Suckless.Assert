using System;
using NUnit.Framework;
using Suckless.Asserts.Tests.Base;

namespace Suckless.Asserts.Tests.ExtensionMethods
{
    internal partial class NotEmptyTest : AssertBaseTest<ArgumentOutOfRangeException> 
    {
        [Test]
        public void NotEmpty_WhenAllowNullAndStringIsNull_DoesNotThrowException()
        {
            StubMetadata<string>(null).NotEmpty();
        }

        [Test]
        public void NotEmpty_WhenStringIsNotEmpty_DoesNotThrowException()
        {
            StubMetadata("Any").NotEmpty();
        }

        [TestCase(null), TestCase("AnyName")]
        public void NotEmpty_WhenStringIsEmpty_ThrowsException(string fieldName)
        {
            var expectedMessagePart = "cannot be empty.";

            AssertExceptionMessage<string>(() => StubMetadata("", fieldName).NotEmpty(), 
                expectedName: fieldName, 
                expectedMessagePart);
        }

        [TestCase(null), TestCase("AnyName")]
        public void NotEmpty_WhenStringIsEmptyAndSpecifiedCustomeMessage_ThrowsExceptionWithCorrectMessage(string fieldName)
        {
            var customeMessage = "Any message";

            AssertCustomExceptionMessage(() => StubMetadata("", fieldName).NotEmpty(customeMessage), 
                expected: customeMessage);
        }
    }
}
