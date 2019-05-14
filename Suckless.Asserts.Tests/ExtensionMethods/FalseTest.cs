using System;
using NUnit.Framework;
using Suckless.Asserts.Tests.Base;

namespace Suckless.Asserts.Tests.ExtensionMethods
{
    internal class FalseTest : AssertBaseTest<ArgumentException> 
    {
        [Test]
        public void False_WhenValueIsEqualToExpectedValue_DoNotThrowException()
        {
            var valueStub = false;

            Metadata(valueStub).False();
        }

        [Test]
        public void False_WhenValueIsNotEqualToExpectedValue_ThrowsExceptionWithCorrectMessage()
        {
            var valueStub = true;
            var messagePart = "must be false.";

            AssertExceptionMessage(m => m.False(), valueStub, messagePart);
        }

        [Test]
        public void False_WhenValueIsNotEqualToExpectedValueAdnCustomMessageWasSpecyfied_ThrowsExceptionWithCorrectMessage()
        {
            var valueStub = true;
            var customeMessageStub = "Any message";

            AssertCustomExceptionMessage(m => m.False(customeMessageStub), 
                valueStub, 
                customeMessageStub);
        }
    }
}
