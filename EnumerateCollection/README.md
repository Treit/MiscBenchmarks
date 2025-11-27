# Enumerating various collection types





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                      | Job       | Runtime   | Count | Mean      | Error    | StdDev   | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|---------------------------- |---------- |---------- |------ |----------:|---------:|---------:|------:|--------:|-------:|----------:|------------:|
| EnumerateArray              | .NET 10.0 | .NET 10.0 | 100   |  41.83 ns | 0.855 ns | 1.305 ns |  0.38 |    0.01 |      - |         - |        0.00 |
| EnumerateArrayAsEnumerable  | .NET 10.0 | .NET 10.0 | 100   |  40.79 ns | 0.571 ns | 0.506 ns |  0.37 |    0.01 |      - |         - |        0.00 |
| EnumerateList               | .NET 10.0 | .NET 10.0 | 100   | 149.95 ns | 1.249 ns | 1.107 ns |  1.36 |    0.02 |      - |         - |        0.00 |
| EnumerateReadOnlyCollection | .NET 10.0 | .NET 10.0 | 100   | 110.27 ns | 1.409 ns | 1.318 ns |  1.00 |    0.02 | 0.0019 |      32 B |        1.00 |
| EnumerateImmutableArray     | .NET 10.0 | .NET 10.0 | 100   | 131.30 ns | 1.462 ns | 1.296 ns |  1.19 |    0.02 | 0.0019 |      32 B |        1.00 |
| EnumerateReadOnlyList       | .NET 10.0 | .NET 10.0 | 100   | 268.25 ns | 3.380 ns | 2.996 ns |  2.43 |    0.04 | 0.0024 |      40 B |        1.25 |
| EnumerateArraySegment       | .NET 10.0 | .NET 10.0 | 100   | 155.58 ns | 3.025 ns | 2.830 ns |  1.41 |    0.03 | 0.0024 |      40 B |        1.25 |
| EnumerateLinkedList         | .NET 10.0 | .NET 10.0 | 100   | 253.84 ns | 2.039 ns | 1.908 ns |  2.30 |    0.03 |      - |         - |        0.00 |
|                             |           |           |       |           |          |          |       |         |        |           |             |
| EnumerateArray              | .NET 9.0  | .NET 9.0  | 100   |  42.82 ns | 0.866 ns | 1.126 ns |  0.38 |    0.01 |      - |         - |        0.00 |
| EnumerateArrayAsEnumerable  | .NET 9.0  | .NET 9.0  | 100   |  43.23 ns | 0.885 ns | 1.403 ns |  0.38 |    0.01 |      - |         - |        0.00 |
| EnumerateList               | .NET 9.0  | .NET 9.0  | 100   | 149.75 ns | 1.268 ns | 1.186 ns |  1.33 |    0.02 |      - |         - |        0.00 |
| EnumerateReadOnlyCollection | .NET 9.0  | .NET 9.0  | 100   | 112.35 ns | 1.531 ns | 1.432 ns |  1.00 |    0.02 | 0.0019 |      32 B |        1.00 |
| EnumerateImmutableArray     | .NET 9.0  | .NET 9.0  | 100   | 138.83 ns | 1.867 ns | 1.747 ns |  1.24 |    0.02 | 0.0019 |      32 B |        1.00 |
| EnumerateReadOnlyList       | .NET 9.0  | .NET 9.0  | 100   | 270.49 ns | 3.841 ns | 3.593 ns |  2.41 |    0.04 | 0.0024 |      40 B |        1.25 |
| EnumerateArraySegment       | .NET 9.0  | .NET 9.0  | 100   | 154.61 ns | 2.157 ns | 2.017 ns |  1.38 |    0.02 | 0.0024 |      40 B |        1.25 |
| EnumerateLinkedList         | .NET 9.0  | .NET 9.0  | 100   | 253.44 ns | 2.192 ns | 2.051 ns |  2.26 |    0.03 |      - |         - |        0.00 |
