using System;
using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;
using Suckless.Asserts.Tests.Base;

namespace Suckless.Asserts.Tests.ExtensionMethods
{
    internal partial class NotEmptyTest : AssertBaseTest<ArgumentOutOfRangeException> 
    {
        [Test]
        public void NotEmpty_WhenEnumerableIsNull_DoesNotThrowException()
        {
            StubMetadata<IEnumerable<int>>(null).NotEmpty();
            StubMetadata<int[]>(null).NotEmpty();
        }

        [Test]
        public void NotEmpty_WhenEnumerableIsNotEmpty_DoesNotThrowException()
        {
            var value = Enumerable.Range(1, 2);

            StubMetadata(value).NotEmpty();
            StubMetadata(value.ToArray()).NotEmpty();
        }

        [TestCase(null), TestCase("AnyName")]
        public void NotEmpty_WhenEnumerableIsEmpty_ThrowsException(string fieldName)
        {
            var value = Enumerable.Empty<int>();
            var expectedMessagePart = "cannot be empty.";

            AssertExceptionMessage<IEnumerable<int>>(() => StubMetadata(value, fieldName).NotEmpty(), 
                expecteddName: fieldName, 
                expectedMessagePart);

            AssertExceptionMessage<int[]>(() => StubMetadata(value.ToArray(), fieldName).NotEmpty(), 
                expecteddName: fieldName, 
                expectedMessagePart);
        }

        [TestCase(null), TestCase("AnyName")]
        public void NotEmpty_WhenAssertionFailedAdnCustomMessageWasSpecyfied_ThrowsExceptionWithCorrectMessage(string fieldName)
        {
            var value = Enumerable.Empty<int>();

            AssertCustomExceptionMessage(() => StubMetadata(value, fieldName).NotEmpty(CUSTOM_MESSAGE), 
                expected: CUSTOM_MESSAGE);

            AssertCustomExceptionMessage(() => StubMetadata(value.ToArray(), fieldName).NotEmpty(CUSTOM_MESSAGE), 
                expected: CUSTOM_MESSAGE);
        }
    }
}
