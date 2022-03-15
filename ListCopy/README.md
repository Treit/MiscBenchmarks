# Copying lists

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.22572
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=6.0.200
  [Host]     : .NET Core 5.0.12 (CoreCLR 5.0.1221.52207, CoreFX 5.0.1221.52207), X64 RyuJIT
  DefaultJob : .NET Core 5.0.12 (CoreCLR 5.0.1221.52207, CoreFX 5.0.1221.52207), X64 RyuJIT


```
|                  Method |   Count |           Mean |         Error |        StdDev | Ratio | RatioSD |
|------------------------ |-------- |---------------:|--------------:|--------------:|------:|--------:|
| **CopyWithListConstructor** |    **1000** |       **468.2 ns** |       **9.62 ns** |      **28.07 ns** |  **1.00** |    **0.00** |
|          CopyWithToList |    1000 |       475.6 ns |       9.47 ns |      24.11 ns |  1.01 |    0.08 |
|          CopyExplicitly |    1000 |     5,829.7 ns |     141.85 ns |     416.03 ns | 12.51 |    1.24 |
|                         |         |                |               |               |       |         |
| **CopyWithListConstructor** |  **100000** |   **258,134.6 ns** |   **5,094.41 ns** |   **9,315.42 ns** |  **1.00** |    **0.00** |
|          CopyWithToList |  100000 |   247,186.0 ns |   4,906.34 ns |   5,249.73 ns |  0.96 |    0.05 |
|          CopyExplicitly |  100000 |   706,559.2 ns |  14,113.59 ns |  28,830.32 ns |  2.74 |    0.16 |
|                         |         |                |               |               |       |         |
| **CopyWithListConstructor** | **1000000** | **2,057,186.4 ns** |  **40,939.45 ns** |  **77,891.56 ns** |  **1.00** |    **0.00** |
|          CopyWithToList | 1000000 | 2,030,443.8 ns |  39,721.84 ns |  53,027.51 ns |  0.99 |    0.04 |
|          CopyExplicitly | 1000000 | 6,520,398.2 ns | 130,338.65 ns | 274,928.46 ns |  3.16 |    0.17 |
