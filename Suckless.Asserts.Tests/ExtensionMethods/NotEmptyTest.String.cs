using Unit = NUnit.Framework;
using System;
using NUnit.Framework;
using Suckless.Asserts.Tests.Base;

namespace Suckless.Asserts.Tests.ExtensionMethods
{
    internal partial class AssertNotEmptyTest : AssertBaseTest<ArgumentOutOfRangeException> 
    {
        [Test]
        public void NotEmpty_WhenAllowNullAndStringIsNull_DoNotThrowException()
        {
            string valueStub = null;

            Metadata(valueStub).NotEmpty();
        }

        [Test]
        public void NotEmpty_WhenStringIsNotEmpty_DoNotThrowException()
        {
            var valueStub = "Any";

            Metadata(valueStub).NotEmpty();
        }

        [Test]
        public void NotEmpty_WhenStringIsEmpty_ThrowsException()
        {
            var valueStub = "";
            var messagePart = "cannot be empty.";

            AssertExceptionMessage(m => m.NotEmpty(), valueStub, messagePart);
        }

        [Test]
        public void NotEmpty_WhenStringIsEmptyAndSpecifiedCustomeMessage_ThrowsExceptionWithCorrectMessage()
        {
            var valueStub = "";
            var customeMessageStub = "Any message";

            AssertCustomExceptionMessage(m => m.NotEmpty(customeMessageStub), 
                valueStub, 
                customeMessageStub);
        }
    }
}
