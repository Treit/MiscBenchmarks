# Array vs. Dictionary lookups by simple integer keys.





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                | Job       | Runtime   | Iterations | Mean          | Error        | StdDev       | Allocated |
|---------------------- |---------- |---------- |----------- |--------------:|-------------:|-------------:|----------:|
| **LookupUsingArray**      | **.NET 10.0** | **.NET 10.0** | **10**         |      **18.27 μs** |     **0.122 μs** |     **0.114 μs** |         **-** |
| LookupUsingDictionary | .NET 10.0 | .NET 10.0 | 10         |      18.91 μs |     0.156 μs |     0.146 μs |         - |
| LookupUsingArray      | .NET 9.0  | .NET 9.0  | 10         |      18.27 μs |     0.129 μs |     0.114 μs |         - |
| LookupUsingDictionary | .NET 9.0  | .NET 9.0  | 10         |      18.88 μs |     0.111 μs |     0.104 μs |         - |
| **LookupUsingArray**      | **.NET 10.0** | **.NET 10.0** | **100**        |     **182.56 μs** |     **0.860 μs** |     **0.804 μs** |         **-** |
| LookupUsingDictionary | .NET 10.0 | .NET 10.0 | 100        |     190.24 μs |     0.734 μs |     0.686 μs |         - |
| LookupUsingArray      | .NET 9.0  | .NET 9.0  | 100        |     182.32 μs |     0.870 μs |     0.771 μs |         - |
| LookupUsingDictionary | .NET 9.0  | .NET 9.0  | 100        |     188.68 μs |     0.859 μs |     0.718 μs |         - |
| **LookupUsingArray**      | **.NET 10.0** | **.NET 10.0** | **1000**       |   **1,826.33 μs** |     **4.142 μs** |     **3.874 μs** |         **-** |
| LookupUsingDictionary | .NET 10.0 | .NET 10.0 | 1000       |   1,901.98 μs |     1.302 μs |     1.016 μs |         - |
| LookupUsingArray      | .NET 9.0  | .NET 9.0  | 1000       |   1,822.83 μs |     5.366 μs |     4.756 μs |         - |
| LookupUsingDictionary | .NET 9.0  | .NET 9.0  | 1000       |   1,901.71 μs |     3.031 μs |     2.687 μs |         - |
| **LookupUsingArray**      | **.NET 10.0** | **.NET 10.0** | **10000**      |  **18,236.27 μs** |   **109.261 μs** |   **102.203 μs** |         **-** |
| LookupUsingDictionary | .NET 10.0 | .NET 10.0 | 10000      |  19,036.45 μs |   123.608 μs |   115.623 μs |         - |
| LookupUsingArray      | .NET 9.0  | .NET 9.0  | 10000      |  18,229.03 μs |    98.460 μs |    92.100 μs |         - |
| LookupUsingDictionary | .NET 9.0  | .NET 9.0  | 10000      |  18,884.05 μs |   115.883 μs |   108.397 μs |         - |
| **LookupUsingArray**      | **.NET 10.0** | **.NET 10.0** | **100000**     | **183,207.43 μs** | **1,499.425 μs** | **1,402.563 μs** |         **-** |
| LookupUsingDictionary | .NET 10.0 | .NET 10.0 | 100000     | 189,109.48 μs | 1,279.690 μs | 1,197.023 μs |         - |
| LookupUsingArray      | .NET 9.0  | .NET 9.0  | 100000     | 183,052.64 μs | 1,387.341 μs | 1,297.720 μs |         - |
| LookupUsingDictionary | .NET 9.0  | .NET 9.0  | 100000     | 189,817.24 μs | 1,231.396 μs | 1,151.849 μs |         - |
