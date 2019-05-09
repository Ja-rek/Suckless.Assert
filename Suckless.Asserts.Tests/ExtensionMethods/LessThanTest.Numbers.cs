using Unit = NUnit.Framework;
using System;
using NUnit.Framework;
using Suckless.Asserts.Tests.Base;

namespace Suckless.Asserts.Tests.ExtensionMethods
{
    internal partial class LessThanTest : AssertBaseTest
    {
        [Test]
        public void LessThan_WhenNumberIsLessThan2_DoNotThrowException()
        {
            var valueStub = 1;

            Metadata((short)valueStub).LessThan((short)2);
            Metadata((ushort)valueStub).LessThan((ushort)2);
            Metadata((int)valueStub).LessThan((int)2);
            Metadata((uint)valueStub).LessThan((uint)2);
            Metadata((long)valueStub).LessThan((long)2);
            Metadata((ulong)valueStub).LessThan((ulong)2);
            Metadata((decimal)valueStub).LessThan((decimal)2);
            Metadata((float)valueStub).LessThan((float)2);
            Metadata((double)valueStub).LessThan((double)2);
        }

        [Test]
        public void LessThan_WhenNumberIsNotLessThan2_ThrowsException()
        {
            var valueStub = 3;

            Unit.Assert.Throws<ArgumentOutOfRangeException>(() => Metadata((short)valueStub).LessThan((short)2));
            Unit.Assert.Throws<ArgumentOutOfRangeException>(() => Metadata((ushort)valueStub).LessThan((ushort)2));
            Unit.Assert.Throws<ArgumentOutOfRangeException>(() => Metadata((int)valueStub).LessThan((int)2));
            Unit.Assert.Throws<ArgumentOutOfRangeException>(() => Metadata((uint)valueStub).LessThan((uint)2));
            Unit.Assert.Throws<ArgumentOutOfRangeException>(() => Metadata((long)valueStub).LessThan((long)2));
            Unit.Assert.Throws<ArgumentOutOfRangeException>(() => Metadata((ulong)valueStub).LessThan((ulong)2));
            Unit.Assert.Throws<ArgumentOutOfRangeException>(() => Metadata((decimal)valueStub).LessThan((decimal)2));
            Unit.Assert.Throws<ArgumentOutOfRangeException>(() => Metadata((float)valueStub).LessThan((float)2));
            Unit.Assert.Throws<ArgumentOutOfRangeException>(() => Metadata((double)valueStub).LessThan((double)2));
        }

        [Test]
        public void LessThan_WhenAssertionFailedAdnCustomMessageWasSpecyfied_ThrowsExceptionWithCorrectMessage()
        {
            var valueStub = 3;
            var expectedMessageStub = "Any message";

            AssertExceptionMessage(() => 
                Metadata((short)valueStub).LessThan((short)2, expectedMessageStub), expectedMessageStub);
            AssertExceptionMessage(() => 
                Metadata((ushort)valueStub).LessThan((ushort)2, expectedMessageStub), expectedMessageStub);
            AssertExceptionMessage(() => 
                Metadata((int)valueStub).LessThan((int)2, expectedMessageStub), expectedMessageStub);
            AssertExceptionMessage(() => 
                Metadata((uint)valueStub).LessThan((uint)2, expectedMessageStub), expectedMessageStub);
            AssertExceptionMessage(() => 
                Metadata((long)valueStub).LessThan((long)2, expectedMessageStub), expectedMessageStub);
            AssertExceptionMessage(() => 
                Metadata((ulong)valueStub).LessThan((ulong)2, expectedMessageStub), expectedMessageStub);
            AssertExceptionMessage(() => 
                Metadata((decimal)valueStub).LessThan((decimal)2, expectedMessageStub), expectedMessageStub);
            AssertExceptionMessage(() => 
                Metadata((float)valueStub).LessThan((float)2, expectedMessageStub), expectedMessageStub);
            AssertExceptionMessage(() => 
                Metadata((double)valueStub).LessThan((double)2, expectedMessageStub), expectedMessageStub);
        }

        public void AssertExceptionMessage(TestDelegate code, string expectedMessageStub)
        {
            var actualMessage = Unit.Assert .Throws<ArgumentOutOfRangeException>(code) .Message;
            Unit.Assert.AreEqual(expectedMessageStub, actualMessage);
        }
    }
}
