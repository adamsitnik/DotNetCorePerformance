using System;
using System.Linq;
using BenchmarkDotNet.Attributes;

namespace Benchmarks.RC4
{
    public class UnsafeApi
    {
        [Params(0, 1, 10, 100, 1000, 100000, 1000000)]
        public int ItemsCount = 0;

        private byte[] source, target;

        [Setup]
        public void Setup()
        {
            source = Enumerable.Range(0, ItemsCount).Select(integer => (byte)integer).ToArray();
            target = new byte[ItemsCount];
        }

        [Benchmark]
        public unsafe void UnsafeBlockCopy()
        {
            fixed (byte* sourcePointer = source, targetPointer = target)
            {
                System.Runtime.CompilerServices.Unsafe.CopyBlock(targetPointer, sourcePointer, (uint)ItemsCount);
            }
        }

        [Benchmark]
        public void ArrayCopy()
        {
            Array.Copy(source, target, ItemsCount);
        }

        [Benchmark]
        public void CopyLoop()
        {
            for (int i = 0; i < source.Length; i++)
            {
                target[i] = source[i];
            }
        }
    }
}