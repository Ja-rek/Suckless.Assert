using System;

namespace Suckless.Asserts
{
    public static partial class Assertions
    {
        public static ref readonly Metadata<bool> False(in this Metadata<bool> metadata, string message = null)
        {
            if (metadata.Value != false) 
            {
                throw new ArgumentException(message == null ? $"The {metadata.Name} must be false." : message);
            }

            return ref metadata;
        }
    }
}
