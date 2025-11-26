# Swapping array elements.




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                         | Count  | Mean          | Error        | StdDev       | Gen0    | Gen1    | Gen2    | Allocated |
|------------------------------- |------- |--------------:|-------------:|-------------:|--------:|--------:|--------:|----------:|
| **SwapWithTempVariable**           | **10**     |      **22.36 ns** |     **0.511 ns** |     **0.525 ns** |  **0.0029** |       **-** |       **-** |      **48 B** |
| SwapWithLocalFunction          | 10     |      19.63 ns |     0.301 ns |     0.251 ns |  0.0029 |       - |       - |      48 B |
| SwapWithTempVariableLocalCopy  | 10     |      17.06 ns |     0.276 ns |     0.259 ns |  0.0029 |       - |       - |      48 B |
| SwapWithLocalFunctionLocalCopy | 10     |      16.33 ns |     0.237 ns |     0.222 ns |  0.0029 |       - |       - |      48 B |
| SwapWithTuple                  | 10     |      20.00 ns |     0.146 ns |     0.129 ns |  0.0029 |       - |       - |      48 B |
| SwapWithTupleLocalCopy         | 10     |      17.51 ns |     0.175 ns |     0.164 ns |  0.0029 |       - |       - |      48 B |
| **SwapWithTempVariable**           | **100000** | **287,302.06 ns** | **2,004.029 ns** | **1,776.519 ns** | **62.0117** | **62.0117** | **62.0117** |  **200045 B** |
| SwapWithLocalFunction          | 100000 | 290,057.41 ns | 2,621.721 ns | 2,452.359 ns | 62.0117 | 62.0117 | 62.0117 |  200045 B |
| SwapWithTempVariableLocalCopy  | 100000 | 288,868.11 ns | 3,005.599 ns | 2,811.439 ns | 62.0117 | 62.0117 | 62.0117 |  200045 B |
| SwapWithLocalFunctionLocalCopy | 100000 | 291,742.10 ns | 2,540.060 ns | 2,375.973 ns | 62.0117 | 62.0117 | 62.0117 |  200045 B |
| SwapWithTuple                  | 100000 | 321,887.19 ns | 1,860.819 ns | 1,740.611 ns | 62.0117 | 62.0117 | 62.0117 |  200045 B |
| SwapWithTupleLocalCopy         | 100000 | 286,677.34 ns | 2,478.709 ns | 2,318.586 ns | 62.0117 | 62.0117 | 62.0117 |  200045 B |
