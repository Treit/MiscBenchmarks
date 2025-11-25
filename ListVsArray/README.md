# Array vs. List




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  Job-CNUJVU : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2

InvocationCount=1  UnrollFactor=1  

```
| Method        | Count   | Mean        | Error      | StdDev       | Median      | Ratio | RatioSD |
|-------------- |-------- |------------:|-----------:|-------------:|------------:|------:|--------:|
| **PopulateList**  | **10000**   |    **20.20 μs** |   **0.597 μs** |     **1.674 μs** |    **19.50 μs** |  **1.51** |    **0.24** |
| PopulateArray | 10000   |    13.93 μs |   0.507 μs |     1.430 μs |    13.50 μs |  1.04 |    0.18 |
| SumList       | 10000   |    16.72 μs |   0.449 μs |     1.251 μs |    16.35 μs |  1.25 |    0.19 |
| SumArray      | 10000   |    13.70 μs |   0.785 μs |     2.177 μs |    12.80 μs |  1.02 |    0.21 |
|               |         |             |            |              |             |       |         |
| **PopulateList**  | **1000000** | **1,999.37 μs** | **355.054 μs** | **1,046.885 μs** | **2,077.65 μs** |  **6.06** |    **3.16** |
| PopulateArray | 1000000 | 1,484.85 μs | 362.436 μs | 1,068.652 μs | 1,520.25 μs |  4.50 |    3.23 |
| SumList       | 1000000 |   646.30 μs |  12.909 μs |    16.786 μs |   638.20 μs |  1.96 |    0.07 |
| SumArray      | 1000000 |   330.05 μs |   6.569 μs |     7.565 μs |   329.75 μs |  1.00 |    0.03 |
