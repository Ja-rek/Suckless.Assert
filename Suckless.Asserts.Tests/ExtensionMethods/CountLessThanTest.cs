using Unit = NUnit.Framework;
using NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;
using Suckless.Asserts.Tests.Base;

namespace Suckless.Asserts.Tests.ExtensionMethods
{
    internal class CountLessThanTest : AssertBaseTest
    {
        [Test]
        public void CountLessThan_WhenEnumerableIsNull_DoNotThrowException()
        {
            IEnumerable<int> enumerableStub = null;
            int[] arrayStub = null;

            Metadata(enumerableStub).CountLessThan(2);
            Metadata(arrayStub).CountLessThan(2);
        }

        [Test]
        public void CountLessThan_WhenCountOfEnumerableIsLessThan6_DoNotThrowException()
        {
            var valueStub = Enumerable.Range(1, 5);

            Metadata(valueStub).CountLessThan(6);
            Metadata(valueStub.ToArray()).CountLessThan(6);
        }

        [Test]
        public void CountLessThan_WhenCountOfEnumerableIsNotLessThan3_ThrowsException()
        {
            var valueStub = Enumerable.Range(1, 5);

            Unit.Assert.Throws<ArgumentOutOfRangeException>(() => Metadata(valueStub).CountLessThan(3));
            Unit.Assert.Throws<ArgumentOutOfRangeException>(() => Metadata(valueStub.ToArray()).CountLessThan(3));
        }

        [Test]
        public void CountLessThan_WhenAssertionFailedAdnCustomMessageWasSpecyfied_ThrowsExceptionWithCorrectMessage()
        {
            var valueStub = Enumerable.Range(1, 5);
            var expectedMessageStub = "Any message";

            //Asserts
            var actualMessage = Unit.Assert
                .Throws<ArgumentOutOfRangeException>(() => Metadata(valueStub).CountLessThan(3, expectedMessageStub))
                .Message;
            Unit.Assert.AreEqual(expectedMessageStub, actualMessage);

            var actualMessage2 = Unit.Assert
                .Throws<ArgumentOutOfRangeException>(() => 
                    Metadata(valueStub.ToArray()).CountLessThan(3, expectedMessageStub))
                .Message;
            Unit.Assert.AreEqual(expectedMessageStub, actualMessage2);
        }
    }
}
