using Unit = NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;
using Suckless.Asserts.Tests.Base;

namespace Suckless.Asserts.Tests.ExtensionMethods
{
    internal class CountGreaterThanTest : AssertBaseTest
    {
        [Test]
        public void CountGreaterThan_WhenEnumerableIsNull_DoNotThrowException()
        {
            IEnumerable<int> enumerableStub = null;
            int[] arrayStub = null;

            Metadata(enumerableStub).CountGreaterThan(2);
            Metadata(arrayStub).CountGreaterThan(2);
        }

        [Test]
        public void CountGreaterThan_WhenCountOfEnumerableIsGreaterThan3_DoNotThrowException()
        {
            var valueStub = Enumerable.Range(1, 5);

            Metadata(valueStub).CountGreaterThan(3);
            Metadata(valueStub.ToArray()).CountGreaterThan(3);
        }

        [Test]
        public void CountGreaterThan_WhenCountOfEnumerableIsNotGreaterThan10_ThrowsException()
        {
            var valueStub = Enumerable.Range(1, 5);

            Unit.Assert.Throws<ArgumentOutOfRangeException>(() => Metadata(valueStub).CountGreaterThan(10));
        }

        [Test]
        public void CountGreaterThan_WhenAssertionFailedAdnCustomMessageWasSpecyfied_ThrowsExceptionWithCorrectMessage()
        {
            var valueStub = Enumerable.Range(1, 5);
            var expectedMessageStub = "Any message";

            //Asserts
            var actualMessage = Unit.Assert
                .Throws<ArgumentOutOfRangeException>(() => Metadata(valueStub).CountGreaterThan(10, expectedMessageStub))
                .Message;
            Unit.Assert.AreEqual(expectedMessageStub, actualMessage);

            var actualMessage2 = Unit.Assert
                .Throws<ArgumentOutOfRangeException>(() => 
                    Metadata(valueStub.ToArray()).CountGreaterThan(10, expectedMessageStub))
                .Message;
            Unit.Assert.AreEqual(expectedMessageStub, actualMessage2);
        }
    }
}
