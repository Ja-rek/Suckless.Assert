using Unit = NUnit.Framework;
using static Suckless.Asserts.Assertions;
using System;

namespace Suckless.Asserts.Tests.AssertNotEmptyTests
{
    internal partial class AssertNotEmptyTest
    {
        [Unit.Test]
        public void NotEmpty_WhenAllowNullAndArrayIsNull_DoNotThrowException()
        {
            int[] valueStub = null;

            AllowNull.Assert(valueStub).NotEmpty();
        }

        [Unit.Test]
        public void NotEmpty_WhenArrayIsNotEmpty_DoNotThrowException()
        {
            var valueStub = new int[] { 1 };

            Assert(valueStub).NotEmpty();
        }

        [Unit.Test]
        public void NotEmpty_WhenArrayIsEmpty_ThrowsException()
        {
            var valueStub = new int[] {};

            Unit.Assert.Throws<ArgumentOutOfRangeException>(() => Assert(valueStub).NotEmpty());
        }

        [Unit.Test]
        public void NotEmpty_WhenArrayIsEmptyAndSpecifiedCustomeMessage_ThrowsExceptionWithCorrectMessage()
        {
            var valueStub = new int[] {};
            var expectedMessageStub = "Any message";

            var actualMessage = Unit.Assert
                .Throws<ArgumentOutOfRangeException>(() => Assert(valueStub).NotEmpty(expectedMessageStub))
                .Message;

            Unit.Assert.AreEqual(expectedMessageStub, actualMessage);
        }
    }
}
