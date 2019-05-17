using System;
using NUnit.Framework;
using Suckless.Asserts.Tests.Base;

namespace Suckless.Asserts.Tests.ExtensionMethods
{
    internal class ZeroTest : AssertBaseTest<ArgumentException>
    {
        [Test]
        public void Zero_WhenNumberIsZero_DoNotThrowException()
        {
            foreach (var x in ZeroMethodByTypes(value: 0)) x.AssertZero.Invoke();
        }

        [Test, TestCase(null), TestCase("AnyName")]
        public void Zero_WhenNumberIsNotZero_ThrowsException(string fieldName)
        {
            var expectedMessagePart = "must be zero.";

            foreach (var x in ZeroMethodByTypes(value: 1, fieldName))
            {
                AssertExceptionMessage(() => x.AssertZero.Invoke(), 
                    expectedType: x.Type, 
                    expectedName: fieldName, 
                    expectedMessagePart);
            }
        }

        [Test, TestCase(null), TestCase("AnyName")]
        public void Zero_WhenNumberIsNotZeroAdnCustomMessageWasSpecyfied_ThrowsExceptionWithCorrectMessage(string fieldName)
        {
            foreach (var x in ZeroMethodByTypes(value: 1, fieldName, CUSTOM_MESSAGE))
            {
                AssertCustomExceptionMessage(() => x.AssertZero.Invoke(), expected: CUSTOM_MESSAGE);
            }
        }

        private (Type Type, Action AssertZero)[] ZeroMethodByTypes(int value, 
            string fieldName = null, 
            string message = null)
        {
            return new(Type, Action)[] 
            {
                ( typeof(short), () => StubMetadata((short)value, fieldName).Zero(message)),
                ( typeof(int), () => StubMetadata((int)value, fieldName).Zero(message)),
                ( typeof(long), () => StubMetadata((long)value, fieldName).Zero(message)),
                ( typeof(decimal), () => StubMetadata((decimal)value, fieldName).Zero(message)),
                ( typeof(double), () => StubMetadata((double)value, fieldName).Zero(message)),
                ( typeof(float), () => StubMetadata((float)value, fieldName).Zero(message)),
            };
        }
    }
}
