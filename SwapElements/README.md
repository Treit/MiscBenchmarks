# Swapping array elements.



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                         | Count  | Mean          | Error        | StdDev        | Median        | Gen0    | Gen1    | Gen2    | Allocated |
|------------------------------- |------- |--------------:|-------------:|--------------:|--------------:|--------:|--------:|--------:|----------:|
| **SwapWithTempVariable**           | **10**     |      **21.01 ns** |     **0.472 ns** |      **0.613 ns** |      **21.09 ns** |  **0.0029** |       **-** |       **-** |      **48 B** |
| SwapWithLocalFunction          | 10     |      19.85 ns |     0.460 ns |      0.768 ns |      19.90 ns |  0.0029 |       - |       - |      48 B |
| SwapWithTempVariableLocalCopy  | 10     |      16.35 ns |     0.199 ns |      0.186 ns |      16.36 ns |  0.0029 |       - |       - |      48 B |
| SwapWithLocalFunctionLocalCopy | 10     |      16.23 ns |     0.190 ns |      0.178 ns |      16.23 ns |  0.0029 |       - |       - |      48 B |
| SwapWithTuple                  | 10     |      19.67 ns |     0.251 ns |      0.222 ns |      19.68 ns |  0.0029 |       - |       - |      48 B |
| SwapWithTupleLocalCopy         | 10     |      17.26 ns |     0.115 ns |      0.107 ns |      17.28 ns |  0.0029 |       - |       - |      48 B |
| **SwapWithTempVariable**           | **100000** | **340,291.70 ns** | **6,735.241 ns** | **15,064.334 ns** | **344,870.00 ns** | **62.0117** | **62.0117** | **62.0117** |  **200045 B** |
| SwapWithLocalFunction          | 100000 | 342,987.81 ns | 6,803.751 ns | 13,270.194 ns | 346,571.34 ns | 62.0117 | 62.0117 | 62.0117 |  200045 B |
| SwapWithTempVariableLocalCopy  | 100000 | 343,571.89 ns | 6,780.505 ns | 14,002.919 ns | 348,376.17 ns | 62.0117 | 62.0117 | 62.0117 |  200045 B |
| SwapWithLocalFunctionLocalCopy | 100000 | 347,916.08 ns | 6,903.457 ns | 14,561.735 ns | 352,234.99 ns | 62.0117 | 62.0117 | 62.0117 |  200045 B |
| SwapWithTuple                  | 100000 | 379,715.32 ns | 1,421.251 ns |  1,329.439 ns | 380,067.48 ns | 62.0117 | 62.0117 | 62.0117 |  200045 B |
| SwapWithTupleLocalCopy         | 100000 | 338,089.50 ns | 6,709.259 ns | 17,792.005 ns | 345,279.52 ns | 62.0117 | 62.0117 | 62.0117 |  200045 B |
