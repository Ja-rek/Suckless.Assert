using System;

namespace Suckless.Asserts
{
    public static partial class Assertions
    {
        public static ref readonly Metadata<short> Positive(in this Metadata<short> metadata, string message = null)
        {
            if (metadata.Value < 0) 
            {
                throw new ArgumentException(message == null ? metadata.Name + Messages.MUST_BE_POSITIVE : message);
            }

            return ref metadata;
        }

        public static ref readonly Metadata<int> Positive(in this Metadata<int> metadata, string message = null)
        {
            if (metadata.Value < 0) 
            {
                throw new ArgumentException(message == null ? metadata.Name + Messages.MUST_BE_POSITIVE : message);
            }

            return ref metadata;
        }

        public static ref readonly Metadata<long> Positive(in this Metadata<long> metadata, string message = null)
        {
            if (metadata.Value < 0) 
            {
                throw new ArgumentException(message == null ? metadata.Name + Messages.MUST_BE_POSITIVE : message);
            }

            return ref metadata;
        }
        public static ref readonly Metadata<decimal> Positive(in this Metadata<decimal> metadata, string message = null)
        {
            if (metadata.Value < 0) 
            {
                throw new ArgumentException(message == null ? metadata.Name + Messages.MUST_BE_POSITIVE : message);
            }

            return ref metadata;
        }

        public static ref readonly Metadata<float> Positive(in this Metadata<float> metadata, string message = null)
        {
            if (metadata.Value < 0) 
            {
                throw new ArgumentException(message == null ? metadata.Name + Messages.MUST_BE_POSITIVE : message);
            }

            return ref metadata;
        }

        public static ref readonly Metadata<double> Positive(in this Metadata<double> metadata, string message = null)
        {
            if (metadata.Value < 0) 
            {
                throw new ArgumentException(message == null ? metadata.Name + Messages.MUST_BE_POSITIVE : message);
            }

            return ref metadata;
        }
    }
}
