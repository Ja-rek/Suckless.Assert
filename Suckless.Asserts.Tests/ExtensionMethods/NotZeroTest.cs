using System;
using NUnit.Framework;
using Suckless.Asserts.Tests.Base;

namespace Suckless.Asserts.Tests.ExtensionMethods
{
    internal class NotZeroTest : AssertBaseTest<ArgumentException>
    {
        [Test]
        public void NotZero_WhenNumberIsNotZero_DoesNotThrowException()
        {
            foreach (var x in NotZeroMethodByTypes(value: 1)) x.AssertNotZero.Invoke();
        }

        [TestCase(null), TestCase("AnyName")]
        public void NotZero_WhenNumberIsNotNotZero_ThrowsException(string fieldName)
        {
            var expectedMessagePart = "cannot be zero.";

            foreach (var x in NotZeroMethodByTypes(value: 0, fieldName))
            {
                AssertExceptionMessage(() => x.AssertNotZero.Invoke(), 
                    expectedType: x.Type, 
                    expectedName: fieldName, 
                    expectedMessagePart);
            }
        }

        [TestCase(null), TestCase("AnyName")]
        public void NotZero_WhenNumberIsNotNotZeroAdnCustomMessageWasSpecyfied_ThrowsExceptionWithCorrectMessage(string fieldName)
        {
            foreach (var x in NotZeroMethodByTypes(value: 0, fieldName, CUSTOM_MESSAGE))
            {
                AssertCustomExceptionMessage(() => x.AssertNotZero.Invoke(), expected: CUSTOM_MESSAGE);
            }
        }

        private (Type Type, Action AssertNotZero)[] NotZeroMethodByTypes(int value, 
            string fieldName = null, 
            string message = null)
        {
            return new(Type, Action)[] 
            {
                ( typeof(short), () => StubMetadata((short)value, fieldName).NotZero(message)),
                ( typeof(int), () => StubMetadata((int)value, fieldName).NotZero(message)),
                ( typeof(long), () => StubMetadata((long)value, fieldName).NotZero(message)),
                ( typeof(decimal), () => StubMetadata((decimal)value, fieldName).NotZero(message)),
                ( typeof(double), () => StubMetadata((double)value, fieldName).NotZero(message)),
                ( typeof(float), () => StubMetadata((float)value, fieldName).NotZero(message)),
            };
        }
    }
}
