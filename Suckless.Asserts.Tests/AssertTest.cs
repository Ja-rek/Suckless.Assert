using Unit = NUnit.Framework;
using static Suckless.Asserts.Assertions;
using System;
using NUnit.Framework;

namespace Suckless.Asserts.Tests
{
    internal partial class AssertTest
    {
        [Test]
        public void Assert_WhenArgumentIsNull_ThrowsException()
        {
            string valueStub = null;

            Unit.Assert.Throws<ArgumentNullException>(() => Assert(valueStub).Empty());
        }

        [Test]
        public void Assert_WhenExpressionIsNull_ThrowsException()
        {
            string valueStub = null;

            Unit.Assert.Throws<ArgumentNullException>(() => Assert(() => valueStub).Empty());
        }
    }
}
