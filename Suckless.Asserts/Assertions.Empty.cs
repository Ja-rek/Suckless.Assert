using System;
using System.Collections.Generic;
using System.Linq;

namespace Suckless.Asserts
{
    public static partial class Assertions
    {
        public static ref readonly Metadata<string> Empty(in this Metadata<string> metadata, string message = null)
        {
            if (metadata.Value != null) 
            {
                var count = metadata.Value.Length;
                if (count != 0) throw ExceptionNotEmpty(count, metadata.Name, message);
            }

            return ref metadata;
        }

        public static ref readonly Metadata<IEnumerable<TValue>> Empty<TValue>(
            in this Metadata<IEnumerable<TValue>> metadata,
            string message = null)
        {
            if (metadata.Value != null) 
            {
                var count = metadata.Value.Count();
                if (count != 0) throw ExceptionNotEmpty(count, metadata.Name, message);
            }

            return ref metadata;
        }

        public static ref readonly Metadata<TValue[]> Empty<TValue>(in this Metadata<TValue[]> metadata,
            string message = null)
        {
            if (metadata.Value != null) 
            {
                var count = metadata.Value.Length;
                if (count != 0) throw ExceptionNotEmpty(count, metadata.Name, message);
            }

            return ref metadata;
        }

        private static ArgumentOutOfRangeException ExceptionNotEmpty(int count, string name , string message)
        {
            return new ArgumentOutOfRangeException(null, message == null 
                ? $"The {name} must be empty." 
                : message);
        }
    }
}
