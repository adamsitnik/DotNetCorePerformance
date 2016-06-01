﻿using System.Collections.Generic;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Columns;
using System.Linq;
using BenchmarkDotNet.Order;
using BenchmarkDotNet.Reports;

namespace Benchmarks
{
    public class Program
    {
        /// <summary>
        /// execute from cmd with: 
        ///     "dotnet run --framework net46 --configuration Release" (with Memory Diagnostics)
        ///     "dotnet run --framework netcoreapp1.0 --configuration Release" (without Memory Diagnostics but cross platform)
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            var config = ManualConfig.CreateEmpty()
                //.With(Job.Dry.With(Runtime.Clr).With(Platform.X64).With(Framework.V46).With(Jit.RyuJit).With(Mode.Throughput).WithWarmupCount(1).WithTargetCount(1))
                //.With(Job.Dry.With(Runtime.Core).With(Platform.X64).With(Jit.RyuJit).With(Mode.Throughput).WithWarmupCount(1).WithTargetCount(20))
                .With(Job.Dry.With(Runtime.Core).With(Platform.X64).With(Jit.RyuJit).With(Mode.SingleRun).WithLaunchCount(10))
                .With(DefaultConfig.Instance.GetLoggers().ToArray())
                .With(PropertyColumn.Method, PropertyColumn.Runtime, PropertyColumn.Platform, PropertyColumn.Jit, StatisticColumn.Median, StatisticColumn.StdDev, StatisticColumn.Max, StatisticColumn.Min, BaselineDiffColumn.Scaled, BaselineDiffColumn.Delta)
                .With(MarkdownExporter.Default)
                .With(HtmlExporter.Default)
                .With(CsvMeasurementsExporter.Default)
                .With(RPlotExporter.Default)
                //.With(new SlowestToFastestOrderProviderWithoutParameters())
                .RemoveBenchmarkFiles();

#if CLASSIC
            // the parent process is Classic Desktop Clr, but the child process is CoreClr
            // so we can use memory diagnoser and attach to it and get it working for .NET Core!
            config = config.With(new BenchmarkDotNet.Diagnostics.Windows.MemoryDiagnoser());
            //config = config.With(new BenchmarkDotNet.Diagnostics.Windows.InliningDiagnoser());
#endif

            BenchmarkRunner
                .Run<SmallAllocationBenchmarks>(config);
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

        private static IJob SingleRunWithoutWarmup(IJob job)
        {
            return job
                .With(Mode.SingleRun)
                .WithWarmupCount(0);
        }
    }
}
