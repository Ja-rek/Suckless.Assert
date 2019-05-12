using System;

namespace Suckless.Asserts
{
    public static partial class Assertions
    {
        public static ref readonly Metadata<short> LessThan(in this Metadata<short> metadata, 
            short max,
            string message = null)
        {
            if (metadata.Value > max) 
            {
                ThrowWhenNotLess(metadata.Value.ToString(), max.ToString(), metadata.Name, message);
            }

            return ref metadata;
        }

        public static ref readonly Metadata<ushort> LessThan(in this Metadata<ushort> metadata,
            ushort max,
            string message = null)
        {
            if (metadata.Value > max) 
            {
                ThrowWhenNotLess(metadata.Value.ToString(), max.ToString(), metadata.Name, message);
            }

            return ref metadata;
        }


        public static ref readonly Metadata<int> LessThan(in this Metadata<int> metadata,
            int max,
            string message = null)
        {
            if (metadata.Value > max) 
            {
                ThrowWhenNotLess(metadata.Value.ToString(), max.ToString(), metadata.Name, message);
            }

            return ref metadata;
        }

        public static ref readonly Metadata<uint> LessThan(in this Metadata<uint> metadata,
            uint max,
            string message = null)
        {
            if (metadata.Value > max) 
            {
                ThrowWhenNotLess(metadata.Value.ToString(), max.ToString(), metadata.Name, message);
            }

            return ref metadata;
        }

        public static ref readonly Metadata<long> LessThan(in this Metadata<long> metadata,
            long max,
            string message = null)
        {
            if (metadata.Value > max) 
            {
                ThrowWhenNotLess(metadata.Value.ToString(), max.ToString(), metadata.Name, message);
            }

            return ref metadata;
        }

        public static ref readonly Metadata<ulong> LessThan(in this Metadata<ulong> metadata,
            ulong max,
            string message = null)
        {
            if (metadata.Value > max) 
            {
                ThrowWhenNotLess(metadata.Value.ToString(), max.ToString(), metadata.Name, message);
            }

            return ref metadata;
        }

        public static ref readonly Metadata<decimal> LessThan(in this Metadata<decimal> metadata,
            decimal max,
            string message = null)
        {
            if (metadata.Value > max) 
            {
                ThrowWhenNotLess(metadata.Value.ToString(), max.ToString(), metadata.Name, message);
            }

            return ref metadata;
        }

        public static ref readonly Metadata<float> LessThan(in this Metadata<float> metadata, 
            float max,
            string message = null)
        {
            if (metadata.Value > max) 
            {
                ThrowWhenNotLess(metadata.Value.ToString(), max.ToString(), metadata.Name, message);
            }

            return ref metadata;
        }

        public static ref readonly Metadata<double> LessThan(in this Metadata<double> metadata,
            double max,
            string message = null)
        {
            if (metadata.Value > max) 
            {
                ThrowWhenNotLess(metadata.Value.ToString(), max.ToString(), metadata.Name, message);
            }

            return ref metadata;
        }

        private static void ThrowWhenNotLess(string value, string max, string name , string message)
        {
            throw new ArgumentOutOfRangeException(null, message == null 
                ? $"The {name} contains the number {value} but should contain a number less than {max}."
                : message);
        }
    }
}
