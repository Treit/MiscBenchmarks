# ListAnyVsCount

Compares checking if a `List<T>` is empty using the `Count` property versus LINQ's `Any()` method.

```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6345/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.101
  [Host]     : .NET 10.0.1 (10.0.125.57005), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.1 (10.0.125.57005), X64 RyuJIT AVX2


```
| Method                   | Count | Mean        | Error       | StdDev      | Ratio | RatioSD | Allocated | Alloc Ratio |
|------------------------- |------ |------------:|------------:|------------:|------:|--------:|----------:|------------:|
| **CheckListEmptyUsingCount** | **100**   |    **167.4 ns** |     **2.96 ns** |     **2.77 ns** |  **1.00** |    **0.02** |         **-** |          **NA** |
| CheckListEmptyUsingAny   | 100   |    377.8 ns |     5.93 ns |     5.55 ns |  2.26 |    0.05 |         - |          NA |
|                          |       |             |             |             |       |         |           |             |
| **CheckListEmptyUsingCount** | **10000** | **63,264.6 ns** | **1,246.39 ns** | **1,279.95 ns** |  **1.00** |    **0.03** |         **-** |          **NA** |
| CheckListEmptyUsingAny   | 10000 | 78,052.1 ns | 1,207.86 ns | 1,070.74 ns |  1.23 |    0.03 |         - |          NA |
