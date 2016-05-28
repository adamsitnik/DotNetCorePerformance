using System;
using System.Linq;
using System.Runtime.InteropServices;
using BenchmarkDotNet.Attributes;

namespace Benchmarks
{
    public class SpanVsMemcmp
    {
        [Params(0, 1, 10, 100, 1000, 100000, 1000000)]
        public int ItemsCount = 0;

        // we compare array with it's own copy just to measure the pessimistic scenario - full range check required
        private byte[] arrayValues, arraySameValues;
        private Span<byte> spanValues, spanSameValues;

        [Setup]
        public void SetupData()
        {
            arrayValues = Enumerable.Range(0, ItemsCount).Select(number => (byte)number).ToArray();
            arraySameValues = arrayValues.ToArray();
            spanValues = arrayValues.Slice();
            spanSameValues = arraySameValues.Slice();
        }

        [DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe int memcmp(byte* first, byte* second, int count);

        [Benchmark(Baseline = true)]
        public bool MemCmp()
        {
            unsafe
            {
                fixed (byte* first = arrayValues, second = arraySameValues)
                {
                    return memcmp(first, second, arrayValues.Length) == 0;
                }
            }
        }

        [Benchmark]
        public bool SliceSequenceEqual()
        {
            return spanValues.SequenceEqual(spanSameValues);
        }

        [Benchmark]
        public bool SliceBlockEqual()
        {
            return spanValues.BlockEquals(spanSameValues);
        }
    }
}