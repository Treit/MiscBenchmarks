# Dictionary lookups using different case comparison options.





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                         | Iterations | Mean            | Error         | StdDev        | Ratio | RatioSD | Allocated | Alloc Ratio |
|----------------------------------------------- |----------- |----------------:|--------------:|--------------:|------:|--------:|----------:|------------:|
| **DictonaryLookupUsingOrdinal**                    | **10**         |        **21.78 μs** |      **0.149 μs** |      **0.139 μs** |  **1.00** |    **0.01** |         **-** |          **NA** |
| DictonaryLookupUsingOrdinalIgnoreCase          | 10         |        33.23 μs |      0.264 μs |      0.221 μs |  1.53 |    0.01 |         - |          NA |
| DictonaryLookupUsingInvariantCulture           | 10         |       449.84 μs |      2.189 μs |      2.048 μs | 20.65 |    0.16 |         - |          NA |
| DictonaryLookupUsingInvariantCultureIgnoreCase | 10         |       446.08 μs |      8.310 μs |      7.774 μs | 20.48 |    0.37 |         - |          NA |
|                                                |            |                 |               |               |       |         |           |             |
| **DictonaryLookupUsingOrdinal**                    | **100000**     |   **215,816.03 μs** |  **2,121.433 μs** |  **1,984.390 μs** |  **1.00** |    **0.01** |         **-** |          **NA** |
| DictonaryLookupUsingOrdinalIgnoreCase          | 100000     |   306,778.19 μs |  2,142.631 μs |  1,899.387 μs |  1.42 |    0.02 |         - |          NA |
| DictonaryLookupUsingInvariantCulture           | 100000     | 4,627,052.52 μs | 21,661.216 μs | 20,261.915 μs | 21.44 |    0.21 |         - |          NA |
| DictonaryLookupUsingInvariantCultureIgnoreCase | 100000     | 4,520,425.35 μs | 20,883.098 μs | 19,534.062 μs | 20.95 |    0.21 |         - |          NA |
