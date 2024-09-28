# String to bytes


```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27713.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-preview.6.24328.19
  [Host]     : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                                      | Count | Mean     | Error    | StdDev    | Median   | Ratio | RatioSD | Gen0     | Allocated | Alloc Ratio |
|-------------------------------------------- |------ |---------:|---------:|----------:|---------:|------:|--------:|---------:|----------:|------------:|
| StringToBytesUsingUnicodeEncoding           | 1000  | 91.69 μs | 4.246 μs | 12.183 μs | 87.47 μs |  1.00 |    0.00 |  51.8799 | 218.75 KB |        1.00 |
| StringToBytesUsingHandRolledExtensionMethod | 1000  | 57.55 μs | 2.000 μs |  5.608 μs | 56.15 μs |  0.64 |    0.10 | 103.8208 |  437.5 KB |        2.00 |
| StringToBytesUsingMemoryMarshal             | 1000  | 26.70 μs | 0.800 μs |  2.334 μs | 26.12 μs |  0.29 |    0.04 |  51.9104 | 218.75 KB |        1.00 |
