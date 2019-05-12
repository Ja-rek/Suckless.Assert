using Unit = NUnit.Framework;
using System;
using NUnit.Framework;
using Suckless.Asserts.Tests.Base;

namespace Suckless.Asserts.Tests.ExtensionMethods
{
    internal class RangeTest : AssertBaseTest<ArgumentOutOfRangeException> 
    {
        [Test]
        public void Range_WhenNumberIsInRange_DoNotThrowException()
        {
            var valueStub = 5;

            Metadata((short)valueStub).Range(3, 5);
            Metadata((ushort)valueStub).Range(1, 5);
            Metadata((int)valueStub).Range(1, 6);
            Metadata((uint)valueStub).Range(3, 8);
            Metadata((long)valueStub).Range(1, 5);
            Metadata((ulong)valueStub).Range(1, 5);
            Metadata((double)valueStub).Range(1, 5);
            Metadata((decimal)valueStub).Range(1, 5);
            Metadata((float)valueStub).Range(1, 5);
        }

        [Test]
        [TestCase(8)]
        [TestCase(9)]
        [TestCase(18)]
        [TestCase(16)]
        public void Range_WhenNumberIsNotInRange_ThrowsException(int valueStub)
        {
            var messagePart = $"contains the number {valueStub} but should contain a number in range 10 - 15.";

            AssertExceptionMessage<short>(m => m.Range(10, 15), valueStub, messagePart);
            AssertExceptionMessage<ushort>(m => m.Range(10, 15), valueStub, messagePart);
            AssertExceptionMessage<int>(m => m.Range(10, 15), valueStub, messagePart);
            AssertExceptionMessage<uint>(m => m.Range(10, 15), valueStub, messagePart);
            AssertExceptionMessage<long>(m => m.Range(10, 15), valueStub, messagePart);
            AssertExceptionMessage<ulong>(m => m.Range(10, 15), valueStub, messagePart);
            AssertExceptionMessage<decimal>(m => m.Range(10, 15), valueStub, messagePart);
            AssertExceptionMessage<double>(m => m.Range(10, 15), valueStub, messagePart);
            AssertExceptionMessage<decimal>(m => m.Range(10, 15), valueStub, messagePart);
        }

        [Test]
        public void Range_WhenNumberIsNotInRangeAndCustomMessageWasSpecyfied_ThrowsExceptionWithCorrectMessage()
        {
            var valueStub = 5;
            var customeMessageStub = "Any message";

            AssertCustomExceptionMessage<short>(m => m.Range(10, 15, customeMessageStub),
                valueStub, 
                customeMessageStub);
            AssertCustomExceptionMessage<ushort>(m => m.Range(10, 15, customeMessageStub), 
                valueStub, 
                customeMessageStub);
            AssertCustomExceptionMessage<int>(m => m.Range(10, 15, customeMessageStub), 
                valueStub, 
                customeMessageStub);
            AssertCustomExceptionMessage<uint>(m => m.Range(10, 15, customeMessageStub), 
                valueStub, 
                customeMessageStub);
            AssertCustomExceptionMessage<long>(m => m.Range(10, 15, customeMessageStub), 
                valueStub, 
                customeMessageStub);
            AssertCustomExceptionMessage<ulong>(m => m.Range(10, 15, customeMessageStub), 
                valueStub, 
                customeMessageStub);
            AssertCustomExceptionMessage<decimal>(m => m.Range(10, 15, customeMessageStub), 
                valueStub, 
                customeMessageStub);
            AssertCustomExceptionMessage<float>(m => m.Range(10, 15, customeMessageStub), 
                valueStub, 
                customeMessageStub);
            AssertCustomExceptionMessage<decimal>(m => m.Range(10, 15, customeMessageStub), 
                valueStub, 
                customeMessageStub);
        }
    }
}
