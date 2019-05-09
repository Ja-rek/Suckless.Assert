using System;
using System.Collections.Generic;
using System.Linq;

namespace Suckless.Asserts
{
    public static partial class Assertions
    {
        public static ref readonly Metadata<IEnumerable<TValue>> CountLessThan<TValue>(
            in this Metadata<IEnumerable<TValue>> metadata, 
            int max,
            string message = null)
        {
            if (metadata.Value != null) 
            {
                var count = metadata.Value.Count();
                if (count > max)
                {
                    throw new ArgumentOutOfRangeException(null, 
                        message == null ? Messages.CountLessThan(max, count): message);
                }
            }

            return ref metadata;
        }

        public static ref readonly Metadata<TValue[]> CountLessThan<TValue>(
            in this Metadata<TValue[]> metadata, 
            int max,
            string message = null)
        {
            if (metadata.Value != null) 
            {
                var count = metadata.Value.Length;
                if (count > max)
                {
                    throw new ArgumentOutOfRangeException(null, 
                        message == null ? Messages.CountLessThan(max, count): message);
                }
            }

            return ref metadata;
        }
    }
}
