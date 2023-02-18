# Rotating an array
``` ini

BenchmarkDotNet=v0.13.3, OS=arch
11th Gen Intel Core i7-1165G7 2.80GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.102
  [Host]     : .NET 6.0.12 (6.0.1222.56807), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.12 (6.0.1222.56807), X64 RyuJIT AVX2


```
|                   Method | Amount |     Mean |    Error |   StdDev |   Gen0 | Allocated |
|------------------------- |------- |---------:|---------:|---------:|-------:|----------:|
|    **RotateLeftWithReverse** |      **1** | **28.39 ns** | **0.589 ns** | **0.766 ns** |      **-** |         **-** |
|       RotateLeftWithCopy |      1 | 45.25 ns | 0.238 ns | 0.211 ns | 0.0127 |      80 B |
|   RotateLeftWithJuggling |      1 | 34.80 ns | 0.292 ns | 0.259 ns |      - |         - |
| RotateLeftArrayCopyAaron |      1 | 17.85 ns | 0.091 ns | 0.085 ns | 0.0127 |      80 B |
|    **RotateLeftWithReverse** |      **4** | **25.38 ns** | **0.073 ns** | **0.065 ns** |      **-** |         **-** |
|       RotateLeftWithCopy |      4 | 45.84 ns | 0.557 ns | 0.494 ns | 0.0127 |      80 B |
|   RotateLeftWithJuggling |      4 | 29.67 ns | 0.263 ns | 0.233 ns |      - |         - |
| RotateLeftArrayCopyAaron |      4 | 17.97 ns | 0.058 ns | 0.045 ns | 0.0127 |      80 B |
|    **RotateLeftWithReverse** |     **16** | **25.90 ns** | **0.378 ns** | **0.353 ns** |      **-** |         **-** |
|       RotateLeftWithCopy |     16 | 45.65 ns | 0.377 ns | 0.353 ns | 0.0127 |      80 B |
|   RotateLeftWithJuggling |     16 | 39.16 ns | 0.231 ns | 0.216 ns |      - |         - |
| RotateLeftArrayCopyAaron |     16 | 17.98 ns | 0.178 ns | 0.157 ns | 0.0127 |      80 B |
|    **RotateLeftWithReverse** |     **24** | **24.13 ns** | **0.364 ns** | **0.322 ns** |      **-** |         **-** |
|       RotateLeftWithCopy |     24 | 45.45 ns | 0.263 ns | 0.246 ns | 0.0127 |      80 B |
|   RotateLeftWithJuggling |     24 | 29.37 ns | 0.217 ns | 0.182 ns |      - |         - |
| RotateLeftArrayCopyAaron |     24 | 16.85 ns | 0.165 ns | 0.146 ns | 0.0127 |      80 B |

