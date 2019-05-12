using System;
using System.Linq.Expressions;

namespace Suckless.Asserts
{
    public static partial class Assertions
    {
        public static Metadata<TValue> Assert<TValue>(TValue value, string name = null)
        {
            var metadata = new Metadata<TValue>(value, name);

            ThrowWhenNull(value, name);

            return metadata;
        }

        public static Metadata<int> Assert(int value, string name = null) => new Metadata<int>(value, name); 
        public static Metadata<uint> Assert(uint value, string name = null) => new Metadata<uint>(value, name); 
        public static Metadata<long> Assert(long value, string name = null) => new Metadata<long>(value, name); 
        public static Metadata<ulong> Assert(ulong value, string name = null) => new Metadata<ulong>(value, name); 
        public static Metadata<decimal> Assert(decimal value, string name = null) => new Metadata<decimal>(value, name); 
        public static Metadata<double> Assert(double value, string name = null) => new Metadata<double>(value, name); 
        public static Metadata<float> Assert(float value, string name = null) => new Metadata<float>(value, name); 

        public static Metadata<int> Assert(Expression<Func<int>> expression, string name = null) 
            => MetadataFactory.MetadataFrom(expression); 

        public static Metadata<uint> Assert(Expression<Func<uint>> expression, string name = null) 
            => MetadataFactory.MetadataFrom(expression); 

        public static Metadata<long> Assert(Expression<Func<long>> expression, string name = null) 
            => MetadataFactory.MetadataFrom(expression); 

        public static Metadata<ulong> Assert(Expression<Func<ulong>> expression, string name = null) 
            => MetadataFactory.MetadataFrom(expression); 

        public static Metadata<decimal> Assert(Expression<Func<decimal>> expression, string name = null) 
            => MetadataFactory.MetadataFrom(expression); 

        public static Metadata<double> Assert(Expression<Func<double>> expression, string name = null) 
            => MetadataFactory.MetadataFrom(expression); 

        public static Metadata<float> Assert(Expression<Func<float>> expression, string name = null) 
            => MetadataFactory.MetadataFrom(expression); 

        public static Metadata<TValue> Assert<TValue>(Expression<Func<TValue>> expression)
        {
            var metadata = MetadataFactory.MetadataFrom(expression);

            ThrowWhenNull(metadata.Value, metadata.Name);

            return metadata;
        }

        public static partial class AllowNull
        {
            public static Metadata<TValue> Assert<TValue>(TValue value, string name = null) 
            {
                return new Metadata<TValue>(value, name);
            }

            public static Metadata<TValue> Assert<TValue>(Expression<Func<TValue>> expression) 
            {
                return MetadataFactory.MetadataFrom(expression);
            }
        }

        private static void ThrowWhenNull<TValue>(TValue value, string name) 
        {
            if (value == null) throw new ArgumentNullException(name + "cannot be null.");
        }
    }
}
