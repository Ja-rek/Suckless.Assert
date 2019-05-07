using Unit = NUnit.Framework;
using static Suckless.Asserts.Assertions;
using System;

namespace Suckless.Asserts.Tests.AssertCountLessThanTests
{
    internal partial class AssertCountLessThanTest 
    {
        [Unit.Test]
        public void CountLessThan_WhenCountOfArrayIsLessThan2_DoNotThrowException()
        {
            var valueStub = new int[] { 1 };

            Assert(valueStub).CountLessThan(2);
        }

        [Unit.Test]
        public void CountLessThan_WhenCountOfArrayIsNotLessThan1_ThrowsException()
        {
            var valueStub = new int[] { 1, 2 };

            Unit.Assert.Throws<ArgumentOutOfRangeException>(() => Assert(valueStub).CountLessThan(1));
        }

        [Unit.Test]
        public void CountLessThan_WhenCountOfArrayIsNotLessThan1AndSpecyfiedCustomeMessage_ThrowsExceptionWithCorrectMessage()
        {
            var valueStub = new int[] { 1, 2 };
            var expectedMessageStub = "Any message";

            var actualMessage = Unit.Assert
                .Throws<ArgumentOutOfRangeException>(() => Assert(valueStub).CountLessThan(1, expectedMessageStub))
                .Message;

            Unit.Assert.AreEqual(expectedMessageStub, actualMessage);
        }
    }
}
