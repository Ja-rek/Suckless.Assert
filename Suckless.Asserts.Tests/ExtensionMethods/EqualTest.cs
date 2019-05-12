using System;
using NUnit.Framework;
using Suckless.Asserts.Tests.Base;

namespace Suckless.Asserts.Tests.ExtensionMethods
{
    internal partial class EqualTest : AssertBaseTest<ArgumentException> 
    {
        [Test]
        public void Equal_WhenValuesIsNull_DoNotThrowException()
        {
            string valueStub = null;

            Metadata(valueStub).Equal(1);
        }

        [Test]
        public void Equal_WhenValueIsEqualToExpectedValue_DoNotThrowException()
        {
            var valueStub = 1;

            Metadata(valueStub).Equal(1);
        }

        [Test]
        public void Equal_WhenValueIsNotEqualToExpectedValue_ThrowsException()
        {
            var valueStub = 1;
            var messagePart = "that contain 1 should be equal to 2.";

            AssertExceptionMessage(m => m.Equal(2), valueStub, messagePart);
        }

        [Test]
        public void Equal_WhenValueIsNotEqualToExpectedValueAdnCustomMessageWasSpecyfied_ThrowsExceptionWithCorrectMessage()
        {
            var valueStub = 1;

            var customeMessageStub = "Any message";

            AssertCustomExceptionMessage(m => m.Equal(2, customeMessageStub), 
                valueStub, 
                customeMessageStub);
        }
    }
}
