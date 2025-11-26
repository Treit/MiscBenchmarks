using BenchmarkDotNet.Attributes;
using Microsoft.EntityFrameworkCore;
using BenchmarkDotNet.Jobs;

namespace Test;

[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.Method)]
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
        ctx.Database.EnsureDeleted();
        ctx.Database.EnsureCreated();

        // Always have initial people to work with
        for (int i = 0; i < InitCount; i++)
            ctx.SmallPeople.Add(new SmallPerson() { IsInit = true });

        ctx.SaveChanges();
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
    public void Add_One()
    {
        var ctx = Contexts[ChangeTrackingStrategy];
        ctx.SmallPeople.Add(new SmallPerson());
        ctx.SaveChanges();
    }

    [Benchmark]
    public void Add_500()
    {
        var ctx = Contexts[ChangeTrackingStrategy];

        for (int i = 0; i < 500; i++)
            ctx.SmallPeople.Add(new SmallPerson());

        ctx.SaveChanges();
    }

    [Benchmark]
    public void Update_All()
    {
        var ctx = Contexts[ChangeTrackingStrategy];

        foreach (var person in ctx.SmallPeople.ToList())
            person.FullName = (++UniqueCounter).ToString();

        ctx.SaveChanges();
    }

    [Benchmark]
    public void Update_Quarter_Init()
    {
        var ctx = Contexts[ChangeTrackingStrategy];

        foreach (var person in ctx.SmallPeople.ToList().Take(InitCount / 4))
            person.FullName = (++UniqueCounter).ToString();

        ctx.SaveChanges();
    }

    private static ulong UniqueCounter;
}
