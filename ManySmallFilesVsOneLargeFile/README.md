# Reading many small files vs. one large file.

```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27754.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100
  [Host]     : .NET 8.0.11 (8.0.1124.51707), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.11 (8.0.1124.51707), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method         | Count | Mean        | Error       | StdDev      | Gen0      | Allocated  |
|--------------- |------ |------------:|------------:|------------:|----------:|-----------:|
| ManySmallFiles | 1000  | 84,101.6 μs | 1,875.01 μs | 5,528.51 μs | 1800.0000 | 7967.52 KB |
| OneBigFile     | 1000  |    125.7 μs |     2.51 μs |     6.87 μs |    9.0332 |      39 KB |
