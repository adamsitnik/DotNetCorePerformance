using BenchmarkDotNet.Attributes;
using System.Threading.Tasks;

namespace Benchmarks
{
    /// <summary>
    /// "Methods should return an instance of ValueTask when it's likely that the result of their
    /// operations will be available synchronously and when the method is expected to be invoked so
    /// frequently that the cost of allocating a new <see cref="Task{TResult}"/> for each call will
    /// be prohibitive."
    /// 
    /// The purpose of this benchmark is to show the gain in sample recommended scenario
    /// 
    /// the code is synchronous on purpose to avoid any overheads of asynchrony!!
    /// </summary>
    public class TypicalScenario
    {
        [Params(0, 10, 100, 10000)]
        public int Count;

        [Benchmark(Baseline = true, Description = "Task")]
        public int Reference()
        {
            int result = 0;
            var reader = new TaskReader(Count);
            while(reader.IsDataAvailable().Result)
            {
                result += reader.ReadNext().Result;
            }
            return result;
        }

        [Benchmark(Description = "Value Task")]
        public int Value()
        {
            int result = 0;
            var reader = new ValueTaskReader(Count);
            while (reader.IsDataAvailable().Result)
            {
                result += reader.ReadNext().Result;
            }
            return result;
        }

        [Benchmark(Description = "Cached Task")]
        public int CachedReference()
        {
            int result = 0;
            var reader = new CachedTaskReader(Count);
            while (reader.IsDataAvailable().Result)
            {
                result += reader.ReadNext().Result;
            }
            return result;
        }

// all "Readers" are structures to avoid any additional heap allocation that could affect benchmark

        struct TaskReader
        {
            int index, maxCount;

            public TaskReader(int maxCount) { this.maxCount = maxCount; index = 0; }

            public Task<bool> IsDataAvailable() => Task.FromResult(index++ < maxCount);

            public Task<int> ReadNext() => Task.FromResult(index);
        }

        struct ValueTaskReader
        {
            int index, maxCount;

            public ValueTaskReader(int maxCount) { this.maxCount = maxCount; index = 0; }

            public ValueTask<bool> IsDataAvailable() => new ValueTask<bool>(index++ < maxCount);

            public ValueTask<int> ReadNext() => new ValueTask<int>(index);
        }

        struct CachedTaskReader
        {
            int index, maxCount;

            static Task<bool> available = Task.FromResult(true);

            static Task<bool> unavailable = Task.FromResult(false);

            public CachedTaskReader(int maxCount) { this.maxCount = maxCount; index = 0; }

            public Task<bool> IsDataAvailable() => index++ < maxCount ? available : unavailable;

            public Task<int> ReadNext() => Task.FromResult(index);
        }
    }
}
