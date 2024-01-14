# Rotating an array

``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                   Method | Amount |     Mean |    Error |   StdDev |   Gen0 | Allocated |
|------------------------- |------- |---------:|---------:|---------:|-------:|----------:|
|    **RotateLeftWithReverse** |      **1** | **27.38 ns** | **0.205 ns** | **0.171 ns** |      **-** |         **-** |
|       RotateLeftWithCopy |      1 | 59.61 ns | 0.617 ns | 0.547 ns | 0.0048 |      80 B |
|   RotateLeftWithJuggling |      1 | 25.89 ns | 0.573 ns | 1.158 ns |      - |         - |
| RotateLeftArrayCopyAaron |      1 | 17.22 ns | 0.288 ns | 0.269 ns | 0.0048 |      80 B |
|    **RotateLeftWithReverse** |      **4** | **27.13 ns** | **0.095 ns** | **0.084 ns** |      **-** |         **-** |
|       RotateLeftWithCopy |      4 | 59.56 ns | 0.690 ns | 0.646 ns | 0.0048 |      80 B |
|   RotateLeftWithJuggling |      4 | 28.51 ns | 0.173 ns | 0.154 ns |      - |         - |
| RotateLeftArrayCopyAaron |      4 | 17.22 ns | 0.201 ns | 0.188 ns | 0.0048 |      80 B |
|    **RotateLeftWithReverse** |     **16** | **26.60 ns** | **0.102 ns** | **0.091 ns** |      **-** |         **-** |
|       RotateLeftWithCopy |     16 | 59.43 ns | 0.690 ns | 0.612 ns | 0.0048 |      80 B |
|   RotateLeftWithJuggling |     16 | 38.70 ns | 0.171 ns | 0.152 ns |      - |         - |
| RotateLeftArrayCopyAaron |     16 | 16.49 ns | 0.123 ns | 0.115 ns | 0.0048 |      80 B |
|    **RotateLeftWithReverse** |     **24** | **30.08 ns** | **0.271 ns** | **0.253 ns** |      **-** |         **-** |
|       RotateLeftWithCopy |     24 | 59.49 ns | 0.306 ns | 0.271 ns | 0.0048 |      80 B |
|   RotateLeftWithJuggling |     24 | 28.08 ns | 0.105 ns | 0.099 ns |      - |         - |
| RotateLeftArrayCopyAaron |     24 | 15.96 ns | 0.203 ns | 0.190 ns | 0.0048 |      80 B |
