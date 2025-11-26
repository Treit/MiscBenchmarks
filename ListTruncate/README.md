# Given a large list, take the first n elements and throw away the rest.




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method              | ListSize | N   | Mean      | Error     | StdDev   | Ratio | RatioSD |
|-------------------- |--------- |---- |----------:|----------:|---------:|------:|--------:|
| **LinqTake**            | **1000**     | **10**  |  **20.73 ns** |  **0.247 ns** | **0.231 ns** |  **1.88** |    **0.03** |
| RangeWithMathDotMin | 1000     | 10  |  11.01 ns |  0.121 ns | 0.108 ns |  1.00 |    0.01 |
| HandWrittenLoop     | 1000     | 10  |  24.22 ns |  0.195 ns | 0.163 ns |  2.20 |    0.03 |
|                     |          |     |           |           |          |       |         |
| **LinqTake**            | **1000**     | **500** | **103.13 ns** |  **2.049 ns** | **2.278 ns** |  **1.17** |    **0.04** |
| RangeWithMathDotMin | 1000     | 500 |  88.05 ns |  1.793 ns | 2.064 ns |  1.00 |    0.03 |
| HandWrittenLoop     | 1000     | 500 | 804.30 ns |  6.351 ns | 5.630 ns |  9.14 |    0.23 |
|                     |          |     |           |           |          |       |         |
| **LinqTake**            | **1000000**  | **10**  |  **20.94 ns** |  **0.211 ns** | **0.187 ns** |  **1.91** |    **0.03** |
| RangeWithMathDotMin | 1000000  | 10  |  10.97 ns |  0.126 ns | 0.118 ns |  1.00 |    0.01 |
| HandWrittenLoop     | 1000000  | 10  |  24.14 ns |  0.245 ns | 0.230 ns |  2.20 |    0.03 |
|                     |          |     |           |           |          |       |         |
| **LinqTake**            | **1000000**  | **500** |  **98.69 ns** |  **1.987 ns** | **2.126 ns** |  **1.10** |    **0.03** |
| RangeWithMathDotMin | 1000000  | 500 |  89.71 ns |  1.713 ns | 1.602 ns |  1.00 |    0.02 |
| HandWrittenLoop     | 1000000  | 500 | 799.61 ns | 10.521 ns | 9.842 ns |  8.92 |    0.19 |
