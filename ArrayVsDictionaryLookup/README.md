# Array vs. Dictionary lookups by simple integer keys.

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.25236
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=7.0.100-preview.5.22307.18
  [Host]     : .NET Core 6.0.10 (CoreCLR 6.0.1022.47605, CoreFX 6.0.1022.47605), X64 RyuJIT
  DefaultJob : .NET Core 6.0.10 (CoreCLR 6.0.1022.47605, CoreFX 6.0.1022.47605), X64 RyuJIT


```
|                Method | Iterations |          Mean |        Error |        StdDev |        Median | Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------- |----------- |--------------:|-------------:|--------------:|--------------:|------:|------:|------:|----------:|
|      **LookupUsingArray** |         **10** |      **14.57 μs** |     **0.280 μs** |      **0.383 μs** |      **14.60 μs** |     **-** |     **-** |     **-** |         **-** |
| LookupUsingDictionary |         10 |      16.94 μs |     0.334 μs |      0.296 μs |      16.92 μs |     - |     - |     - |         - |
|      **LookupUsingArray** |        **100** |     **141.26 μs** |     **2.380 μs** |      **2.226 μs** |     **141.23 μs** |     **-** |     **-** |     **-** |         **-** |
| LookupUsingDictionary |        100 |     171.98 μs |     3.244 μs |      4.102 μs |     171.56 μs |     - |     - |     - |         - |
|      **LookupUsingArray** |       **1000** |   **1,440.06 μs** |    **28.033 μs** |     **44.463 μs** |   **1,433.69 μs** |     **-** |     **-** |     **-** |       **1 B** |
| LookupUsingDictionary |       1000 |   1,747.29 μs |    34.877 μs |     70.453 μs |   1,728.30 μs |     - |     - |     - |       1 B |
|      **LookupUsingArray** |      **10000** |  **14,625.10 μs** |   **291.711 μs** |    **495.348 μs** |  **14,495.09 μs** |     **-** |     **-** |     **-** |       **8 B** |
| LookupUsingDictionary |      10000 |  17,025.05 μs |   325.278 μs |    534.441 μs |  16,892.15 μs |     - |     - |     - |      15 B |
|      **LookupUsingArray** |     **100000** | **143,459.38 μs** | **2,762.062 μs** |  **3,591.460 μs** | **142,906.12 μs** |     **-** |     **-** |     **-** |     **120 B** |
| LookupUsingDictionary |     100000 | 184,070.33 μs | 4,297.234 μs | 12,260.251 μs | 180,573.30 μs |     - |     - |     - |     160 B |
