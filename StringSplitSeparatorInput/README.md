# string.Split with different types of separator input



```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26096.1)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-preview.2.24157.14
  [Host]     : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                   | Count | Mean     | Error     | StdDev    | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|------------------------- |------ |---------:|----------:|----------:|------:|--------:|-------:|----------:|------------:|
| SplitWithSingleChar      | 100   | 2.426 μs | 0.0570 μs | 0.1664 μs |  1.00 |    0.00 | 0.8774 |    3.7 KB |        1.00 |
| SplitWithSingleString    | 100   | 3.356 μs | 0.0659 μs | 0.1271 μs |  1.36 |    0.12 | 0.8774 |    3.7 KB |        1.00 |
| SplitWithNewCharArray    | 100   | 2.526 μs | 0.0494 μs | 0.0725 μs |  1.03 |    0.08 | 0.8850 |   3.73 KB |        1.01 |
| SplitWithStaticCharArray | 100   | 2.485 μs | 0.0493 μs | 0.1246 μs |  1.02 |    0.08 | 0.8774 |    3.7 KB |        1.00 |
