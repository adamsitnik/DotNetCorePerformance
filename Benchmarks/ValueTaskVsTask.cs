using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Benchmarks
{
    public class ValueTaskVsTask
    {
        [Benchmark(Baseline = true, Description = "Creating instance of Task via Task.FromResult")]
        public Task<ValueTaskVsTask> TaskFromResult()
        {
            return Task.FromResult(this);
        }

        [Benchmark(Description = "Creating instance of Value Task via constructor call")]
        public ValueTask<ValueTaskVsTask> ValueTaskCtor()
        {
            return new ValueTask<ValueTaskVsTask>(this);
        }

        [Benchmark(Description = "Creating instance of Value Task via call to FromResult")]
        public ValueTask<ValueTaskVsTask> ValueTaskFromResult()
        {
            return FromResult(this);
        }

        private ValueTask<T> FromResult<T>(T instance)
        {
            return new ValueTask<T>(instance);
        }
    }
}
