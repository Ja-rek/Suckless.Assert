using System;
using NUnit.Framework;
using Suckless.Asserts.Tests.Base;

namespace Suckless.Asserts.Tests.ExtensionMethods
{
    internal class PositiveTest : AssertBaseTest<ArgumentException>
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
            var messagePart = "must be positive.";

            AssertExceptionMessage<short>(m => m.Positive(), valueStub, messagePart);
            AssertExceptionMessage<int>(m => m.Positive(), valueStub, messagePart);
            AssertExceptionMessage<long>(m => m.Positive(), valueStub, messagePart);
            AssertExceptionMessage<decimal>(m => m.Positive(), valueStub, messagePart);
            AssertExceptionMessage<float>(m => m.Positive(), valueStub, messagePart);
            AssertExceptionMessage<double>(m => m.Positive(), valueStub, messagePart);
        }

        [Test]
        public void Positive_WhenNumberIsNotPositiveAdnCustomMessageWasSpecyfied_ThrowsExceptionWithCorrectMessage()
        {
            var valueStub = -1;
            var customeMessageStub = "Any message";

            AssertCustomExceptionMessage<short>(m => m.Positive(customeMessageStub), valueStub, customeMessageStub);
            AssertCustomExceptionMessage<int>(m => m.Positive(customeMessageStub), valueStub, customeMessageStub);
            AssertCustomExceptionMessage<long>(m => m.Positive(customeMessageStub), valueStub, customeMessageStub);
            AssertCustomExceptionMessage<decimal>(m => m.Positive(customeMessageStub), valueStub, customeMessageStub);
            AssertCustomExceptionMessage<float>(m => m.Positive(customeMessageStub), valueStub, customeMessageStub);
            AssertCustomExceptionMessage<decimal>(m => m.Positive(customeMessageStub), valueStub, customeMessageStub);
        }
    }
}
