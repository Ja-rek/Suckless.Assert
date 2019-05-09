using System;
using System.Collections.Generic;
using System.Linq;

namespace Suckless.Asserts
{
    public static partial class Assertions
    {
        public static ref readonly Metadata<IEnumerable<TValue>> Count<TValue>(
            in this Metadata<IEnumerable<TValue>> metadata, 
            int exact,
            string message = null)
        {
            if (metadata.Value != null) 
            {
                var count = metadata.Value.Count();
                if (count != exact) 
                {
                    throw new ArgumentOutOfRangeException(null, 
                        message == null ? Messages.CountGreaterThan(exact, count): message);
                }
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
                if (count != exact) 
                {
                    throw new ArgumentOutOfRangeException(null, 
                        message == null ? Messages.CountGreaterThan(exact, count): message);
                }
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
                    throw new ArgumentOutOfRangeException(null, 
                        message == null ? Messages.CountGreaterThan(min, count): message);
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
                    throw new ArgumentOutOfRangeException(null, 
                        message == null ? Messages.CountGreaterThan(min, count): message);
                }
            }

            return ref metadata;
        }
    }
}
