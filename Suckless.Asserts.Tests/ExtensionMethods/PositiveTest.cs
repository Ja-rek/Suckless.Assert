using Unit = NUnit.Framework;
using System;
using NUnit.Framework;
using Suckless.Asserts.Tests.Base;

namespace Suckless.Asserts.Tests.ExtensionMethods
{
    internal class PositiveTest : AssertBaseTest
    {
        [Test]
        public void Positive_WhenNumberIsPositive_DoNotThrowException()
        {
            var valueStub = 1;

            Metadata((short)valueStub).Positive();
            Metadata((int)valueStub).Positive();
            Metadata((long)valueStub).Positive();
            Metadata((decimal)valueStub).Positive();
            Metadata((float)valueStub).Positive();
            Metadata((double)valueStub).Positive();
        }

        [Test]
        public void Positive_WhenNumberIsNotPositive_ThrowsException()
        {
            var valueStub = -1;

            Unit.Assert.Throws<ArgumentException>(() => Metadata((short)valueStub).Positive());
            Unit.Assert.Throws<ArgumentException>(() => Metadata((int)valueStub).Positive());
            Unit.Assert.Throws<ArgumentException>(() => Metadata((long)valueStub).Positive());
            Unit.Assert.Throws<ArgumentException>(() => Metadata((decimal)valueStub).Positive());
            Unit.Assert.Throws<ArgumentException>(() => Metadata((float)valueStub).Positive());
            Unit.Assert.Throws<ArgumentException>(() => Metadata((double)valueStub).Positive());
        }

        [Test]
        public void Positive_WhenAssertionFailedAdnCustomMessageWasSpecyfied_ThrowsExceptionWithCorrectMessage()
        {
            var valueStub = -1;
            var expectedMessageStub = "Any message";

            AssertExceptionMessage(() => Metadata((short)valueStub).Positive(expectedMessageStub), expectedMessageStub);
            AssertExceptionMessage(() => Metadata((int)valueStub).Positive(expectedMessageStub), expectedMessageStub);
            AssertExceptionMessage(() => Metadata((long)valueStub).Positive(expectedMessageStub), expectedMessageStub);
            AssertExceptionMessage(() => Metadata((decimal)valueStub).Positive(expectedMessageStub), expectedMessageStub);
            AssertExceptionMessage(() => Metadata((float)valueStub).Positive(expectedMessageStub), expectedMessageStub);
            AssertExceptionMessage(() => Metadata((double)valueStub).Positive(expectedMessageStub), expectedMessageStub);
        }

        public void AssertExceptionMessage(TestDelegate code, string expectedMessageStub)
        {
            var actualMessage = Unit.Assert .Throws<ArgumentException>(code).Message;
            Console.WriteLine(actualMessage);
            Unit.Assert.AreEqual(expectedMessageStub, actualMessage);
        }
    }
}
