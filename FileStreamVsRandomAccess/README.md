## FileStream vs. RandomAccess for reading random portions of a file.

.NET 6 was used for the results below.

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.22000
AMD Ryzen Threadripper 3960X, 1 CPU, 48 logical and 24 physical cores
.NET Core SDK=6.0.100-rc.1.21458.32
  [Host]   : .NET Core 6.0.0 (CoreCLR 6.0.21.45113, CoreFX 6.0.21.45113), X64 RyuJIT
  ShortRun : .NET Core 6.0.0 (CoreCLR 6.0.21.45113, CoreFX 6.0.21.45113), X64 RyuJIT

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
|                             Method |      Count |     Mean |   Error |  StdDev | Ratio |    Gen 0 |    Gen 1 |    Gen 2 | Allocated |
|----------------------------------- |----------- |---------:|--------:|--------:|------:|---------:|---------:|---------:|----------:|
|   **HashFileLocationsUsingFileStream** |    **3145728** | **136.8 ms** | **2.71 ms** | **0.15 ms** |  **1.00** | **250.0000** | **250.0000** | **250.0000** |      **2 MB** |
| HashFileLocationsUsingRandomAccess |    3145728 | 138.4 ms | 1.68 ms | 0.09 ms |  1.01 | 250.0000 | 250.0000 | 250.0000 |      2 MB |
|                                    |            |          |         |         |       |          |          |          |           |
|   **HashFileLocationsUsingFileStream** | **1073741824** | **137.7 ms** | **3.80 ms** | **0.21 ms** |  **1.00** | **333.3333** | **333.3333** | **333.3333** |      **2 MB** |
| HashFileLocationsUsingRandomAccess | 1073741824 | 139.9 ms | 3.65 ms | 0.20 ms |  1.02 | 333.3333 | 333.3333 | 333.3333 |      2 MB |
