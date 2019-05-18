using System;
using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;
using Suckless.Asserts.Tests.Base;

namespace Suckless.Asserts.Tests.ExtensionMethods
{
    internal partial class EmptyTest : AssertBaseTest<ArgumentOutOfRangeException> 
    {
        [Test]
        public void Empty_WhenEnumerableIsNull_DoesNotThrowException()
        {
            StubMetadata<IEnumerable<int>>(null).Empty();
            StubMetadata<int[]>(null).Empty();
        }

        [Test]
        public void Empty_WhenEnumerableIsEmpty_DoesNotThrowException()
        {
            var valueStub = Enumerable.Empty<int>();

            StubMetadata(valueStub).Empty();
            StubMetadata(valueStub.ToArray()).Empty();
        }

        [TestCase(null), TestCase("AnyName")]
        public void Empty_WhenEnumerableIsNotEmpty_ThrowsExceptionWithCorrectMessage(string fieldName)
        {
            var value = Enumerable.Range(1, 2);
            var expectedMessagePart = "must be empty.";

            AssertExceptionMessage<IEnumerable<int>>(() => StubMetadata(value, fieldName).Empty(), 
                expecteddName: fieldName, 
                expectedMessagePart);

            AssertExceptionMessage<int[]>(() => StubMetadata(value.ToArray(), fieldName).Empty(), 
                expecteddName: fieldName, 
                expectedMessagePart);
        }

        [TestCase(null), TestCase("AnyName")]
        public void Empty_WhenAssertionFailedAdnCustomMessageWasSpecyfied__ThrowsExceptionWithCorrectMessage(string fieldName)
        {
            var value = Enumerable.Range(1, 2);

            AssertCustomExceptionMessage(() => StubMetadata(value, fieldName).Empty(CUSTOM_MESSAGE), 
                expected: CUSTOM_MESSAGE);

            AssertCustomExceptionMessage(() => StubMetadata(value.ToArray(), fieldName).Empty(CUSTOM_MESSAGE), 
                expected: CUSTOM_MESSAGE);
        }
    }
}
