using Unit = NUnit.Framework;
using System;
using NUnit.Framework;
using Suckless.Asserts.Tests.Base;

namespace Suckless.Asserts.Tests.ExtensionMethods
{
    internal class ZeroTest : AssertBaseTest
    {
        [Test]
        public void Zero_WhenNumberIsZero_DoNotThrowException()
        {
            var valueStub = 0;

            Metadata((short)valueStub).Zero();
            Metadata((ushort)valueStub).Zero();
            Metadata((int)valueStub).Zero();
            Metadata((uint)valueStub).Zero();
            Metadata((long)valueStub).Zero();
            Metadata((ulong)valueStub).Zero();
            Metadata((decimal)valueStub).Zero();
            Metadata((float)valueStub).Zero();
            Metadata((double)valueStub).Zero();
        }

        [Test]
        public void Zero_WhenNumberIsNotZero_ThrowsException()
        {
            var valueStub = 1;

            Unit.Assert.Throws<ArgumentException>(() => Metadata((short)valueStub).Zero());
            Unit.Assert.Throws<ArgumentException>(() => Metadata((ushort)valueStub).Zero());
            Unit.Assert.Throws<ArgumentException>(() => Metadata((int)valueStub).Zero());
            Unit.Assert.Throws<ArgumentException>(() => Metadata((uint)valueStub).Zero());
            Unit.Assert.Throws<ArgumentException>(() => Metadata((long)valueStub).Zero());
            Unit.Assert.Throws<ArgumentException>(() => Metadata((ulong)valueStub).Zero());
            Unit.Assert.Throws<ArgumentException>(() => Metadata((decimal)valueStub).Zero());
            Unit.Assert.Throws<ArgumentException>(() => Metadata((float)valueStub).Zero());
            Unit.Assert.Throws<ArgumentException>(() => Metadata((double)valueStub).Zero());
        }

        [Test]
        public void Zero_WhenAssertionFailedAdnCustomMessageWasSpecyfied_ThrowsExceptionWithCorrectMessage()
        {
            var valueStub = 1;
            var expectedMessageStub = "Any message";

            AssertExceptionMessage(() => Metadata((short)valueStub).Zero(expectedMessageStub), expectedMessageStub);
            AssertExceptionMessage(() => Metadata((ushort)valueStub).Zero(expectedMessageStub), expectedMessageStub);
            AssertExceptionMessage(() => Metadata((int)valueStub).Zero(expectedMessageStub), expectedMessageStub);
            AssertExceptionMessage(() => Metadata((uint)valueStub).Zero(expectedMessageStub), expectedMessageStub);
            AssertExceptionMessage(() => Metadata((long)valueStub).Zero(expectedMessageStub), expectedMessageStub);
            AssertExceptionMessage(() => Metadata((ulong)valueStub).Zero(expectedMessageStub), expectedMessageStub);
            AssertExceptionMessage(() => Metadata((decimal)valueStub).Zero(expectedMessageStub), expectedMessageStub);
            AssertExceptionMessage(() => Metadata((float)valueStub).Zero(expectedMessageStub), expectedMessageStub);
            AssertExceptionMessage(() => Metadata((double)valueStub).Zero(expectedMessageStub), expectedMessageStub);
        }

        public void AssertExceptionMessage(TestDelegate code, string expectedMessageStub)
        {
            var actualMessage = Unit.Assert .Throws<ArgumentException>(code) .Message;
            Unit.Assert.AreEqual(expectedMessageStub, actualMessage);
        }
    }
}
