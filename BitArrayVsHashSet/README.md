## Looking up integer values in a bit array vs. a HashSet





```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27779.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100
  [Host]     : .NET 8.0.11 (8.0.1124.51707), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.11 (8.0.1124.51707), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method              | Mean       | Error    | StdDev   | Ratio | RatioSD |
|-------------------- |-----------:|---------:|---------:|------:|--------:|
| LookupUsingHashSet  | 2,998.4 ns | 59.55 ns | 96.16 ns |  5.21 |    0.24 |
| LookupUsingBitArray |   582.5 ns | 11.38 ns | 27.93 ns |  1.00 |    0.00 |
