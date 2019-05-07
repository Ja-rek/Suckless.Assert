using Unit = NUnit.Framework;
using static Suckless.Asserts.Assertions;
using System;

namespace Suckless.Asserts.Tests.AssertEmptyTests
{
    internal partial class AssertEmptyTest
    {
        [Unit.Test]
        public void Empty_WhenAllowNullAndArrayIsNull_DoNotThrowException()
        {
            int[] valueStub = null;

            AllowNull.Assert(valueStub).Empty();
        }

        [Unit.Test]
        public void Empty_WhenArrayIsEmpty_DoNotThrowException()
        {
            var valueStub = new int[] {};

            Assert(valueStub).Empty();
        }

        [Unit.Test]
        public void Empty_WhenArrayIsNotEmpty_ThrowsException()
        {
            var valueStub = new int[] { 1 };

            Unit.Assert.Throws<ArgumentOutOfRangeException>(() => Assert(valueStub).Empty());
        }

        [Unit.Test]
        public void Empty_WhenArrayIsNotEmptyAndSpecifiedCustomeMessage_ThrowsExceptionWithCorrectMessage()
        {
            var valueStub = new int[] { 1 };
            var expectedMessageStub = "Any message";

            var actualMessage = Unit.Assert
                .Throws<ArgumentOutOfRangeException>(() => Assert(valueStub).Empty(expectedMessageStub))
                .Message;

            Unit.Assert.AreEqual(expectedMessageStub, actualMessage);
        }
    }
}
