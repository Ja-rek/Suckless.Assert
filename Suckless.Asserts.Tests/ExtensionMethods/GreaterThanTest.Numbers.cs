using Unit = NUnit.Framework;
using System;
using NUnit.Framework;
using Suckless.Asserts.Tests.Base;

namespace Suckless.Asserts.Tests.ExtensionMethods
{
    internal partial class GreaterThanTest : AssertBaseTest
    {
        [Test]
        public void GreaterThan_WhenNumberIsGreaterThan1_DoNotThrowException()
        {
            var valueStub = 2;

            Metadata((short)valueStub).GreaterThan((short)1);
            Metadata((ushort)valueStub).GreaterThan((ushort)1);
            Metadata((int)valueStub).GreaterThan((int)1);
            Metadata((uint)valueStub).GreaterThan((uint)1);
            Metadata((long)valueStub).GreaterThan((long)1);
            Metadata((ulong)valueStub).GreaterThan((ulong)1);
            Metadata((decimal)valueStub).GreaterThan((decimal)1);
            Metadata((float)valueStub).GreaterThan((float)1);
            Metadata((double)valueStub).GreaterThan((double)1);
        }

        [Test]
        public void GreaterThan_WhenNumberIsNotGreaterThan2_ThrowsException()
        {
            var valueStub = 1;

            Unit.Assert.Throws<ArgumentOutOfRangeException>(() => Metadata((short)valueStub).GreaterThan((short)2));
            Unit.Assert.Throws<ArgumentOutOfRangeException>(() => Metadata((ushort)valueStub).GreaterThan((ushort)2));
            Unit.Assert.Throws<ArgumentOutOfRangeException>(() => Metadata((int)valueStub).GreaterThan((int)2));
            Unit.Assert.Throws<ArgumentOutOfRangeException>(() => Metadata((uint)valueStub).GreaterThan((uint)2));
            Unit.Assert.Throws<ArgumentOutOfRangeException>(() => Metadata((long)valueStub).GreaterThan((long)2));
            Unit.Assert.Throws<ArgumentOutOfRangeException>(() => Metadata((ulong)valueStub).GreaterThan((ulong)2));
            Unit.Assert.Throws<ArgumentOutOfRangeException>(() => Metadata((decimal)valueStub).GreaterThan((decimal)2));
            Unit.Assert.Throws<ArgumentOutOfRangeException>(() => Metadata((float)valueStub).GreaterThan((float)2));
            Unit.Assert.Throws<ArgumentOutOfRangeException>(() => Metadata((double)valueStub).GreaterThan((double)2));
        }

        [Test]
        public void GreaterThan_WhenAssertionFailedAdnCustomMessageWasSpecyfied_ThrowsExceptionWithCorrectMessage()
        {
            var valueStub = 1;
            var expectedMessageStub = "Any message";

            AssertExceptionMessage(() => 
                Metadata((short)valueStub).GreaterThan((short)2, expectedMessageStub), expectedMessageStub);
            AssertExceptionMessage(() => 
                Metadata((ushort)valueStub).GreaterThan((ushort)2, expectedMessageStub), expectedMessageStub);
            AssertExceptionMessage(() => 
                Metadata((int)valueStub).GreaterThan((int)2, expectedMessageStub), expectedMessageStub);
            AssertExceptionMessage(() => 
                Metadata((uint)valueStub).GreaterThan((uint)2, expectedMessageStub), expectedMessageStub);
            AssertExceptionMessage(() => 
                Metadata((long)valueStub).GreaterThan((long)2, expectedMessageStub), expectedMessageStub);
            AssertExceptionMessage(() => 
                Metadata((ulong)valueStub).GreaterThan((ulong)2, expectedMessageStub), expectedMessageStub);
            AssertExceptionMessage(() => 
                Metadata((decimal)valueStub).GreaterThan((decimal)2, expectedMessageStub), expectedMessageStub);
            AssertExceptionMessage(() => 
                Metadata((float)valueStub).GreaterThan((float)2, expectedMessageStub), expectedMessageStub);
            AssertExceptionMessage(() => 
                Metadata((double)valueStub).GreaterThan((double)2, expectedMessageStub), expectedMessageStub);
        }

        public void AssertExceptionMessage(TestDelegate code, string expectedMessageStub)
        {
            var actualMessage = Unit.Assert .Throws<ArgumentOutOfRangeException>(code) .Message;
            Unit.Assert.AreEqual(expectedMessageStub, actualMessage);
        }
    }
}
