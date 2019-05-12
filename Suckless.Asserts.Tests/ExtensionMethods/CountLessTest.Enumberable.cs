using System;
using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;
using Suckless.Asserts.Tests.Base;

namespace Suckless.Asserts.Tests.ExtensionMethods
{
    internal partial class CountLessTest : AssertBaseTest<ArgumentOutOfRangeException>
    {
        [Test]
        public void CountLess_WhenEnumerableIsNull_DoNotThrowException()
        {
            IEnumerable<int> enumerableStub = null;
            int[] arrayStub = null;

            Metadata(enumerableStub).CountLess(2);
            Metadata(arrayStub).CountLess(2);
        }

        [Test]
        public void CountLess_WhenCountOfEnumerableIsLess_DoNotThrowException()
        {
            var valueStub = Enumerable.Range(1, 5);

            Metadata(valueStub).CountLess(6);
            Metadata(valueStub.ToArray()).CountLess(6);
        }

        [Test]
        public void CountLess_WhenCountOfEnumerableIsNotLess_ThrowsExceptionWithCorrectMessage()
        {
            var valueStub = Enumerable.Range(1, 5);
            var messagePart = "contains 5 item/s but should contain less than 3.";

            AssertExceptionMessage(m => m.CountLess(3), valueStub, messagePart);
        }

        [Test]
        public void CountLess_WhenCountOfEnumerableIsNotLessAdnCustomMessageWasSpecyfied_ThrowsExceptionWithCorrectMessage()
        {
            var valueStub = Enumerable.Range(1, 5);
            var customeMessageStub = "Any message";

            AssertCustomExceptionMessage(m => m.CountLess(3, customeMessageStub), 
                valueStub, 
                customeMessageStub);

            AssertCustomExceptionMessage(m => m.CountLess(3, customeMessageStub), 
                valueStub.ToArray(), 
                customeMessageStub);
        }
    }
}
