using Unit = NUnit.Framework;
using static Suckless.Asserts.Assertions;
using System;

namespace Suckless.Asserts.Tests.AssertCountGreaterThanTests
{
    internal partial class AssertCountGreaterThanTest 
    {
        [Unit.Test]
        public void CountGreaterThan_WhenCountOfArrayIsGreaterThan3_DoNotThrowException()
        {
            var valueStub = new int[] { 1, 2 };

            Assert(valueStub).CountGreaterThan(1);
        }

        [Unit.Test]
        public void CountGreaterThan_WhenCountOfArrayIsNotGreaterThan2_ThrowsException()
        {
            var valueStub = new int[] { 1 };

            Unit.Assert.Throws<ArgumentOutOfRangeException>(() => Assert(valueStub).CountGreaterThan(2));
        }

        [Unit.Test]
        public void CountGreaterThan_WhenCountOfArrayIsNotGreaterThan2AndSpecyfiedCustomeMessage_ThrowsExceptionWithCorrectMessage()
        {
            var valueStub = new int[] { 1 };
            var expectedMessageStub = "Any message";

            var actualMessage = Unit.Assert
                .Throws<ArgumentOutOfRangeException>(() => Assert(valueStub).CountGreaterThan(2, expectedMessageStub))
                .Message;

            Unit.Assert.AreEqual(expectedMessageStub, actualMessage);
        }
    }
}
