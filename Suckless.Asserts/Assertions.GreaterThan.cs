using System;

namespace Suckless.Asserts
{
    public static partial class Assertions
    {
        public static ref readonly Metadata<string> GreaterThan(in this Metadata<string> metadata, 
            int min, 
            string message = null)
        {
            if (metadata.Value != null) 
            {
                var length = metadata.Value.Length;
                if (length < min)
                {
                    throw new ArgumentOutOfRangeException(null, 
                        message == null ? Messages.GreaterThan(min.ToString(), 
                            metadata.Value.ToString()): message);
                }
            }

            return ref metadata;
        }

        public static ref readonly Metadata<short> GreaterThan(in this Metadata<short> metadata, 
            short min,
            string message = null)
        {
            if (metadata.Value < min) 
            {
                throw new ArgumentOutOfRangeException(null, 
                    message == null ? Messages.GreaterThan(min.ToString(), metadata.Value.ToString()): message);
            }

            return ref metadata;
        }

        public static ref readonly Metadata<ushort> GreaterThan(in this Metadata<ushort> metadata,
            ushort min,
            string message = null)
        {
            if (metadata.Value < min) 
            {
                throw new ArgumentOutOfRangeException(null, 
                    message == null ? Messages.GreaterThan(min.ToString(), metadata.Value.ToString()): message);
            }

            return ref metadata;
        }


        public static ref readonly Metadata<int> GreaterThan(in this Metadata<int> metadata,
            int min,
            string message = null)
        {
            if (metadata.Value < min) 
            {
                throw new ArgumentOutOfRangeException(null, 
                    message == null ? Messages.GreaterThan(min.ToString(), metadata.Value.ToString()): message);
            }

            return ref metadata;
        }

        public static ref readonly Metadata<uint> GreaterThan(in this Metadata<uint> metadata,
            uint min,
            string message = null)
        {
            if (metadata.Value < min) 
            {
                throw new ArgumentOutOfRangeException(null, 
                    message == null ? Messages.GreaterThan(min.ToString(), metadata.Value.ToString()): message);
            }

            return ref metadata;
        }

        public static ref readonly Metadata<long> GreaterThan(in this Metadata<long> metadata,
            long min,
            string message = null)
        {
            if (metadata.Value < min) 
            {
                throw new ArgumentOutOfRangeException(null, 
                    message == null ? Messages.GreaterThan(min.ToString(), metadata.Value.ToString()): message);
            }

            return ref metadata;
        }

        public static ref readonly Metadata<ulong> GreaterThan(in this Metadata<ulong> metadata,
            ulong min,
            string message = null)
        {
            if (metadata.Value < min) 
            {
                throw new ArgumentOutOfRangeException(null, 
                    message == null ? Messages.GreaterThan(min.ToString(), metadata.Value.ToString()): message);
            }

            return ref metadata;
        }

        public static ref readonly Metadata<decimal> GreaterThan(in this Metadata<decimal> metadata,
            decimal min,
            string message = null)
        {
            if (metadata.Value < min) 
            {
                throw new ArgumentOutOfRangeException(null, 
                    message == null ? Messages.GreaterThan(min.ToString(), metadata.Value.ToString()): message);
            }

            return ref metadata;
        }

        public static ref readonly Metadata<float> GreaterThan(in this Metadata<float> metadata, 
            float min,
            string message = null)
        {
            if (metadata.Value < min) 
            {
                throw new ArgumentOutOfRangeException(null, 
                    message == null ? Messages.GreaterThan(min.ToString(), metadata.Value.ToString()): message);
            }

            return ref metadata;
        }

        public static ref readonly Metadata<double> GreaterThan(in this Metadata<double> metadata,
            double min,
            string message = null)
        {
            if (metadata.Value < min) 
            {
                throw new ArgumentOutOfRangeException(null, 
                    message == null ? Messages.GreaterThan(min.ToString(), metadata.Value.ToString()): message);
            }

            return ref metadata;
        }
    }
}
