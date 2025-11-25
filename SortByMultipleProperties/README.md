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
| SortUsingLinqOrderByThenBy                | 10000 | 1.710 ms | 0.0059 ms | 0.0050 ms |  1.00 |    0.00 |  48.8281 |  48.8281 |  48.8281 |  508.48 KB |        1.00 |
| SortUsingLinqOrderByValueTupleKey         | 10000 | 2.134 ms | 0.0223 ms | 0.0209 ms |  1.25 |    0.01 |  97.6563 |  97.6563 |  97.6563 |  508.14 KB |        1.00 |
| SortUsingParallelLinqOrderByThenBy        | 10000 | 1.461 ms | 0.0285 ms | 0.0280 ms |  0.85 |    0.02 | 146.4844 | 142.5781 | 142.5781 | 2608.13 KB |        5.13 |
| SortUsingParallelLinqOrderByValueTupleKey | 10000 | 1.307 ms | 0.0160 ms | 0.0149 ms |  0.76 |    0.01 | 142.5781 | 142.5781 | 142.5781 | 2607.68 KB |        5.13 |
