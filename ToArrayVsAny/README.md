# Finding if a collection has elements matching a collection. Any() vs. Length > 0 and variants.




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                          | Job       | Runtime   | Count  | Mean           | Error         | StdDev        | Ratio      | RatioSD  | Gen0     | Gen1     | Gen2     | Allocated | Alloc Ratio |
|-------------------------------- |---------- |---------- |------- |---------------:|--------------:|--------------:|-----------:|---------:|---------:|---------:|---------:|----------:|------------:|
| **ToArrayDotLengthGreaterThanZero** | **.NET 10.0** | **.NET 10.0** | **10**     |      **95.890 ns** |     **0.6940 ns** |     **0.5795 ns** |      **43.17** |     **0.28** |   **0.0086** |        **-** |        **-** |     **144 B** |          **NA** |
| LinqCountGreaterThanZero        | .NET 10.0 | .NET 10.0 | 10     |      31.927 ns |     0.2337 ns |     0.2186 ns |      14.37 |     0.10 |   0.0029 |        - |        - |      48 B |          NA |
| Any                             | .NET 10.0 | .NET 10.0 | 10     |       2.221 ns |     0.0073 ns |     0.0065 ns |       1.00 |     0.00 |        - |        - |        - |         - |          NA |
|                                 |           |           |        |                |               |               |            |          |          |          |          |           |             |
| ToArrayDotLengthGreaterThanZero | .NET 9.0  | .NET 9.0  | 10     |      96.321 ns |     0.7597 ns |     0.6734 ns |      43.44 |     0.31 |   0.0086 |        - |        - |     144 B |          NA |
| LinqCountGreaterThanZero        | .NET 9.0  | .NET 9.0  | 10     |      31.751 ns |     0.2208 ns |     0.2065 ns |      14.32 |     0.10 |   0.0029 |        - |        - |      48 B |          NA |
| Any                             | .NET 9.0  | .NET 9.0  | 10     |       2.217 ns |     0.0069 ns |     0.0057 ns |       1.00 |     0.00 |        - |        - |        - |         - |          NA |
|                                 |           |           |        |                |               |               |            |          |          |          |          |           |             |
| **ToArrayDotLengthGreaterThanZero** | **.NET 10.0** | **.NET 10.0** | **100000** | **736,027.086 ns** | **6,435.5653 ns** | **5,704.9610 ns** | **386,653.18** | **5,628.57** | **127.9297** | **127.9297** | **127.9297** |  **721190 B** |          **NA** |
| LinqCountGreaterThanZero        | .NET 10.0 | .NET 10.0 | 100000 | 223,839.444 ns |   504.6474 ns |   447.3568 ns | 117,588.38 | 1,485.41 |        - |        - |        - |      48 B |          NA |
| Any                             | .NET 10.0 | .NET 10.0 | 100000 |       1.904 ns |     0.0266 ns |     0.0249 ns |       1.00 |     0.02 |        - |        - |        - |         - |          NA |
|                                 |           |           |        |                |               |               |            |          |          |          |          |           |             |
| ToArrayDotLengthGreaterThanZero | .NET 9.0  | .NET 9.0  | 100000 | 655,550.599 ns | 5,120.9921 ns | 4,790.1792 ns | 349,661.90 | 2,515.11 | 126.9531 | 126.9531 | 126.9531 |  721181 B |          NA |
| LinqCountGreaterThanZero        | .NET 9.0  | .NET 9.0  | 100000 | 223,056.642 ns |   237.4468 ns |   210.4904 ns | 118,975.42 |   187.36 |        - |        - |        - |      48 B |          NA |
| Any                             | .NET 9.0  | .NET 9.0  | 100000 |       1.875 ns |     0.0030 ns |     0.0025 ns |       1.00 |     0.00 |        - |        - |        - |         - |          NA |
