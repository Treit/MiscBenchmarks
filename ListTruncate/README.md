# Given a large list, take the first n elements and throw away the rest.



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method              | ListSize | N   | Mean      | Error    | StdDev   | Ratio | RatioSD |
|-------------------- |--------- |---- |----------:|---------:|---------:|------:|--------:|
| **LinqTake**            | **1000**     | **10**  |  **20.62 ns** | **0.242 ns** | **0.227 ns** |  **1.87** |    **0.02** |
| RangeWithMathDotMin | 1000     | 10  |  11.03 ns | 0.094 ns | 0.083 ns |  1.00 |    0.01 |
| HandWrittenLoop     | 1000     | 10  |  24.41 ns | 0.316 ns | 0.295 ns |  2.21 |    0.03 |
|                     |          |     |           |          |          |       |         |
| **LinqTake**            | **1000**     | **500** | **100.73 ns** | **1.849 ns** | **1.730 ns** |  **1.16** |    **0.04** |
| RangeWithMathDotMin | 1000     | 500 |  87.15 ns | 1.794 ns | 2.395 ns |  1.00 |    0.04 |
| HandWrittenLoop     | 1000     | 500 | 795.19 ns | 7.221 ns | 6.755 ns |  9.13 |    0.27 |
|                     |          |     |           |          |          |       |         |
| **LinqTake**            | **1000000**  | **10**  |  **20.78 ns** | **0.204 ns** | **0.191 ns** |  **1.83** |    **0.04** |
| RangeWithMathDotMin | 1000000  | 10  |  11.34 ns | 0.252 ns | 0.236 ns |  1.00 |    0.03 |
| HandWrittenLoop     | 1000000  | 10  |  24.84 ns | 0.438 ns | 0.388 ns |  2.19 |    0.06 |
|                     |          |     |           |          |          |       |         |
| **LinqTake**            | **1000000**  | **500** | **101.07 ns** | **2.006 ns** | **2.464 ns** |  **1.14** |    **0.04** |
| RangeWithMathDotMin | 1000000  | 500 |  88.89 ns | 1.757 ns | 2.284 ns |  1.00 |    0.04 |
| HandWrittenLoop     | 1000000  | 500 | 785.87 ns | 5.988 ns | 5.308 ns |  8.85 |    0.24 |
