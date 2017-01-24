using System;
using BenchmarkDotNet.Attributes;

namespace Benchmarks
{
    public class LargeObjectHeapBenchmarks
    {
        const int LohSizeThreshold = 85000;

        private static readonly int ArraySizeOverhead = 3 * IntPtr.Size;

        [Benchmark]
        public byte[] LOH() => new byte[LohSizeThreshold - ArraySizeOverhead + 1];

        [Benchmark]
        public byte[] SOH() => new byte[LohSizeThreshold - ArraySizeOverhead - 1];
    }
}