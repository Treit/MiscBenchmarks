# Using Equals instead of ReferenceEquals



```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27823.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.201
  [Host]     : .NET 8.0.14 (8.0.1425.11118), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.14 (8.0.1425.11118), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method          | Mean     | Error    | StdDev   | Median   | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|---------------- |---------:|---------:|---------:|---------:|------:|--------:|-------:|----------:|------------:|
| Equals          | 33.41 ns | 0.647 ns | 1.739 ns | 32.72 ns |  1.00 |    0.00 | 0.0074 |      32 B |        1.00 |
| ReferenceEquals | 31.01 ns | 0.652 ns | 1.775 ns | 30.52 ns |  0.93 |    0.07 | 0.0074 |      32 B |        1.00 |
