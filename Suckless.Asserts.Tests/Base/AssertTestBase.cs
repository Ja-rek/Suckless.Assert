using System;
using NUnit.Framework;

namespace Suckless.Asserts.Tests.Base
{
    internal abstract class AssertBaseTest<TException> where TException : Exception
    {
        public Metadata<TValue> Metadata<TValue>(TValue value, string name = null)
        {
            return new Metadata<TValue>(value, name);
        }

        protected void AssertCustomExceptionMessage<TValue>(Action<Metadata<TValue>> action, 
            object value, 
            string customMessage) where TValue : IConvertible 
        {
            var castedValue = (TValue)Convert.ChangeType(value, typeof(TValue));

            AssertCustomExceptionMessage<TValue>(action, castedValue, customMessage);
        }

        protected void AssertCustomExceptionMessage<TValue>(Action<Metadata<TValue>> action, 
            TValue value, 
            string customMessage)
        {
            var anyName = "anyName";
            var castedValue = value;

            var actualMessage = Assert.Throws<TException>(() => 
                action(Metadata<TValue>(castedValue, anyName))).Message; 

            Assert.AreEqual(customMessage, actualMessage);
        }

        public void AssertExceptionMessage<TValue>(Action<Metadata<TValue>> action, object value, string messagePart)
             where TValue : IConvertible
        {
            var castedValue = (TValue)Convert.ChangeType(value, typeof(TValue));

            AssertExceptionMessage<TValue>(action, castedValue, messagePart);
        }

        public void AssertExceptionMessage<TValue>(Action<Metadata<TValue>> action, TValue value, string messagePart)
        {
            var anyName = "anyName";

            var actualMessageWithFieldName = Assert.Throws<TException>(() => 
                action(Metadata<TValue>(value, anyName))).Message; 

            var actualMessageWithoutFieldName = Assert.Throws<TException>(() => 
                action(Metadata<TValue>(value))).Message; 

            Assert.AreEqual($"The {anyName}: {typeof(TValue).Name} {messagePart}", actualMessageWithFieldName);
            Assert.AreEqual($"The value: {typeof(TValue).Name} {messagePart}", actualMessageWithoutFieldName);
        }

    }
}
