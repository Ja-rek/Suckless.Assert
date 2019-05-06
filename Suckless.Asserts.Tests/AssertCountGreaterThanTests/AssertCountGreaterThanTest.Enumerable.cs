using Unit = NUnit.Framework;
using static Suckless.Asserts.Assertions;
using System;
using System.Linq;

namespace Suckless.Asserts.Tests.AssertCountGreaterThanTests
{
    internal partial class AssertCountGreaterThanTest 
    {
        [Unit.Test]
        public void CountGreaterThan_WhenCountOfEnumerableIsGreaterThan3_DoNotThrowException()
        {
            var valueStub = Enumerable.Range(1, 5);

            Assert(valueStub).CountGreaterThan(3);
        }

        [Unit.Test]
        public void CountGreaterThan_WhenCountOfEnumerableIsNotGreaterThan10_ThrowsException()
        {
            var valueStub = Enumerable.Range(1, 5);

            Unit.Assert.Throws<ArgumentOutOfRangeException>(() => Assert(valueStub).CountGreaterThan(10));
        }

        [Unit.Test]
        public void CountGreaterThan_WhenCountOfEnumerableIsNotGreaterThan10AndSpecyfiedCustomeMessage_ThrowsExceptionWithCorrectMessage()
        {
            var valueStub = Enumerable.Range(1, 5);
            var expectedMessageStub = "Any message";

            var actualMessage = Unit.Assert
                .Throws<ArgumentOutOfRangeException>(() => Assert(valueStub).CountGreaterThan(10, expectedMessageStub))
                .Message;

            Unit.Assert.AreEqual(expectedMessageStub, actualMessage);
        }
    }
}
