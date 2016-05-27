using System.Buffers;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using BenchmarkDotNet.Attributes;

namespace Benchmarks
{
    public class ArrayPoolBenchmarks
    {
        [Params((int)1E+2, // 100 bytes
            (int)1E+3, // 1 000 bytes = 1 KB
            (int)1E+4, // 10 000 bytes = 10 KB
            (int)1E+5, // 100 000 bytes = 100 KB
            (int)1E+6, // 1 000 000 bytes = 1 MB
            (int)1E+7, // 10 000 000 bytes = 10 MB
            (int)1E+8)] // 100 000 000 bytes = 100 MB
        public int Bytes;

        private ArrayPool<byte> _dedicatedManagedPool;

        [Setup]
        public void Setup()
        {
            // the default for max size is 2MB, taken as the default since the average HTTP page is 1.9MB
            // per http://httparchive.org/interesting.php, as of October 2015
            // so here I set it in explicit way
            _dedicatedManagedPool = ArrayPool<byte>.Create(maxArrayLength: Bytes + 1, maxArraysPerBucket: 1);
        }

        [Benchmark(Baseline = true, Description = "new byte[]")]
        public void Allocate()
        {
            var array = new byte[Bytes];
            Blackhole(array);
        }

        [Benchmark(Description = "stackalloc byte[]")]
        public unsafe void AllocateWithStackalloc()
        {
            var array = stackalloc byte[Bytes];
            Blackhole(array);
        }

        [Benchmark(Description = "Marshal.AllocHGlobal()")]
        public void AllocateWithMarshall()
        {
            var arrayPointer = Marshal.AllocHGlobal(Bytes);
            Blackhole(arrayPointer);
            Marshal.FreeHGlobal(arrayPointer);
        }

        [Benchmark(Description = "ArrayPool<byte>.Shared.Rent()")]
        public void RentManagedFromShared()
        {
            var buffer = ArrayPool<byte>.Shared.Rent(Bytes);
            Blackhole(buffer);

            ArrayPool<byte>.Shared.Return(buffer);
        }

        [Benchmark(Description = "DedicatedManagedPool.Rent()")]
        public void RentManagedFromDedicated()
        {
            var buffer = _dedicatedManagedPool.Rent(Bytes);
            Blackhole(buffer);

            _dedicatedManagedPool.Return(buffer);
        }

        [Benchmark(Description = "NativeBufferPool<byte>.Shared.RentBuffer()")]
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
