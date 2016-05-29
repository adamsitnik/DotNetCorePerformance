using BenchmarkDotNet.Attributes;
using System.Threading.Tasks;

namespace Benchmarks
{
    public class ValueTaskVsTaskCreation
    {
        [Benchmark(Baseline = true)]//, Description = "Creating instance of Task via Task.FromResult")]
        public Task<ValueTaskVsTaskCreation> TaskFromResult()
        {
            return Task.FromResult(this);
        }

        [Benchmark]//(Description = "Creating instance of Value Task via constructor call")]
        public ValueTask<ValueTaskVsTaskCreation> ValueTaskCtor()
        {
            return new ValueTask<ValueTaskVsTaskCreation>(this);
        }

        [Benchmark]//(Description = "Creating instance of Value Task via call to FromResult")]
        public ValueTask<ValueTaskVsTaskCreation> ValueTaskFromResult()
        {
            return FromResult(this);
        }

        private ValueTask<T> FromResult<T>(T instance)
        {
            return new ValueTask<T>(instance);
        }
    }
}
