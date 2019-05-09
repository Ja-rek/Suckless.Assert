using System;

namespace Suckless.Asserts
{
    public static partial class Assertions
    {
        public static ref readonly Metadata<string> LessThan(in this Metadata<string> metadata, 
            int max, 
            string message = null)
        {
            if (metadata.Value != null) 
            {
                var length = metadata.Value.Length;
                if (length > max)
                {
                    throw new ArgumentOutOfRangeException(null, 
                        message == null ? Messages.LessThan(max.ToString(), 
                            metadata.Value.ToString()): message);
                }
            }

            return ref metadata;
        }

        public static ref readonly Metadata<short> LessThan(in this Metadata<short> metadata, 
            short max,
            string message = null)
        {
            if (metadata.Value > max) 
            {
                throw new ArgumentOutOfRangeException(null, 
                    message == null ? Messages.LessThan(max.ToString(), metadata.Value.ToString()): message);
            }

            return ref metadata;
        }

        public static ref readonly Metadata<ushort> LessThan(in this Metadata<ushort> metadata,
            ushort max,
            string message = null)
        {
            if (metadata.Value > max) 
            {
                throw new ArgumentOutOfRangeException(null, 
                    message == null ? Messages.LessThan(max.ToString(), metadata.Value.ToString()): message);
            }

            return ref metadata;
        }


        public static ref readonly Metadata<int> LessThan(in this Metadata<int> metadata,
            int max,
            string message = null)
        {
            if (metadata.Value > max) 
            {
                throw new ArgumentOutOfRangeException(null, 
                    message == null ? Messages.LessThan(max.ToString(), metadata.Value.ToString()): message);
            }

            return ref metadata;
        }

        public static ref readonly Metadata<uint> LessThan(in this Metadata<uint> metadata,
            uint max,
            string message = null)
        {
            if (metadata.Value > max) 
            {
                throw new ArgumentOutOfRangeException(null, 
                    message == null ? Messages.LessThan(max.ToString(), metadata.Value.ToString()): message);
            }

            return ref metadata;
        }

        public static ref readonly Metadata<long> LessThan(in this Metadata<long> metadata,
            long max,
            string message = null)
        {
            if (metadata.Value > max) 
            {
                throw new ArgumentOutOfRangeException(null, 
                    message == null ? Messages.LessThan(max.ToString(), metadata.Value.ToString()): message);
            }

            return ref metadata;
        }

        public static ref readonly Metadata<ulong> LessThan(in this Metadata<ulong> metadata,
            ulong max,
            string message = null)
        {
            if (metadata.Value > max) 
            {
                throw new ArgumentOutOfRangeException(null, 
                    message == null ? Messages.LessThan(max.ToString(), metadata.Value.ToString()): message);
            }

            return ref metadata;
        }

        public static ref readonly Metadata<decimal> LessThan(in this Metadata<decimal> metadata,
            decimal max,
            string message = null)
        {
            if (metadata.Value > max) 
            {
                throw new ArgumentOutOfRangeException(null, 
                    message == null ? Messages.LessThan(max.ToString(), metadata.Value.ToString()): message);
            }

            return ref metadata;
        }

        public static ref readonly Metadata<float> LessThan(in this Metadata<float> metadata, 
            float max,
            string message = null)
        {
            if (metadata.Value > max) 
            {
                throw new ArgumentOutOfRangeException(null, 
                    message == null ? Messages.LessThan(max.ToString(), metadata.Value.ToString()): message);
            }

            return ref metadata;
        }

        public static ref readonly Metadata<double> LessThan(in this Metadata<double> metadata,
            double max,
            string message = null)
        {
            if (metadata.Value > max) 
            {
                throw new ArgumentOutOfRangeException(null, 
                    message == null ? Messages.LessThan(max.ToString(), metadata.Value.ToString()): message);
            }

            return ref metadata;
        }
    }
}
