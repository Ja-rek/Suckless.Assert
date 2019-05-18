using System;

namespace Suckless.Asserts
{
    public static partial class Assertions
    {
        public static ref readonly Metadata<short> NotZero(in this Metadata<short> metadata, string message = null)
        {
            if (metadata.Value == 0) 
            {
                throw ExceptionNotNotZero(metadata.Name , message);
            }

            return ref metadata;
        }

        public static ref readonly Metadata<ushort> NotZero(in this Metadata<ushort> metadata, string message = null)
        {
            if (metadata.Value == 0) 
            {
                throw ExceptionNotNotZero(metadata.Name , message);
            }

            return ref metadata;
        }

        public static ref readonly Metadata<int> NotZero(in this Metadata<int> metadata, string message = null)
        {
            if (metadata.Value == 0) 
            {
                throw ExceptionNotNotZero(metadata.Name , message);
            }

            return ref metadata;
        }

        public static ref readonly Metadata<uint> NotZero(in this Metadata<uint> metadata, string message = null)
        {
            if (metadata.Value == 0) 
            {
                throw ExceptionNotNotZero(metadata.Name , message);
            }

            return ref metadata;
        }

        public static ref readonly Metadata<long> NotZero(in this Metadata<long> metadata, string message = null)
        {
            if (metadata.Value == 0) 
            {
                throw ExceptionNotNotZero(metadata.Name , message);
            }

            return ref metadata;
        }

        public static ref readonly Metadata<ulong> NotZero(in this Metadata<ulong> metadata, string message = null)
        {
            if (metadata.Value == 0) 
            {
                throw ExceptionNotNotZero(metadata.Name , message);
            }

            return ref metadata;
        }

        public static ref readonly Metadata<decimal> NotZero(in this Metadata<decimal> metadata, string message = null)
        {
            if (metadata.Value == 0) 
            {
                throw ExceptionNotNotZero(metadata.Name , message);
            }

            return ref metadata;
        }

        public static ref readonly Metadata<float> NotZero(in this Metadata<float> metadata, string message = null)
        {
            if (metadata.Value == 0) 
            {
                throw ExceptionNotNotZero(metadata.Name , message);
            }

            return ref metadata;
        }

        public static ref readonly Metadata<double> NotZero(in this Metadata<double> metadata, string message = null)
        {
            if (metadata.Value == 0) 
            {
                throw ExceptionNotNotZero(metadata.Name , message);
            }

            return ref metadata;
        }

        private static ArgumentException ExceptionNotNotZero(string name , string message)
        {
            return new ArgumentException(message == null ? $"The {name} cannot be zero." : message);
        }
    }
}
