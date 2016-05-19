using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Columns;
using System;
using System.Linq;
using System.Reflection;

namespace Benchmarks
{
    public class Program
    {
        public static void Main(string[] args)
        {
#if !CORE
            var memoryDiagnoser = new BenchmarkDotNet.Diagnostics.Windows.MemoryDiagnoser();

            BenchmarkRunner
                .Run<ValueTaskVsTask>(
                    ManualConfig.CreateEmpty()
                        //.With(Job.Dry.With(Runtime.Clr).With(Platform.X64).With(Framework.V46).With(Jit.RyuJit).With(Mode.Throughput).WithWarmupCount(1).WithTargetCount(1))
                        .With(Job.Dry.With(Runtime.Core).With(Platform.X64).With(Jit.RyuJit).With(Mode.Throughput).WithWarmupCount(1).WithTargetCount(1))
                        .With(DefaultConfig.Instance.GetLoggers().ToArray())
                        .With(PropertyColumn.Method, PropertyColumn.Runtime, PropertyColumn.Platform, PropertyColumn.Jit, StatisticColumn.Median, BaselineDiffColumn.Scaled, BaselineDiffColumn.Delta)
                        .With(MarkdownExporter.Default)
                        .With(HtmlExporter.Default)
                        .RemoveBenchmarkFiles()
                        .With(memoryDiagnoser));
#else
            throw new InvalidOperationException("Please run this app as NET 4.6 app");
#endif
        }
    }
}
