# Iterating dictionary entries.




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                    | Count  | Mean          | Error        | StdDev       | Ratio | RatioSD |
|-------------------------- |------- |--------------:|-------------:|-------------:|------:|--------:|
| **IterateAndLookupUsingKeys** | **10**     |      **39.35 ns** |     **0.298 ns** |     **0.279 ns** |  **3.03** |    **0.02** |
| IterateUsingKeyValuePairs | 10     |      10.28 ns |     0.062 ns |     0.052 ns |  0.79 |    0.01 |
| IterateUsingValues        | 10     |      12.99 ns |     0.067 ns |     0.060 ns |  1.00 |    0.01 |
|                           |        |               |              |              |       |         |
| **IterateAndLookupUsingKeys** | **1000**   |   **3,553.42 ns** |    **10.590 ns** |     **9.388 ns** |  **3.76** |    **0.03** |
| IterateUsingKeyValuePairs | 1000   |     944.44 ns |     8.386 ns |     7.844 ns |  1.00 |    0.01 |
| IterateUsingValues        | 1000   |     945.21 ns |     8.616 ns |     8.060 ns |  1.00 |    0.01 |
|                           |        |               |              |              |       |         |
| **IterateAndLookupUsingKeys** | **100000** | **357,432.54 ns** | **2,261.039 ns** | **2,114.977 ns** |  **3.76** |    **0.03** |
| IterateUsingKeyValuePairs | 100000 |  94,922.78 ns |   459.036 ns |   406.923 ns |  1.00 |    0.01 |
| IterateUsingValues        | 100000 |  95,122.40 ns |   405.879 ns |   338.927 ns |  1.00 |    0.00 |
