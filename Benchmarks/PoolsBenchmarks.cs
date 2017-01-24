using System.Buffers;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Order;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using System.Linq;

namespace Benchmarks
{
    //[Config(typeof(PoolsBenchmarksConfig))]
    public class PoolsBenchmarks
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

        // it does not prove anything, because single block of memory would be reused all the time
        //[Benchmark(Description = "Marshal")]
        //public void AllocateWithMarshall()
        //{
        //    var arrayPointer = Marshal.AllocHGlobal(Bytes);
        //    Blackhole(arrayPointer);
        //    Marshal.FreeHGlobal(arrayPointer);
        //}

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
            var buffer =  NativeBufferPool.Shared.Rent(Bytes);
            Blackhole(buffer);

            NativeBufferPool.Shared.Return(buffer);
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

    internal class PoolsBenchmarksConfig : ManualConfig
    {
        public PoolsBenchmarksConfig()
        {
            Set(new SlowestToFastestOrderProvider());
        }

        private class SlowestToFastestOrderProvider : IOrderProvider
        {
            public IEnumerable<Benchmark> GetExecutionOrder(Benchmark[] benchmarks) =>
                from benchmark in benchmarks
                orderby benchmark.Parameters["Bytes"] descending,
                        benchmark.Target.DisplayInfo
                select benchmark;

            public IEnumerable<Benchmark> GetSummaryOrder(Benchmark[] benchmarks, Summary summary) =>
                from benchmark in benchmarks
                orderby summary[benchmark]?.ResultStatistics?.Median descending
                select benchmark;

            public string GetGroupKey(Benchmark benchmark, Summary summary) => null;
        }
    }
}
