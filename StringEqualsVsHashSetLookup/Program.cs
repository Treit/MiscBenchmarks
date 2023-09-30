using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

BenchmarkRunner.Run<StringTest>();

enum ObjectTag
{
    Enemy,
    FriendlyNPC
}

record GameObject(string Name, int Health, string TagStr, ObjectTag Tag);

public class StringTest
{
    HashSet<GameObject> _enemies = new HashSet<GameObject>();
    HashSet<GameObject> _gameObjects = new HashSet<GameObject>();
    GameObject? _target;

    [Params(10_000)]
    public int Count { get; set; }

    [GlobalSetup]
    public void GlobalSetup()
    {
        for (int i = 0; i < Count; i++)
        {
            _enemies.Add(new GameObject($"Enemy {i}", 100, "Enemy", ObjectTag.Enemy));
        }

        for (int i = 0; i < Count; i++)
        {
            _gameObjects.Add(new GameObject($"NPC {i}", 100, "FriendlyNPC", ObjectTag.FriendlyNPC));
        }

        foreach (var enemy in _enemies)
        {
            _gameObjects.Add(enemy);
        }

        _target = _gameObjects.ElementAt(Random.Shared.Next(0, Count));
    }

    [Benchmark]
    public bool CheckUsingEquals()
    {
        return _target?.TagStr == "Enemy";
    }

    [Benchmark]
    public bool CheckUsingHashset()
    {
        return _enemies!.Contains(_target!);
    }

    [Benchmark]
    public bool CheckUsingEnum()
    {
        return _target!.Tag == ObjectTag.Enemy;
    }
}
