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
| **PopulateList**  | **10000**   |    **20.56 μs** |   **0.804 μs** |     **2.213 μs** |    **19.80 μs** |  **1.59** |    **0.25** |
| PopulateArray | 10000   |    14.28 μs |   0.782 μs |     2.191 μs |    13.70 μs |  1.11 |    0.21 |
| SumList       | 10000   |    16.82 μs |   0.564 μs |     1.562 μs |    16.60 μs |  1.30 |    0.19 |
| SumArray      | 10000   |    13.09 μs |   0.582 μs |     1.662 μs |    12.70 μs |  1.01 |    0.17 |
|               |         |             |            |              |             |       |         |
| **PopulateList**  | **1000000** | **2,014.87 μs** | **361.516 μs** | **1,065.937 μs** | **1,960.95 μs** |  **6.11** |    **3.22** |
| PopulateArray | 1000000 | 1,476.71 μs | 359.724 μs | 1,060.655 μs | 1,303.10 μs |  4.48 |    3.20 |
| SumList       | 1000000 |   641.48 μs |  10.015 μs |    10.285 μs |   637.10 μs |  1.95 |    0.05 |
| SumArray      | 1000000 |   329.74 μs |   6.545 μs |     6.428 μs |   329.70 μs |  1.00 |    0.03 |
