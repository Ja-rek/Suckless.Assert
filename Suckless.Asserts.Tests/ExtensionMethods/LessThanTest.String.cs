using Unit = NUnit.Framework;
using System; 
using NUnit.Framework;
using Suckless.Asserts.Tests.Base;

namespace Suckless.Asserts.Tests.ExtensionMethods
{
    internal partial class LessThanTest : AssertBaseTest
    {
        [Test]
        public void LessThan_WhenStringIsLessThan3_DoNotThrowException()
        {
            var valueStub = "12";

            Metadata(valueStub).LessThan(3);
        }

        [Test]
        public void LessThan_WhenStringIsNotLessThan2_ThrowsException()
        {
            var valueStub = "123";

            Unit.Assert.Throws<ArgumentOutOfRangeException>(() => Metadata(valueStub).LessThan(2));
        }

        [Test]
        public void LessThan_WhenStringIsNotLessThan2AdnCustomMessageWasSpecyfied_ThrowsExceptionWithCorrectMessage()
        {
            var valueStub = "123";

            var expectedMessageStub = "Any message";

            var actualMessage = Unit.Assert
                .Throws<ArgumentOutOfRangeException>(() => Metadata(valueStub).LessThan(2, expectedMessageStub))
                .Message;

            Unit.Assert.AreEqual(expectedMessageStub, actualMessage);
        }
    }
}
