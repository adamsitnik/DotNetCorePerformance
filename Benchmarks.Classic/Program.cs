using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Benchmarks.Classic
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = ManualConfig.CreateEmpty()
                .With(Job.Dry.With(Runtime.Clr).With(Platform.X64).With(Framework.V46).With(Jit.RyuJit).With(Mode.Throughput).WithWarmupCount(1).WithTargetCount(20))
                .With(DefaultConfig.Instance.GetLoggers().ToArray())
                .With(PropertyColumn.Method, PropertyColumn.Runtime, PropertyColumn.Platform, PropertyColumn.Jit, StatisticColumn.Median, StatisticColumn.StdDev, BaselineDiffColumn.Scaled, BaselineDiffColumn.Delta)
                .With(MarkdownExporter.Default)
                .With(HtmlExporter.Default)
                //.With(CsvMeasurementsExporter.Default)
                //.With(RPlotExporter.Default)
                .RemoveBenchmarkFiles();

            config = config.With(new BenchmarkDotNet.Diagnostics.Windows.MemoryDiagnoser());
            //config = config.With(new BenchmarkDotNet.Diagnostics.Windows.InliningDiagnoser());

            BenchmarkRunner
                .Run<UnsafeApi>(config);
        }
    }
}
