# Calling methods on sealed vs non-sealed classes.

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.22593
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=6.0.201
  [Host]     : .NET Core 6.0.3 (CoreCLR 6.0.322.12309, CoreFX 6.0.322.12309), X64 RyuJIT
  DefaultJob : .NET Core 6.0.3 (CoreCLR 6.0.322.12309, CoreFX 6.0.322.12309), X64 RyuJIT


```
|                 Method | Count |         Mean |       Error |      StdDev |
|----------------------- |------ |-------------:|------------:|------------:|
|                 **Sealed** |    **10** |     **5.856 μs** |   **0.1168 μs** |   **0.2386 μs** |
|              NonSealed |    10 |     5.907 μs |   0.1102 μs |   0.2225 μs |
| NonSealedVirtualMethod |    10 |     5.860 μs |   0.1172 μs |   0.1643 μs |
|               OneChild |    10 |     5.905 μs |   0.1152 μs |   0.2107 μs |
|                 **Sealed** |  **1000** | **9,139.518 μs** | **180.8975 μs** | **312.0392 μs** |
|              NonSealed |  1000 | 9,210.397 μs | 183.1138 μs | 352.7980 μs |
| NonSealedVirtualMethod |  1000 | 9,193.683 μs | 165.2184 μs | 247.2911 μs |
|               OneChild |  1000 | 9,294.288 μs | 185.7367 μs | 366.6261 μs |
