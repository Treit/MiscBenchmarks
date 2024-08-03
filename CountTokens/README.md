# Getting the count of tokens in a delimited string


```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27673.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-preview.6.24328.19
  [Host]     : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                                 | Count | Mean      | Error    | StdDev   | Ratio | RatioSD | Gen0    | Allocated | Alloc Ratio |
|--------------------------------------- |------ |----------:|---------:|---------:|------:|--------:|--------:|----------:|------------:|
| CountTokensUsingLinqCount              | 1000  |  34.79 μs | 0.552 μs | 0.461 μs |  3.12 |    0.11 |  7.3853 |   32000 B |          NA |
| CountTokensUsingSpanCount              | 1000  |  11.12 μs | 0.216 μs | 0.310 μs |  1.00 |    0.00 |       - |         - |          NA |
| CountTokensUsingHandWrittenForEachLoop | 1000  |  10.95 μs | 0.053 μs | 0.047 μs |  0.98 |    0.03 |       - |         - |          NA |
| CountTokensUsingHandWrittenForLoop     | 1000  |  11.13 μs | 0.200 μs | 0.274 μs |  1.00 |    0.04 |       - |         - |          NA |
| CountTokensUsingSplitAndLength         | 1000  |  68.61 μs | 1.337 μs | 1.875 μs |  6.18 |    0.25 | 28.8086 |  124584 B |          NA |
| CountTokensUsingSplitToListAndCount    | 1000  | 107.72 μs | 2.043 μs | 3.837 μs |  9.77 |    0.43 | 46.5088 |  200744 B |          NA |
