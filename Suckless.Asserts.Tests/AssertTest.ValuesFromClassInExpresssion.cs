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
        public void Assert_WhenArgumentIsVariableFromClass_ReturnsCorrectMetadata()
        {
            var classSut = new ValuesSut();

            var actualMetadata = Assert(() => classSut.variable);
            var expectedMetadata = new Metadata<string>(classSut.variable, nameof(classSut.variable));
            
            Unit.Assert.AreEqual(expectedMetadata, actualMetadata);
        }

        [Test]
        public void Assert_WhenArgumentIsPropertyFromClass_ReturnsCorrectMetadata()
        {
            var classSut = new ValuesSut();

            var actualMetadata = Assert(() => classSut.Property);
            var expectedMetadata = new Metadata<string>(classSut.Property, nameof(classSut.Property));

            Unit.Assert.AreEqual(expectedMetadata, actualMetadata);
        }

        [Test]
        public void Assert_WhenArgumentIsConstFromClass_ThrowsApplicationException()
        {
            Unit.Assert.Throws<ApplicationException>(() => Assert(() => ValuesSut.ANY_VALUE));
        }

        [Test]
        public void Assert_WhenArgumentIsStaticPropertyOrFieldFromClass_ThrowsApplicationException()
        {
            Unit.Assert.Throws<ApplicationException>(() => Assert(() => ValuesSut.staticVariable));
            Unit.Assert.Throws<ApplicationException>(() => Assert(() => ValuesSut.StaticProperty));
        }

        [Test]
        public void Assert_WhenArgumentIsMethodFromClass_ThrowsApplicationException()
        {
            var classSut = new ValuesSut();

            Unit.Assert.Throws<ApplicationException>(() => Assert(() => classSut.Method()));
            Unit.Assert.Throws<ApplicationException>(() => Assert(() => ValuesSut.StaticMethod()));
        }
    }
}
