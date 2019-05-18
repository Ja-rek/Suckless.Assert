using System;
using NUnit.Framework;

namespace Suckless.Asserts.Tests.Base
{
    internal abstract class AssertBaseTest<TException> where TException : Exception
    {
        protected Metadata<TValue> StubMetadata<TValue>(TValue value, string name = null)
        {
            return new Metadata<TValue>(value, name);
        }

        protected const string CUSTOM_MESSAGE = "Custom message";
         
        protected void AssertCustomExceptionMessage(TestDelegate testDelegate, string expected)
        {
            var actualMessage = Assert.Throws<TException>(testDelegate).Message; 

            Assert.AreEqual(expected, actualMessage);
        }

        protected void AssertExceptionMessage<TValue>(TestDelegate testDelegate, 
            string expectedName, 
            string expectedMessagePart)
        {
            AssertExceptionMessage(testDelegate, typeof(TValue), expectedName, expectedMessagePart);
        }

        protected void AssertExceptionMessage(TestDelegate testDelegate, 
            Type expectedType, 
            string expectedName, 
            string expectedMessagePart)
        {
            var actualMessage = Assert.Throws<TException>(testDelegate).Message; 

            Assert.AreEqual($"The {expectedName ?? "value"}: {expectedType.Name} {expectedMessagePart}", actualMessage);
        }
    }
}
