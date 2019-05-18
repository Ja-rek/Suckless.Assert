using System;
using System.Linq.Expressions;

namespace Suckless.Asserts
{
    public static partial class Assertions
    {
        public static void AssertNotNull<TValue>(TValue value, string name = null, string message = null)
        {
            var metadata = new Metadata<TValue>(value, name);

            if (metadata.Value == null) throw ExceptionNotNull(metadata.Value, metadata.Name, message);
        }

        public static void AssertNotNull<TValue>(Expression<Func<TValue>> expression, string message = null)
        {
            var metadata = MetadataFactory.MetadataFrom(expression);

            if (metadata.Value == null) throw ExceptionNotNull(metadata.Value, metadata.Name, message);
        }
    }
}
