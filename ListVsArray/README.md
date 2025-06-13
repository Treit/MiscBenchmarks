# Array vs. List



```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27876.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.300
  [Host]     : .NET 9.0.5 (9.0.525.21509), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  Job-NKVDMO : .NET 9.0.5 (9.0.525.21509), X64 RyuJIT AVX-512F+CD+BW+DQ+VL

InvocationCount=1  UnrollFactor=1  

```
| Method        | Count   | Mean        | Error      | StdDev     | Median      | Ratio | RatioSD |
|-------------- |-------- |------------:|-----------:|-----------:|------------:|------:|--------:|
| **PopulateList**  | **10000**   |    **24.82 μs** |   **0.231 μs** |   **0.204 μs** |    **24.80 μs** |  **1.62** |    **0.06** |
| PopulateArray | 10000   |    17.88 μs |   1.721 μs |   5.073 μs |    16.75 μs |  1.34 |    0.38 |
| SumList       | 10000   |    15.97 μs |   0.458 μs |   1.277 μs |    15.60 μs |  1.17 |    0.11 |
| SumArray      | 10000   |    13.72 μs |   0.491 μs |   1.385 μs |    13.35 μs |  1.00 |    0.00 |
|               |         |             |            |            |             |       |         |
| **PopulateList**  | **1000000** | **1,677.26 μs** | **105.915 μs** | **312.293 μs** | **1,724.90 μs** |  **3.51** |    **0.76** |
| PopulateArray | 1000000 |   734.90 μs | 114.366 μs | 337.212 μs |   788.70 μs |  1.55 |    0.75 |
| SumList       | 1000000 |   652.82 μs |  11.224 μs |  10.499 μs |   655.10 μs |  1.37 |    0.10 |
| SumArray      | 1000000 |   482.32 μs |  11.735 μs |  33.669 μs |   496.70 μs |  1.00 |    0.00 |
