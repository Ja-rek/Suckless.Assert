using System;
using System.Linq.Expressions;
using BenchmarkDotNet.Attributes;
using static Suckless.Asserts.Assertions;

namespace Suckless.Asserts.Benchmark
{
    public class CreateMetadataTest
    {
        [Benchmark]
        public void LocalStructureField()
        {
            var value = 5;

            Assert(value);
        }

        [Benchmark]
        public void LocalField()
        {
            var value = "";

            Assert(value);
        }

        [Benchmark]
        public void PropertyFromClass()
        {
            var props = new PropsFieldsSut();

            Assert(props.Prop);
        }

        [Benchmark]
        public void FieldFromClass()
        {
            var props = new PropsFieldsSut();

            Assert(props.field);
        }

        [Benchmark]
        public void PropertyFromClassUseExpresssion()
        {
            var props = new PropsFieldsSut();

            Assert(() => props.Prop);
        }

        [Benchmark]
        public void FieldFromClassUseExpresssion()
        {
            var props = new PropsFieldsSut();

            Assert(() => props.field);
        }

        [Benchmark]
        public void LocalFieldUseExpresssion()
        {
            var value = "";

            Assert(() => value);
        }

        [Benchmark]
        public void LocalStructFieldUseExpresssion()
        {
            var value = 5;

            Assert(() => value);
        }

        [Benchmark]
        public void CompileAndInvokeExpresssion()
        {
            var value = "";

            FakeFactoryMethod(() => value);
        }

        public Metadata<TValue> FakeFactoryMethod<TValue>(Expression<Func<TValue>> expression)
        {
            var memberExpression = (MemberExpression)expression.Body;
            var name = memberExpression.Member.Name;

            var value = expression.Compile().Invoke();

            return new Metadata<TValue>(value, name);
        }
    }
}
