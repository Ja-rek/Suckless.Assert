using System;
using Unit = NUnit.Framework;
using static Suckless.Asserts.Assertions;
using NUnit.Framework;
using Suckless.Asserts.Tests.Base;

namespace Suckless.Asserts.Tests
{
    internal partial class AssertTest : AssertByExpressionTestBase
    {
        [Test]
        public void Assert_WhenArgumentIsNestedVariable_ThrowsApplicationException()
        {
            var nestedClassSut = new NestedValuesSut();

            Unit.Assert.Throws<ApplicationException>(() => Assert(() => nestedClassSut.variable.variable));
        }

        [Test]
        public void Assert_WhenArgumentIsNestedProperty_ThrowsApplicationException()
        {
            var nestedClassSut = new NestedValuesSut();

            Unit.Assert.Throws<ApplicationException>(() => Assert(() => nestedClassSut.Property.Property));
        }

        [Test]
        public void Assert_WhenArgumentIsStaticNestedPropertyOrField_ThrowsApplicationException()
        {
            Unit.Assert.Throws<ApplicationException>(() => Assert(() => NestedValuesSut.staticVariable.variable));
            Unit.Assert.Throws<ApplicationException>(() => Assert(() => NestedValuesSut.StaticProperty.Property));
        }

        [Test]
        public void Assert_WhenArgumentIsNestedMethod_ThrowsApplicationException()
        {
            var nestedClassSut = new NestedValuesSut();

            Unit.Assert.Throws<ApplicationException>(() => Assert(() => nestedClassSut.Method().Method()));
            Unit.Assert.Throws<ApplicationException>(() => Assert(() => NestedValuesSut.StaticMethod().Method()));
        }
    }
}
