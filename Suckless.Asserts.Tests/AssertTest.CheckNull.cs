using Unit = NUnit.Framework;
using static Suckless.Asserts.Assertions;
using System;

namespace Suckless.Asserts.Tests
{
    internal class Assert
    {
        [Unit.Test]
        public void Assert_WhenArgumentIsNull_ThrowsException()
        {
            string valueStub = null;

            Unit.Assert.Throws<ArgumentNullException>(() => Assert(valueStub).Empty());
        }

        [Unit.Test]
        public void Assert_WhenExpressionIsNull_ThrowsException()
        {
            string valueStub = null;

            Unit.Assert.Throws<ArgumentNullException>(() => Assert(() => valueStub).Empty());
        }
    }
}
