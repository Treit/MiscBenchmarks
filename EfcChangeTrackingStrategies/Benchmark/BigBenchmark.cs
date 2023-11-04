using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Test;

[SimpleJob(launchCount: 1, warmupCount: 2, iterationCount: 3)]
public class BigBenchmark
{
    private const int InitCount = 1_000;

    private readonly Dictionary<ChangeTrackingStrategy, Context> Contexts = new Dictionary<ChangeTrackingStrategy, Context>()
    {
        [ChangeTrackingStrategy.Snapshot] = new Context(ChangeTrackingStrategy.Snapshot),
        //[ChangeTrackingStrategy.ChangingAndChangedNotificationsWithOriginalValues] = new Context(ChangeTrackingStrategy.ChangingAndChangedNotificationsWithOriginalValues),
        //[ChangeTrackingStrategy.ChangedNotifications] = new Context(ChangeTrackingStrategy.ChangedNotifications),
        [ChangeTrackingStrategy.ChangingAndChangedNotifications] = new Context(ChangeTrackingStrategy.ChangingAndChangedNotifications)
    };

    [Params(
        ChangeTrackingStrategy.Snapshot,
        //ChangeTrackingStrategy.ChangingAndChangedNotificationsWithOriginalValues,
        //ChangeTrackingStrategy.ChangedNotifications,
        ChangeTrackingStrategy.ChangingAndChangedNotifications
        )]
    public ChangeTrackingStrategy ChangeTrackingStrategy { get; set; }

    [GlobalSetup]
    public void GlobalSetup()
    {
        var ctx = Contexts.Values.First();
        //ctx.Database.Migrate();

        ctx.BigPeople.RemoveRange(ctx.BigPeople.ToList().ToList());

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
        ctx1.BigPeople.RemoveRange(ctx1.BigPeople.ToList().ToList());
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
        ctx.ChangeTracker.Clear();
    }

    [Benchmark]
    public void Add_HalfOfTotal()
    {
        var ctx = Contexts[ChangeTrackingStrategy];

        for (int i = 0; i < (InitCount / 2); i++)
            ctx.BigPeople.Add(new BigPerson());

        ctx.SaveChanges();
        ctx.ChangeTracker.Clear();
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
        ctx.ChangeTracker.Clear();
    }

    [Benchmark]
    public void Update_Half_Init()
    {
        var ctx = Contexts[ChangeTrackingStrategy];

        foreach (var person in ctx.BigPeople.ToList().Take(InitCount / 2))
        {
            string counter = (++UniqueCounter).ToString();
            person.Property1 = counter;
            person.Property250 = counter;
            person.Property500 = counter;
        }

        ctx.SaveChanges();
        ctx.ChangeTracker.Clear();
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
        ctx.ChangeTracker.Clear();
    }

    [Benchmark]
    public void Update_10_Init()
    {
        var ctx = Contexts[ChangeTrackingStrategy];

        foreach (var person in ctx.BigPeople.ToList().Take(10))
        {
            string counter = (++UniqueCounter).ToString();
            person.Property1 = counter;
            person.Property250 = counter;
            person.Property500 = counter;
        }

        ctx.SaveChanges();
        ctx.ChangeTracker.Clear();
    }

    private static ulong UniqueCounter;
}