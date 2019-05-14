using System;
using NUnit.Framework;
using Suckless.Asserts.Tests.Base;

namespace Suckless.Asserts.Tests.ExtensionMethods
{
    internal class TrueTest : AssertBaseTest<ArgumentException> 
    {
        [Test]
        public void True_WhenValueIsEqualToExpectedValue_DoNotThrowException()
        {
            var valueStub = true;

            Metadata(valueStub).True();
        }

        [Test]
        public void True_WhenValueIsNotEqualToExpectedValue_ThrowsExceptionWithCorrectMessage()
        {
            var valueStub = false;
            var messagePart = "must be true.";

            AssertExceptionMessage(m => m.True(), valueStub, messagePart);
        }

        [Test]
        public void True_WhenValueIsNotEqualToExpectedValueAdnCustomMessageWasSpecyfied_ThrowsExceptionWithCorrectMessage()
        {
            var valueStub = false;
            var customeMessageStub = "Any message";

            AssertCustomExceptionMessage(m => m.True(customeMessageStub), 
                valueStub, 
                customeMessageStub);
        }
    }
}
