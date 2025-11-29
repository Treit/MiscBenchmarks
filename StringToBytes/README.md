# String to bytes





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                      | Job       | Runtime   | Count | Mean     | Error    | StdDev   | Ratio | Gen0    | Allocated | Alloc Ratio |
|-------------------------------------------- |---------- |---------- |------ |---------:|---------:|---------:|------:|--------:|----------:|------------:|
| StringToBytesUsingUnicodeEncoding           | .NET 10.0 | .NET 10.0 | 1000  | 45.85 μs | 0.410 μs | 0.363 μs |  1.00 | 13.3667 | 218.75 KB |        1.00 |
| StringToBytesUsingHandRolledExtensionMethod | .NET 10.0 | .NET 10.0 | 1000  | 32.77 μs | 0.413 μs | 0.386 μs |  0.71 | 26.7334 |  437.5 KB |        2.00 |
| StringToBytesUsingMemoryMarshal             | .NET 10.0 | .NET 10.0 | 1000  | 14.61 μs | 0.128 μs | 0.120 μs |  0.32 | 13.3820 | 218.75 KB |        1.00 |
|                                             |           |           |       |          |          |          |       |         |           |             |
| StringToBytesUsingUnicodeEncoding           | .NET 9.0  | .NET 9.0  | 1000  | 48.31 μs | 0.492 μs | 0.460 μs |  1.00 | 13.3667 | 218.75 KB |        1.00 |
| StringToBytesUsingHandRolledExtensionMethod | .NET 9.0  | .NET 9.0  | 1000  | 32.80 μs | 0.602 μs | 0.563 μs |  0.68 | 26.7334 |  437.5 KB |        2.00 |
| StringToBytesUsingMemoryMarshal             | .NET 9.0  | .NET 9.0  | 1000  | 14.43 μs | 0.274 μs | 0.269 μs |  0.30 | 13.3820 | 218.75 KB |        1.00 |
