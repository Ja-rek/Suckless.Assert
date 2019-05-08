using System;

namespace Suckless.Asserts
{
    public static partial class Assertions
    {
        public static ref readonly Metadata<string> GreaterThan(in this Metadata<string> metadata, 
            int maxCharacters, 
            string message = null)
        {
            if (metadata.Value != null) 
            {
                var length = metadata.Value.Length;
                if (length < maxCharacters)
                {
                    throw new ArgumentOutOfRangeException(null, 
                        message == null ? Messages.GreaterThan(maxCharacters.ToString(), 
                            metadata.Value.ToString()): message);
                }
            }

            return ref metadata;
        }

        public static ref readonly Metadata<short> GreaterThan(in this Metadata<short> metadata, 
            short maxNumber,
            string message = null)
        {
            if (metadata.Value < maxNumber) 
            {
                throw new ArgumentOutOfRangeException(null, 
                    message == null ? Messages.GreaterThan(maxNumber.ToString(), metadata.Value.ToString()): message);
            }

            return ref metadata;
        }

        public static ref readonly Metadata<ushort> GreaterThan(in this Metadata<ushort> metadata,
            ushort maxNumber,
            string message = null)
        {
            if (metadata.Value < maxNumber) 
            {
                throw new ArgumentOutOfRangeException(null, 
                    message == null ? Messages.GreaterThan(maxNumber.ToString(), metadata.Value.ToString()): message);
            }

            return ref metadata;
        }


        public static ref readonly Metadata<int> GreaterThan(in this Metadata<int> metadata,
            int maxNumber,
            string message = null)
        {
            if (metadata.Value < maxNumber) 
            {
                throw new ArgumentOutOfRangeException(null, 
                    message == null ? Messages.GreaterThan(maxNumber.ToString(), metadata.Value.ToString()): message);
            }

            return ref metadata;
        }

        public static ref readonly Metadata<uint> GreaterThan(in this Metadata<uint> metadata,
            uint maxNumber,
            string message = null)
        {
            if (metadata.Value < maxNumber) 
            {
                throw new ArgumentOutOfRangeException(null, 
                    message == null ? Messages.GreaterThan(maxNumber.ToString(), metadata.Value.ToString()): message);
            }

            return ref metadata;
        }

        public static ref readonly Metadata<long> GreaterThan(in this Metadata<long> metadata,
            long maxNumber,
            string message = null)
        {
            if (metadata.Value < maxNumber) 
            {
                throw new ArgumentOutOfRangeException(null, 
                    message == null ? Messages.GreaterThan(maxNumber.ToString(), metadata.Value.ToString()): message);
            }

            return ref metadata;
        }

        public static ref readonly Metadata<ulong> GreaterThan(in this Metadata<ulong> metadata,
            ulong maxNumber,
            string message = null)
        {
            if (metadata.Value < maxNumber) 
            {
                throw new ArgumentOutOfRangeException(null, 
                    message == null ? Messages.GreaterThan(maxNumber.ToString(), metadata.Value.ToString()): message);
            }

            return ref metadata;
        }

        public static ref readonly Metadata<decimal> GreaterThan(in this Metadata<decimal> metadata,
            decimal maxNumber,
            string message = null)
        {
            if (metadata.Value < maxNumber) 
            {
                throw new ArgumentOutOfRangeException(null, 
                    message == null ? Messages.GreaterThan(maxNumber.ToString(), metadata.Value.ToString()): message);
            }

            return ref metadata;
        }

        public static ref readonly Metadata<float> GreaterThan(in this Metadata<float> metadata, 
            float maxNumber,
            string message = null)
        {
            if (metadata.Value < maxNumber) 
            {
                throw new ArgumentOutOfRangeException(null, 
                    message == null ? Messages.GreaterThan(maxNumber.ToString(), metadata.Value.ToString()): message);
            }

            return ref metadata;
        }

        public static ref readonly Metadata<double> GreaterThan(in this Metadata<double> metadata,
            double maxNumber,
            string message = null)
        {
            if (metadata.Value < maxNumber) 
            {
                throw new ArgumentOutOfRangeException(null, 
                    message == null ? Messages.GreaterThan(maxNumber.ToString(), metadata.Value.ToString()): message);
            }

            return ref metadata;
        }
    }
}
