using System;
using NUnit.Framework;
using Unit = NUnit.Framework;
using static Suckless.Asserts.Assertions;

namespace Suckless.Asserts.Tests.AssertExpressionAsArgumentTests
{
    internal partial class AssertExpressionAsArgumentTest : MetadataFactoryTestBase
    {
        private const string ANY_VALUE = "any value";
        private string variable = ANY_VALUE;
        private static string staticVariable = ANY_VALUE;
        private string Property { get; set; } = ANY_VALUE;
        private static string StaticProperty { get; set; } = ANY_VALUE;

        [Test]
        public void MetadataFrom_WhenArgumentIsVariable_ReturnsCorrectMetadata()
        {
            var variable = ANY_VALUE;

            var actualMetadata = Assert(() => variable);
            var expectedMetadata = new Metadata<string>(variable, nameof(variable));

            Unit.Assert.AreEqual(expectedMetadata, actualMetadata);
        }

        [Test]
        public void MetadataFrom_WhenArgumentIsThisVariable_ReturnsCorrectMetadata()
        {
            var actualMetadata = Assert(() => this.variable);
            var expectedMetadata = new Metadata<string>(this.variable, nameof(this.variable));

            Unit.Assert.AreEqual(expectedMetadata, actualMetadata);
        }

        [Test]
        public void MetadataFrom_WhenArgumentIsProperty_ReturnsCorrectMetadata()
        {
            var actualMetadata = Assert(() => Property);
            var expectedMetadata = new Metadata<string>(Property, nameof(Property));

            Unit.Assert.AreEqual(expectedMetadata, actualMetadata);
        }

        [Test]
        public void MetadataFrom_WhenArgumentIsConst_ThrowsApplicationException()
        {
            Unit.Assert.Throws<ApplicationException>(() => Assert(() => ANY_VALUE));
        }

        [Test]
        public void MetadataFrom_WhenArgumentIsStaticPropertyOrField_ThrowsApplicationException()
        {
            Unit.Assert.Throws<ApplicationException>(() => Assert(() => staticVariable));
            Unit.Assert.Throws<ApplicationException>(() => Assert(() => StaticProperty));
        }

        [Test]
        public void MetadataFrom_WhenArgumentIsMethod_ThrowsApplicationException()
        {
            Unit.Assert.Throws<ApplicationException>(() => Assert(() => Method()));
            Unit.Assert.Throws<ApplicationException>(() => Assert(() => StaticMethod()));
        }

        private string Method() => ANY_VALUE;
        private static string StaticMethod() => ANY_VALUE;
    }
}
