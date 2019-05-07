using Unit = NUnit.Framework;
using static Suckless.Asserts.Assertions;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Suckless.Asserts.Tests.AssertNotEmptyTests
{
    internal partial class AssertNotEmptyTest
    {
        [Unit.Test]
        public void NotEmpty_WhenAllowNullAndEnumerableIsNull_DoNotThrowException()
        {
            IEnumerable<int> valueStub = null;

            AllowNull.Assert(valueStub).NotEmpty();
        }

        [Unit.Test]
        public void NotEmpty_WhenEnumerableIsNotEmpty_DoNotThrowException()
        {
            var valueStub = Enumerable.Range(1, 2);

            Assert(valueStub).NotEmpty();
        }

        [Unit.Test]
        public void NotEmpty_WhenEnumerableIsEmpty_ThrowsException()
        {
            var valueStub = Enumerable.Empty<int>();

            Unit.Assert.Throws<ArgumentOutOfRangeException>(() => Assert(valueStub).NotEmpty());
        }

        [Unit.Test]
        public void NotEmpty_WhenEnumerableIsEmptyAndSpecifiedCustomeMessage_ThrowsExceptionWithCorrectMessage()
        {
            var valueStub = Enumerable.Empty<int>();
            var expectedMessageStub = "Any message";

            var actualMessage = Unit.Assert
                .Throws<ArgumentOutOfRangeException>(() => Assert(valueStub).NotEmpty(expectedMessageStub))
                .Message;

            Unit.Assert.AreEqual(expectedMessageStub, actualMessage);
        }
    }
}
