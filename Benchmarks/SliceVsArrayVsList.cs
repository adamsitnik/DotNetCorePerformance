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
        public int ArrayForLoop()
        {
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }
            return sum;
        }

        [Benchmark]
        public int SliceForLoop()
        {
            int sum = 0;
            for (int i = 0; i < slice.Length; i++)
            {
                sum += slice[i];
            }
            return sum;
        }

        [Benchmark]
        public int ListForLoop()
        {
            int sum = 0;
            for (int i = 0; i < list.Count; i++)
            {
                sum += list[i];
            }
            return sum;
        }
    }

    public class StrongEnumeratorBenchmarks : SliceVsArrayVsList
    {
        [Benchmark(Baseline = true)]
        public int ArrayStrongEnumerator()
        {
            int sum = 0;
            foreach (var item in array)
            {
                sum += item;
            }
            return sum;
        }

        [Benchmark]
        public int SliceStrongEnumerator()
        {
            int sum = 0;
            foreach (var item in slice)
            {
                sum += item;
            }
            return sum;
        }

        [Benchmark]
        public int ListStrongEnumerator()
        {
            int sum = 0;
            foreach (var item in list)
            {
                sum += item;
            }
            return sum;
        }
    }

    public class ObjectEnumeratorBenchmarks : SliceVsArrayVsList
    {
        [Benchmark(Baseline = true)]
        public int ArrayObjectEnumerator()
        {
            return IterateOverEnumerable(array);
        }

        [Benchmark]
        public int SliceObjectEnumerator()
        {
            return IterateOverEnumerable(slice);
        }

        [Benchmark]
        public int ListObjectEnumerator()
        {
            return IterateOverEnumerable(list);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private int IterateOverEnumerable(IEnumerable<int> enumerable)
        {
            int sum = 0;
            foreach (var item in enumerable)
            {
                sum += item;
            }
            return sum;
        }
    }
}
