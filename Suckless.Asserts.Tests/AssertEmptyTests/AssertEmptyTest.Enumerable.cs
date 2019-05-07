using Unit = NUnit.Framework;
using static Suckless.Asserts.Assertions;
using System;
using System.Linq;

namespace Suckless.Asserts.Tests.AssertEmptyTests
{
    internal partial class AssertEmptyTest
    {
        [Unit.Test]
        public void Empty_WhenEnumerableIsEmpty_DoNotThrowException()
        {
            var valueStub = Enumerable.Empty<int>();

            Assert(valueStub).Empty();
        }

        [Unit.Test]
        public void Empty_WhenEnumerableIsNotEmpty_ThrowsException()
        {
            var valueStub = Enumerable.Range(1, 2);

            Unit.Assert.Throws<ArgumentOutOfRangeException>(() => Assert(valueStub).Empty());
        }

        [Unit.Test]
        public void Empty_WhenEnumerableIsNotEmptyAndSpecifieCustomeMessage_ThrowsExceptionWithCorrectMessage()
        {
            var valueStub = Enumerable.Range(1, 2);
            var expectedMessageStub = "Any message";

            var actualMessage = Unit.Assert
                .Throws<ArgumentOutOfRangeException>(() => Assert(valueStub).Empty(expectedMessageStub))
                .Message;

            Unit.Assert.AreEqual(expectedMessageStub, actualMessage);
        }
    }
}
