using Unit = NUnit.Framework;
using System;
using NUnit.Framework;
using Suckless.Asserts.Tests.Base;

namespace Suckless.Asserts.Tests.ExtensionMethods
{
    internal class RangeTest : AssertBaseTest
    {
        [Test]
        public void Range_WhenNumberIsInRange_DoNotThrowException()
        {
            var valueStub = 5;

            Metadata((short)valueStub).Range((short)3, (short)5);
            Metadata((ushort)valueStub).Range((ushort)1, (ushort)5);
            Metadata((int)valueStub).Range((int)1, (int)6);
            Metadata((uint)valueStub).Range((uint)3, (uint)8);
            Metadata((long)valueStub).Range((long)1, (long)5);
            Metadata((ulong)valueStub).Range((ulong)1, (ulong)5);
            Metadata((double)valueStub).Range((double)1, (double)5);
            Metadata((decimal)valueStub).Range((decimal)1, (decimal)5);
            Metadata((float)valueStub).Range((float)1, (float)5);
        }

        [Test]
        [TestCase(8)]
        [TestCase(9)]
        [TestCase(18)]
        [TestCase(16)]
        public void Range_WhenNumberIsNotInRange_ThrowsException(int valueStub)
        {
            Unit.Assert.Throws<ArgumentOutOfRangeException>(() => Metadata((short)valueStub).Range((short)10, (short)15));
            Unit.Assert.Throws<ArgumentOutOfRangeException>(() => Metadata((ushort)valueStub).Range((ushort)10, (ushort)15));
            Unit.Assert.Throws<ArgumentOutOfRangeException>(() => Metadata((int)valueStub).Range((int)10, (int)15));
            Unit.Assert.Throws<ArgumentOutOfRangeException>(() => Metadata((uint)valueStub).Range((uint)10, (uint)15));
            Unit.Assert.Throws<ArgumentOutOfRangeException>(() => Metadata((long)valueStub).Range((long)10, (long)15));
            Unit.Assert.Throws<ArgumentOutOfRangeException>(() => Metadata((ulong)valueStub).Range((ulong)10, (ulong)15));
            Unit.Assert.Throws<ArgumentOutOfRangeException>(() => Metadata((decimal)valueStub).Range((decimal)10, (decimal)15));
            Unit.Assert.Throws<ArgumentOutOfRangeException>(() => Metadata((double)valueStub).Range((double)10, (double)15));
            Unit.Assert.Throws<ArgumentOutOfRangeException>(() => Metadata((decimal)valueStub).Range((decimal)10, (decimal)15));
        }

        [Test]
        public void Range_WhenNumberIsNotInRangeAndCustomMessageWasSpecyfied_ThrowsExceptionWithCorrectMessage()
        {
            var valueStub = 5;
            var expectedMessageStub = "Any message";

            AssertExceptionMessage(() => 
                Metadata((short)valueStub).Range((short)6,(short)7, expectedMessageStub), expectedMessageStub);
            AssertExceptionMessage(() => 
                Metadata((ushort)valueStub).Range((ushort)6,(ushort)7, expectedMessageStub), expectedMessageStub);

            AssertExceptionMessage(() => 
                Metadata((int)valueStub).Range((int)6,(int)7, expectedMessageStub), expectedMessageStub);
            AssertExceptionMessage(() => 
                Metadata((uint)valueStub).Range((uint)6,(uint)7, expectedMessageStub), expectedMessageStub);

            AssertExceptionMessage(() => 
                Metadata((long)valueStub).Range((long)6,(long)7, expectedMessageStub), expectedMessageStub);
            AssertExceptionMessage(() => 
                Metadata((ulong)valueStub).Range((ulong)6,(ulong)7, expectedMessageStub), expectedMessageStub);

            AssertExceptionMessage(() => 
                Metadata((decimal)valueStub).Range((decimal)6,(decimal)7, expectedMessageStub), expectedMessageStub);

            AssertExceptionMessage(() => 
                Metadata((double)valueStub).Range((double)6,(double)7, expectedMessageStub), expectedMessageStub);

            AssertExceptionMessage(() => 
                Metadata((float)valueStub).Range((float)6,(float)7, expectedMessageStub), expectedMessageStub);
        }

        public void AssertExceptionMessage(TestDelegate code, string expectedMessageStub)
        {
            var actualMessage = Unit.Assert .Throws<ArgumentOutOfRangeException>(code) .Message;
            Unit.Assert.AreEqual(expectedMessageStub, actualMessage);
        }
    }
}
