# Iterating dictionary entries.





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                    | Job       | Runtime   | Count  | Mean           | Error         | StdDev        | Ratio | RatioSD |
|-------------------------- |---------- |---------- |------- |---------------:|--------------:|--------------:|------:|--------:|
| **IterateAndLookupUsingKeys** | **.NET 10.0** | **.NET 10.0** | **10**     |      **39.469 ns** |     **0.3886 ns** |     **0.3635 ns** |  **3.00** |    **0.03** |
| IterateUsingKeyValuePairs | .NET 10.0 | .NET 10.0 | 10     |       9.930 ns |     0.1801 ns |     0.1684 ns |  0.76 |    0.01 |
| IterateUsingValues        | .NET 10.0 | .NET 10.0 | 10     |      13.140 ns |     0.0488 ns |     0.0408 ns |  1.00 |    0.00 |
|                           |           |           |        |                |               |               |       |         |
| IterateAndLookupUsingKeys | .NET 9.0  | .NET 9.0  | 10     |      40.925 ns |     0.4899 ns |     0.4582 ns |  3.10 |    0.03 |
| IterateUsingKeyValuePairs | .NET 9.0  | .NET 9.0  | 10     |      10.035 ns |     0.0880 ns |     0.0780 ns |  0.76 |    0.01 |
| IterateUsingValues        | .NET 9.0  | .NET 9.0  | 10     |      13.211 ns |     0.0360 ns |     0.0336 ns |  1.00 |    0.00 |
|                           |           |           |        |                |               |               |       |         |
| **IterateAndLookupUsingKeys** | **.NET 10.0** | **.NET 10.0** | **1000**   |   **3,552.987 ns** |    **21.2005 ns** |    **19.8310 ns** |  **3.75** |    **0.03** |
| IterateUsingKeyValuePairs | .NET 10.0 | .NET 10.0 | 1000   |     949.850 ns |     9.9464 ns |     9.3039 ns |  1.00 |    0.01 |
| IterateUsingValues        | .NET 10.0 | .NET 10.0 | 1000   |     948.620 ns |     6.5859 ns |     5.1418 ns |  1.00 |    0.01 |
|                           |           |           |        |                |               |               |       |         |
| IterateAndLookupUsingKeys | .NET 9.0  | .NET 9.0  | 1000   |   3,615.516 ns |    32.3028 ns |    30.2160 ns |  3.82 |    0.03 |
| IterateUsingKeyValuePairs | .NET 9.0  | .NET 9.0  | 1000   |     954.834 ns |    12.3231 ns |    10.9241 ns |  1.01 |    0.01 |
| IterateUsingValues        | .NET 9.0  | .NET 9.0  | 1000   |     946.126 ns |     1.5517 ns |     1.2958 ns |  1.00 |    0.00 |
|                           |           |           |        |                |               |               |       |         |
| **IterateAndLookupUsingKeys** | **.NET 10.0** | **.NET 10.0** | **100000** | **357,680.577 ns** | **1,578.5452 ns** | **1,399.3392 ns** |  **3.77** |    **0.02** |
| IterateUsingKeyValuePairs | .NET 10.0 | .NET 10.0 | 100000 |  94,873.619 ns |   557.5210 ns |   494.2278 ns |  1.00 |    0.01 |
| IterateUsingValues        | .NET 10.0 | .NET 10.0 | 100000 |  94,960.300 ns |   537.5649 ns |   502.8385 ns |  1.00 |    0.01 |
|                           |           |           |        |                |               |               |       |         |
| IterateAndLookupUsingKeys | .NET 9.0  | .NET 9.0  | 100000 | 357,159.494 ns | 2,098.8345 ns | 1,860.5621 ns |  3.76 |    0.03 |
| IterateUsingKeyValuePairs | .NET 9.0  | .NET 9.0  | 100000 |  94,962.074 ns |   622.0517 ns |   551.4326 ns |  1.00 |    0.01 |
| IterateUsingValues        | .NET 9.0  | .NET 9.0  | 100000 |  94,981.299 ns |   585.0768 ns |   488.5656 ns |  1.00 |    0.01 |
