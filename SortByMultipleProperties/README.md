# Sorting types by multiple properties





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                    | Job       | Runtime   | Count | Mean     | Error     | StdDev    | Ratio | RatioSD | Gen0     | Gen1     | Gen2     | Allocated  | Alloc Ratio |
|------------------------------------------ |---------- |---------- |------ |---------:|----------:|----------:|------:|--------:|---------:|---------:|---------:|-----------:|------------:|
| SortUsingLinqOrderByThenBy                | .NET 10.0 | .NET 10.0 | 10000 | 1.572 ms | 0.0072 ms | 0.0068 ms |  1.00 |    0.01 |  48.8281 |  48.8281 |  48.8281 |  508.48 KB |        1.00 |
| SortUsingLinqOrderByValueTupleKey         | .NET 10.0 | .NET 10.0 | 10000 | 2.080 ms | 0.0164 ms | 0.0153 ms |  1.32 |    0.01 |  97.6563 |  97.6563 |  97.6563 |  508.14 KB |        1.00 |
| SortUsingParallelLinqOrderByThenBy        | .NET 10.0 | .NET 10.0 | 10000 | 1.402 ms | 0.0198 ms | 0.0185 ms |  0.89 |    0.01 | 154.2969 | 142.5781 | 142.5781 | 2608.37 KB |        5.13 |
| SortUsingParallelLinqOrderByValueTupleKey | .NET 10.0 | .NET 10.0 | 10000 | 1.265 ms | 0.0241 ms | 0.0237 ms |  0.80 |    0.01 | 144.5313 | 142.5781 | 142.5781 | 2607.89 KB |        5.13 |
|                                           |           |           |       |          |           |           |       |         |          |          |          |            |             |
| SortUsingLinqOrderByThenBy                | .NET 9.0  | .NET 9.0  | 10000 | 1.581 ms | 0.0051 ms | 0.0048 ms |  1.00 |    0.00 |  48.8281 |  48.8281 |  48.8281 |  508.48 KB |        1.00 |
| SortUsingLinqOrderByValueTupleKey         | .NET 9.0  | .NET 9.0  | 10000 | 2.043 ms | 0.0121 ms | 0.0107 ms |  1.29 |    0.01 |  97.6563 |  97.6563 |  97.6563 |  508.14 KB |        1.00 |
| SortUsingParallelLinqOrderByThenBy        | .NET 9.0  | .NET 9.0  | 10000 | 1.389 ms | 0.0269 ms | 0.0331 ms |  0.88 |    0.02 | 150.3906 | 142.5781 | 142.5781 | 2608.35 KB |        5.13 |
| SortUsingParallelLinqOrderByValueTupleKey | .NET 9.0  | .NET 9.0  | 10000 | 1.267 ms | 0.0232 ms | 0.0206 ms |  0.80 |    0.01 | 146.4844 | 142.5781 | 142.5781 | 2607.92 KB |        5.13 |
