using BenchmarkDotNet.Attributes;
using System.Threading.Tasks;

namespace Benchmarks
{
    public class ValueTaskVsTaskCreation
    {
        [Benchmark(Baseline = true, Description = "Task.FromResult")]
        public Task<ValueTaskVsTaskCreation> TaskFromResult()
        {
            return Task.FromResult(this);
        }

        [Benchmark(Description = "new ValueTask()")]
        public ValueTask<ValueTaskVsTaskCreation> ValueTaskCtor()
        {
            return new ValueTask<ValueTaskVsTaskCreation>(this);
        }

        [Benchmark(Description = "ValueTask.FromResult")]
        public ValueTask<ValueTaskVsTaskCreation> ValueTaskFromResult()
        {
            return FromResult(this);
        }

        // this method is created to mimic Task.FromResult
        // to show the diff with extra method call compared to ctor
        // because Task's ctor is not public
        private ValueTask<T> FromResult<T>(T instance)
        {
            return new ValueTask<T>(instance);
        }
    }
}
