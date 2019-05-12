using System;
using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;
using Suckless.Asserts.Tests.Base;

namespace Suckless.Asserts.Tests.ExtensionMethods
{
    internal partial class CountGreaterTest : AssertBaseTest<ArgumentOutOfRangeException>
    {
        [Test]
        public void CountGreater_WhenEnumerableIsNull_DoNotThrowException()
        {
            IEnumerable<int> enumerableStub = null;
            int[] arrayStub = null;

            Metadata(enumerableStub).CountGreater(2);
            Metadata(arrayStub).CountGreater(2);
        }

        [Test]
        public void CountGreater_WhenCountOfEnumerableIsGreater_DoNotThrowException()
        {
            var valueStub = Enumerable.Range(1, 5);

            Metadata(valueStub).CountGreater(3);
            Metadata(valueStub.ToArray()).CountGreater(3);
        }

        [Test]
        public void CountGreater_WhenCountOfEnumerableIsNotGreater_ThrowsExceptionWithCorrectMessage()
        {
            var valueStub = Enumerable.Range(1, 5);
            var messagePart = "contains 5 item/s but should contain more than 10.";

            AssertExceptionMessage(m => m.CountGreater(10), valueStub, messagePart);
        }

        [Test]
        public void CountGreater_WhenCountOfEnumerableIsNotGreaterAdnCustomMessageWasSpecyfied_ThrowsExceptionWithCorrectMessage()
        {
            var valueStub = Enumerable.Range(1, 5);
            var customeMessageStub = "Any message";

            AssertCustomExceptionMessage(m => m.CountGreater(10, customeMessageStub), 
                valueStub, 
                customeMessageStub);

            AssertCustomExceptionMessage(m => m.CountGreater(10, customeMessageStub), 
                valueStub.ToArray(), 
                customeMessageStub);
        }
    }
}
