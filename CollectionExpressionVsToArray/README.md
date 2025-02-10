# Creating an array using ToArray vs. Collection Expression.

```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27793.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.102
  [Host]     : .NET 8.0.12 (8.0.1224.60305), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.12 (8.0.1224.60305), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method               | Mean     | Error    | StdDev   | Median   | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|--------------------- |---------:|---------:|---------:|---------:|------:|--------:|-------:|----------:|------------:|
| ToArray              | 41.02 ns | 0.901 ns | 2.482 ns | 40.26 ns |  1.00 |    0.00 | 0.0111 |      48 B |        1.00 |
| CollectionExpression | 64.62 ns | 1.354 ns | 2.299 ns | 64.07 ns |  1.54 |    0.09 | 0.0315 |     136 B |        2.83 |
