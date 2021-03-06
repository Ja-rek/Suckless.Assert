using System;
using System.Collections.Generic;
using System.Linq;

namespace Suckless.Asserts
{
    public static partial class Assertions
    {
        public static ref readonly Metadata<string> CountGreater(in this Metadata<string> metadata, 
            int min, 
            string message = null)
        {
            if (metadata.Value != null) 
            {
                var length = metadata.Value.Length;
                if (length < min)
                {
                    throw new ArgumentOutOfRangeException(null, message == null 
                        ? $"The {metadata.Name} contains {length} character/s but should contain more than {min}." 
                        : message);
                }
            }

            return ref metadata;
        }

        public static ref readonly Metadata<IEnumerable<TValue>> CountGreater<TValue>(
            in this Metadata<IEnumerable<TValue>> metadata, 
            int min,
            string message = null)
        {
            if (metadata.Value != null) 
            {
                var count = metadata.Value.Count();
                if (count < min) throw ExceptionCountIsNotGreater(count, min, metadata.Name, message);
            }

            return ref metadata;
        }

        public static ref readonly Metadata<TValue[]> CountGreater<TValue>(
            in this Metadata<TValue[]> metadata, 
            int min,
            string message = null)
        {
            if (metadata.Value != null) 
            {
                var count = metadata.Value.Length;
                if (count < min) throw ExceptionCountIsNotGreater(count, min, metadata.Name, message);
            }

            return ref metadata;
        }

        private static ArgumentOutOfRangeException ExceptionCountIsNotGreater(int count, int min, string name , string message)
        {
            return new ArgumentOutOfRangeException(null, message == null 
                ? $"The {name} contains {count} item/s but should contain more than {min}." 
                : message);
        }
    }
}
