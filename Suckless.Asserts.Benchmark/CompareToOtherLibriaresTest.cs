using BenchmarkDotNet.Attributes;
using static Suckless.Asserts.Assertions;
using Code = Seterlund.CodeGuard;
using Seterlund.CodeGuard;
using Dawn;
using ArgumentAssertions.Generic;

namespace Suckless.Asserts.Benchmark
{
    public class CompareToOtherLibrieresTest
    {
        [Benchmark]
        public void DawnGuard()
        {
            var value = "any";

            Dawn.Guard.Argument(value).NotNull().NotEmpty();
        }

        [Benchmark]
        public void CodeGuardAssert()
        {
            var value = "any";

            Code.Guard.That(value).IsNotNull().IsNotEmpty();
        }

        [Benchmark]
        public void SucklessAssert()
        {
            var value = "any";

            Assert(value).NotEmpty();
        }

        [Benchmark]
        public void DawnGuardValueType()
        {
            var value = 0;

            Dawn.Guard.Argument(value).Zero();
        }

        [Benchmark]
        public void CodeGuardAssertValueType()
        {
            var value = 1;

            Code.Guard.That(value).IsNotDefault();
        }

        [Benchmark]
        public void SucklessAssertValueType()
        {
            var value = 0;

            Assert(value).Zero();
        }

        [Benchmark]
        public void DawnGuardLambda()
        {
            var value = "any";

            Dawn.Guard.Argument(() => value).NotNull().NotEmpty();
        }

        [Benchmark]
        public void CodeGuardLambda()
        {
            var value = "any";

            Code.Guard.That(() => value).IsNotNull().IsNotEmpty();
        }

        [Benchmark]
        public void ArgumentAssertionsLambda()
        {
            var value = "any";

            value.ThrowIf(() => value).Null().OrIf.EqualTo("sdfs");
        }

        [Benchmark]
        public void SucklessAssertLambda()
        {
            var value = "any";

            Assert(() => value).NotEmpty();
        }

        [Benchmark]
        public void CodeGuardAssertLambdaNestedProperty()
        {
            var value = new PropsFieldsSut();

            Code.Guard.That(() => value.Prop).IsNotNull().IsNotEmpty();
        }

        [Benchmark]
        public void SucklessAssertLambdaNestedProperty()
        {
            var value = new PropsFieldsSut();

            Assert(() => value.Prop).NotEmpty();
        }
    }
}
