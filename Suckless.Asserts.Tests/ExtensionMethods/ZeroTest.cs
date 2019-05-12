using System;
using NUnit.Framework;
using Suckless.Asserts.Tests.Base;

namespace Suckless.Asserts.Tests.ExtensionMethods
{
    internal class ZeroTest : AssertBaseTest<ArgumentException>
    {
        [Test]
        public void Zero_WhenNumberIsZero_DoNotThrowException()
        {
            var valueStub = 0;

            Metadata((short)valueStub).Zero();
            Metadata((int)valueStub).Zero();
            Metadata((long)valueStub).Zero();
            Metadata((decimal)valueStub).Zero();
            Metadata((float)valueStub).Zero();
            Metadata((double)valueStub).Zero();
        }

        [Test]
        public void Zero_WhenNumberIsNotZero_ThrowsException()
        {
            var valueStub = 1;
            var messagePart = "must be zero.";

            AssertExceptionMessage<short>(m => m.Zero(), valueStub, messagePart);
            AssertExceptionMessage<int>(m => m.Zero(), valueStub, messagePart);
            AssertExceptionMessage<long>(m => m.Zero(), valueStub, messagePart);
            AssertExceptionMessage<decimal>(m => m.Zero(), valueStub, messagePart);
            AssertExceptionMessage<float>(m => m.Zero(), valueStub, messagePart);
            AssertExceptionMessage<double>(m => m.Zero(), valueStub, messagePart);
        }

        [Test]
        public void Zero_WhenNumberIsNotZeroAdnCustomMessageWasSpecyfied_ThrowsExceptionWithCorrectMessage()
        {
            var valueStub = 1;
            var customeMessageStub = "Any message";

            AssertCustomExceptionMessage<short>(m => m.Zero(customeMessageStub), valueStub, customeMessageStub);
            AssertCustomExceptionMessage<int>(m => m.Zero(customeMessageStub), valueStub, customeMessageStub);
            AssertCustomExceptionMessage<long>(m => m.Zero(customeMessageStub), valueStub, customeMessageStub);
            AssertCustomExceptionMessage<decimal>(m => m.Zero(customeMessageStub), valueStub, customeMessageStub);
            AssertCustomExceptionMessage<float>(m => m.Zero(customeMessageStub), valueStub, customeMessageStub);
            AssertCustomExceptionMessage<decimal>(m => m.Zero(customeMessageStub), valueStub, customeMessageStub);
        }
    }
}
