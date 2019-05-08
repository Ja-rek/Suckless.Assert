using Unit = NUnit.Framework;
using System;
using NUnit.Framework;
using Suckless.Asserts.Tests.Base;

namespace Suckless.Asserts.Tests.ExtensionMethods
{
    internal partial class EmptyTest : AssertBaseTest
    {
        [Test]
        public void Empty_WhenStringIsNull_DoNotThrowException()
        {
            string valueStub = null;

            Metadata(valueStub).Empty();
        }

        [Test]
        public void Empty_WhenStringIsEmpty_DoNotThrowException()
        {
            var valueStub = "";

            Metadata(valueStub).Empty();
        }

        [Test]
        public void Empty_WhenStringIsNotEmpty_ThrowsException()
        {
            var valueStub = "Any";

            Unit.Assert.Throws<ArgumentOutOfRangeException>(() => Metadata(valueStub).Empty());
        }

        [Test]
        public void Empty_WhenAssertionFailedAdnCustomMessageWasSpecyfied_ThrowsExceptionWithCorrectMessage()
        {
            var valueStub = "Any";
            var expectedMessageStub = "Any message";

            var actualMessage = Unit.Assert
                .Throws<ArgumentOutOfRangeException>(() => Metadata(valueStub).Empty(expectedMessageStub))
                .Message;

            Unit.Assert.AreEqual(expectedMessageStub, actualMessage);
        }
    }
}
