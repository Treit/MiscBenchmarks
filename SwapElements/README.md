# Swapping array elements.





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                         | Job       | Runtime   | Count  | Mean          | Error        | StdDev       | Gen0    | Gen1    | Gen2    | Allocated |
|------------------------------- |---------- |---------- |------- |--------------:|-------------:|-------------:|--------:|--------:|--------:|----------:|
| **SwapWithTempVariable**           | **.NET 10.0** | **.NET 10.0** | **10**     |      **20.36 ns** |     **0.274 ns** |     **0.229 ns** |  **0.0029** |       **-** |       **-** |      **48 B** |
| SwapWithLocalFunction          | .NET 10.0 | .NET 10.0 | 10     |      19.08 ns |     0.373 ns |     0.330 ns |  0.0029 |       - |       - |      48 B |
| SwapWithTempVariableLocalCopy  | .NET 10.0 | .NET 10.0 | 10     |      16.52 ns |     0.156 ns |     0.138 ns |  0.0029 |       - |       - |      48 B |
| SwapWithLocalFunctionLocalCopy | .NET 10.0 | .NET 10.0 | 10     |      16.04 ns |     0.098 ns |     0.082 ns |  0.0029 |       - |       - |      48 B |
| SwapWithTuple                  | .NET 10.0 | .NET 10.0 | 10     |      19.58 ns |     0.160 ns |     0.150 ns |  0.0029 |       - |       - |      48 B |
| SwapWithTupleLocalCopy         | .NET 10.0 | .NET 10.0 | 10     |      17.10 ns |     0.113 ns |     0.105 ns |  0.0029 |       - |       - |      48 B |
| SwapWithTempVariable           | .NET 9.0  | .NET 9.0  | 10     |      20.69 ns |     0.471 ns |     0.578 ns |  0.0029 |       - |       - |      48 B |
| SwapWithLocalFunction          | .NET 9.0  | .NET 9.0  | 10     |      18.86 ns |     0.161 ns |     0.134 ns |  0.0029 |       - |       - |      48 B |
| SwapWithTempVariableLocalCopy  | .NET 9.0  | .NET 9.0  | 10     |      16.25 ns |     0.137 ns |     0.128 ns |  0.0029 |       - |       - |      48 B |
| SwapWithLocalFunctionLocalCopy | .NET 9.0  | .NET 9.0  | 10     |      16.23 ns |     0.210 ns |     0.196 ns |  0.0029 |       - |       - |      48 B |
| SwapWithTuple                  | .NET 9.0  | .NET 9.0  | 10     |      19.55 ns |     0.126 ns |     0.118 ns |  0.0029 |       - |       - |      48 B |
| SwapWithTupleLocalCopy         | .NET 9.0  | .NET 9.0  | 10     |      17.29 ns |     0.154 ns |     0.144 ns |  0.0029 |       - |       - |      48 B |
| **SwapWithTempVariable**           | **.NET 10.0** | **.NET 10.0** | **100000** | **286,546.67 ns** | **2,123.263 ns** | **1,986.101 ns** | **62.0117** | **62.0117** | **62.0117** |  **200045 B** |
| SwapWithLocalFunction          | .NET 10.0 | .NET 10.0 | 100000 | 289,058.82 ns | 1,778.035 ns | 1,663.175 ns | 62.0117 | 62.0117 | 62.0117 |  200045 B |
| SwapWithTempVariableLocalCopy  | .NET 10.0 | .NET 10.0 | 100000 | 285,391.04 ns | 2,012.224 ns | 1,882.236 ns | 62.0117 | 62.0117 | 62.0117 |  200045 B |
| SwapWithLocalFunctionLocalCopy | .NET 10.0 | .NET 10.0 | 100000 | 290,722.91 ns | 2,061.139 ns | 1,927.991 ns | 62.0117 | 62.0117 | 62.0117 |  200045 B |
| SwapWithTuple                  | .NET 10.0 | .NET 10.0 | 100000 | 320,487.93 ns | 1,235.349 ns | 1,031.572 ns | 62.0117 | 62.0117 | 62.0117 |  200045 B |
| SwapWithTupleLocalCopy         | .NET 10.0 | .NET 10.0 | 100000 | 285,279.46 ns | 2,549.555 ns | 2,384.855 ns | 62.0117 | 62.0117 | 62.0117 |  200045 B |
| SwapWithTempVariable           | .NET 9.0  | .NET 9.0  | 100000 | 287,002.50 ns | 2,224.935 ns | 2,081.205 ns | 62.0117 | 62.0117 | 62.0117 |  200045 B |
| SwapWithLocalFunction          | .NET 9.0  | .NET 9.0  | 100000 | 288,380.79 ns | 2,243.460 ns | 2,098.533 ns | 62.0117 | 62.0117 | 62.0117 |  200045 B |
| SwapWithTempVariableLocalCopy  | .NET 9.0  | .NET 9.0  | 100000 | 285,968.39 ns | 2,476.742 ns | 2,316.746 ns | 62.0117 | 62.0117 | 62.0117 |  200045 B |
| SwapWithLocalFunctionLocalCopy | .NET 9.0  | .NET 9.0  | 100000 | 291,146.56 ns | 2,365.928 ns | 2,213.090 ns | 62.0117 | 62.0117 | 62.0117 |  200045 B |
| SwapWithTuple                  | .NET 9.0  | .NET 9.0  | 100000 | 320,158.73 ns | 1,749.134 ns | 1,636.141 ns | 62.0117 | 62.0117 | 62.0117 |  200045 B |
| SwapWithTupleLocalCopy         | .NET 9.0  | .NET 9.0  | 100000 | 285,973.89 ns | 2,190.459 ns | 2,048.957 ns | 62.0117 | 62.0117 | 62.0117 |  200045 B |
