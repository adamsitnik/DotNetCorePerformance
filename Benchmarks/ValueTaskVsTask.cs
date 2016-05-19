using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Benchmarks
{
    public class ValueTaskVsTask
    {
        [Benchmark(Baseline = true, Description = "Creating instance of Task")]
        public Task<ValueTaskVsTask> CreateInstanceOfTask()
        {
            return Task.FromResult(this);
        }

        [Benchmark(Description = "Creating instance of Value Task")]
        public ValueTask<ValueTaskVsTask> CreateInstanceOfValueTask()
        {
            return new ValueTask<ValueTaskVsTask>(this);
        }
    }
}
