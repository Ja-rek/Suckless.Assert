using System;
using NUnit.Framework;
using Suckless.Asserts.Tests.Base;

namespace Suckless.Asserts.Tests.ExtensionMethods
{
    internal partial class CountGreaterTest : AssertBaseTest<ArgumentOutOfRangeException> 
    {
        [Test]
        public void CountGreater_WhenStringIsGreaterThan1_DoNotThrowException()
        {
            var valueStub = "12";

            Metadata(valueStub).CountGreater(1);
        }

        [Test]
        public void CountGreater_WhenStringIsNotGreaterThan2_ThrowsException()
        {
            var valueStub = "1";
            var messagePart = "contains 1 character/s but should contain more than 2.";

            AssertExceptionMessage(m => m.CountGreater(2), valueStub, messagePart);
        }

        [Test]
        public void CountGreater_WhenStringIsNotGreaterThan2AdnCustomMessageWasSpecyfied_ThrowsExceptionWithCorrectMessage()
        {
            var valueStub = "1";

            var customeMessageStub = "Any message";

            AssertCustomExceptionMessage(m => m.CountGreater(2, customeMessageStub), 
                valueStub, 
                customeMessageStub);
        }
    }
}
