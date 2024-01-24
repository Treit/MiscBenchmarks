# Dynamic vs regular C# types


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                 Method | Size |        Mean |       Error |      StdDev |      Gen0 |      Gen1 |     Gen2 | Allocated |
|----------------------- |----- |------------:|------------:|------------:|----------:|----------:|---------:|----------:|
|        InitJaggedArray | 1024 |    770.9 μs |    12.84 μs |    11.38 μs |   64.4531 |   32.2266 |        - |   1.03 MB |
| InitDynamicJaggedArray | 1024 | 63,448.3 μs | 1,260.52 μs | 2,870.85 μs | 2777.7778 | 2666.6667 | 777.7778 |  32.03 MB |
