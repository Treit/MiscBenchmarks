# Rotating an array
``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.25290.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.102
  [Host]     : .NET 6.0.13 (6.0.1322.58009), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.13 (6.0.1322.58009), X64 RyuJIT AVX2


```
|                   Method | Amount |      Mean |    Error |   StdDev |    Median |   Gen0 | Allocated |
|------------------------- |------- |----------:|---------:|---------:|----------:|-------:|----------:|
|    **RotateLeftWithReverse** |      **1** |  **37.71 ns** | **0.898 ns** | **2.619 ns** |  **36.88 ns** |      **-** |         **-** |
|       RotateLeftWithCopy |      1 | 115.31 ns | 2.318 ns | 2.931 ns | 114.42 ns | 0.0185 |      80 B |
|   RotateLeftWithJuggling |      1 |  65.99 ns | 2.370 ns | 6.799 ns |  64.30 ns |      - |         - |
| RotateLeftArrayCopyAaron |      1 |  33.26 ns | 1.267 ns | 3.736 ns |  33.12 ns | 0.0185 |      80 B |
|    **RotateLeftWithReverse** |      **4** |  **40.11 ns** | **1.589 ns** | **4.533 ns** |  **39.44 ns** |      **-** |         **-** |
|       RotateLeftWithCopy |      4 | 117.18 ns | 2.279 ns | 3.745 ns | 116.38 ns | 0.0185 |      80 B |
|   RotateLeftWithJuggling |      4 |  71.14 ns | 1.449 ns | 2.538 ns |  70.88 ns |      - |         - |
| RotateLeftArrayCopyAaron |      4 |  29.53 ns | 1.168 ns | 3.371 ns |  29.22 ns | 0.0185 |      80 B |
|    **RotateLeftWithReverse** |     **16** |  **46.14 ns** | **2.027 ns** | **5.978 ns** |  **44.73 ns** |      **-** |         **-** |
|       RotateLeftWithCopy |     16 | 107.85 ns | 1.272 ns | 1.190 ns | 107.92 ns | 0.0185 |      80 B |
|   RotateLeftWithJuggling |     16 |  96.52 ns | 2.408 ns | 6.753 ns |  94.58 ns |      - |         - |
| RotateLeftArrayCopyAaron |     16 |  31.10 ns | 1.358 ns | 3.960 ns |  30.52 ns | 0.0185 |      80 B |
|    **RotateLeftWithReverse** |     **24** |  **41.37 ns** | **0.861 ns** | **2.161 ns** |  **41.39 ns** |      **-** |         **-** |
|       RotateLeftWithCopy |     24 | 117.24 ns | 2.668 ns | 7.826 ns | 116.75 ns | 0.0184 |      80 B |
|   RotateLeftWithJuggling |     24 |  70.67 ns | 1.866 ns | 5.293 ns |  70.31 ns |      - |         - |
| RotateLeftArrayCopyAaron |     24 |  31.73 ns | 1.848 ns | 5.390 ns |  30.34 ns | 0.0185 |      80 B |
