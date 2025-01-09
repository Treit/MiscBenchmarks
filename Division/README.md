# Dividing



```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27768.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100
  [Host]     : .NET 9.0.0 (9.0.24.52809), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 9.0.0 (9.0.24.52809), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method             | Count  | Mean          | Error        | StdDev       | Ratio | RatioSD | Allocated | Alloc Ratio |
|------------------- |------- |--------------:|-------------:|-------------:|------:|--------:|----------:|------------:|
| **DivideUsingFloat**   | **100**    |      **63.68 ns** |     **0.564 ns** |     **0.500 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
| DivideUsingDouble  | 100    |      65.35 ns |     1.320 ns |     1.622 ns |  1.02 |    0.03 |         - |          NA |
| DivideUsingDecimal | 100    |   3,261.76 ns |    14.662 ns |    11.447 ns | 51.28 |    0.46 |         - |          NA |
| DivideUsingInt     | 100    |      74.47 ns |     0.462 ns |     0.432 ns |  1.17 |    0.01 |         - |          NA |
|                    |        |               |              |              |       |         |           |             |
| **DivideUsingFloat**   | **100000** | **108,600.71 ns** | **1,117.949 ns** | **1,045.730 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
| DivideUsingDouble  | 100000 | 109,048.10 ns |   583.415 ns |   517.182 ns |  1.01 |    0.01 |         - |          NA |
| DivideUsingDecimal | 100000 | 616,152.68 ns | 7,532.093 ns | 7,045.525 ns |  5.67 |    0.07 |         - |          NA |
| DivideUsingInt     | 100000 |  80,536.91 ns |   796.069 ns |   705.695 ns |  0.74 |    0.01 |         - |          NA |
