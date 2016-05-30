using System;
using System.Text;
using BenchmarkDotNet.Attributes;

namespace Benchmarks
{
    public class SubslicesBenchmarks
    {
        const string Text = ".NET Core: Performance Storm!";

        [Benchmark(Baseline = true, Description = "String.Substring")]
        public string StringSubstring()
        {
            return Text.Substring(startIndex: 0, length: 9);
        }

        [Benchmark(Description = "Subslice")]
        public ReadOnlySpan<char> StringSlice()
        {
            return Text.Slice(start: 0, length: 9);
        }
    }
}