using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;

namespace Benchmarks
{
    public class SliceVsArrayVsList
    {
        [Params(1, 10, 100, 1000)]
        public int Length;

        protected int[] array;
        protected Span<int> slice;
        protected List<int> list;

        [Setup]
        public void Setup()
        {
            array = Enumerable.Range(0, Length).ToArray();
            slice = array.Slice();
            list = array.ToList();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        protected static void Blackhole<T>(T input) { }
    }

    public class IndexersBenchmarks : SliceVsArrayVsList
    {
        [Benchmark(Baseline = true)]
        public int ArrayIndexer()
        {
            return array[Length - 1];
        }

        [Benchmark]
        public int SliceIndexer()
        {
            return slice[Length - 1];
        }

        [Benchmark]
        public int ListIndexer()
        {
            return list[Length - 1];
        }
    }

    public class ForLoopBenchmarks : SliceVsArrayVsList
    {
        [Benchmark(Baseline = true)]
        public void ArrayForLoop()
        {
            for (int i = 0; i < array.Length; i++)
            {
                Blackhole(array[i]);
            }
        }

        [Benchmark]
        public void SliceForLoop()
        {
            for (int i = 0; i < slice.Length; i++)
            {
                Blackhole(slice[i]);
            }
        }

        [Benchmark]
        public void ListForLoop()
        {
            for (int i = 0; i < list.Count; i++)
            {
                Blackhole(list[i]);
            }
        }
    }

    public class StrongEnumeratorBenchmarks : SliceVsArrayVsList
    {
        [Benchmark(Baseline = true)]
        public void ArrayStrongEnumerator()
        {
            foreach (var item in array)
            {
                Blackhole(item);
            }
        }

        [Benchmark]
        public void SliceStrongEnumerator()
        {
            foreach (var item in slice)
            {
                Blackhole(item);
            }
        }

        [Benchmark]
        public void ListStrongEnumerator()
        {
            foreach (var item in list)
            {
                Blackhole(item);
            }
        }
    }

    public class ObjectEnumeratorBenchmarks : SliceVsArrayVsList
    {
        [Benchmark(Baseline = true)]
        public void ArrayObjectEnumerator()
        {
            IterateOverEnumerable(array);
        }

        [Benchmark]
        public void SliceObjectEnumerator()
        {
            IterateOverEnumerable(slice);
        }

        [Benchmark]
        public void ListObjectEnumerator()
        {
            IterateOverEnumerable(list);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void IterateOverEnumerable(IEnumerable<int> enumerable)
        {
            foreach (var item in enumerable)
            {
                Blackhole(item);
            }
        }
    }
}
