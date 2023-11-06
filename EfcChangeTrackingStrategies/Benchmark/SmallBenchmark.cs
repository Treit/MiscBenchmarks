using BenchmarkDotNet.Attributes;
using Microsoft.EntityFrameworkCore;

namespace Test;

[SimpleJob(launchCount: 1, warmupCount: 2, iterationCount: 3)]
public class SmallBenchmark
{
    private const int InitCount = 250_000;

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

        ctx.SmallPeople.RemoveRange(ctx.SmallPeople.ToList());

        ctx.SaveChanges();

        // Always have initial people to work with
        for (int i = 0; i < InitCount; i++)
            ctx.SmallPeople.Add(new SmallPerson() { IsInit = true });

        ctx.SaveChanges();
    }

    [GlobalCleanup]
    public void GlobalCleanup()
    {
        // Each iteration remove all people except the init people
        var ctx1 = Contexts.Values.First();
        ctx1.SmallPeople.RemoveRange(ctx1.SmallPeople.ToList());
        ctx1.SaveChanges();

        foreach (var ctx in Contexts.Values)
            ctx.ChangeTracker.Clear();
    }

    [IterationCleanup]
    public void IterationCleanup()
    {
        // Each iteration remove all people except the init people
        var ctx1 = Contexts.Values.First();
        ctx1.SmallPeople.RemoveRange(ctx1.SmallPeople.Where(x => !x.IsInit).ToList());
        ctx1.SaveChanges();

        foreach (var ctx in Contexts.Values)
            ctx.ChangeTracker.Clear();

        UniqueCounter = 0;
    }

    [Benchmark]
    public void SmallPerson_Add_One()
    {
        var ctx = Contexts[ChangeTrackingStrategy];
        ctx.SmallPeople.Add(new SmallPerson());
        ctx.SaveChanges();
    }

    [Benchmark]
    public void SmallPerson_Add_Half()
    {
        var ctx = Contexts[ChangeTrackingStrategy];

        for (int i = 0; i < (InitCount / 2); i++)
            ctx.SmallPeople.Add(new SmallPerson());

        ctx.SaveChanges();
    }

    [Benchmark]
    public void SmallPerson_Update_All()
    {
        var ctx = Contexts[ChangeTrackingStrategy];

        foreach (var person in ctx.SmallPeople.ToList())
            person.FullName = (++UniqueCounter).ToString();

        ctx.SaveChanges();
    }

    [Benchmark]
    public void SmallPerson_Update_Half_Init()
    {
        var ctx = Contexts[ChangeTrackingStrategy];

        foreach (var person in ctx.SmallPeople.ToList().Take(InitCount / 2))
            person.FullName = (++UniqueCounter).ToString();

        ctx.SaveChanges();
    }

    [Benchmark]
    public void SmallPerson_Update_Quarter_Init()
    {
        var ctx = Contexts[ChangeTrackingStrategy];

        foreach (var person in ctx.SmallPeople.ToList().Take(InitCount / 4))
            person.FullName = (++UniqueCounter).ToString();

        ctx.SaveChanges();
    }

    [Benchmark]
    public void SmallPerson_Update_10_Init()
    {
        var ctx = Contexts[ChangeTrackingStrategy];

        foreach (var person in ctx.SmallPeople.ToList().Take(10))
            person.FullName = (++UniqueCounter).ToString();

        ctx.SaveChanges();
    }
    
    private static ulong UniqueCounter;
}
