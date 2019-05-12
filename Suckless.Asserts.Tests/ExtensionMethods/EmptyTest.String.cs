using System;
using NUnit.Framework;
using Suckless.Asserts.Tests.Base;

namespace Suckless.Asserts.Tests.ExtensionMethods
{
    internal partial class EmptyTest : AssertBaseTest<ArgumentOutOfRangeException> 
    {
        [Test]
        public void Empty_WhenStringIsNull_DoNotThrowException()
        {
            string valueStub = null;

            Metadata(valueStub).Empty();
        }

        [Test]
        public void Empty_WhenStringIsEmpty_DoNotThrowException()
        {
            var valueStub = "";

            Metadata(valueStub).Empty();
        }

        [Test]
        public void Empty_WhenStringIsNotEmpty_ThrowsException()
        {
            var valueStub = "Any";
            var messagePart = "must be empty.";

            AssertExceptionMessage(m => m.Empty(), valueStub, messagePart);
        }

        [Test]
        public void Empty_WhenAssertionFailedAdnCustomMessageWasSpecyfied_ThrowsExceptionWithCorrectMessage()
        {
            var valueStub = "Any";
            var customeMessageStub = "Any message";

            AssertCustomExceptionMessage(m => m.Empty(customeMessageStub), 
                valueStub, 
                customeMessageStub);
        }
    }
}
