using Unit = NUnit.Framework;
using static Suckless.Asserts.Assertions;
using System;
using NUnit.Framework;

namespace Suckless.Asserts.Tests
{
    internal partial class AssertTest
    {
        const string MESSAGE = "The value: String cannot be null.";
        const string MESSAGE_WITH_FIELD_NAME = "The value: String cannot be null.";

        [Test]
        public void Assert_WhenArgumentIsNull_ThrowsException()
        {
            string value = null;

            var actualMessage = Unit.Assert.Throws<ArgumentNullException>(() => Assert(value)).Message;
            var actualMessageWithFieldName = Unit.Assert.Throws<ArgumentNullException>(() => 
                Assert(value, "value")).Message;

            Unit.Assert.AreEqual(expected: MESSAGE, actualMessage);
            Unit.Assert.AreEqual(expected: MESSAGE_WITH_FIELD_NAME, actualMessageWithFieldName);
        }

        [Test]
        public void Assert_WhenExpressionIsNull_ThrowsException()
        {
            string value = null;

            var actualMessageWithFieldName = Unit.Assert.Throws<ArgumentNullException>(() => 
                Assert(() => value)).Message;

            Unit.Assert.AreEqual(expected: MESSAGE_WITH_FIELD_NAME, actualMessageWithFieldName);
        }

        [Test]
        public void Assert_WhenArgumentIsNotNull_DoesNotThrowsException()
        {
            string value = "any value";

            Assert(value);
            Assert(() => value);
        }
    }
}
