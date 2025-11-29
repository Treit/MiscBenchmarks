namespace Test;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using System;
using BenchmarkDotNet.Jobs;

[DisassemblyDiagnoser(exportDiff: true, exportHtml: true)]
[SimpleJob(RuntimeMoniker.Net90)]
[SimpleJob(RuntimeMoniker.Net10_0)]
public class Benchmark
{
    private float[] _floats;

    [Params(100_000)]
    public int Count { get; set; }

    [GlobalSetup]
    public void GlobalSetup()
    {
        var r = new Random(Count);

        _floats = new float[Count];

        for (int i = 0; i < Count; i++)
        {
            _floats[i] = r.NextSingle();
        }
    }

    [Benchmark(Baseline = true)]
    public float[] ArrayCopy()
    {
        var copy = new float[_floats.Length];
        Array.Copy(_floats, copy, _floats.Length);
        return copy;
    }

    [Benchmark]
    public float[] BufferBlockCopy()
    {
        var copy = new float[_floats.Length];
        Buffer.BlockCopy(_floats, 0, copy, 0, _floats.Length * sizeof(float));
        return copy;
    }
}
