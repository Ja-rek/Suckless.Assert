using System;
using System.Collections.Generic;
using System.Linq;

namespace Suckless.Asserts
{
    public static partial class Assertions
    {
        public static ref readonly Metadata<string> CountLess(in this Metadata<string> metadata, 
            int max, 
            string message = null)
        {
            if (metadata.Value != null) 
            {
                var length = metadata.Value.Length;
                if (length > max)
                {
                    throw new ArgumentOutOfRangeException(null, message == null 
                        ? $"The {metadata.Name} contains {length} character/s but should contain less than {max}." 
                        : message);
                }
            }

            return ref metadata;
        }

        public static ref readonly Metadata<IEnumerable<TValue>> CountLess<TValue>(
            in this Metadata<IEnumerable<TValue>> metadata, 
            int max,
            string message = null)
        {
            if (metadata.Value != null) 
            {
                ThrowWhenCountIsNotLess(metadata.Value.Count(), max, metadata.Name, message);
            }

            return ref metadata;
        }

        public static ref readonly Metadata<TValue[]> CountLess<TValue>(
            in this Metadata<TValue[]> metadata, 
            int max,
            string message = null)
        {
            if (metadata.Value != null) 
            {
                ThrowWhenCountIsNotLess(metadata.Value.Length, max, metadata.Name, message);
            }

            return ref metadata;
        }

        private static void ThrowWhenCountIsNotLess(int count, int max, string name , string message)
        {
            if (count > max)
            {
                throw new ArgumentOutOfRangeException(null, message == null 
                    ? $"The {name} contains {count} item/s but should contain less than {max}."
                    : message);
            }
        }
    }
}
