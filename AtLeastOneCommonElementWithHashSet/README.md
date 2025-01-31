# Testing perf of iterating an array of strings and doing a HashSet lookup vs. HashSet intersect





```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27783.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.102
  [Host]     : .NET 8.0.12 (8.0.1224.60305), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.12 (8.0.1224.60305), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                                                   | Count | Mean         | Error        | StdDev       | Median       | Ratio  | RatioSD | Gen0   | Allocated | Alloc Ratio |
|--------------------------------------------------------- |------ |-------------:|-------------:|-------------:|-------------:|-------:|--------:|-------:|----------:|------------:|
| ArrayWalkAndHashSetLookupWithIEnumerableContains          | 100   |     85.24 ns |     8.130 ns |    23.973 ns |     75.08 ns |   1.43 |    0.57 | 0.0315 |     136 B |        4.25 |
| ArrayWalkAndHashSetLookupWithIEnumerableContainsNoOverlap | 100   | 14,829.41 ns | 1,481.501 ns | 4,368.240 ns | 14,012.47 ns | 243.01 |   83.63 | 0.0916 |     496 B |       15.50 |
| ArrayWalkAndHashSetLookupWithHashSetContains              | 100   |     55.05 ns |     2.669 ns |     7.615 ns |     54.41 ns |   0.94 |    0.29 | 0.0222 |      96 B |        3.00 |
| ArrayWalkAndHashSetLookupWithHashSetContainsNoOverlap     | 100   |    220.55 ns |    10.188 ns |    28.232 ns |    211.48 ns |   3.82 |    1.09 | 0.0219 |      96 B |        3.00 |
| HashSetOverlapsMethod                                     | 100   |     63.98 ns |     5.566 ns |    16.411 ns |     62.64 ns |   1.00 |    0.00 | 0.0074 |      32 B |        1.00 |
| HashSetOverlapsMethodWithNoOverlap                        | 100   |    335.28 ns |    28.871 ns |    85.125 ns |    363.83 ns |   5.83 |    2.58 | 0.0067 |      32 B |        1.00 |
