# String to bytes

```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27713.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-preview.6.24328.19
  [Host]     : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                                      | Count | Mean     | Error    | StdDev   | Ratio | RatioSD | Gen0     | Allocated | Alloc Ratio |
|-------------------------------------------- |------ |---------:|---------:|---------:|------:|--------:|---------:|----------:|------------:|
| StringToBytesUsingUnicodeEncoding           | 1000  | 88.38 μs | 1.833 μs | 5.376 μs |  1.00 |    0.00 |  51.8799 | 218.75 KB |        1.00 |
| StringToBytesUsingHandRolledExtensionMethod | 1000  | 59.80 μs | 1.950 μs | 5.657 μs |  0.68 |    0.08 | 103.8208 |  437.5 KB |        2.00 |
