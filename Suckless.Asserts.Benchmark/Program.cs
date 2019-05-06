using BenchmarkDotNet.Running;

namespace Suckless.Asserts.Benchmark
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<CreateMetadataTest>();
        }
    }
}
