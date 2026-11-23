namespace Test;

using System;
using System.Linq;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;

internal class Program
{
    static void Main(string[] args)
    {
#if RELEASE
        var config = DefaultConfig.Instance.AddJob(Job.Default
            .WithRuntime(CoreRuntime.Core10_0)
            .WithEnvironmentVariable("DOTNET_ROLL_FORWARD", "LatestPatch")
            .AsDefault());
        BenchmarkRunner.Run<Benchmark>(config, args);
#else
        foreach (var rowCount in new[] { 100, 10_000 })
        {
            foreach (var columnCount in new[] { 10, 100 })
            {
                var benchmark = new Benchmark
                {
                    RowCount = rowCount,
                    ColumnCount = columnCount
                };
                benchmark.GlobalSetup();
                var concatenated = benchmark.BuildTsvWithConcat();
                var built = benchmark.BuildTsvWithStringBuilder();

                if (concatenated.Count != rowCount || !concatenated.SequenceEqual(built))
                {
                    throw new InvalidOperationException("The TSV implementations returned different rows.");
                }

                for (var row = 0; row < rowCount; row++)
                {
                    var expected = string.Join('\t', Enumerable.Range(0, columnCount)
                        .Select(column => $"{row:D6}:{column:D3}".PadRight(64, 'x')));

                    if (concatenated[row] != expected)
                    {
                        throw new InvalidOperationException($"Unexpected TSV content in row {row}.");
                    }
                }

                var characterCount = concatenated.Sum(row => (long)row.Length);
                Console.WriteLine($"{rowCount:N0} rows x {columnCount} columns: {characterCount:N0} characters; outputs match.");
            }
        }
#endif
    }
}