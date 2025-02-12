# Adding items to a dictionary

```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27793.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.200
  [Host]     : .NET 8.0.13 (8.0.1325.6609), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.13 (8.0.1325.6609), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                   | Count | Mean     | Error     | StdDev    | Median   | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|------------------------- |------ |---------:|----------:|----------:|---------:|------:|--------:|-------:|----------:|------------:|
| AddToDictWithForEachLoop | 100   | 5.612 μs | 0.1780 μs | 0.5051 μs | 5.425 μs |  3.97 |    0.39 | 2.3727 |  10.01 KB |        3.28 |
| AddToDictPresetCapacity  | 100   | 3.228 μs | 0.0641 μs | 0.1017 μs | 3.212 μs |  2.23 |    0.12 | 0.7362 |   3.11 KB |        1.02 |
| AddToDictWithConstructor | 100   | 1.447 μs | 0.0290 μs | 0.0705 μs | 1.426 μs |  1.00 |    0.00 | 0.7248 |   3.05 KB |        1.00 |
