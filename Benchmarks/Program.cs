using System.Collections.Generic;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Columns;
using System.Linq;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Order;
using BenchmarkDotNet.Reports;

namespace Benchmarks
{
    public class Program
    {
        /// <summary>
        /// execute from cmd with: 
        ///     "dotnet run --framework net46 --configuration Release"
        ///     "dotnet run --framework netcoreapp1.1 --configuration Release"
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            var config = ManualConfig.CreateEmpty()
                // uncomment to benchmark classic Clr
                //.With(Job.Dry.With(Runtime.Clr).With(Platform.X64).With(Framework.V46).With(Jit.RyuJit).With(Mode.Throughput).WithWarmupCount(1).WithTargetCount(1))
                .With(Job.Default.With(new GcMode() { Force = false, Concurrent = true, Server = false }))
                // uncomment to benchmark allocations
                //.With(Job.Dry.With(Runtime.Core).With(Platform.X64).With(Jit.RyuJit).With(Mode.SingleRun).WithLaunchCount(10))
                .With(DefaultConfig.Instance.GetLoggers().ToArray())
                .With(DefaultConfig.Instance.GetColumnProviders().ToArray())
                .With(StatisticColumn.Min, StatisticColumn.Max, StatisticColumn.Median, StatisticColumn.Mean)
                //.With(PropertyColumn.Method, PropertyColumn.Runtime, PropertyColumn.Platform, PropertyColumn.Jit, StatisticColumn.Median, StatisticColumn.StdDev, StatisticColumn.Max, StatisticColumn.Min, BaselineDiffColumn.Scaled, BaselineDiffColumn.Delta)
                .With(MarkdownExporter.GitHub)
                .With(HtmlExporter.Default)
                .With(MemoryDiagnoser.Default)
                // uncomment to get image representation
                //.With(CsvMeasurementsExporter.Default)
                //.With(RPlotExporter.Default)
                // uncomment to sort the results 
                //.With(new SlowestToFastestOrderProviderWithoutParameters())
                .KeepBenchmarkFiles();

#if CLASSIC
            // the parent process is Classic Desktop Clr, but the child process is CoreClr
            // so we can use memory diagnoser and attach to it and get it working for .NET Core!
            // uncomment to check inlining
            //config = config.With(new BenchmarkDotNet.Diagnostics.Windows.InliningDiagnoser());
#endif

            BenchmarkRunner
                .Run<LargeObjectHeapBenchmarks>(config);
        }

        private class SlowestToFastestOrderProviderWithoutParameters : IOrderProvider
        {
            public IEnumerable<Benchmark> GetExecutionOrder(Benchmark[] benchmarks) => benchmarks;

            public IEnumerable<Benchmark> GetSummaryOrder(Benchmark[] benchmarks, Summary summary) =>
                from benchmark in benchmarks
                orderby summary[benchmark]?.ResultStatistics?.Median descending
                select benchmark;

            public string GetGroupKey(Benchmark benchmark, Summary summary) => null;
        }
    }
}
