using BenchmarkDotNet.Attributes;
using Microsoft.EntityFrameworkCore;

namespace Test;

public class Benchmark
{
    [GlobalSetup]
    public void Setup()
    {
    }

    [IterationCleanup]
    public void Cleanup()
    {
        using var ctx = new Context(ChangeTrackingStrategy.Snapshot);
        ctx.People.RemoveRange(ctx.People.ToList());
        ctx.SaveChanges();
    }

    [Benchmark(Baseline = true)]
    public void Add_1k_Snapshot()
    {
        using var ctx = new Context(ChangeTrackingStrategy.Snapshot);

        for (int i = 0; i < 1_000; i++)
            ctx.People.Add(new Person() { FullName = "123" });

        ctx.SaveChanges();
    }

    [Benchmark]
    public void Add_1k_ChangedNotifications()
    {
        using var ctx = new Context(ChangeTrackingStrategy.ChangedNotifications);

        for (int i = 0; i < 1_000; i++)
            ctx.People.Add(new Person() { FullName = "123" });

        ctx.SaveChanges();
    }

    [Benchmark]
    public void Add_1k_ChangingAndChangedNotifications()
    {
        using var ctx = new Context(ChangeTrackingStrategy.ChangingAndChangedNotifications);

        for (int i = 0; i < 1_000; i++)
            ctx.People.Add(new Person() { FullName = "123" });

        ctx.SaveChanges();
    }

    [Benchmark]
    public void Add_1k_ChangingAndChangedNotificationsWithOriginalValues()
    {
        using var ctx = new Context(ChangeTrackingStrategy.ChangingAndChangedNotificationsWithOriginalValues);

        for (int i = 0; i < 1_000; i++)
            ctx.People.Add(new Person() { FullName = "123" });

        ctx.SaveChanges();
    }
}