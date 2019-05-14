using System;

namespace Suckless.Asserts
{
    public static partial class Assertions
    {
        public static ref readonly Metadata<bool> True(in this Metadata<bool> metadata, string message = null)
        {
            if (metadata.Value != true) 
            {
                throw new ArgumentException(message == null ? $"The {metadata.Name} must be true." : message);
            }

            return ref metadata;
        }
    }
}
