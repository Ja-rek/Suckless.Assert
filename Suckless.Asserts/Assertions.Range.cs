using System;

namespace Suckless.Asserts
{
    public static partial class Assertions
    {
        public static ref readonly Metadata<short> Range(in this Metadata<short> metadata, 
            short min,
            short max,
            string message = null)
        {
            if (metadata.Value < min || metadata.Value > max) 
            {
                ThrowWhenIsNotInRange(metadata.Value.ToString(), 
                    min.ToString(), 
                    max.ToString(), 
                    metadata.Name, 
                    message);
            }

            return ref metadata;
        }

        public static ref readonly Metadata<ushort> Range(in this Metadata<ushort> metadata,
            ushort min,
            ushort max,
            string message = null)
        {
            if (metadata.Value < min || metadata.Value > max) 
            {
                ThrowWhenIsNotInRange(metadata.Value.ToString(), 
                    min.ToString(), 
                    max.ToString(), 
                    metadata.Name, 
                    message);
            }

            return ref metadata;
        }


        public static ref readonly Metadata<int> Range(in this Metadata<int> metadata,
            int min,
            int max,
            string message = null)
        {
            if (metadata.Value < min || metadata.Value > max) 
            {
                ThrowWhenIsNotInRange(metadata.Value.ToString(), 
                    min.ToString(), 
                    max.ToString(), 
                    metadata.Name, 
                    message);
            }

            return ref metadata;
        }

        public static ref readonly Metadata<uint> Range(in this Metadata<uint> metadata,
            uint min,
            uint max,
            string message = null)
        {
            if (metadata.Value < min || metadata.Value > max) 
            {
                ThrowWhenIsNotInRange(metadata.Value.ToString(), 
                    min.ToString(), 
                    max.ToString(), 
                    metadata.Name, 
                    message);
            }

            return ref metadata;
        }

        public static ref readonly Metadata<long> Range(in this Metadata<long> metadata,
            long min,
            long max,
            string message = null)
        {
            if (metadata.Value < min || metadata.Value > max) 
            {
                ThrowWhenIsNotInRange(metadata.Value.ToString(), 
                    min.ToString(), 
                    max.ToString(), 
                    metadata.Name, 
                    message);
            }

            return ref metadata;
        }

        public static ref readonly Metadata<ulong> Range(in this Metadata<ulong> metadata,
            ulong min,
            ulong max,
            string message = null)
        {
            if (metadata.Value < min || metadata.Value > max) 
            {
                ThrowWhenIsNotInRange(metadata.Value.ToString(), 
                    min.ToString(), 
                    max.ToString(), 
                    metadata.Name, 
                    message);
            }

            return ref metadata;
        }

        public static ref readonly Metadata<decimal> Range(in this Metadata<decimal> metadata,
            decimal min,
            decimal max,
            string message = null)
        {
            if (metadata.Value < min || metadata.Value > max) 
            {
                ThrowWhenIsNotInRange(metadata.Value.ToString(), 
                    min.ToString(), 
                    max.ToString(), 
                    metadata.Name, 
                    message);
            }

            return ref metadata;
        }

        public static ref readonly Metadata<float> Range(in this Metadata<float> metadata, 
            float min,
            float max,
            string message = null)
        {
            if (metadata.Value < min || metadata.Value > max) 
            {
                ThrowWhenIsNotInRange(metadata.Value.ToString(), 
                    min.ToString(), 
                    max.ToString(), 
                    metadata.Name, 
                    message);
            }

            return ref metadata;
        }

        public static ref readonly Metadata<double> Range(in this Metadata<double> metadata,
            double min,
            double max,
            string message = null)
        {
            if (metadata.Value < min || metadata.Value > max) 
            {
                ThrowWhenIsNotInRange(metadata.Value.ToString(), 
                    min.ToString(), 
                    max.ToString(), 
                    metadata.Name, 
                    message);
            }

            return ref metadata;
        }

        private static void ThrowWhenIsNotInRange(string value, string min, string max, string name , string message)
        {
            throw new ArgumentOutOfRangeException(null, message == null 
                ? $"The {name} contains the number {value} but should contain a number in range {min} - {max}." 
                : message);
        }
    }
}
