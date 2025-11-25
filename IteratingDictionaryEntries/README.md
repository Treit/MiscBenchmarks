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
| **IterateAndLookupUsingKeys** | **10**     |      **41.48 ns** |     **0.391 ns** |     **0.366 ns** |  **3.20** |    **0.03** |
| IterateUsingKeyValuePairs | 10     |      10.28 ns |     0.064 ns |     0.060 ns |  0.79 |    0.00 |
| IterateUsingValues        | 10     |      12.95 ns |     0.040 ns |     0.034 ns |  1.00 |    0.00 |
|                           |        |               |              |              |       |         |
| **IterateAndLookupUsingKeys** | **1000**   |   **3,540.44 ns** |     **9.945 ns** |     **8.305 ns** |  **3.75** |    **0.03** |
| IterateUsingKeyValuePairs | 1000   |     944.44 ns |     2.905 ns |     2.717 ns |  1.00 |    0.01 |
| IterateUsingValues        | 1000   |     943.51 ns |     6.990 ns |     6.539 ns |  1.00 |    0.01 |
|                           |        |               |              |              |       |         |
| **IterateAndLookupUsingKeys** | **100000** | **356,667.97 ns** | **1,646.116 ns** | **1,459.239 ns** |  **3.76** |    **0.02** |
| IterateUsingKeyValuePairs | 100000 |  95,069.00 ns |   445.733 ns |   416.939 ns |  1.00 |    0.01 |
| IterateUsingValues        | 100000 |  94,838.21 ns |   418.354 ns |   391.328 ns |  1.00 |    0.01 |
