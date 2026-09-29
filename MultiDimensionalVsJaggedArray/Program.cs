namespace Test;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using System;

internal class Program
{
    static void Main(string[] args)
    {
#if RELEASE
        var config = DefaultConfig.Instance
            .AddJob(Job.Default
                .WithRuntime(CoreRuntime.Core10_0)
                .WithMsBuildArguments("/p:BenchmarkTargeting=true"))
            .AddJob(Job.Default
                .WithRuntime(CoreRuntime.Core11_0)
                .WithMsBuildArguments("/p:BenchmarkTargeting=true"));

        BenchmarkRunner.Run<Benchmark>(config);
#else
        Benchmark b = new Benchmark();
        b.Size = 1024;
        b.GlobalSetup();
        Console.WriteLine(b.SumJagged());
        Console.WriteLine(b.SumJaggedLinq());
        Console.WriteLine(b.SumMultiDimensionalLinq());
#endif

    }
}
