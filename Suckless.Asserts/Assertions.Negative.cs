using System;

namespace Suckless.Asserts
{
    public static partial class Assertions
    {
        public static ref readonly Metadata<short> Negative(in this Metadata<short> metadata, string message = null)
        {
            if (metadata.Value > 0) 
            {
                ThrowWhenNotNegative(metadata.Name , message);
            }

            return ref metadata;
        }

        public static ref readonly Metadata<int> Negative(in this Metadata<int> metadata, string message = null)
        {
            if (metadata.Value > 0) 
            {
                ThrowWhenNotNegative(metadata.Name , message);
            }

            return ref metadata;
        }

        public static ref readonly Metadata<long> Negative(in this Metadata<long> metadata, string message = null)
        {
            if (metadata.Value > 0) 
            {
                ThrowWhenNotNegative(metadata.Name , message);
            }

            return ref metadata;
        }
        public static ref readonly Metadata<decimal> Negative(in this Metadata<decimal> metadata, string message = null)
        {
            if (metadata.Value > 0) 
            {
                ThrowWhenNotNegative(metadata.Name , message);
            }

            return ref metadata;
        }

        public static ref readonly Metadata<float> Negative(in this Metadata<float> metadata, string message = null)
        {
            if (metadata.Value > 0) 
            {
                ThrowWhenNotNegative(metadata.Name , message);
            }

            return ref metadata;
        }

        public static ref readonly Metadata<double> Negative(in this Metadata<double> metadata, string message = null)
        {
            if (metadata.Value > 0) 
            {
                ThrowWhenNotNegative(metadata.Name , message);
            }

            return ref metadata;
        }

        private static void ThrowWhenNotNegative(string name , string message)
        {
            throw new ArgumentException(message == null ? $"The {name} must be negative." : message);
        }
    }
}
