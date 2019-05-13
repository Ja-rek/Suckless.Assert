using System;
using System.Collections.Generic;
using System.Linq;

namespace Suckless.Asserts
{
    public static partial class Assertions
    {
        public static ref readonly Metadata<string> NotEmpty(in this Metadata<string> metadata, string message = null)
        {
            if (metadata.Value != null) 
            {
                var count = metadata.Value.Length;
                if (count == 0) throw ExceptionEmpty(count, metadata.Name, message);
            }

            return ref metadata;
        }

        public static ref readonly Metadata<IEnumerable<TValue>> NotEmpty<TValue>(
            in this Metadata<IEnumerable<TValue>> metadata,
            string message = null)
        {
            if (metadata.Value != null) 
            {
                var count = metadata.Value.Count();
                if (count == 0) throw ExceptionEmpty(count, metadata.Name, message);
            }

            return ref metadata;
        }

        public static ref readonly Metadata<TValue[]> NotEmpty<TValue>(in this Metadata<TValue[]> metadata,
            string message = null)
        {
            if (metadata.Value != null) 
            {
                var count = metadata.Value.Length;
                if (count == 0) throw ExceptionEmpty(count, metadata.Name, message);
            }

            return ref metadata;
        }

        private static ArgumentOutOfRangeException ExceptionEmpty(int count, string name , string message)
        {
            return new ArgumentOutOfRangeException(null, message == null 
                ? $"The {name} cannot be empty." 
                : message);
        }
    }
}
