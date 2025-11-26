# Array vs. Dictionary lookups by simple integer keys.




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                | Iterations | Mean          | Error        | StdDev       | Allocated |
|---------------------- |----------- |--------------:|-------------:|-------------:|----------:|
| **LookupUsingArray**      | **10**         |      **18.47 μs** |     **0.342 μs** |     **0.320 μs** |         **-** |
| LookupUsingDictionary | 10         |      18.94 μs |     0.115 μs |     0.108 μs |         - |
| **LookupUsingArray**      | **100**        |     **182.77 μs** |     **0.726 μs** |     **0.679 μs** |       **3 B** |
| LookupUsingDictionary | 100        |     189.01 μs |     0.819 μs |     0.766 μs |         - |
| **LookupUsingArray**      | **1000**       |   **1,828.64 μs** |     **5.162 μs** |     **4.310 μs** |         **-** |
| LookupUsingDictionary | 1000       |   1,906.34 μs |     4.445 μs |     3.940 μs |         - |
| **LookupUsingArray**      | **10000**      |  **18,273.56 μs** |   **110.707 μs** |   **103.555 μs** |         **-** |
| LookupUsingDictionary | 10000      |  19,066.91 μs |   109.754 μs |   102.664 μs |         - |
| **LookupUsingArray**      | **100000**     | **182,785.07 μs** | **1,128.518 μs** | **1,055.617 μs** |         **-** |
| LookupUsingDictionary | 100000     | 189,434.77 μs | 1,205.848 μs | 1,127.951 μs |         - |
