using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;

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
    /// this benchmark is a very, very simplified
    /// I should have not called the Result and return Tasks, but for now BenchmarkDotNet does not support async/await
    /// </summary>
    public class ValueTaskVsTaskRecommendedScenario
    {
        //[Params(100, 1000)]
        public int Count = 100000;

        private int index;

        private int[] result;

        public ValueTaskVsTaskRecommendedScenario()
        {
            index = 0;
            result = new int[Count];
        }

        [Benchmark(Baseline = true, Description = "Task")]
        public int[] Reference()
        {
            return ReadAsync().Result;
        }

        private async Task<int[]> ReadAsync()
        {
            index = 0;
            while (index < Count)
            {
                result[index] += await AsynchronousOperation();
                index++;
            }
            return result;
        }

        private Task<int> AsynchronousOperation()
        {
            if (IsSynchronousOperationPossible())
            {
                return Task.FromResult(SynchronousOperation());
            }

            return Task.Factory.StartNew(SynchronousOperation);
        }

        private bool IsSynchronousOperationPossible() => index % 20 != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private int SynchronousOperation() => index * index * + 20;

        [Benchmark(Description = "ValueTask")]
        public int[] ValueType()
        {
            return ReadMixedAsync().Result;
        }

        private async Task<int[]> ReadMixedAsync()
        {
            index = 0;
            while (index < Count)
            {
                var valueTask = MixedOperation();
                if (valueTask.IsCompletedSuccessfully)
                {
                    result[index] = valueTask.Result;
                }
                else
                {
                    result[index] = await valueTask.AsTask();
                }
                index++;
            }

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private ValueTask<int> MixedOperation()
        {
            if (IsSynchronousOperationPossible())
            {
                return new ValueTask<int>(SynchronousOperation());
            }

            return new ValueTask<int>(Task.Factory.StartNew(SynchronousOperation));
        }
    }
}