using Unit = NUnit.Framework;
using System;
using NUnit.Framework;
using Suckless.Asserts.Tests.Base;

namespace Suckless.Asserts.Tests.ExtensionMethods
{
    internal class LessTest : AssertBaseTest<ArgumentOutOfRangeException> 
    {
        [Test]
        public void Less_WhenNumberIsLessThanExpectedNumber_DoNotThrowException()
        {
            var valueStub = 1;

            Metadata((short)valueStub).Less((short)2);
            Metadata((ushort)valueStub).Less((ushort)2);
            Metadata((int)valueStub).Less((int)2);
            Metadata((uint)valueStub).Less((uint)2);
            Metadata((long)valueStub).Less((long)2);
            Metadata((ulong)valueStub).Less((ulong)2);
            Metadata((decimal)valueStub).Less((decimal)2);
            Metadata((float)valueStub).Less((float)2);
            Metadata((double)valueStub).Less((double)2);
        }

        [Test]
        public void Less_WhenNumberIsNotLessThanExpectedNumber_ThrowsExceptionWithCorrectMessage()
        {
            var valueStub = 3;
            var messagePart = $"contains the number {valueStub} but should contain a number less than 2.";

            AssertExceptionMessage<short>(m => m.Less((short)2), valueStub, messagePart);
            AssertExceptionMessage<ushort>(m => m.Less((ushort)2), valueStub, messagePart);
            AssertExceptionMessage<int>(m => m.Less((int)2), valueStub, messagePart);
            AssertExceptionMessage<uint>(m => m.Less((uint)2), valueStub, messagePart);
            AssertExceptionMessage<long>(m => m.Less((long)2), valueStub, messagePart);
            AssertExceptionMessage<ulong>(m => m.Less((ulong)2), valueStub, messagePart);
            AssertExceptionMessage<decimal>(m => m.Less((decimal)2), valueStub, messagePart);
            AssertExceptionMessage<float>(m => m.Less((float)2), valueStub, messagePart);
            AssertExceptionMessage<double>(m => m.Less((double)2), valueStub, messagePart);
        }

        [Test]
        public void Less_WhenAssertionFailedAdnCustomMessageWasSpecyfied_ThrowsExceptionWithCorrectMessage()
        {
            var valueStub = 3;
            var customeMessageStub = "Any message";

            AssertCustomExceptionMessage<short>(m => m.Less((short)2, customeMessageStub), 
                valueStub, 
                customeMessageStub);
            AssertCustomExceptionMessage<ushort>(m => m.Less((ushort)2, customeMessageStub), 
                valueStub, 
                customeMessageStub);
            AssertCustomExceptionMessage<int>(m => m.Less((int)2, customeMessageStub), 
                valueStub, 
                customeMessageStub);
            AssertCustomExceptionMessage<uint>(m => m.Less((uint)2, customeMessageStub), 
                valueStub, 
                customeMessageStub);
            AssertCustomExceptionMessage<long>(m => m.Less((long)2, customeMessageStub), 
                valueStub, 
                customeMessageStub);
            AssertCustomExceptionMessage<ulong>(m => m.Less((ulong)2, customeMessageStub), 
                valueStub, 
                customeMessageStub);
            AssertCustomExceptionMessage<decimal>(m => m.Less((decimal)2, customeMessageStub), 
                valueStub, 
                customeMessageStub);
            AssertCustomExceptionMessage<float>(m => m.Less((float)2, customeMessageStub), 
                valueStub, 
                customeMessageStub);
            AssertCustomExceptionMessage<double>(m => m.Less((double)2, customeMessageStub), 
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
