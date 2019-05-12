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
        public void NotEmpty_WhenEnumerableIsNull_DoNotThrowException()
        {
            IEnumerable<int> enumerableStub = null;
            int[] arrayStub = null;

            Metadata(enumerableStub).NotEmpty();
            Metadata(arrayStub).NotEmpty();
        }

        [Test]
        public void NotEmpty_WhenEnumerableIsNotEmpty_DoNotThrowException()
        {
            var valueStub = Enumerable.Range(1, 2);

            Metadata(valueStub).NotEmpty();
            Metadata(valueStub.ToArray()).NotEmpty();
        }

        [Test]
        public void NotEmpty_WhenEnumerableIsEmpty_ThrowsException()
        {
            var valueStub = Enumerable.Empty<int>();
            var messagePart = "cannot be empty.";

            AssertExceptionMessage(m => m.NotEmpty(), valueStub, messagePart);
            AssertExceptionMessage(m => m.NotEmpty(), valueStub.ToArray(), messagePart);
        }

        [Test]
        public void NotEmpty_WhenAssertionFailedAdnCustomMessageWasSpecyfied_ThrowsExceptionWithCorrectMessage()
        {
            var valueStub = Enumerable.Empty<int>();
            var customeMessageStub = "Any message";

            AssertCustomExceptionMessage(m => m.NotEmpty(customeMessageStub), valueStub, customeMessageStub);
            AssertCustomExceptionMessage(m => m.NotEmpty(customeMessageStub), valueStub.ToArray(), customeMessageStub);
        }
    }
}
