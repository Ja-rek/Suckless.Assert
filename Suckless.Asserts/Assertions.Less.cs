using System;

namespace Suckless.Asserts
{
    public static partial class Assertions
    {
        public static ref readonly Metadata<short> Less(in this Metadata<short> metadata, 
            short max,
            string message = null)
        {
            if (metadata.Value > max) 
            {
                throw ExceptionNotLess(metadata.Value.ToString(), max.ToString(), metadata.Name, message);
            }

            return ref metadata;
        }

        public static ref readonly Metadata<ushort> Less(in this Metadata<ushort> metadata,
            ushort max,
            string message = null)
        {
            if (metadata.Value > max) 
            {
                throw ExceptionNotLess(metadata.Value.ToString(), max.ToString(), metadata.Name, message);
            }

            return ref metadata;
        }


        public static ref readonly Metadata<int> Less(in this Metadata<int> metadata,
            int max,
            string message = null)
        {
            if (metadata.Value > max) 
            {
                throw ExceptionNotLess(metadata.Value.ToString(), max.ToString(), metadata.Name, message);
            }

            return ref metadata;
        }

        public static ref readonly Metadata<uint> Less(in this Metadata<uint> metadata,
            uint max,
            string message = null)
        {
            if (metadata.Value > max) 
            {
                throw ExceptionNotLess(metadata.Value.ToString(), max.ToString(), metadata.Name, message);
            }

            return ref metadata;
        }

        public static ref readonly Metadata<long> Less(in this Metadata<long> metadata,
            long max,
            string message = null)
        {
            if (metadata.Value > max) 
            {
                throw ExceptionNotLess(metadata.Value.ToString(), max.ToString(), metadata.Name, message);
            }

            return ref metadata;
        }

        public static ref readonly Metadata<ulong> Less(in this Metadata<ulong> metadata,
            ulong max,
            string message = null)
        {
            if (metadata.Value > max) 
            {
                throw ExceptionNotLess(metadata.Value.ToString(), max.ToString(), metadata.Name, message);
            }

            return ref metadata;
        }

        public static ref readonly Metadata<decimal> Less(in this Metadata<decimal> metadata,
            decimal max,
            string message = null)
        {
            if (metadata.Value > max) 
            {
                throw ExceptionNotLess(metadata.Value.ToString(), max.ToString(), metadata.Name, message);
            }

            return ref metadata;
        }

        public static ref readonly Metadata<float> Less(in this Metadata<float> metadata, 
            float max,
            string message = null)
        {
            if (metadata.Value > max) 
            {
                throw ExceptionNotLess(metadata.Value.ToString(), max.ToString(), metadata.Name, message);
            }

            return ref metadata;
        }

        public static ref readonly Metadata<double> Less(in this Metadata<double> metadata,
            double max,
            string message = null)
        {
            if (metadata.Value > max) 
            {
                throw ExceptionNotLess(metadata.Value.ToString(), max.ToString(), metadata.Name, message);
            }

            return ref metadata;
        }

        private static ArgumentOutOfRangeException ExceptionNotLess(string value, string max, string name , string message)
        {
            return new ArgumentOutOfRangeException(null, message == null 
                ? $"The {name} contains the number {value} but should contain a number less than {max}."
                : message);
        }
    }
}
