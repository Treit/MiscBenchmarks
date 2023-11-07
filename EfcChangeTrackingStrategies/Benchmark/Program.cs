using BenchmarkDotNet.Analysers;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Running;

namespace Test;

internal class Program
{
    static void Main(string[] args)
    {
        var config = new ManualConfig();
        config.AddColumnProvider(DefaultConfig.Instance.GetColumnProviders().ToArray());
        config.AddExporter(DefaultConfig.Instance.GetExporters().ToArray());
        config.AddDiagnoser(DefaultConfig.Instance.GetDiagnosers().ToArray());
        config.AddAnalyser(DefaultConfig.Instance.GetAnalysers().ToArray());
        config.AddJob(DefaultConfig.Instance.GetJobs().ToArray());
        config.AddValidator(DefaultConfig.Instance.GetValidators().ToArray());
        config.UnionRule = ConfigUnionRule.AlwaysUseGlobal; // Overriding the default

        var smallSummary = BenchmarkRunner.Run<SmallBenchmark>(config);
        var bigSummary = BenchmarkRunner.Run<BigBenchmark>(config);

        var logger = ConsoleLogger.Default;
        MarkdownExporter.Console.ExportToLog(smallSummary, logger);
        ConclusionHelper.Print(logger, smallSummary.BenchmarksCases.First().Config.GetCompositeAnalyser().Analyse(smallSummary).ToList());

        MarkdownExporter.Console.ExportToLog(bigSummary, logger);
        ConclusionHelper.Print(logger, bigSummary.BenchmarksCases.First().Config.GetCompositeAnalyser().Analyse(bigSummary).ToList());
    }
}
