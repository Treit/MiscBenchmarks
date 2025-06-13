# Summing integer arrays


``` ini

BenchmarkDotNet=v0.13.2.20250612-develop, OS=Windows 11 (10.0.27876.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=9.0.300
  [Host]     : .NET 9.0.5 (9.0.525.21509), X64 RyuJIT AVX2
  DefaultJob : .NET 9.0.5 (9.0.525.21509), X64 RyuJIT AVX2


```
|          Method | Count |         Mean |      Error |     StdDev | Ratio | RatioSD | Allocated | Alloc Ratio |
|---------------- |------ |-------------:|-----------:|-----------:|------:|--------:|----------:|------------:|
| **SumUsingForLoop** |    **10** |     **3.869 ns** |  **0.0985 ns** |  **0.0822 ns** |  **0.50** |    **0.01** |         **-** |          **NA** |
| SumUsingLinqSum |    10 |     7.695 ns |  0.1176 ns |  0.1043 ns |  1.00 |    0.00 |         - |          NA |
|                 |       |              |            |            |       |         |           |             |
| **SumUsingForLoop** | **10000** | **3,381.166 ns** | **55.6945 ns** | **49.3717 ns** |  **4.02** |    **0.08** |         **-** |          **NA** |
| SumUsingLinqSum | 10000 |   841.159 ns |  9.2930 ns |  7.7600 ns |  1.00 |    0.00 |         - |          NA |
