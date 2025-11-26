# Sorting types by multiple properties




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                    | Count | Mean     | Error     | StdDev    | Ratio | RatioSD | Gen0     | Gen1     | Gen2     | Allocated  | Alloc Ratio |
|------------------------------------------ |------ |---------:|----------:|----------:|------:|--------:|---------:|---------:|---------:|-----------:|------------:|
| SortUsingLinqOrderByThenBy                | 10000 | 1.573 ms | 0.0116 ms | 0.0109 ms |  1.00 |    0.01 |  48.8281 |  48.8281 |  48.8281 |  508.48 KB |        1.00 |
| SortUsingLinqOrderByValueTupleKey         | 10000 | 2.035 ms | 0.0280 ms | 0.0262 ms |  1.29 |    0.02 |  97.6563 |  97.6563 |  97.6563 |  508.14 KB |        1.00 |
| SortUsingParallelLinqOrderByThenBy        | 10000 | 1.500 ms | 0.0294 ms | 0.0412 ms |  0.95 |    0.03 | 154.2969 | 142.5781 | 142.5781 | 2608.37 KB |        5.13 |
| SortUsingParallelLinqOrderByValueTupleKey | 10000 | 1.306 ms | 0.0151 ms | 0.0141 ms |  0.83 |    0.01 | 150.3906 | 142.5781 | 142.5781 | 2607.95 KB |        5.13 |
