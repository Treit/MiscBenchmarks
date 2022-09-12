# Sorting types by multiple properties

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.25201
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=7.0.100-preview.5.22307.18
  [Host]     : .NET Core 6.0.8 (CoreCLR 6.0.822.36306, CoreFX 6.0.822.36306), X64 RyuJIT
  DefaultJob : .NET Core 6.0.8 (CoreCLR 6.0.822.36306, CoreFX 6.0.822.36306), X64 RyuJIT


```
|                                    Method | Count |     Mean |     Error |    StdDev |   Median | Ratio | RatioSD |    Gen 0 |    Gen 1 |    Gen 2 |  Allocated |
|------------------------------------------ |------ |---------:|----------:|----------:|---------:|------:|--------:|---------:|---------:|---------:|-----------:|
|                SortUsingLinqOrderByThenBy | 10000 | 2.102 ms | 0.0603 ms | 0.1731 ms | 2.050 ms |  1.00 |    0.00 |  97.6563 |  46.8750 |  46.8750 |  508.39 KB |
|         SortUsingLinqOrderByValueTupleKey | 10000 | 3.392 ms | 0.0670 ms | 0.1766 ms | 3.372 ms |  1.63 |    0.15 |  97.6563 |  97.6563 |  97.6563 |  508.11 KB |
|        SortUsingParallelLinqOrderByThenBy | 10000 | 3.331 ms | 0.1319 ms | 0.3826 ms | 3.297 ms |  1.59 |    0.21 | 425.7813 | 281.2500 | 140.6250 | 2425.35 KB |
| SortUsingParallelLinqOrderByValueTupleKey | 10000 | 2.959 ms | 0.0949 ms | 0.2799 ms | 2.998 ms |  1.42 |    0.19 | 425.7813 | 281.2500 | 140.6250 | 2424.61 KB |
