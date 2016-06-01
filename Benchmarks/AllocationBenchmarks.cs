using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using BenchmarkDotNet.Attributes;

namespace Benchmarks
{
    public class SmallAllocationBenchmarks : AllocationBenchmarks
    {
        [Params((int)1E+2, // 100 bytes
            (int)1E+3, // 1 000 bytes = 1 KB
            (int)1E+4, // 10 000 bytes = 10 KB
            (int)1E+5)] // 100 000 bytes = 100 KB
        public override int Bytes { get; set; }

        [Benchmark(Description = "stackalloc")]
        public unsafe void AllocateWithStackalloc()
        {
            var array = stackalloc byte[Bytes];
            Blackhole(array);
        }
    }

    public class BigAllocationBenchmarks : AllocationBenchmarks
    {
        [Params((int)1E+6, // 1 000 000 bytes = 1 MB
            (int)1E+7, // 10 000 000 bytes = 10 MB
            (int)1E+8)] // 100 000 000 bytes = 100 MB
        public override int Bytes { get; set; }
    }

    public class AllocationBenchmarks
    {
        private List<byte[]> instances = new List<byte[]>(10);

        public virtual int Bytes { get; set; }

        [Benchmark(Baseline = true, Description = "new")]
        public void Allocate()
        {
            var array = new byte[Bytes];
            Blackhole(array);

            // I am NOT freeing the memory on Purpose
            // I want to test the allocation speed, not the GC throughput
            // this method is supposed to be called twice per each launch: once for JIT warmup, second time for the target
            instances.Add(array);
        }

        [Benchmark(Description = "Marshal")]
        public void AllocateWithMarshall()
        {
            var arrayPointer = Marshal.AllocHGlobal(Bytes);
            Blackhole(arrayPointer);

            // I am NOT freeing the memory on Purpose
            // why? because otherwise every other benchmark run will get the same block of memory 
            // that was returned for the warmup run, and it would show that Marshall is 100x faster than new
            // Marshal.FreeHGlobal(arrayPointer);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void Blackhole<T>(T input)
        {
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        protected unsafe void Blackhole(byte* input)
        {
        }
    }
}