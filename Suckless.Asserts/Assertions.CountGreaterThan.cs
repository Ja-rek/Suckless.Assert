using System;
using System.Collections.Generic;
using System.Linq;

namespace Suckless.Asserts
{
    public static partial class Assertions
    {
        public static ref readonly Metadata<IEnumerable<TValue>> CountGreaterThan<TValue>(
            in this Metadata<IEnumerable<TValue>> metadata, 
            int maxNumber,
            string message = null)
        {
            if (metadata.Value != null) 
            {
                var count = metadata.Value.Count();
                if (count < maxNumber) 
                {
                    throw new ArgumentOutOfRangeException(null, 
                        message == null ? Messages.CountGreaterThan(maxNumber, count): message);
                }
            }

            return ref metadata;
        }

        public static ref readonly Metadata<TValue[]> CountGreaterThan<TValue>(
            in this Metadata<TValue[]> metadata, 
            int maxNumber,
            string message = null)
        {
            if (metadata.Value != null) 
            {
                var count = metadata.Value.Length;
                if (count < maxNumber) 
                {
                    throw new ArgumentOutOfRangeException(null, 
                        message == null ? Messages.CountGreaterThan(maxNumber, count): message);
                }
            }

            return ref metadata;
        }
    }
}
