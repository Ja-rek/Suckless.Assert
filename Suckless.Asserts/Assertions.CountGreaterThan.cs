using System;
using System.Collections.Generic;
using System.Linq;

namespace Suckless.Asserts
{
    public static partial class Assertions
    {
        public static ref readonly Metadata<IEnumerable<TValue>> CountGreaterThan<TValue>(
            in this Metadata<IEnumerable<TValue>> metadata, 
            int min,
            string message = null)
        {
            if (metadata.Value != null) 
            {
                var count = metadata.Value.Count();
                if (count < min) 
                {
                    throw new ArgumentOutOfRangeException(null, 
                        message == null ? Messages.CountGreaterThan(min, count): message);
                }
            }

            return ref metadata;
        }

        public static ref readonly Metadata<TValue[]> CountGreaterThan<TValue>(
            in this Metadata<TValue[]> metadata, 
            int min,
            string message = null)
        {
            if (metadata.Value != null) 
            {
                var count = metadata.Value.Length;
                if (count < min) 
                {
                    throw new ArgumentOutOfRangeException(null, 
                        message == null ? Messages.CountGreaterThan(min, count): message);
                }
            }

            return ref metadata;
        }
    }
}
