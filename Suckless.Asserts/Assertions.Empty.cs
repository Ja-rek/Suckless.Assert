using System;
using System.Collections.Generic;
using System.Linq;

namespace Suckless.Asserts
{
    public static partial class Assertions
    {
        public static ref readonly Metadata<string> Empty(in this Metadata<string> metadata, string message = null)
        {
            if (metadata.Value != null && metadata.Value.Length != 0) 
            {
                throw new ArgumentOutOfRangeException(null, 
                    message == null ? metadata.Name + Messages.MUST_BE_EMPTY : message);
            }

            return ref metadata;
        }

        public static ref readonly Metadata<IEnumerable<TValue>> Empty<TValue>(
            in this Metadata<IEnumerable<TValue>> metadata,
            string message = null)
        {
            if (metadata.Value != null && metadata.Value.Count() != 0) 
            {
                throw new ArgumentOutOfRangeException(null, 
                    message == null ? metadata.Name + Messages.MUST_BE_EMPTY : message);
            }

            return ref metadata;
        }

        public static ref readonly Metadata<TValue[]> Empty<TValue>(in this Metadata<TValue[]> metadata,
            string message = null)
        {
            if (metadata.Value != null && metadata.Value.Length != 0) 
            {
                throw new ArgumentOutOfRangeException(null, 
                    message == null ? metadata.Name + Messages.MUST_BE_EMPTY : message);
            }

            return ref metadata;
        }
    }
}
