using System;
using System.Linq;
using BenchmarkDotNet.Attributes;
using System.Runtime.InteropServices;

namespace Benchmarks.Classic
{
    public class UnsafeApi
    {
        [Params(1000000)]
        public int ItemsCount = 0;

        private byte[] source, target;

        [Setup]
        public void Setup()
        {
            source = Enumerable.Range(0, ItemsCount).Select(integer => (byte)integer).ToArray();
            target = new byte[ItemsCount];
        }

        [DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe void memcpy(byte* first, byte* second, int count);

        [Benchmark(Baseline = true)]
        public unsafe void ExternMemCpy()
        {
            fixed (byte* first = source, second = target)
            {
                memcpy(first, second, source.Length);
            }
        }

        [Benchmark]
        public unsafe void UnsafeCopyBlock()
        {
            fixed (byte* sourcePointer = source, targetPointer = target)
            {
                System.Runtime.CompilerServices.Unsafe.CopyBlock(targetPointer, sourcePointer, (uint)ItemsCount);
            }
        }

        [Benchmark]
        public void BufferBlockCopy()
        {
            Buffer.BlockCopy(source, 0, target, 0, source.Length);
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