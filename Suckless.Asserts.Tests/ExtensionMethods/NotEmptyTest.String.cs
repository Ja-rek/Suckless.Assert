using Unit = NUnit.Framework;
using System;
using NUnit.Framework;
using Suckless.Asserts.Tests.Base;

namespace Suckless.Asserts.Tests.ExtensionMethods
{
    internal partial class AssertNotEmptyTest : AssertBaseTest
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

            Unit.Assert.Throws<ArgumentOutOfRangeException>(() => Metadata(valueStub).NotEmpty());
        }

        [Test]
        public void NotEmpty_WhenStringIsEmptyAndSpecifiedCustomeMessage_ThrowsExceptionWithCorrectMessage()
        {
            var valueStub = "";
            var expectedMessageStub = "Any message";

            var actualMessage = Unit.Assert
                .Throws<ArgumentOutOfRangeException>(() => Metadata(valueStub).NotEmpty(expectedMessageStub))
                .Message;

            Unit.Assert.AreEqual(expectedMessageStub, actualMessage);
        }
    }
}
