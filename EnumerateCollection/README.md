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
| EnumerateArray              | 100   |  42.74 ns | 0.879 ns | 1.562 ns |  0.38 |    0.01 |      - |         - |        0.00 |
| EnumerateArrayAsEnumerable  | 100   |  42.83 ns | 0.893 ns | 1.466 ns |  0.38 |    0.01 |      - |         - |        0.00 |
| EnumerateList               | 100   | 149.10 ns | 0.957 ns | 0.895 ns |  1.33 |    0.01 |      - |         - |        0.00 |
| EnumerateReadOnlyCollection | 100   | 111.93 ns | 1.048 ns | 0.929 ns |  1.00 |    0.01 | 0.0019 |      32 B |        1.00 |
| EnumerateImmutableArray     | 100   | 130.32 ns | 0.882 ns | 0.825 ns |  1.16 |    0.01 | 0.0019 |      32 B |        1.00 |
| EnumerateReadOnlyList       | 100   | 267.09 ns | 2.675 ns | 2.502 ns |  2.39 |    0.03 | 0.0024 |      40 B |        1.25 |
| EnumerateArraySegment       | 100   | 153.33 ns | 2.132 ns | 1.994 ns |  1.37 |    0.02 | 0.0024 |      40 B |        1.25 |
| EnumerateLinkedList         | 100   | 257.48 ns | 3.125 ns | 2.923 ns |  2.30 |    0.03 |      - |         - |        0.00 |
