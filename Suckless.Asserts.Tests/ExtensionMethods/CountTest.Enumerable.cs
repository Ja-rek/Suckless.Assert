using System;
using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;
using Suckless.Asserts.Tests.Base;

namespace Suckless.Asserts.Tests.ExtensionMethods
{
    internal partial class CountTest : AssertBaseTest<ArgumentOutOfRangeException> 
    {
        [Test]
        public void Count_WhenEnumerableIsNull_DoesNotThrowException()
        {
            IEnumerable<int> enumerable = null;
            int[] array = null;

            StubMetadata(enumerable).Count(2);
            StubMetadata(array).Count(2);
            StubMetadata(enumerable).Count(2, 3);
            StubMetadata(array).Count(2, 3);
        }

        [Test]
        public void Count_WhenCountIsExactAsExpectedNumber_DoesNotThrowException()
        {
            var value = Enumerable.Range(1, 3);

            StubMetadata(value).Count(3);
            StubMetadata(value.ToArray()).Count(3);
        }

        [Test]
        public void Count_WhenCountIsBetweenExpectedNumbers_DoesNotThrowException()
        {
            var value = Enumerable.Range(1, 3);

            StubMetadata(value).Count(2, 3);
            StubMetadata(value.ToArray()).Count(2, 3);
        }

        [TestCase(null), TestCase("AnyName")]
        public void Count_WhenCountIsNotExactAsExpectedNumber_ThrowsExceptionWithCorrectMessage(string fieldName)
        {
            var value = Enumerable.Range(1, 5);
            var expectedMessagePart = "contains 5 item/s but should contain exact 10.";

            AssertExceptionMessage<IEnumerable<int>>(() => StubMetadata(value, fieldName).Count(10), 
                expectedName: fieldName, 
                expectedMessagePart);

            AssertExceptionMessage<int[]>(() => StubMetadata(value.ToArray(), fieldName).Count(10), 
                expectedName: fieldName, 
                expectedMessagePart);
        }

        [TestCase(null, new int[] { 1, 2 }), 
        TestCase(null, new int[] { 1, 2, 3, 4, 5 }), 
        TestCase("AnyName", new int[] { 1, 2 }),
        TestCase("AnyName", new int[] { 1, 2, 3, 4, 5 })]
        public void Count_WhenCountIsNotBetweenExpectedNumbers_ThrowsExceptionWithCorrectMessage(string fieldName, IEnumerable<int> value)
        {
            var expectedMessagePart = $"contains {value.Count()} item/s but should contain between 3 - 4.";

            AssertExceptionMessage<IEnumerable<int>>(() => StubMetadata(value, fieldName).Count(3, 4), 
                expectedName: fieldName, 
                expectedMessagePart);

            AssertExceptionMessage<int[]>(() => StubMetadata(value.ToArray(), fieldName).Count(3, 4), 
                expectedName: fieldName, 
                expectedMessagePart);
        }

        [TestCase(null), TestCase("AnyName")]
        public void Count_WhenAssertionFailedAdnCustomMessageWasSpecyfied_ThrowsExceptionWithCorrectMessage(string fiedName)
        {
            var value = Enumerable.Range(1, 5);

            AssertCustomExceptionMessage(() => StubMetadata(value, fiedName).Count(6, 7, CUSTOM_MESSAGE), 
                expected: CUSTOM_MESSAGE);

            AssertCustomExceptionMessage(() => StubMetadata(value.ToArray(), fiedName).Count(6, 7, CUSTOM_MESSAGE), 
                expected: CUSTOM_MESSAGE);

            AssertCustomExceptionMessage(() => StubMetadata(value, fiedName).Count(6, CUSTOM_MESSAGE), 
                expected: CUSTOM_MESSAGE);

            AssertCustomExceptionMessage(() => StubMetadata(value.ToArray(), fiedName).Count(6, CUSTOM_MESSAGE), 
                expected: CUSTOM_MESSAGE);
        }
    }
}
