using Unit = NUnit.Framework;
using System;
using NUnit.Framework;
using Suckless.Asserts.Tests.Base;

namespace Suckless.Asserts.Tests.ExtensionMethods
{
    internal class LessThanTest : AssertBaseTest<ArgumentOutOfRangeException> 
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
            var messagePart = $"contains the number {valueStub} but should contain a number less than 2.";

            AssertExceptionMessage<short>(m => m.LessThan((short)2), valueStub, messagePart);
            AssertExceptionMessage<ushort>(m => m.LessThan((ushort)2), valueStub, messagePart);
            AssertExceptionMessage<int>(m => m.LessThan((int)2), valueStub, messagePart);
            AssertExceptionMessage<uint>(m => m.LessThan((uint)2), valueStub, messagePart);
            AssertExceptionMessage<long>(m => m.LessThan((long)2), valueStub, messagePart);
            AssertExceptionMessage<ulong>(m => m.LessThan((ulong)2), valueStub, messagePart);
            AssertExceptionMessage<decimal>(m => m.LessThan((decimal)2), valueStub, messagePart);
            AssertExceptionMessage<float>(m => m.LessThan((float)2), valueStub, messagePart);
            AssertExceptionMessage<double>(m => m.LessThan((double)2), valueStub, messagePart);
        }

        [Test]
        public void LessThan_WhenAssertionFailedAdnCustomMessageWasSpecyfied_ThrowsExceptionWithCorrectMessage()
        {
            var valueStub = 3;
            var customeMessageStub = "Any message";

            AssertCustomExceptionMessage<short>(m => m.LessThan((short)2, customeMessageStub), 
                valueStub, 
                customeMessageStub);
            AssertCustomExceptionMessage<ushort>(m => m.LessThan((ushort)2, customeMessageStub), 
                valueStub, 
                customeMessageStub);
            AssertCustomExceptionMessage<int>(m => m.LessThan((int)2, customeMessageStub), 
                valueStub, 
                customeMessageStub);
            AssertCustomExceptionMessage<uint>(m => m.LessThan((uint)2, customeMessageStub), 
                valueStub, 
                customeMessageStub);
            AssertCustomExceptionMessage<long>(m => m.LessThan((long)2, customeMessageStub), 
                valueStub, 
                customeMessageStub);
            AssertCustomExceptionMessage<ulong>(m => m.LessThan((ulong)2, customeMessageStub), 
                valueStub, 
                customeMessageStub);
            AssertCustomExceptionMessage<decimal>(m => m.LessThan((decimal)2, customeMessageStub), 
                valueStub, 
                customeMessageStub);
            AssertCustomExceptionMessage<float>(m => m.LessThan((float)2, customeMessageStub), 
                valueStub, 
                customeMessageStub);
            AssertCustomExceptionMessage<double>(m => m.LessThan((double)2, customeMessageStub), 
                valueStub, 
                customeMessageStub);
        }

        public void AssertExceptionMessage(TestDelegate code, string expectedMessageStub)
        {
            var actualMessage = Unit.Assert .Throws<ArgumentOutOfRangeException>(code) .Message;
            Unit.Assert.AreEqual(expectedMessageStub, actualMessage);
        }
    }
}
