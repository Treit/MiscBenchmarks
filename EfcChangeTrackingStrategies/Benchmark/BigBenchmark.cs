using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using Iced.Intel;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Test;

[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.Method)]
public class BigBenchmark
{
    private const int InitCount = 1_000;

    private readonly Dictionary<ChangeTrackingStrategy, IContext> Contexts = new()
    {
        [ChangeTrackingStrategy.Snapshot] = new SnapshotContext(),
        [ChangeTrackingStrategy.ChangingAndChangedNotificationsWithOriginalValues] = new ChangingAndChangedNotificationsWithOriginalValuesContext(),
        [ChangeTrackingStrategy.ChangedNotifications] = new ChangedNotificationsContext(),
        [ChangeTrackingStrategy.ChangingAndChangedNotifications] = new ChangingAndChangedNotificationsContext()
    };

    [Params(
        ChangeTrackingStrategy.Snapshot,
        ChangeTrackingStrategy.ChangingAndChangedNotificationsWithOriginalValues,
        ChangeTrackingStrategy.ChangedNotifications,
        ChangeTrackingStrategy.ChangingAndChangedNotifications
        )]
    public ChangeTrackingStrategy ChangeTrackingStrategy { get; set; }

    [GlobalSetup]
    public void GlobalSetup()
    {
        var ctx = Contexts.Values.First();
        //ctx.Database.Migrate();

        ctx.BigPeople.RemoveRange(ctx.BigPeople.ToList());

        ctx.SaveChanges();

        // Always have initial people to work with
        for (int i = 0; i < InitCount; i++)
            ctx.BigPeople.Add(new BigPerson() { IsInit = true });

        ctx.SaveChanges();
    }

    [GlobalCleanup]
    public void GlobalCleanup()
    {
        // Each iteration remove all people except the init people
        var ctx1 = Contexts.Values.First();
        ctx1.BigPeople.RemoveRange(ctx1.BigPeople.ToList());
        ctx1.SaveChanges();

        foreach (var ctx in Contexts.Values)
            ctx.ChangeTracker.Clear();
    }

    [IterationCleanup]
    public void IterationCleanup()
    {
        // Each iteration remove all people except the init people
        var ctx1 = Contexts.Values.First();
        ctx1.BigPeople.RemoveRange(ctx1.BigPeople.Where(x => !x.IsInit).ToList());
        ctx1.SaveChanges();

        foreach (var ctx in Contexts.Values)
            ctx.ChangeTracker.Clear();

        UniqueCounter = 0;
    }

    [Benchmark]
    public void Add_One()
    {
        var ctx = Contexts[ChangeTrackingStrategy];
        ctx.BigPeople.Add(new BigPerson());
        ctx.SaveChanges();
    }

    [Benchmark]
    public void Add_1k()
    {
        var ctx = Contexts[ChangeTrackingStrategy];

        for (int i = 0; i < 500; i++)
            ctx.BigPeople.Add(new BigPerson());

        ctx.SaveChanges();
    }

    [Benchmark]
    public void Update_All()
    {
        var ctx = Contexts[ChangeTrackingStrategy];

        foreach (var person in ctx.BigPeople.ToList())
        {
            string counter = (++UniqueCounter).ToString();
            person.Property1 = counter;
            person.Property250 = counter;
            person.Property500 = counter;
        }

        ctx.SaveChanges();
    }

    [Benchmark]
    public void Update_Quarter_Init()
    {
        var ctx = Contexts[ChangeTrackingStrategy];

        foreach (var person in ctx.BigPeople.ToList().Take(InitCount / 4))
        {
            string counter = (++UniqueCounter).ToString();
            person.Property1 = counter;
            person.Property250 = counter;
            person.Property500 = counter;
        }
        ctx.SaveChanges();
    }

    private static ulong UniqueCounter;
}