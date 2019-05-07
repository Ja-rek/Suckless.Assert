using Unit = NUnit.Framework;
using static Suckless.Asserts.Assertions;
using System;

namespace Suckless.Asserts.Tests.AssertEmptyTests
{
    internal partial class AssertEmptyTest
    {
        [Unit.Test]
        public void Empty_WhenStringIsEmpty_DoNotThrowException()
        {
            var valueStub = "";

            Assert(valueStub).Empty();
        }

        [Unit.Test]
        public void Empty_WhenStringIsNotEmpty_ThrowsException()
        {
            var valueStub = "Any";

            Unit.Assert.Throws<ArgumentOutOfRangeException>(() => Assert(valueStub).Empty());
        }

        [Unit.Test]
        public void Empty_WhenStringIsNotEmptyAndSpecifiedCustomeMessage_ThrowsExceptionWithCorrectMessage()
        {
            var valueStub = "Any";
            var expectedMessageStub = "Any message";

            var actualMessage = Unit.Assert
                .Throws<ArgumentOutOfRangeException>(() => Assert(valueStub).Empty(expectedMessageStub))
                .Message;

            Unit.Assert.AreEqual(expectedMessageStub, actualMessage);
        }
    }
}
