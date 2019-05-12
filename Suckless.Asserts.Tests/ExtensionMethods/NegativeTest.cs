using System;
using NUnit.Framework;
using Suckless.Asserts.Tests.Base;

namespace Suckless.Asserts.Tests.ExtensionMethods
{
    internal class NegativeTest : AssertBaseTest<ArgumentException>
    {
        [Test]
        public void Negative_WhenNumberIsNegative_DoNotThrowException()
        {
            var valueStub = -1;

            Metadata((short)valueStub).Negative();
            Metadata((int)valueStub).Negative();
            Metadata((long)valueStub).Negative();
            Metadata((decimal)valueStub).Negative();
            Metadata((float)valueStub).Negative();
            Metadata((double)valueStub).Negative();
        }

        [Test]
        public void Negative_WhenNumberIsNotNegative_ThrowsException()
        {
            var valueStub = 1;
            var messagePart = "must be negative.";

            AssertExceptionMessage<short>(m => m.Negative(), valueStub, messagePart);
            AssertExceptionMessage<int>(m => m.Negative(), valueStub, messagePart);
            AssertExceptionMessage<long>(m => m.Negative(), valueStub, messagePart);
            AssertExceptionMessage<decimal>(m => m.Negative(), valueStub, messagePart);
            AssertExceptionMessage<float>(m => m.Negative(), valueStub, messagePart);
            AssertExceptionMessage<double>(m => m.Negative(), valueStub, messagePart);
        }

        [Test]
        public void Negative_WhenNumberIsNotNegativeAdnCustomMessageWasSpecyfied_ThrowsExceptionWithCorrectMessage()
        {
            var valueStub = 1;
            var customeMessageStub = "Any message";

            AssertCustomExceptionMessage<short>(m => m.Negative(customeMessageStub), valueStub, customeMessageStub);
            AssertCustomExceptionMessage<int>(m => m.Negative(customeMessageStub), valueStub, customeMessageStub);
            AssertCustomExceptionMessage<long>(m => m.Negative(customeMessageStub), valueStub, customeMessageStub);
            AssertCustomExceptionMessage<decimal>(m => m.Negative(customeMessageStub), valueStub, customeMessageStub);
            AssertCustomExceptionMessage<float>(m => m.Negative(customeMessageStub), valueStub, customeMessageStub);
            AssertCustomExceptionMessage<decimal>(m => m.Negative(customeMessageStub), valueStub, customeMessageStub);
        }
    }
}
