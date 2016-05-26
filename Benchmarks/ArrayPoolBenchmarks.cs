using System.Buffers;
using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;

namespace Benchmarks
{
    public class ArrayPoolBenchmarks
    {
        [Params((int)1E+2, (int)1E+3, (int)1E+4, (int)1E+5, (int)1E+6)]
        public int Length;

        [Benchmark(Baseline = true, Description = "Allocating new array every time")]
        public void Allocate()
        {
            var array = new byte[Length];
            Blackhole(array);
        }

        [Benchmark(Description = "Renting array from the pool")]
        public void Rent()
        {
            var array = ArrayPool<byte>.Shared.Rent(Length);
            Blackhole(array);

            ArrayPool<byte>.Shared.Return(array);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void Blackhole<T>(T input)
        {
        }
    }
}
