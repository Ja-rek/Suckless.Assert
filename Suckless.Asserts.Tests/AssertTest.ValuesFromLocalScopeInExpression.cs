using System;
using NUnit.Framework;
using Unit = NUnit.Framework;
using static Suckless.Asserts.Assertions;
using Suckless.Asserts.Tests.Base;

namespace Suckless.Asserts.Tests
{
    internal partial class AssertTest : AssertByExpressionTestBase
    {
        private const string ANY_VALUE = "any value";
        private string variable = ANY_VALUE;
        private static string staticVariable = ANY_VALUE;
        private string Property { get; set; } = ANY_VALUE;
        private static string StaticProperty { get; set; } = ANY_VALUE;

        [Test]
        public void Assert_WhenArgumentIsVariable_ReturnsCorrectMetadata()
        {
            var variable = ANY_VALUE;

            var actualMetadata = Assert(() => variable);
            var expectedMetadata = new Metadata<string>(variable, nameof(variable));

            Unit.Assert.AreEqual(expectedMetadata, actualMetadata);
        }

        [Test]
        public void Assert_WhenArgumentIsThisVariable_ReturnsCorrectMetadata()
        {
            var actualMetadata = Assert(() => this.variable);
            var expectedMetadata = new Metadata<string>(this.variable, nameof(this.variable));

            Unit.Assert.AreEqual(expectedMetadata, actualMetadata);
        }

        [Test]
        public void Assert_WhenArgumentIsProperty_ReturnsCorrectMetadata()
        {
            var actualMetadata = Assert(() => Property);
            var expectedMetadata = new Metadata<string>(Property, nameof(Property));

            Unit.Assert.AreEqual(expectedMetadata, actualMetadata);
        }

        [Test]
        public void Assert_WhenArgumentIsConst_ThrowsApplicationException()
        {
            Unit.Assert.Throws<ApplicationException>(() => Assert(() => ANY_VALUE));
        }

        [Test]
        public void Assert_WhenArgumentIsStaticPropertyOrField_ThrowsApplicationException()
        {
            Unit.Assert.Throws<ApplicationException>(() => Assert(() => staticVariable));
            Unit.Assert.Throws<ApplicationException>(() => Assert(() => StaticProperty));
        }

        [Test]
        public void Assert_WhenArgumentIsMethod_ThrowsApplicationException()
        {
            Unit.Assert.Throws<ApplicationException>(() => Assert(() => Method()));
            Unit.Assert.Throws<ApplicationException>(() => Assert(() => StaticMethod()));
        }

        private string Method() => ANY_VALUE;
        private static string StaticMethod() => ANY_VALUE;
    }
}
