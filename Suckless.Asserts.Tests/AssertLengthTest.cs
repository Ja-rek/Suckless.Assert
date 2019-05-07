using Unit = NUnit.Framework;
using static Suckless.Asserts.Assertions;
using System;

namespace Suckless.Asserts.Tests
{
    internal class AssertLengthTest
    {
        [Unit.Test]
        public void Length_WhenLengthIsExact5_DoNotThrowException()
        {
            string valueStub = "123";

            Assert(valueStub).Length(3);
        }

        [Unit.Test]
        public void Length_WhenLengthIsBetween1And5_DoNotThrowException()
        {
            string valueStub = "12345";

            Assert(valueStub).Length(1, 5);
        }

        [Unit.Test]
        public void Length_WhenLengthIsNot5_ThrowsException()
        {
            string valueStub = "123";

            Unit.Assert.Throws<ArgumentOutOfRangeException>(() => Assert(valueStub).Length(5));
        }

        [Unit.Test]
        public void Length_WhenLengthIsNotBetween3And6_ThrowsException()
        {
            string valueStub = "12345";

            Unit.Assert.Throws<ArgumentOutOfRangeException>(() => Assert(valueStub).Length(3, 7));
        }

        [Unit.Test]
        public void Length_WhenLengthIsNotBetween3And5_ThrowsException()
        {
            string valueStub = "12";

            Unit.Assert.Throws<ArgumentOutOfRangeException>(() => Assert(valueStub).Length(3, 5));
        }
    }
}
