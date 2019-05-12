using System;
using NUnit.Framework;
using Suckless.Asserts.Tests.Base;

namespace Suckless.Asserts.Tests.ExtensionMethods
{
    internal partial class CountLessTest : AssertBaseTest<ArgumentOutOfRangeException> 
    {
        [Test]
        public void CountLess_WhenStringIsLessExpectedNumber_DoNotThrowException()
        {
            var valueStub = "12";

            Metadata(valueStub).CountLess(3);
        }

        [Test]
        public void CountLess_WhenStringIsNotLessExpectedNumber_ThrowsException()
        {
            var valueStub = "123";
            var messagePart = "contains 3 character/s but should contain less than 2.";

            AssertExceptionMessage(m => m.CountLess(2), valueStub, messagePart);
        }

        [Test]
        public void CountLess_WhenStringIsNotLessExpectedNumberAdnCustomMessageWasSpecyfied_ThrowsExceptionWithCorrectMessage()
        {
            var valueStub = "123";

            var customeMessageStub = "Any message";

            AssertCustomExceptionMessage(m => m.CountLess(2, customeMessageStub), 
                valueStub, 
                customeMessageStub);
        }
    }
}
