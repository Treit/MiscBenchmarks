# Swapping array elements.


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                         Method |  Count |          Mean |      Error |     StdDev |    Gen0 |    Gen1 |    Gen2 | Allocated |
|------------------------------- |------- |--------------:|-----------:|-----------:|--------:|--------:|--------:|----------:|
|           **SwapWithTempVariable** |     **10** |      **20.09 ns** |   **0.414 ns** |   **0.367 ns** |  **0.0029** |       **-** |       **-** |      **48 B** |
|          SwapWithLocalFunction |     10 |      19.26 ns |   0.157 ns |   0.147 ns |  0.0029 |       - |       - |      48 B |
|                  SwapWithTuple |     10 |      21.46 ns |   0.493 ns |   1.421 ns |  0.0029 |       - |       - |      48 B |
|  SwapWithTempVariableLocalCopy |     10 |      16.65 ns |   0.149 ns |   0.139 ns |  0.0029 |       - |       - |      48 B |
| SwapWithLocalFunctionLocalCopy |     10 |      16.05 ns |   0.130 ns |   0.121 ns |  0.0029 |       - |       - |      48 B |
|         SwapWithTupleLocalCopy |     10 |      17.37 ns |   0.207 ns |   0.194 ns |  0.0029 |       - |       - |      48 B |
|           **SwapWithTempVariable** | **100000** | **216,588.44 ns** | **571.454 ns** | **506.579 ns** | **62.2559** | **62.2559** | **62.2559** |  **200045 B** |
|          SwapWithLocalFunction | 100000 | 217,634.24 ns | 388.429 ns | 363.337 ns | 62.2559 | 62.2559 | 62.2559 |  200045 B |
|                  SwapWithTuple | 100000 | 252,399.70 ns | 685.971 ns | 608.096 ns | 62.0117 | 62.0117 | 62.0117 |  200045 B |
|  SwapWithTempVariableLocalCopy | 100000 | 218,176.28 ns | 591.808 ns | 553.577 ns | 62.2559 | 62.2559 | 62.2559 |  200045 B |
| SwapWithLocalFunctionLocalCopy | 100000 | 220,540.83 ns | 774.479 ns | 724.448 ns | 62.2559 | 62.2559 | 62.2559 |  200045 B |
|         SwapWithTupleLocalCopy | 100000 | 221,108.05 ns | 944.938 ns | 883.896 ns | 62.2559 | 62.2559 | 62.2559 |  200045 B |
