using System;
using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;
using Suckless.Asserts.Tests.Base;

namespace Suckless.Asserts.Tests.ExtensionMethods
{
    internal partial class CountGreaterTest : AssertBaseTest<ArgumentOutOfRangeException>
    {
        private IEnumerable<int> value = Enumerable.Range(1, 5);

        [Test]
        public void CountGreater_WhenEnumerableIsNull_DoNotThrowException()
        {
            StubMetadata<IEnumerable<int>>(null).CountGreater(2);
            StubMetadata<int[]>(null).CountGreater(2);
        }

        [Test]
        public void CountGreater_WhenCountOfEnumerableIsGreater_DoNotThrowException()
        {
            StubMetadata(value).CountGreater(3);
            StubMetadata(value.ToArray()).CountGreater(3);
        }

        [TestCase(null), TestCase("AnyName")]
        public void CountGreater_WhenCountOfEnumerableIsNotGreater_ThrowsExceptionWithCorrectMessage(string fieldName)
        {
            var expectedMessagePart = "contains 5 item/s but should contain more than 10.";

            AssertExceptionMessage<IEnumerable<int>>(() => StubMetadata(value, fieldName).CountGreater(10), 
                expecteddName: fieldName, 
                expectedMessagePart);

            AssertExceptionMessage<int[]>(() => StubMetadata(value.ToArray(), fieldName).CountGreater(10), 
                expecteddName: fieldName, 
                expectedMessagePart);
        }

        [TestCase(null), TestCase("AnyName")]
        public void CountGreater_WhenCountOfEnumerableIsNotGreaterAdnCustomMessageWasSpecyfied_ThrowsExceptionWithCorrectMessage(string fieldName)
        {
            AssertCustomExceptionMessage(() => StubMetadata(value, fieldName).CountGreater(10, CUSTOM_MESSAGE), 
                expected: CUSTOM_MESSAGE);

            AssertCustomExceptionMessage(() => StubMetadata(value.ToArray(), fieldName).CountGreater(10, CUSTOM_MESSAGE), 
                expected: CUSTOM_MESSAGE);
        }
    }
}
