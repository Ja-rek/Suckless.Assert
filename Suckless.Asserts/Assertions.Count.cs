using System;
using System.Collections.Generic;
using System.Linq;

namespace Suckless.Asserts
{
    public static partial class Assertions
    {
        public static ref readonly Metadata<string> Count(in this Metadata<string> metadata, 
            int exact, 
            string message = null)
        {
            if (metadata.Value != null) 
            {
                var length = metadata.Value.Length;
                if (length != exact) 
                {
                    throw new ArgumentOutOfRangeException(null, message == null 
                        ? $"The {metadata.Name} contains {length} character/s but should contain exact {exact}." 
                        : message);
                }
            }

            return ref metadata;
        }

        public static ref readonly Metadata<string> Count(in this Metadata<string> metadata, 
            int min, 
            int max, 
            string message = null)
        {
            if (metadata.Value != null) 
            {
                var length = metadata.Value.Length;
                if (length < min || length > max)
                {
                    throw new ArgumentOutOfRangeException(null, message == null 
                        ? $"The {metadata.Name} contains {length} character/s but should contain between {min} - {max}." 
                        : message);
                }
            }

            return ref metadata;
        }

        public static ref readonly Metadata<IEnumerable<TValue>> Count<TValue>(
            in this Metadata<IEnumerable<TValue>> metadata, 
            int exact,
            string message = null)
        {
            if (metadata.Value != null) 
            {
                var count = metadata.Value.Count();
                if (count != exact) throw ExceptionCountIsNotExact(count, exact, metadata.Name, message);
            }

            return ref metadata;
        }

        public static ref readonly Metadata<TValue[]> Count<TValue>(in this Metadata<TValue[]> metadata, 
            int exact,
            string message = null)
        {
            if (metadata.Value != null) 
            {
                var count = metadata.Value.Length;
                if (count != exact) throw ExceptionCountIsNotExact(count, exact, metadata.Name, message);
            }

            return ref metadata;
        }

        public static ref readonly Metadata<IEnumerable<TValue>> Count<TValue>(
            in this Metadata<IEnumerable<TValue>> metadata, 
            int min,
            int max,
            string message = null)
        {
            if (metadata.Value != null) 
            {
                var count = metadata.Value.Count();
                if (count < min || count > max)
                {
                    throw ExceptionCountIsNotInRange(count, min, max, metadata.Name, message);
                }
            }

            return ref metadata;
        }

        public static ref readonly Metadata<TValue[]> Count<TValue>(in this Metadata<TValue[]> metadata, 
            int min,
            int max,
            string message = null)
        {
            if (metadata.Value != null) 
            {
                var count = metadata.Value.Length;
                if (count < min || count > max)
                {
                    throw ExceptionCountIsNotInRange(count, min, max, metadata.Name, message);
                }
            }

            return ref metadata;
        }

        private static ArgumentOutOfRangeException ExceptionCountIsNotInRange(int count, int min, int max, string name , string message)
        {
            return new ArgumentOutOfRangeException(null, message == null 
                ? $"The {name} contains {count} item/s but should contain between {min} - {max}." 
                : message);
        }

        private static ArgumentOutOfRangeException ExceptionCountIsNotExact(int count, int exact, string name , string message)
        {
            return new ArgumentOutOfRangeException(null, message == null 
                ? $"The {name} contains {count} item/s but should contain exact {exact}." 
                : message);
        }
    }
}
