using Unit = NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;
using Suckless.Asserts.Tests.Base;

namespace Suckless.Asserts.Tests.ExtensionMethods
{
    internal class CountTest : AssertBaseTest
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
        public void Count_WhenCountIs3_DoNotThrowException()
        {
            var valueStub = Enumerable.Range(1, 3);

            Metadata(valueStub).Count(3);
            Metadata(valueStub.ToArray()).Count(3);
        }

        [Test]
        public void Count_WhenCountIsBetween2And3_DoNotThrowException()
        {
            var valueStub = Enumerable.Range(1, 3);

            Metadata(valueStub).Count(2, 3);
            Metadata(valueStub.ToArray()).Count(2, 3);
        }

        [Test]
        public void Count_WhenCountIsNot10_ThrowsException()
        {
            var valueStub = Enumerable.Range(1, 5);

            Unit.Assert.Throws<ArgumentOutOfRangeException>(() => Metadata(valueStub).Count(10));
            Unit.Assert.Throws<ArgumentOutOfRangeException>(() => Metadata(valueStub.ToArray()).Count(10));
        }

        [Test]
        public void Count_WhenCountIsNotBetween1And5_ThrowsException()
        {
            var valueStub = Enumerable.Range(1, 6);

            Unit.Assert.Throws<ArgumentOutOfRangeException>(() => Metadata(valueStub).Count(1, 5));
            Unit.Assert.Throws<ArgumentOutOfRangeException>(() => Metadata(valueStub.ToArray()).Count(1, 5));
        }

        [Test]
        public void Count_WhenAssertionFailedAdnCustomMessageWasSpecyfied_ThrowsExceptionWithCorrectMessage()
        {
            var valueStub = Enumerable.Range(1, 5);
            var expectedMessageStub = "Any message";

            AssertExceptionMessage(() => 
                Metadata(valueStub).Count(6, 7, expectedMessageStub), expectedMessageStub);

            AssertExceptionMessage(() => 
                Metadata(valueStub).Count(6, expectedMessageStub), expectedMessageStub);
            
            AssertExceptionMessage(() => 
                Metadata(valueStub.ToArray()).Count(6, 7, expectedMessageStub), expectedMessageStub);

            AssertExceptionMessage(() => 
                Metadata(valueStub.ToArray()).Count(6, expectedMessageStub), expectedMessageStub);
        }

        public void AssertExceptionMessage(TestDelegate code, string expectedMessageStub)
        {
            var actualMessage = Unit.Assert .Throws<ArgumentOutOfRangeException>(code) .Message;
            Unit.Assert.AreEqual(expectedMessageStub, actualMessage);
        }
    }
}
