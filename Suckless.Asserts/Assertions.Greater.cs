using System;

namespace Suckless.Asserts
{
    public static partial class Assertions
    {
        public static ref readonly Metadata<ushort> Greater(in this Metadata<ushort> metadata,
            ushort min,
            string message = null)
        {
            if (metadata.Value < min) 
            {
                throw ExceptionNotGreater(metadata.Value.ToString(), min.ToString(), metadata.Name, message);
            }

            return ref metadata;
        }

        public static ref readonly Metadata<short> Greater(in this Metadata<short> metadata,
            short min,
            string message = null)
        {
            if (metadata.Value < min) 
            {
                throw ExceptionNotGreater(metadata.Value.ToString(), min.ToString(), metadata.Name, message);
            }

            return ref metadata;
        }

        public static ref readonly Metadata<int> Greater(in this Metadata<int> metadata,
            int min,
            string message = null)
        {
            if (metadata.Value < min) 
            {
                throw ExceptionNotGreater(metadata.Value.ToString(), min.ToString(), metadata.Name, message);
            }

            return ref metadata;
        }

        public static ref readonly Metadata<uint> Greater(in this Metadata<uint> metadata,
            uint min,
            string message = null)
        {
            if (metadata.Value < min) 
            {
                throw ExceptionNotGreater(metadata.Value.ToString(), min.ToString(), metadata.Name, message);
            }

            return ref metadata;
        }

        public static ref readonly Metadata<long> Greater(in this Metadata<long> metadata,
            long min,
            string message = null)
        {
            if (metadata.Value < min) 
            {
                throw ExceptionNotGreater(metadata.Value.ToString(), min.ToString(), metadata.Name, message);
            }

            return ref metadata;
        }

        public static ref readonly Metadata<ulong> Greater(in this Metadata<ulong> metadata,
            ulong min,
            string message = null)
        {
            if (metadata.Value < min) 
            {
                throw ExceptionNotGreater(metadata.Value.ToString(), min.ToString(), metadata.Name, message);
            }

            return ref metadata;
        }

        public static ref readonly Metadata<decimal> Greater(in this Metadata<decimal> metadata,
            decimal min,
            string message = null)
        {
            if (metadata.Value < min) 
            {
                throw ExceptionNotGreater(metadata.Value.ToString(), min.ToString(), metadata.Name, message);
            }

            return ref metadata;
        }

        public static ref readonly Metadata<float> Greater(in this Metadata<float> metadata, 
            float min,
            string message = null)
        {
            if (metadata.Value < min) 
            {
                throw ExceptionNotGreater(metadata.Value.ToString(), min.ToString(), metadata.Name, message);
            }

            return ref metadata;
        }

        public static ref readonly Metadata<double> Greater(in this Metadata<double> metadata,
            double min,
            string message = null)
        {
            if (metadata.Value < min) 
            {
                throw ExceptionNotGreater(metadata.Value.ToString(), min.ToString(), metadata.Name, message);
            }

            return ref metadata;
        }

        private static ArgumentOutOfRangeException ExceptionNotGreater(string value, string min, string name , string message)
        {
            return new ArgumentOutOfRangeException(null, message == null 
                ? $"The {name} contains the number {value} but should contain a number greater than {min}."
                : message);
        }
    }
}
