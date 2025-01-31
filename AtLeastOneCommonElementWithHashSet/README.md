# Testing perf of iterating an array of strings and doing a HashSet lookup vs. HashSet intersect




```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27783.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.102
  [Host]     : .NET 8.0.12 (8.0.1224.60305), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.12 (8.0.1224.60305), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                                          | Count | Mean     | Error    | StdDev    | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|------------------------------------------------ |------ |---------:|---------:|----------:|------:|--------:|-------:|----------:|------------:|
| ArrayWalkAndHashSetLookupAndIEnumerableContains | 100   | 78.30 ns | 6.789 ns | 20.016 ns |  1.84 |    0.67 | 0.0315 |     136 B |        3.40 |
| ArrayWalkAndHashSetLookupAndHashSetContains     | 100   | 67.02 ns | 3.765 ns | 10.924 ns |  1.54 |    0.35 | 0.0222 |      96 B |        2.40 |
| HashSetOverlap                                  | 100   | 44.67 ns | 2.783 ns |  7.986 ns |  1.00 |    0.00 | 0.0092 |      40 B |        1.00 |
