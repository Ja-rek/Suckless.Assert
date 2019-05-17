using System;
using NUnit.Framework;
using Suckless.Asserts.Tests.Base;

namespace Suckless.Asserts.Tests.ExtensionMethods
{
    internal class GreaterTest : AssertBaseTest<ArgumentOutOfRangeException> 
    {
        [Test]
        public void Greater_WhenNumberIsGreaterThanExpectedNumber_DoNotThrowException()
        {
            foreach (var x in GreaterMethodByTypes(min: 1, value: 2))
            {
                x.AssertGreater.Invoke();
            }
        }

        [TestCase(null), TestCase("AnyName")]
        public void Greater_WhenNumberIsNotGreaterThanExpectedNumber_ThrowsExceptionWithCorrectMessage(string fieldName)
        {
            var expectedMessagePart = $"contains the number 1 but should contain a number greater than 2.";

            foreach (var x in GreaterMethodByTypes(min: 2, value: 1, fieldName))
            {
                AssertExceptionMessage(() => x.AssertGreater.Invoke(), 
                    expectedType: x.Type, 
                    expectedName: fieldName, 
                    expectedMessagePart);
            }
        }

        [TestCase(null), TestCase("AnyName")]
        public void Greater_WhenAssertionFailedAdnCustomMessageWasSpecyfied_ThrowsExceptionWithCorrectMessage(string fieldName)
        {
            foreach (var x in GreaterMethodByTypes(min: 2, value: 1, fieldName, CUSTOM_MESSAGE))
            {
                AssertCustomExceptionMessage(() => x.AssertGreater.Invoke(), expected: CUSTOM_MESSAGE);
            }
        }

        private (Type Type, Action AssertGreater)[] GreaterMethodByTypes(int min, 
            int value, 
            string fieldName = null, 
            string message = null)
        {
            return new(Type, Action)[] 
            {
                ( typeof(short), () => StubMetadata((short)value, fieldName).Greater((short)min, message)),
                ( typeof(ushort), () => StubMetadata((ushort)value, fieldName).Greater((ushort)min, message)),
                ( typeof(int), () => StubMetadata((int)value, fieldName).Greater((int)min, message)),
                ( typeof(uint), () => StubMetadata((uint)value, fieldName).Greater((uint)min, message)),
                ( typeof(long), () => StubMetadata((long)value, fieldName).Greater((long)min, message)),
                ( typeof(ulong), () => StubMetadata((ulong)value, fieldName).Greater((ulong)min, message)),
                ( typeof(decimal), () => StubMetadata((decimal)value, fieldName).Greater((decimal)min, message)),
                ( typeof(double), () => StubMetadata((double)value, fieldName).Greater((double)min, message)),
                ( typeof(float), () => StubMetadata((float)value, fieldName).Greater((float)min, message)),
            };
        }
    }
}
