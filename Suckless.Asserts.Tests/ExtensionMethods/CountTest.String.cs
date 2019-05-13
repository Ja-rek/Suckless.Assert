using System;
using System.Linq;
using NUnit.Framework;
using Suckless.Asserts.Tests.Base;

namespace Suckless.Asserts.Tests.ExtensionMethods
{
    internal partial class CountTest : AssertBaseTest<ArgumentOutOfRangeException> 
    {
        [Test]
        public void Count_WhenAllowNullAndStringIsNull_DoNotThrowException()
        {
            string valueStub = null;

            Metadata(valueStub).Count(1);
        }

        [Test]
        public void Count_WhenCountIsExactAsExpedtedNumber_DoNotThrowException()
        {
            string valueStub = "123";

            Metadata(valueStub).Count(3);
        }

        [Test]
        public void Count_WhenCountIsBetweenExpectedCharacters_DoNotThrowException()
        {
            string valueStub = "12345";

            Metadata(valueStub).Count(1, 5);
        }

        [Test]
        public void Count_WhenCountIsNotAsExpecptedNumber_ThrowsExceptionWithCorrectMessage()
        {
            string valueStub = "123";
            var messagePart = "contains 3 character/s but should contain exact 5.";

            AssertExceptionMessage(m => m.Count(5), valueStub, messagePart);
        }

        [Test]
        [TestCase("123456")]
        [TestCase("12")]
        public void Count_WhenCountIsNotBetweenExpectedCharacters_ThrowsException(string valueStub)
        {
            var messagePart = $"contains {valueStub.Count()} character/s but should contain between 3 - 4.";

            AssertExceptionMessage(m => m.Count(3, 4), valueStub, messagePart);
        }

        [Test]
        public void CountCharacters_WhenAssertionFailedAdnCustomMessageWasSpecyfied_ThrowsExceptionWithCorrectMessage()
        {
            string valueStub = "12";
            var customMessageStub = "Any message";

            AssertCustomExceptionMessage(m => m.Count(3, 5, customMessageStub), 
                valueStub, 
                customMessageStub);
        }
    }
}
