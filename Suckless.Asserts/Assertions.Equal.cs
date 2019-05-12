using System;

namespace Suckless.Asserts
{
    public static partial class Assertions
    {
        public static ref readonly Metadata<TValue> Equal<TValue>(in this Metadata<TValue> metadata, 
            object obj, 
            string message = null)
        {
            if (metadata.Value != null && !metadata.Value.Equals(obj)) 
            {
                var strValueA = metadata.Value.ToString();
                var strValueB = obj.ToString();
                const int length = 60;

                if (strValueA.Length > length) strValueA = strValueA.Substring(0, length);
                if (strValueA.Length > length) strValueB = strValueB.Substring(0, length);

                throw new ArgumentException(message == null 
                    ? $"The {metadata.Name} that contain {strValueA} should be equal to {strValueB}."
                    : message);
            }

            return ref metadata;
        }
    }
}
