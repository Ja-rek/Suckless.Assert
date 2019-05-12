using System;

namespace Suckless.Asserts
{
    public static partial class Assertions
    {
        public static ref readonly Metadata<short> Zero(in this Metadata<short> metadata, string message = null)
        {
            if (metadata.Value != 0) 
            {
                ThrowWhenNotZero(metadata.Name , message);
            }

            return ref metadata;
        }

        public static ref readonly Metadata<ushort> Zero(in this Metadata<ushort> metadata, string message = null)
        {
            if (metadata.Value != 0) 
            {
                ThrowWhenNotZero(metadata.Name , message);
            }

            return ref metadata;
        }

        public static ref readonly Metadata<int> Zero(in this Metadata<int> metadata, string message = null)
        {
            if (metadata.Value != 0) 
            {
                ThrowWhenNotZero(metadata.Name , message);
            }

            return ref metadata;
        }

        public static ref readonly Metadata<uint> Zero(in this Metadata<uint> metadata, string message = null)
        {
            if (metadata.Value != 0) 
            {
                ThrowWhenNotZero(metadata.Name , message);
            }

            return ref metadata;
        }

        public static ref readonly Metadata<long> Zero(in this Metadata<long> metadata, string message = null)
        {
            if (metadata.Value != 0) 
            {
                ThrowWhenNotZero(metadata.Name , message);
            }

            return ref metadata;
        }

        public static ref readonly Metadata<ulong> Zero(in this Metadata<ulong> metadata, string message = null)
        {
            if (metadata.Value != 0) 
            {
                ThrowWhenNotZero(metadata.Name , message);
            }

            return ref metadata;
        }

        public static ref readonly Metadata<decimal> Zero(in this Metadata<decimal> metadata, string message = null)
        {
            if (metadata.Value != 0) 
            {
                ThrowWhenNotZero(metadata.Name , message);
            }

            return ref metadata;
        }

        public static ref readonly Metadata<float> Zero(in this Metadata<float> metadata, string message = null)
        {
            if (metadata.Value != 0) 
            {
                ThrowWhenNotZero(metadata.Name , message);
            }

            return ref metadata;
        }

        public static ref readonly Metadata<double> Zero(in this Metadata<double> metadata, string message = null)
        {
            if (metadata.Value != 0) 
            {
                ThrowWhenNotZero(metadata.Name , message);
            }

            return ref metadata;
        }

        private static void ThrowWhenNotZero(string name , string message)
        {
            throw new ArgumentException(message == null ? $"The {name} must be zero." : message);
        }
    }
}
