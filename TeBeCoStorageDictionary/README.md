# TeBeCoStorageDictionary

```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.28000.1199)
Unknown processor
.NET SDK 10.0.100-preview.6.25358.103
  [Host]     : .NET 9.0.10 (9.0.1025.47515), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 9.0.10 (9.0.1025.47515), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                   | EntityCount | Mean           | Error         | StdDev          | Median         | Ratio | RatioSD | Gen0     | Allocated | Alloc Ratio |
|------------------------- |------------ |---------------:|--------------:|----------------:|---------------:|------:|--------:|---------:|----------:|------------:|
| **NewImplementationTypeOf**  | **1**           |    **16,307.0 ns** |   **1,068.30 ns** |     **3,082.29 ns** |    **15,587.4 ns** |  **1.03** |    **0.26** |   **0.6409** |    **2889 B** |        **1.00** |
| OldImplementationTypeOf  | 1           |       376.9 ns |      18.63 ns |        54.64 ns |       365.0 ns |  0.02 |    0.01 |   0.1426 |     616 B |        0.21 |
| NewImplementationGetType | 1           |    15,759.1 ns |     952.16 ns |     2,701.12 ns |    14,942.9 ns |  1.00 |    0.24 |   0.6409 |    2889 B |        1.00 |
| OldImplementationGetType | 1           |       384.1 ns |      21.30 ns |        61.44 ns |       366.1 ns |  0.02 |    0.01 |   0.1426 |     616 B |        0.21 |
|                          |             |                |               |                 |                |       |         |          |           |             |
| **NewImplementationTypeOf**  | **512**         | **7,370,961.4 ns** | **385,094.42 ns** | **1,111,085.54 ns** | **7,017,710.2 ns** |  **1.02** |    **0.21** | **328.1250** | **1478935 B** |        **1.00** |
| OldImplementationTypeOf  | 512         |   172,255.5 ns |   6,935.00 ns |    20,448.01 ns |   167,916.7 ns |  0.02 |    0.00 |  72.9980 |  315418 B |        0.21 |
| NewImplementationGetType | 512         | 7,479,333.7 ns | 401,335.67 ns | 1,151,507.35 ns | 7,243,023.4 ns |  1.04 |    0.21 | 328.1250 | 1478935 B |        1.00 |
| OldImplementationGetType | 512         |   186,509.9 ns |  10,314.71 ns |    30,088.49 ns |   177,426.7 ns |  0.03 |    0.01 |  72.9980 |  315418 B |        0.21 |
