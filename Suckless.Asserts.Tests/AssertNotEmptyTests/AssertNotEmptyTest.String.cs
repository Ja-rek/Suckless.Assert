using Unit = NUnit.Framework;
using static Suckless.Asserts.Assertions;
using System;

namespace Suckless.Asserts.Tests.AssertNotEmptyTests
{
    internal partial class AssertNotEmptyTest
    {
        [Unit.Test]
        public void NotEmpty_WhenStringIsNotEmpty_DoNotThrowException()
        {
            var valueStub = "Any";

            Assert(valueStub).NotEmpty();
        }

        [Unit.Test]
        public void NotEmpty_WhenStringIsEmpty_ThrowsException()
        {
            var valueStub = "";

            Unit.Assert.Throws<ArgumentOutOfRangeException>(() => Assert(valueStub).NotEmpty());
        }

        [Unit.Test]
        public void NotEmpty_WhenStringIsEmptyAndSpecifiedCustomeMessage_ThrowsExceptionWithCorrectMessage()
        {
            var valueStub = "";
            var expectedMessageStub = "Any message";

            var actualMessage = Unit.Assert
                .Throws<ArgumentOutOfRangeException>(() => Assert(valueStub).NotEmpty(expectedMessageStub))
                .Message;

            Unit.Assert.AreEqual(expectedMessageStub, actualMessage);
        }
    }
}
