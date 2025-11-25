# Enumerating various collection types



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                      | Count | Mean      | Error    | StdDev   | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|---------------------------- |------ |----------:|---------:|---------:|------:|--------:|-------:|----------:|------------:|
| EnumerateArray              | 100   |  40.50 ns | 0.315 ns | 0.279 ns |  0.37 |    0.01 |      - |         - |        0.00 |
| EnumerateArrayAsEnumerable  | 100   |  42.00 ns | 0.872 ns | 1.278 ns |  0.39 |    0.01 |      - |         - |        0.00 |
| EnumerateList               | 100   | 149.08 ns | 0.990 ns | 0.926 ns |  1.37 |    0.03 |      - |         - |        0.00 |
| EnumerateReadOnlyCollection | 100   | 108.57 ns | 2.100 ns | 2.063 ns |  1.00 |    0.03 | 0.0019 |      32 B |        1.00 |
| EnumerateImmutableArray     | 100   | 129.95 ns | 1.105 ns | 0.980 ns |  1.20 |    0.02 | 0.0019 |      32 B |        1.00 |
| EnumerateReadOnlyList       | 100   | 266.19 ns | 2.255 ns | 2.109 ns |  2.45 |    0.05 | 0.0024 |      40 B |        1.25 |
| EnumerateArraySegment       | 100   | 152.92 ns | 2.440 ns | 2.282 ns |  1.41 |    0.03 | 0.0024 |      40 B |        1.25 |
| EnumerateLinkedList         | 100   | 258.43 ns | 3.925 ns | 3.671 ns |  2.38 |    0.06 |      - |         - |        0.00 |
