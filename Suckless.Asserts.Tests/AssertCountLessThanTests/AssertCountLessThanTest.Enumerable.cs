using Unit = NUnit.Framework;
using static Suckless.Asserts.Assertions;
using System;
using System.Linq;

namespace Suckless.Asserts.Tests.AssertCountLessThanTests
{
    internal partial class AssertCountLessThanTest 
    {
        [Unit.Test]
        public void CountLessThan_WhenCountOfEnumerableIsLessThan6_DoNotThrowException()
        {
            var valueStub = Enumerable.Range(1, 5);

            Assert(valueStub).CountLessThan(6);
        }

        [Unit.Test]
        public void CountLessThan_WhenCountOfEnumerableIsNotLessThan3_ThrowsException()
        {
            var valueStub = Enumerable.Range(1, 5);

            Unit.Assert.Throws<ArgumentOutOfRangeException>(() => Assert(valueStub).CountLessThan(3));
        }

        [Unit.Test]
        public void CountLessThan_WhenCountOfEnumerableIsNotLessThan3AndSpecyfiedCustomeMessage_ThrowsExceptionWithCorrectMessage()
        {
            var valueStub = Enumerable.Range(1, 5);
            var expectedMessageStub = "Any message";

            var actualMessage = Unit.Assert
                .Throws<ArgumentOutOfRangeException>(() => Assert(valueStub).CountLessThan(3, expectedMessageStub))
                .Message;

            Unit.Assert.AreEqual(expectedMessageStub, actualMessage);
        }
    }
}
