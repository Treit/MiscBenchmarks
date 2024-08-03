# Getting the count of tokens in a delimited string

```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27673.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-preview.6.24328.19
  [Host]     : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                              | Count | Mean      | Error    | StdDev   | Ratio | RatioSD | Gen0    | Allocated | Alloc Ratio |
|------------------------------------ |------ |----------:|---------:|---------:|------:|--------:|--------:|----------:|------------:|
| CountTokensUsingLinqCount           | 1000  |  34.57 μs | 0.331 μs | 0.294 μs |  3.17 |    0.04 |  7.3853 |   32000 B |          NA |
| CountTokensUsingSpanCount           | 1000  |  10.90 μs | 0.122 μs | 0.109 μs |  1.00 |    0.00 |       - |         - |          NA |
| CountTokensUsingSplitAndLength      | 1000  |  66.14 μs | 1.321 μs | 1.718 μs |  6.12 |    0.20 | 28.8086 |  124584 B |          NA |
| CountTokensUsingSplitToListAndCount | 1000  | 106.22 μs | 1.505 μs | 1.257 μs |  9.73 |    0.11 | 46.5088 |  200744 B |          NA |
