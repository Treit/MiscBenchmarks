using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Order;
using BenchmarkDotNet.Running;
using Microsoft.EntityFrameworkCore;

namespace Test;

internal class Program
{
    static void Main(string[] args)
    {
#if RELEASE
        //BenchmarkRunner.Run<SmallBenchmark>();
        BenchmarkRunner.Run<BigBenchmark>();
        //var benchmark = new BigBenchmark();

        //Console.WriteLine("Snapshot:");
        //benchmark.ChangeTrackingStrategy = ChangeTrackingStrategy.Snapshot;
        //benchmark.GlobalSetup();
        //benchmark.BigPerson_Update_Half_Init();

        //Console.WriteLine("ChangingAndChangedNotification:");
        //benchmark.ChangeTrackingStrategy = ChangeTrackingStrategy.ChangingAndChangedNotifications;
        //benchmark.GlobalSetup();
        //benchmark.BigPerson_Update_Half_Init();
#else
        var benchmark1 = new Benchmark();
        benchmark1.GlobalSetup();
        benchmark1.SmallPerson_Add_One();
        benchmark1.BigPerson_Add_One();
#endif
    }
}
