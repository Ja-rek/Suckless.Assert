using Unit = NUnit.Framework;
using System;
using NUnit.Framework;
using Suckless.Asserts.Tests.Base;

namespace Suckless.Asserts.Tests.ExtensionMethods
{
    internal class RangeTest : AssertBaseTest<ArgumentOutOfRangeException> 
    {
        [Test]
        public void Range_WhenNumberIsInRange_DoNotThrowException()
        {
            foreach (var x in RangeMethodByTypes(min: 4, max: 6, value: 5)) x.AssertRange.Invoke();
        }

        [Test]
        [TestCase(null, 8), 
        TestCase(null, 16), 
        TestCase("AnyName", 8), 
        TestCase("AnyName", 16)]
        public void Range_WhenNumberIsNotInRange_ThrowsException(string fieldName, int value)
        {
            var expectedMessagePart = $"contains the number {value} but should contain a number in range 10 - 15.";

            foreach (var x in RangeMethodByTypes(min: 10, max: 15, value, fieldName))
            {
                AssertExceptionMessage(() => x.AssertRange.Invoke(), 
                    expectedType: x.Type, 
                    expectedName: fieldName,
                    expectedMessagePart);
            }
        }

        [Test]
        [TestCase(null, 8), 
        TestCase(null, 16), 
        TestCase("AnyName", 8), 
        TestCase("AnyName", 16)]
        public void Range_WhenNumberIsNotInRangeAndCustomMessageWasSpecyfied_ThrowsExceptionWithCorrectMessage(string fieldName, int value)
        {
            foreach (var x in RangeMethodByTypes(min: 10, max: 15, value, fieldName, CUSTOM_MESSAGE))
            {
                AssertCustomExceptionMessage(() => x.AssertRange.Invoke(), 
                    expected: CUSTOM_MESSAGE);
            }
        }

        private (Type Type, Action AssertRange)[] RangeMethodByTypes(int min, 
            int max, 
            int value, 
            string fieldName = null, 
            string message = null)
        {
            return new(Type, Action)[] 
            {
                ( typeof(short), () => StubMetadata((short)value, fieldName).Range((short)min, (short)max, message) ),
                ( typeof(ushort), () => StubMetadata((ushort)value, fieldName).Range((ushort)min, (ushort)max, message) ),
                ( typeof(int), () => StubMetadata((int)value, fieldName).Range((int)min, (int)max, message) ),
                ( typeof(uint), () => StubMetadata((uint)value, fieldName).Range((uint)min, (uint)max, message)),
                ( typeof(long), () => StubMetadata((long)value, fieldName).Range((long)min, (long)max, message)),
                ( typeof(ulong), () => StubMetadata((ulong)value, fieldName).Range((ulong)min, (ulong)max, message)),
                ( typeof(decimal), () => StubMetadata((decimal)value, fieldName).Range((decimal)min, (decimal)max, message)),
                ( typeof(double), () => StubMetadata((double)value, fieldName).Range((double)min, (double)max, message)),
                ( typeof(float), () => StubMetadata((float)value, fieldName).Range((float)min, (float)max, message)),
            };
        }
    }
}
