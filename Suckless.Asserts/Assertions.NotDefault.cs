using System;
using System.Collections.Generic;

namespace Suckless.Asserts
{
    public static partial class Assertions
    {
        public static ref readonly Metadata<TValue> NotDefault<TValue>(in this Metadata<TValue> metadata, string message = null)
        {
            if (EqualityComparer<TValue>.Default.Equals(metadata.Value, default)) 
            {
                var strValue = metadata.Value.ToString();
                const int length = 60;

                if (strValue.Length > length) strValue = strValue.Substring(0, length);

                throw new ArgumentException(message == null 
                    ? $"The {metadata.Name} that contain {strValue} cannot be default."
                    : message);
            }

            return ref metadata;
        }
    }
}
