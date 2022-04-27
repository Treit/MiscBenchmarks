# Reading and writing files

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.22598
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=6.0.202
  [Host]     : .NET Core 6.0.4 (CoreCLR 6.0.422.16404, CoreFX 6.0.422.16404), X64 RyuJIT
  DefaultJob : .NET Core 6.0.4 (CoreCLR 6.0.422.16404, CoreFX 6.0.422.16404), X64 RyuJIT


```
|         Method |  Count |         Mean |      Error |     StdDev |     Gen 0 |  Gen 1 | Gen 2 |   Allocated |
|--------------- |------- |-------------:|-----------:|-----------:|----------:|-------:|------:|------------:|
|  **WriteFileSync** |     **10** |    **485.28 μs** |   **8.856 μs** |  **10.198 μs** |    **1.4648** | **0.4883** |     **-** |     **6.73 KB** |
| WriteFileAsync |     10 |    477.60 μs |   9.425 μs |  17.234 μs |    0.9766 |      - |     - |     6.73 KB |
|   ReadFileSync |     10 |     53.89 μs |   1.070 μs |   2.281 μs |    1.8921 | 0.9155 |     - |        8 KB |
|  ReadFileAsync |     10 |    118.56 μs |   3.085 μs |   8.901 μs |    2.4414 | 1.2207 |     - |     9.81 KB |
|  **WriteFileSync** |    **100** |    **498.98 μs** |   **9.908 μs** |  **12.168 μs** |    **2.9297** | **1.4648** |     **-** |    **12.57 KB** |
| WriteFileAsync |    100 |    490.97 μs |   9.125 μs |   8.535 μs |    2.9297 | 1.4648 |     - |    12.57 KB |
|   ReadFileSync |    100 |     64.54 μs |   2.567 μs |   7.568 μs |    2.5635 | 1.2207 |     - |    10.81 KB |
|  ReadFileAsync |    100 |    136.21 μs |   3.148 μs |   9.233 μs |    5.1270 | 2.4414 |     - |    18.94 KB |
|  **WriteFileSync** | **100000** |  **6,022.87 μs** | **226.930 μs** | **640.060 μs** |  **742.1875** |      **-** |     **-** |  **3134.45 KB** |
| WriteFileAsync | 100000 | 10,504.15 μs | 313.117 μs | 888.260 μs |  750.0000 |      - |     - |   3185.9 KB |
|   ReadFileSync | 100000 |  3,142.32 μs |  85.677 μs | 251.275 μs |  769.5313 |      - |     - |  3245.17 KB |
|  ReadFileAsync | 100000 |  8,788.52 μs | 327.200 μs | 949.267 μs | 2453.1250 |      - |     - | 10315.57 KB |
