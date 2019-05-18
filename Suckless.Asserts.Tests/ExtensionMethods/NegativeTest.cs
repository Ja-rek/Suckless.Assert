using System;
using NUnit.Framework;
using Suckless.Asserts.Tests.Base;

namespace Suckless.Asserts.Tests.ExtensionMethods
{
    internal class NegativeTest : AssertBaseTest<ArgumentException>
    {
        [Test]
        public void Negative_WhenNumberIsNegative_DoesNotThrowException()
        {
            foreach (var x in NegativeMethodByTypes(value: -1)) x.AssertNegative.Invoke();
        }

        [TestCase(null), TestCase("AnyName")]
        public void Negative_WhenNumberIsNotNegative_ThrowsException(string fieldName)
        {
            var expectedMessagePart = "must be negative.";

            foreach (var x in NegativeMethodByTypes(value: 1, fieldName))
            {
                AssertExceptionMessage(() => x.AssertNegative.Invoke(), 
                    expectedType: x.Type, 
                    expectedName: fieldName, 
                    expectedMessagePart);
            }
        }

        [TestCase(null), TestCase("AnyName")]
        public void Negative_WhenNumberIsNotNegativeAdnCustomMessageWasSpecyfied_ThrowsExceptionWithCorrectMessage(string fieldName)
        {
            foreach (var x in NegativeMethodByTypes(value: 1, fieldName, CUSTOM_MESSAGE))
            {
                AssertCustomExceptionMessage(() => x.AssertNegative.Invoke(), expected: CUSTOM_MESSAGE);
            }
        }

        private (Type Type, Action AssertNegative)[] NegativeMethodByTypes(int value, 
            string fieldName = null, 
            string message = null)
        {
            return new(Type, Action)[] 
            {
                ( typeof(short), () => StubMetadata((short)value, fieldName).Negative(message)),
                ( typeof(int), () => StubMetadata((int)value, fieldName).Negative(message)),
                ( typeof(long), () => StubMetadata((long)value, fieldName).Negative(message)),
                ( typeof(decimal), () => StubMetadata((decimal)value, fieldName).Negative(message)),
                ( typeof(double), () => StubMetadata((double)value, fieldName).Negative(message)),
                ( typeof(float), () => StubMetadata((float)value, fieldName).Negative(message)),
            };
        }
    }
}
