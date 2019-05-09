using Unit = NUnit.Framework;
using System;
using NUnit.Framework;
using Suckless.Asserts.Tests.Base;

namespace Suckless.Asserts.Tests.ExtensionMethods
{
    internal class NegativeTest : AssertBaseTest
    {
        [Test]
        public void Negative_WhenNumberIsNegative_DoNotThrowException()
        {
            var valueStub = -1;

            Metadata((short)valueStub).Negative();
            Metadata((int)valueStub).Negative();
            Metadata((long)valueStub).Negative();
            Metadata((decimal)valueStub).Negative();
            Metadata((float)valueStub).Negative();
            Metadata((double)valueStub).Negative();
        }

        [Test]
        public void Negative_WhenNumberIsNotNegative_ThrowsException()
        {
            var valueStub = 1;

            Unit.Assert.Throws<ArgumentException>(() => Metadata((short)valueStub).Negative());
            Unit.Assert.Throws<ArgumentException>(() => Metadata((int)valueStub).Negative());
            Unit.Assert.Throws<ArgumentException>(() => Metadata((long)valueStub).Negative());
            Unit.Assert.Throws<ArgumentException>(() => Metadata((decimal)valueStub).Negative());
            Unit.Assert.Throws<ArgumentException>(() => Metadata((float)valueStub).Negative());
            Unit.Assert.Throws<ArgumentException>(() => Metadata((double)valueStub).Negative());
        }

        [Test]
        public void Negative_WhenAssertionFailedAdnCustomMessageWasSpecyfied_ThrowsExceptionWithCorrectMessage()
        {
            var valueStub = 1;
            var expectedMessageStub = "Any message";

            AssertExceptionMessage(() => Metadata((short)valueStub).Negative(expectedMessageStub), expectedMessageStub);
            AssertExceptionMessage(() => Metadata((int)valueStub).Negative(expectedMessageStub), expectedMessageStub);
            AssertExceptionMessage(() => Metadata((long)valueStub).Negative(expectedMessageStub), expectedMessageStub);
            AssertExceptionMessage(() => Metadata((decimal)valueStub).Negative(expectedMessageStub), expectedMessageStub);
            AssertExceptionMessage(() => Metadata((float)valueStub).Negative(expectedMessageStub), expectedMessageStub);
            AssertExceptionMessage(() => Metadata((double)valueStub).Negative(expectedMessageStub), expectedMessageStub);
        }

        public void AssertExceptionMessage(TestDelegate code, string expectedMessageStub)
        {
            var actualMessage = Unit.Assert .Throws<ArgumentException>(code) .Message;
            Unit.Assert.AreEqual(expectedMessageStub, actualMessage);
        }
    }
}
