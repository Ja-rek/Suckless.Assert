using System;
using NUnit.Framework;
using Suckless.Asserts.Tests.Base;

namespace Suckless.Asserts.Tests.ExtensionMethods
{
    internal partial class EmptyTest : AssertBaseTest<ArgumentOutOfRangeException> 
    {
        [Test]
        public void Empty_WhenStringIsNull_DoesNotThrowException()
        {
            StubMetadata<string>(null).Empty();
        }

        [Test]
        public void Empty_WhenStringIsEmpty_DoesNotThrowException()
        {
            StubMetadata("").Empty();
        }

        [TestCase(null), TestCase("AnyName")]
        public void Empty_WhenStringIsNotEmpty_ThrowsExceptionWithCorrectMessage(string fieldName)
        {
            var expectedMessagePart = "must be empty.";

            AssertExceptionMessage<string>(() => StubMetadata("Any", fieldName).Empty(), 
                expectedName: fieldName, 
                expectedMessagePart);
        }

        [TestCase(null), TestCase("AnyName")]
        public void Empty_WhenAssertionFailedAdnCustomMessageWasSpecyfied_ThrowsExceptionWithCorrectMessage(string fieldName)
        {
            AssertCustomExceptionMessage(() => StubMetadata("Any", fieldName).Empty(CUSTOM_MESSAGE), 
                expected: CUSTOM_MESSAGE);
        }
    }
}
