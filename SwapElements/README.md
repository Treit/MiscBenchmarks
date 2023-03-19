# Swapping array elements.

``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.25314.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.201
  [Host]     : .NET 7.0.3 (7.0.323.6910), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.3 (7.0.323.6910), X64 RyuJIT AVX2


```
|                         Method |  Count |          Mean |        Error |        StdDev |    Gen0 |    Gen1 |    Gen2 | Allocated |
|------------------------------- |------- |--------------:|-------------:|--------------:|--------:|--------:|--------:|----------:|
|           **SwapWithTempVariable** |     **10** |      **26.93 ns** |     **0.642 ns** |      **1.842 ns** |  **0.0111** |       **-** |       **-** |      **48 B** |
|          SwapWithLocalFunction |     10 |      28.91 ns |     0.865 ns |      2.508 ns |  0.0111 |       - |       - |      48 B |
|                  SwapWithTuple |     10 |      29.08 ns |     0.950 ns |      2.740 ns |  0.0111 |       - |       - |      48 B |
|  SwapWithTempVariableLocalCopy |     10 |      21.26 ns |     0.785 ns |      2.226 ns |  0.0111 |       - |       - |      48 B |
| SwapWithLocalFunctionLocalCopy |     10 |      22.37 ns |     0.671 ns |      1.936 ns |  0.0111 |       - |       - |      48 B |
|         SwapWithTupleLocalCopy |     10 |      21.76 ns |     0.547 ns |      1.587 ns |  0.0111 |       - |       - |      48 B |
|           **SwapWithTempVariable** | **100000** | **176,610.75 ns** | **4,335.605 ns** | **12,715.579 ns** | **62.2559** | **62.2559** | **62.2559** |  **200045 B** |
|          SwapWithLocalFunction | 100000 | 187,417.44 ns | 4,310.172 ns | 12,504.591 ns | 62.2559 | 62.2559 | 62.2559 |  200045 B |
|                  SwapWithTuple | 100000 | 178,309.54 ns | 3,410.282 ns |  5,882.568 ns | 62.2559 | 62.2559 | 62.2559 |  200045 B |
|  SwapWithTempVariableLocalCopy | 100000 | 155,295.38 ns | 1,875.578 ns |  1,754.417 ns | 62.2559 | 62.2559 | 62.2559 |  200045 B |
| SwapWithLocalFunctionLocalCopy | 100000 | 158,582.56 ns | 2,161.915 ns |  2,022.257 ns | 62.2559 | 62.2559 | 62.2559 |  200045 B |
|         SwapWithTupleLocalCopy | 100000 | 168,234.08 ns | 3,234.065 ns |  3,321.147 ns | 62.2559 | 62.2559 | 62.2559 |  200045 B |
