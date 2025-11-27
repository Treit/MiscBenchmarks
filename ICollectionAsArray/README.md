# Test the claim that converting an ICollection to an array yields better enumeration performance.





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                         | Job       | Runtime   | Count  | Mean           | Error         | StdDev         | Median         | Ratio | RatioSD | Gen0    | Gen1    | Gen2    | Allocated | Alloc Ratio |
|------------------------------- |---------- |---------- |------- |---------------:|--------------:|---------------:|---------------:|------:|--------:|--------:|--------:|--------:|----------:|------------:|
| **IterateUsingNormalForEachLoop**  | **.NET 10.0** | **.NET 10.0** | **10**     |       **8.737 ns** |     **0.0649 ns** |      **0.0575 ns** |       **8.750 ns** |  **1.00** |    **0.01** |       **-** |       **-** |       **-** |         **-** |          **NA** |
| IterateUsingNormalForLoop      | .NET 10.0 | .NET 10.0 | 10     |       8.485 ns |     0.1969 ns |      0.2107 ns |       8.457 ns |  0.97 |    0.02 |       - |       - |       - |         - |          NA |
| IterateUsingAsArrayForLoop     | .NET 10.0 | .NET 10.0 | 10     |      25.411 ns |     0.5397 ns |      1.3540 ns |      25.548 ns |  2.91 |    0.16 |  0.0062 |       - |       - |     104 B |          NA |
| IterateUsingAsArrayForEachLoop | .NET 10.0 | .NET 10.0 | 10     |      24.573 ns |     0.5226 ns |      1.2820 ns |      24.655 ns |  2.81 |    0.15 |  0.0062 |       - |       - |     104 B |          NA |
|                                |           |           |        |                |               |                |                |       |         |         |         |         |           |             |
| IterateUsingNormalForEachLoop  | .NET 9.0  | .NET 9.0  | 10     |       8.688 ns |     0.0689 ns |      0.0645 ns |       8.708 ns |  1.00 |    0.01 |       - |       - |       - |         - |          NA |
| IterateUsingNormalForLoop      | .NET 9.0  | .NET 9.0  | 10     |       8.361 ns |     0.1899 ns |      0.2031 ns |       8.464 ns |  0.96 |    0.02 |       - |       - |       - |         - |          NA |
| IterateUsingAsArrayForLoop     | .NET 9.0  | .NET 9.0  | 10     |      22.884 ns |     0.4883 ns |      1.2779 ns |      22.761 ns |  2.63 |    0.15 |  0.0062 |       - |       - |     104 B |          NA |
| IterateUsingAsArrayForEachLoop | .NET 9.0  | .NET 9.0  | 10     |      23.125 ns |     0.4937 ns |      1.4479 ns |      23.161 ns |  2.66 |    0.17 |  0.0062 |       - |       - |     104 B |          NA |
|                                |           |           |        |                |               |                |                |       |         |         |         |         |           |             |
| **IterateUsingNormalForEachLoop**  | **.NET 10.0** | **.NET 10.0** | **100000** | **133,502.427 ns** | **3,719.3440 ns** | **10,966.5706 ns** | **126,622.144 ns** |  **1.01** |    **0.12** |       **-** |       **-** |       **-** |         **-** |          **NA** |
| IterateUsingNormalForLoop      | .NET 10.0 | .NET 10.0 | 100000 | 132,994.294 ns | 3,985.4031 ns | 11,751.0518 ns | 138,782.739 ns |  1.00 |    0.12 |       - |       - |       - |         - |          NA |
| IterateUsingAsArrayForLoop     | .NET 10.0 | .NET 10.0 | 100000 | 275,313.402 ns | 7,319.7410 ns | 21,582.4230 ns | 275,257.056 ns |  2.08 |    0.23 | 57.1289 | 57.1289 | 57.1289 |  800034 B |          NA |
| IterateUsingAsArrayForEachLoop | .NET 10.0 | .NET 10.0 | 100000 | 272,570.617 ns | 5,929.7673 ns | 17,390.9822 ns | 270,071.875 ns |  2.06 |    0.21 | 57.6172 | 57.6172 | 57.6172 |  800035 B |          NA |
|                                |           |           |        |                |               |                |                |       |         |         |         |         |           |             |
| IterateUsingNormalForEachLoop  | .NET 9.0  | .NET 9.0  | 100000 | 129,721.209 ns | 4,096.4153 ns | 12,078.3738 ns | 130,516.016 ns |  1.01 |    0.13 |       - |       - |       - |         - |          NA |
| IterateUsingNormalForLoop      | .NET 9.0  | .NET 9.0  | 100000 | 148,305.860 ns | 3,706.3983 ns | 10,928.3997 ns | 154,844.543 ns |  1.15 |    0.14 |       - |       - |       - |         - |          NA |
| IterateUsingAsArrayForLoop     | .NET 9.0  | .NET 9.0  | 100000 | 255,857.278 ns | 4,903.1784 ns |  5,646.5075 ns | 257,582.312 ns |  1.99 |    0.19 | 64.2090 | 64.2090 | 64.2090 |  800039 B |          NA |
| IterateUsingAsArrayForEachLoop | .NET 9.0  | .NET 9.0  | 100000 | 270,992.030 ns | 6,882.9830 ns | 20,294.6321 ns | 267,947.510 ns |  2.11 |    0.25 | 56.1523 | 56.1523 | 56.1523 |  800034 B |          NA |
