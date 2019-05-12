using System;
using NUnit.Framework;
using Suckless.Asserts.Tests.Base;

namespace Suckless.Asserts.Tests.ExtensionMethods
{
    internal class GreaterTest : AssertBaseTest<ArgumentOutOfRangeException> 
    {
        [Test]
        public void Greater_WhenNumberIsGreater1_DoNotThrowException()
        {
            var valueStub = 2;

            Metadata((short)valueStub).Greater((short)1);
            Metadata((ushort)valueStub).Greater((ushort)1);
            Metadata((int)valueStub).Greater((int)1);
            Metadata((uint)valueStub).Greater((uint)1);
            Metadata((long)valueStub).Greater((long)1);
            Metadata((ulong)valueStub).Greater((ulong)1);
            Metadata((decimal)valueStub).Greater((decimal)1);
            Metadata((float)valueStub).Greater((float)1);
            Metadata((double)valueStub).Greater((double)1);
        }

        [Test]
        public void Greater_WhenNumberIsNotGreater2_ThrowsException()
        {
            var valueStub = 1;
            var messagePart = $"contains the number {valueStub} but should contain a number greater than 2.";

            AssertExceptionMessage<short>(m => m.Greater((short)2), valueStub, messagePart);
            AssertExceptionMessage<ushort>(m => m.Greater((ushort)2), valueStub, messagePart);
            AssertExceptionMessage<int>(m => m.Greater((int)2), valueStub, messagePart);
            AssertExceptionMessage<uint>(m => m.Greater((uint)2), valueStub, messagePart);
            AssertExceptionMessage<long>(m => m.Greater((long)2), valueStub, messagePart);
            AssertExceptionMessage<ulong>(m => m.Greater((ulong)2), valueStub, messagePart);
            AssertExceptionMessage<decimal>(m => m.Greater((decimal)2), valueStub, messagePart);
            AssertExceptionMessage<float>(m => m.Greater((float)2), valueStub, messagePart);
            AssertExceptionMessage<double>(m => m.Greater((double)2), valueStub, messagePart);
        }

        [Test]
        public void Greater_WhenAssertionFailedAdnCustomMessageWasSpecyfied_ThrowsExceptionWithCorrectMessage()
        {
            var valueStub = 1;
            var customeMessageStub = "Any message";

            AssertCustomExceptionMessage<short>(m => m.Greater((short)2, customeMessageStub), 
                valueStub, 
                customeMessageStub);
            AssertCustomExceptionMessage<ushort>(m => m.Greater((ushort)2, customeMessageStub), 
                valueStub, 
                customeMessageStub);
            AssertCustomExceptionMessage<int>(m => m.Greater((int)2, customeMessageStub), 
                valueStub, 
                customeMessageStub);
            AssertCustomExceptionMessage<uint>(m => m.Greater((uint)2, customeMessageStub), 
                valueStub, 
                customeMessageStub);
            AssertCustomExceptionMessage<long>(m => m.Greater((long)2, customeMessageStub), 
                valueStub, 
                customeMessageStub);
            AssertCustomExceptionMessage<ulong>(m => m.Greater((ulong)2, customeMessageStub), 
                valueStub, 
                customeMessageStub);
            AssertCustomExceptionMessage<decimal>(m => m.Greater((decimal)2, customeMessageStub), 
                valueStub, 
                customeMessageStub);
            AssertCustomExceptionMessage<float>(m => m.Greater((float)2, customeMessageStub), 
                valueStub, 
                customeMessageStub);
            AssertCustomExceptionMessage<double>(m => m.Greater((double)2, customeMessageStub), 
                valueStub, 
                customeMessageStub);
        }
    }
}
