# Using Equals instead of ReferenceEquals


```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27823.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.201
  [Host]     : .NET 8.0.14 (8.0.1425.11118), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.14 (8.0.1425.11118), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method          | Mean     | Error   | StdDev   | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|---------------- |---------:|--------:|---------:|------:|--------:|-------:|----------:|------------:|
| Equals          | 390.3 ns | 7.72 ns | 14.30 ns |  1.00 |    0.00 | 0.3839 |   1.62 KB |        1.00 |
| ReferenceEquals | 394.7 ns | 7.93 ns | 16.73 ns |  1.02 |    0.06 | 0.3839 |   1.62 KB |        1.00 |
