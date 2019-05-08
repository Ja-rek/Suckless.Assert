using Unit = NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;
using Suckless.Asserts.Tests.Base;

namespace Suckless.Asserts.Tests.ExtensionMethods
{
    internal partial class NotEmptyTest : AssertBaseTest
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

            Unit.Assert.Throws<ArgumentOutOfRangeException>(() => Metadata(valueStub).NotEmpty());
            Unit.Assert.Throws<ArgumentOutOfRangeException>(() => Metadata(valueStub.ToArray()).NotEmpty());
        }

        [Test]
        public void NotEmpty_WhenAssertionFailedAdnCustomMessageWasSpecyfied_ThrowsExceptionWithCorrectMessage()
        {
            var valueStub = Enumerable.Empty<int>();
            var expectedMessageStub = "Any message";

            //Assert
            var actualMessage = Unit.Assert
                .Throws<ArgumentOutOfRangeException>(() => Metadata(valueStub).NotEmpty(expectedMessageStub))
                .Message;
            Unit.Assert.AreEqual(expectedMessageStub, actualMessage);

            var actualMessage2 = Unit.Assert
                .Throws<ArgumentOutOfRangeException>(() => Metadata(valueStub.ToArray()).NotEmpty(expectedMessageStub))
                .Message;
            Unit.Assert.AreEqual(expectedMessageStub, actualMessage2);
        }
    }
}
