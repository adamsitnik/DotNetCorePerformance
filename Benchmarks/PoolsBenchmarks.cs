using System.Buffers;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using BenchmarkDotNet.Attributes;

namespace Benchmarks
{
    public class PoolsBenchmarks
    {
        //[Params((int)1E+2, // 100 bytes
        //    (int)1E+3, // 1 000 bytes = 1 KB
        //    (int)1E+4, // 10 000 bytes = 10 KB
        //    (int)1E+5, // 100 000 bytes = 100 KB
        //    (int)1E+6, // 1 000 000 bytes = 1 MB
        //    (int)1E+7, // 10 000 000 bytes = 10 MB
        //    (int)1E+8)] // 100 000 000 bytes = 100 MB
        public int Bytes = 1000000;

        private ArrayPool<byte> _dedicatedManagedPool;

        [Setup]
        public void Setup()
        {
            // default is 2^20
            _dedicatedManagedPool = ArrayPool<byte>.Create(maxArrayLength: Bytes + 1, maxArraysPerBucket: 1);
        }

        [Benchmark(Baseline = true, Description = "new")]
        public void Allocate()
        {
            var array = new byte[Bytes];
            Blackhole(array);
        }

        [Benchmark(Description = "stackalloc")]
        public unsafe void AllocateWithStackalloc()
        {
            var array = stackalloc byte[Bytes];
            Blackhole(array);
        }

        [Benchmark(Description = "Marshal")]
        public void AllocateWithMarshall()
        {
            var arrayPointer = Marshal.AllocHGlobal(Bytes);
            Blackhole(arrayPointer);
            Marshal.FreeHGlobal(arrayPointer);
        }

        [Benchmark(Description = "ArrayPool.Shared")]
        public void RentManagedFromShared()
        {
            var buffer = ArrayPool<byte>.Shared.Rent(Bytes);
            Blackhole(buffer);

            ArrayPool<byte>.Shared.Return(buffer);
        }

        [Benchmark(Description = "SizeAware")]
        public void RentManagedFromDedicated()
        {
            var buffer = _dedicatedManagedPool.Rent(Bytes);
            Blackhole(buffer);

            _dedicatedManagedPool.Return(buffer);
        }

        [Benchmark(Description = "NativePool.Shared")]
        public void RentUnmanaged()
        {
            var buffer = NativeBufferPool<byte>.SharedByteBufferPool.RentBuffer(Bytes);
            Blackhole(buffer);

            NativeBufferPool<byte>.SharedByteBufferPool.ReturnBuffer(ref buffer);
        }

        // it fails without any reason given ;/
        //[Benchmark(Description = "DedicatedUnmanagedPool.Rent()")]
        //public void RentUnmanagedFromDedicated()
        //{
        //    var buffer = _dedicatedUnmanagedPool.RentBuffer(Bytes);
        //    Blackhole(buffer);

        //    _dedicatedUnmanagedPool.ReturnBuffer(ref buffer);
        //}

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void Blackhole<T>(T input)
        {
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private unsafe void Blackhole(byte* input)
        {
        }
    }
}
