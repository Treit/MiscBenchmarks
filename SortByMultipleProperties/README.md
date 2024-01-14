# Sorting types by multiple properties


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                                    Method | Count |     Mean |     Error |    StdDev | Ratio | RatioSD |     Gen0 |     Gen1 |     Gen2 |  Allocated | Alloc Ratio |
|------------------------------------------ |------ |---------:|----------:|----------:|------:|--------:|---------:|---------:|---------:|-----------:|------------:|
|                SortUsingLinqOrderByThenBy | 10000 | 1.664 ms | 0.0194 ms | 0.0182 ms |  1.00 |    0.00 |  48.8281 |  48.8281 |  48.8281 |  508.39 KB |        1.00 |
|         SortUsingLinqOrderByValueTupleKey | 10000 | 2.856 ms | 0.0347 ms | 0.0325 ms |  1.72 |    0.03 |  97.6563 |  97.6563 |  97.6563 |  508.11 KB |        1.00 |
|        SortUsingParallelLinqOrderByThenBy | 10000 | 1.480 ms | 0.0139 ms | 0.0130 ms |  0.89 |    0.01 | 160.1563 | 142.5781 | 142.5781 | 2608.28 KB |        5.13 |
| SortUsingParallelLinqOrderByValueTupleKey | 10000 | 1.404 ms | 0.0111 ms | 0.0104 ms |  0.84 |    0.01 | 154.2969 | 142.5781 | 142.5781 | 2607.71 KB |        5.13 |
