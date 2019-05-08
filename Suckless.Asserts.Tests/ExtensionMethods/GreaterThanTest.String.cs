using Unit = NUnit.Framework;
using System; 
using NUnit.Framework;
using Suckless.Asserts.Tests.Base;

namespace Suckless.Asserts.Tests.ExtensionMethods
{
    internal partial class GreaterThanTest : AssertBaseTest
    {
        [Test]
        public void GreaterThan_WhenStringIsGreaterThan1_DoNotThrowException()
        {
            var valueStub = "12";

            Metadata(valueStub).GreaterThan(1);
        }

        [Test]
        public void GreaterThan_WhenStringIsNotGreaterThan2_ThrowsException()
        {
            var valueStub = "1";

            Unit.Assert.Throws<ArgumentOutOfRangeException>(() => Metadata(valueStub).GreaterThan(2));
        }

        [Test]
        public void GreaterThan_WhenStringIsNotGreaterThan2AdnCustomMessageWasSpecyfied_ThrowsExceptionWithCorrectMessage()
        {
            var valueStub = "1";

            var expectedMessageStub = "Any message";

            var actualMessage = Unit.Assert
                .Throws<ArgumentOutOfRangeException>(() => Metadata(valueStub).GreaterThan(2, expectedMessageStub))
                .Message;

            Unit.Assert.AreEqual(expectedMessageStub, actualMessage);
        }
    }
}
