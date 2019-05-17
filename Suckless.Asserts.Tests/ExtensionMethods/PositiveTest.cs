using System;
using NUnit.Framework;
using Suckless.Asserts.Tests.Base;

namespace Suckless.Asserts.Tests.ExtensionMethods
{
    internal class PositiveTest : AssertBaseTest<ArgumentException>
    {
        [Test]
        public void Positive_WhenNumberIsPositive_DoNotThrowException()
        {
            foreach (var x in PositiveMethodByTypes(value: 1)) x.PositiveMethod.Invoke();
        }

        [Test, TestCase(null), TestCase("AnyName")]
        public void Positive_WhenNumberIsNotPositive_ThrowsException(string fieldName)
        {
            var expectedMessagePart = "must be positive.";

            foreach (var x in PositiveMethodByTypes(value: -1, fieldName))
            {
                AssertExceptionMessage(() => x.PositiveMethod.Invoke(), 
                    expectedType: x.Type, 
                    expectedName: fieldName, 
                    expectedMessagePart);
            }
        }

        [Test, TestCase(null), TestCase("AnyName")]
        public void Positive_WhenNumberIsNotPositiveAdnCustomMessageWasSpecyfied_ThrowsExceptionWithCorrectMessage(string fieldName)
        {
            var customMessage = "Any message";

            foreach (var x in PositiveMethodByTypes(value: -1, fieldName, customMessage))
            {
                AssertCustomExceptionMessage(() => x.PositiveMethod.Invoke(), expected: customMessage);
            }
        }

        private (Type Type, Action PositiveMethod)[] PositiveMethodByTypes(int value, 
            string fieldName = null, 
            string message = null)
        {
            return new(Type, Action)[] 
            {
                ( typeof(short), () => StubMetadata((short)value, fieldName).Positive(message)),
                ( typeof(int), () => StubMetadata((int)value, fieldName).Positive(message)),
                ( typeof(long), () => StubMetadata((long)value, fieldName).Positive(message)),
                ( typeof(decimal), () => StubMetadata((decimal)value, fieldName).Positive(message)),
                ( typeof(double), () => StubMetadata((double)value, fieldName).Positive(message)),
                ( typeof(float), () => StubMetadata((float)value, fieldName).Positive(message)),
            };
        }
    }
}
