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
        public void Empty_WhenEnumerableIsNull_DoNotThrowException()
        {
            IEnumerable<int> enumerableStub = null;
            int[] arrayStub = null;

            Metadata(enumerableStub).Empty();
            Metadata(arrayStub).Empty();
        }

        [Test]
        public void Empty_WhenEnumerableIsEmpty_DoNotThrowException()
        {
            var valueStub = Enumerable.Empty<int>();

            Metadata(valueStub).Empty();
            Metadata(valueStub.ToArray()).Empty();
        }

        [Test]
        public void Empty_WhenEnumerableIsNotEmpty_ThrowsException()
        {
            var valueStub = Enumerable.Range(1, 2);
            var messagePart = "must be empty.";

            AssertExceptionMessage(m => m.Empty(), valueStub, messagePart);
            AssertExceptionMessage(m => m.Empty(), valueStub.ToArray(), messagePart);
        }

        [Test]
        public void Empty_WhenAssertionFailedAdnCustomMessageWasSpecyfied__ThrowsExceptionWithCorrectMessage()
        {
            var valueStub = Enumerable.Range(1, 2);
            var customeMessageStub = "Any message";

            AssertCustomExceptionMessage(m => m.Empty(customeMessageStub), 
                valueStub, 
                customeMessageStub);

            AssertCustomExceptionMessage(m => m.Empty(customeMessageStub), 
                valueStub.ToArray(), 
                customeMessageStub);
        }
    }
}
