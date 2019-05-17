using System;
using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;
using Suckless.Asserts.Tests.Base;

namespace Suckless.Asserts.Tests.ExtensionMethods
{
    internal partial class CountLessTest : AssertBaseTest<ArgumentOutOfRangeException>
    {
        private IEnumerable<int> value = Enumerable.Range(1, 5);

        [Test]
        public void CountLess_WhenEnumerableIsNull_DoNotThrowException()
        {
            StubMetadata<IEnumerable<int>>(null).CountLess(2);
            StubMetadata<int[]>(null).CountLess(2);
        }

        [Test]
        public void CountLess_WhenCountOfEnumerableIsLess_DoNotThrowException()
        {
            StubMetadata(value).CountLess(6);
            StubMetadata(value.ToArray()).CountLess(6);
        }

        [TestCase(null), TestCase("AnyName")]
        public void CountLess_WhenCountOfEnumerableIsNotLess_ThrowsExceptionWithCorrectMessage(string fieldName)
        {
            var expectedMessagePart = "contains 5 item/s but should contain less than 3.";

            AssertExceptionMessage<IEnumerable<int>>(() => StubMetadata(value, fieldName).CountLess(3), 
                expecteddName: fieldName, 
                expectedMessagePart);

            AssertExceptionMessage<int[]>(() => StubMetadata(value.ToArray(), fieldName).CountLess(3), 
                expecteddName: fieldName, 
                expectedMessagePart);
        }

        [TestCase(null), TestCase("AnyName")]
        public void CountLess_WhenCountOfEnumerableIsNotLessAdnCustomMessageWasSpecyfied_ThrowsExceptionWithCorrectMessage(string fieldName)
        {
            AssertCustomExceptionMessage(() => StubMetadata(value, fieldName).CountLess(3, CUSTOM_MESSAGE), 
                expected: CUSTOM_MESSAGE);

            AssertCustomExceptionMessage(() => StubMetadata(value.ToArray(), fieldName).CountLess(3, CUSTOM_MESSAGE), 
                expected: CUSTOM_MESSAGE);
        }
    }
}
