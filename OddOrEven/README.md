# Counting odd numbers

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.22598
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=6.0.201
  [Host]     : .NET Core 6.0.3 (CoreCLR 6.0.322.12309, CoreFX 6.0.322.12309), X64 RyuJIT
  DefaultJob : .NET Core 6.0.3 (CoreCLR 6.0.322.12309, CoreFX 6.0.322.12309), X64 RyuJIT


```
|                  Method |  Count |          Mean |         Error |        StdDev | Ratio | RatioSD | Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------ |------- |--------------:|--------------:|--------------:|------:|--------:|------:|------:|------:|----------:|
|        **CountOddUsingMod** |     **10** |      **19.56 ns** |      **0.422 ns** |      **0.842 ns** |  **1.00** |    **0.00** |     **-** |     **-** |     **-** |         **-** |
| CountOddUsingBranchless |     10 |      19.18 ns |      0.420 ns |      0.914 ns |  0.98 |    0.07 |     - |     - |     - |         - |
|                         |        |               |               |               |       |         |       |       |       |           |
|        **CountOddUsingMod** |   **1000** |   **1,914.22 ns** |     **36.324 ns** |    **100.047 ns** |  **1.00** |    **0.00** |     **-** |     **-** |     **-** |         **-** |
| CountOddUsingBranchless |   1000 |   1,927.77 ns |     38.456 ns |     95.053 ns |  1.01 |    0.07 |     - |     - |     - |         - |
|                         |        |               |               |               |       |         |       |       |       |           |
|        **CountOddUsingMod** | **100000** | **578,944.10 ns** | **11,342.665 ns** | **19,565.540 ns** |  **1.00** |    **0.00** |     **-** |     **-** |     **-** |         **-** |
| CountOddUsingBranchless | 100000 | 553,671.83 ns | 11,015.188 ns | 18,098.269 ns |  0.96 |    0.05 |     - |     - |     - |         - |
