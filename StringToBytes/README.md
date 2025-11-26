# String to bytes




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                      | Count | Mean     | Error    | StdDev   | Ratio | Gen0    | Allocated | Alloc Ratio |
|-------------------------------------------- |------ |---------:|---------:|---------:|------:|--------:|----------:|------------:|
| StringToBytesUsingUnicodeEncoding           | 1000  | 68.54 μs | 0.778 μs | 0.690 μs |  1.00 | 13.3057 | 218.75 KB |        1.00 |
| StringToBytesUsingHandRolledExtensionMethod | 1000  | 34.09 μs | 0.660 μs | 0.734 μs |  0.50 | 26.7334 |  437.5 KB |        2.00 |
| StringToBytesUsingMemoryMarshal             | 1000  | 14.36 μs | 0.278 μs | 0.273 μs |  0.21 | 13.3820 | 218.75 KB |        1.00 |
