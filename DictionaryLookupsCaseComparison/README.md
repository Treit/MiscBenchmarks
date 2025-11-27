# Dictionary lookups using different case comparison options.






```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                         | Job       | Runtime   | Iterations | Mean            | Error         | StdDev        | Ratio | RatioSD | Allocated | Alloc Ratio |
|----------------------------------------------- |---------- |---------- |----------- |----------------:|--------------:|--------------:|------:|--------:|----------:|------------:|
| **DictonaryLookupUsingOrdinal**                    | **.NET 10.0** | **.NET 10.0** | **10**         |        **21.77 μs** |      **0.161 μs** |      **0.151 μs** |  **1.00** |    **0.01** |         **-** |          **NA** |
| DictonaryLookupUsingOrdinalIgnoreCase          | .NET 10.0 | .NET 10.0 | 10         |        33.20 μs |      0.248 μs |      0.232 μs |  1.53 |    0.01 |         - |          NA |
| DictonaryLookupUsingInvariantCulture           | .NET 10.0 | .NET 10.0 | 10         |       467.41 μs |      8.176 μs |      7.648 μs | 21.48 |    0.37 |         - |          NA |
| DictonaryLookupUsingInvariantCultureIgnoreCase | .NET 10.0 | .NET 10.0 | 10         |       441.63 μs |      8.232 μs |      7.701 μs | 20.29 |    0.37 |         - |          NA |
|                                                |           |           |            |                 |               |               |       |         |           |             |
| DictonaryLookupUsingOrdinal                    | .NET 9.0  | .NET 9.0  | 10         |        21.74 μs |      0.097 μs |      0.090 μs |  1.00 |    0.01 |         - |          NA |
| DictonaryLookupUsingOrdinalIgnoreCase          | .NET 9.0  | .NET 9.0  | 10         |        33.24 μs |      0.260 μs |      0.243 μs |  1.53 |    0.01 |         - |          NA |
| DictonaryLookupUsingInvariantCulture           | .NET 9.0  | .NET 9.0  | 10         |       445.25 μs |      8.863 μs |      7.857 μs | 20.48 |    0.36 |         - |          NA |
| DictonaryLookupUsingInvariantCultureIgnoreCase | .NET 9.0  | .NET 9.0  | 10         |       443.43 μs |      5.166 μs |      4.832 μs | 20.40 |    0.23 |         - |          NA |
|                                                |           |           |            |                 |               |               |       |         |           |             |
| **DictonaryLookupUsingOrdinal**                    | **.NET 10.0** | **.NET 10.0** | **100000**     |   **215,957.58 μs** |  **1,748.668 μs** |  **1,635.705 μs** |  **1.00** |    **0.01** |         **-** |          **NA** |
| DictonaryLookupUsingOrdinalIgnoreCase          | .NET 10.0 | .NET 10.0 | 100000     |   306,826.50 μs |  2,536.197 μs |  2,248.272 μs |  1.42 |    0.01 |         - |          NA |
| DictonaryLookupUsingInvariantCulture           | .NET 10.0 | .NET 10.0 | 100000     | 5,040,948.45 μs | 52,884.293 μs | 49,468.001 μs | 23.34 |    0.28 |         - |          NA |
| DictonaryLookupUsingInvariantCultureIgnoreCase | .NET 10.0 | .NET 10.0 | 100000     | 4,572,900.55 μs | 84,624.406 μs | 79,157.722 μs | 21.18 |    0.39 |         - |          NA |
|                                                |           |           |            |                 |               |               |       |         |           |             |
| DictonaryLookupUsingOrdinal                    | .NET 9.0  | .NET 9.0  | 100000     |   216,716.41 μs |  2,496.464 μs |  2,335.194 μs |  1.00 |    0.01 |         - |          NA |
| DictonaryLookupUsingOrdinalIgnoreCase          | .NET 9.0  | .NET 9.0  | 100000     |   306,728.81 μs |  1,939.710 μs |  1,719.502 μs |  1.42 |    0.02 |         - |          NA |
| DictonaryLookupUsingInvariantCulture           | .NET 9.0  | .NET 9.0  | 100000     | 4,618,783.54 μs | 28,789.292 μs | 26,929.522 μs | 21.31 |    0.25 |         - |          NA |
| DictonaryLookupUsingInvariantCultureIgnoreCase | .NET 9.0  | .NET 9.0  | 100000     | 4,253,003.21 μs | 34,812.045 μs | 32,563.208 μs | 19.63 |    0.25 |         - |          NA |
