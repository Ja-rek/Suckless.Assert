using System;

namespace Suckless.Asserts
{
    public static partial class Assertions
    {
        public static ref readonly Metadata<string> Length(in this Metadata<string> metadata, int exact, string message = null)
        {
            if (metadata.Value != null) 
            {
                var length = metadata.Value.Length;
                if (length != exact) 
                {
                    throw new ArgumentOutOfRangeException(null, 
                        message == null ? metadata.Name + Messages.Length(exact, length) : message);
                }
            }

            return ref metadata;
        }

        public static ref readonly Metadata<string> Length(in this Metadata<string> metadata, 
            int min, 
            int max, 
            string message = null)
        {
            if (metadata.Value != null) 
            {
                var length = metadata.Value.Length;
                if (length < min || length < max)
                {
                    throw new ArgumentOutOfRangeException(null, 
                        message == null ? metadata.Name + Messages.Length(min, max, length) : message);
                }
            }

            return ref metadata;
        }
    }
}
