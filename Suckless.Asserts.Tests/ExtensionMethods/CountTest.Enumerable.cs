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
        public void Count_WhenEnumerableIsNull_DoNotThrowException()
        {
            IEnumerable<int> enumerableStub = null;
            int[] arrayStub = null;

            Metadata(enumerableStub).Count(2);
            Metadata(arrayStub).Count(2);
            Metadata(enumerableStub).Count(2, 3);
            Metadata(arrayStub).Count(2, 3);
        }

        [Test]
        public void Count_WhenCountIsExactAsExpectedNumber_DoNotThrowException()
        {
            var valueStub = Enumerable.Range(1, 3);

            Metadata(valueStub).Count(3);
            Metadata(valueStub.ToArray()).Count(3);
        }

        [Test]
        public void Count_WhenCountIsBetweenExpectedNumbers_DoNotThrowException()
        {
            var valueStub = Enumerable.Range(1, 3);

            Metadata(valueStub).Count(2, 3);
            Metadata(valueStub.ToArray()).Count(2, 3);
        }

        [Test]
        public void Count_WhenCountIsNotExactAsExpectedNumber_ThrowsExceptionWithCorrectMessage()
        {
            var valueStub = Enumerable.Range(1, 5);
            var messagePart = "contains 5 item/s but should contain exact 10.";

            AssertExceptionMessage(m => m.Count(10), valueStub, messagePart);
            AssertExceptionMessage(m => m.Count(10), valueStub.ToArray(), messagePart);
        }

        [Test]
        public void Count_WhenCountIsNotBetweenExpectedNumbers_ThrowsExceptionWithCorrectMessage()
        {
            var valueStub = Enumerable.Range(1, 6);
            var messagePart = "contains 6 item/s but should contain between 1 - 5.";

            AssertExceptionMessage(m => m.Count(1, 5), valueStub, messagePart);
            AssertExceptionMessage(m => m.Count(1, 5), valueStub.ToArray(), messagePart);
        }

        [Test]
        public void Count_WhenAssertionFailedAdnCustomMessageWasSpecyfied_ThrowsExceptionWithCorrectMessage()
        {
            var valueStub = Enumerable.Range(1, 5);
            var customMessageStub = "Any message";

            AssertCustomExceptionMessage(m => m.Count(6, 7, customMessageStub), 
                valueStub, 
                customMessageStub);

            AssertCustomExceptionMessage(m => m.Count(6, 7, customMessageStub), 
                valueStub.ToArray(), 
                customMessageStub);

            AssertCustomExceptionMessage(m => m.Count(6, customMessageStub),
                valueStub, 
                customMessageStub);

            AssertCustomExceptionMessage(m => m.Count(6, customMessageStub),
                valueStub.ToArray(), 
                customMessageStub);
        }
    }
}
