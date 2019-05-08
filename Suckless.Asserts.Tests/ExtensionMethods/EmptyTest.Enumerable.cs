using Unit = NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;
using Suckless.Asserts.Tests.Base;

namespace Suckless.Asserts.Tests.ExtensionMethods
{
    internal partial class EmptyTest : AssertBaseTest
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

            Unit.Assert.Throws<ArgumentOutOfRangeException>(() => Metadata(valueStub).Empty());
            Unit.Assert.Throws<ArgumentOutOfRangeException>(() => Metadata(valueStub.ToArray()).Empty());
        }

        [Test]
        public void Empty_WhenAssertionFailedAdnCustomMessageWasSpecyfied__ThrowsExceptionWithCorrectMessage()
        {
            var valueStub = Enumerable.Range(1, 2);
            var expectedMessageStub = "Any message";

            //Asserts
            var actualMessage = Unit.Assert
                .Throws<ArgumentOutOfRangeException>(() => Metadata(valueStub).Empty(expectedMessageStub))
                .Message;
            Unit.Assert.AreEqual(expectedMessageStub, actualMessage);

            var actualMessage2 = Unit.Assert
                .Throws<ArgumentOutOfRangeException>(() => Metadata(valueStub.ToArray()).Empty(expectedMessageStub))
                .Message;
            Unit.Assert.AreEqual(expectedMessageStub, actualMessage2);
        }
    }
}
