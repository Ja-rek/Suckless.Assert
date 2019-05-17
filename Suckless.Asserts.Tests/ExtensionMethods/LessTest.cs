using System;
using NUnit.Framework;
using Suckless.Asserts.Tests.Base;

namespace Suckless.Asserts.Tests.ExtensionMethods
{
    internal class LessTest : AssertBaseTest<ArgumentOutOfRangeException> 
    {
        [Test]
        public void Less_WhenNumberIsLessThanExpectedNumber_DoNotThrowException()
        {
            foreach (var x in LessMethodByTypes(max: 2, value: 1)) x.AssertLess.Invoke();
        }

        [TestCase(null), TestCase("AnyName")]
        public void Less_WhenNumberIsNotLessThanExpectedNumber_ThrowsExceptionWithCorrectMessage(string fieldName)
        {
            var expectedMessagePart = $"contains the number 2 but should contain a number less than 1.";

            foreach (var x in LessMethodByTypes(max: 1, value: 2, fieldName))
            {
                AssertExceptionMessage(() => x.AssertLess.Invoke(), 
                    expectedType: x.Type, 
                    expectedName: fieldName, 
                    expectedMessagePart);
            }
        }

        [TestCase(null), TestCase("AnyName")]
        public void Less_WhenAssertionFailedAdnCustomMessageWasSpecyfied_ThrowsExceptionWithCorrectMessage(string fieldName)
        {
            foreach (var x in LessMethodByTypes(max: 1, value: 2, fieldName, CUSTOM_MESSAGE))
            {
                AssertCustomExceptionMessage(() => x.AssertLess.Invoke(), expected: CUSTOM_MESSAGE);
            }
        }

        private (Type Type, Action AssertLess)[] LessMethodByTypes(int max, 
            int value, 
            string fieldName = null, 
            string message = null)
        {
            return new(Type, Action)[] 
            {
                ( typeof(short), () => StubMetadata((short)value, fieldName).Less((short)max, message) ),
                ( typeof(ushort), () => StubMetadata((ushort)value, fieldName).Less((ushort)max, message) ),
                ( typeof(int), () => StubMetadata((int)value, fieldName).Less((int)max, message) ),
                ( typeof(uint), () => StubMetadata((uint)value, fieldName).Less((uint)max, message)),
                ( typeof(long), () => StubMetadata((long)value, fieldName).Less((long)max, message)),
                ( typeof(ulong), () => StubMetadata((ulong)value, fieldName).Less((ulong)max, message)),
                ( typeof(decimal), () => StubMetadata((decimal)value, fieldName).Less((decimal)max, message)),
                ( typeof(double), () => StubMetadata((double)value, fieldName).Less((double)max, message)),
                ( typeof(float), () => StubMetadata((float)value, fieldName).Less((float)max, message)),
            };
        }
    }
}
