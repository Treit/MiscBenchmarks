# Enumerating various collection types


```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27852.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.203
  [Host]     : .NET 8.0.15 (8.0.1525.16413), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.15 (8.0.1525.16413), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                      | Count | Mean     | Error    | StdDev   | Median   | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|---------------------------- |------ |---------:|---------:|---------:|---------:|------:|--------:|-------:|----------:|------------:|
| EnumerateArray              | 100   | 245.9 ns | 11.50 ns | 33.91 ns | 231.6 ns |  1.20 |    0.07 | 0.0074 |      32 B |        1.00 |
| EnumerateArrayAsEnumerable  | 100   | 258.5 ns | 10.75 ns | 31.70 ns | 254.5 ns |  1.55 |    0.10 | 0.0072 |      32 B |        1.00 |
| EnumerateList               | 100   | 350.7 ns |  8.26 ns | 23.70 ns | 344.6 ns |  1.83 |    0.13 | 0.0091 |      40 B |        1.25 |
| EnumerateReadOnlyCollection | 100   | 190.6 ns |  3.79 ns |  4.79 ns | 189.0 ns |  1.00 |    0.00 | 0.0074 |      32 B |        1.00 |
| EnumerateImmutableArray     | 100   | 212.2 ns |  4.27 ns |  8.92 ns | 210.6 ns |  1.12 |    0.06 | 0.0129 |      56 B |        1.75 |
| EnumerateReadOnlyList       | 100   | 363.3 ns |  7.21 ns |  6.74 ns | 363.9 ns |  1.90 |    0.06 | 0.0091 |      40 B |        1.25 |
| EnumerateArraySegment       | 100   | 229.1 ns |  4.58 ns |  5.45 ns | 228.4 ns |  1.20 |    0.04 | 0.0167 |      72 B |        2.25 |
| EnumerateLinkedList         | 100   | 525.9 ns | 10.56 ns | 11.30 ns | 526.7 ns |  2.75 |    0.08 | 0.0105 |      48 B |        1.50 |
