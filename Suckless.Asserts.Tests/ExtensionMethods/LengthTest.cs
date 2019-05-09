using Unit = NUnit.Framework;
using System;
using NUnit.Framework;
using Suckless.Asserts.Tests.Base;

namespace Suckless.Asserts.Tests.ExtensionMethods
{
    internal class LengthTest : AssertBaseTest
    {
        [Test]
        public void Length_WhenAllowNullAndStringIsNull_DoNotThrowException()
        {
            string valueStub = null;

            Metadata(valueStub).Length(1);
        }

        [Test]
        public void Length_WhenLengthIsExact5_DoNotThrowException()
        {
            string valueStub = "123";

            Metadata(valueStub).Length(3);
        }

        [Test]
        public void Length_WhenLengthIsBetween1And5_DoNotThrowException()
        {
            string valueStub = "12345";

            Metadata(valueStub).Length(1, 5);
        }

        [Test]
        public void Length_WhenLengthIsNot5_ThrowsException()
        {
            string valueStub = "123";

            Unit.Assert.Throws<ArgumentOutOfRangeException>(() => Metadata(valueStub).Length(5));
        }

        [Test]
        public void Length_WhenLengthIsNotBetween3And6_ThrowsException()
        {
            string valueStub = "12345";

            Unit.Assert.Throws<ArgumentOutOfRangeException>(() => Metadata(valueStub).Length(3, 4));
        }

        [Test]
        public void Length_WhenLengthIsNotBetween3And5_ThrowsException()
        {
            string valueStub = "12";

            Unit.Assert.Throws<ArgumentOutOfRangeException>(() => Metadata(valueStub).Length(3, 5));
        }

        [Test]
        public void Length_WhenAssertionFailedAdnCustomMessageWasSpecyfied_ThrowsExceptionWithCorrectMessage()
        {
            string valueStub = "12";
            var expectedMessageStub = "Any message";

            var actualMessage = Unit.Assert
                .Throws<ArgumentOutOfRangeException>(() => Metadata(valueStub).Length(3, 5, expectedMessageStub))
                .Message;
            Unit.Assert.AreEqual(expectedMessageStub, actualMessage);
        }
    }
}
