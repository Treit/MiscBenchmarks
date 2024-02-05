# Test the claim that converting an ICollection to an array yields better enumeration performance.


```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26052.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                         | Count  | Mean          | Error         | StdDev        | Ratio | RatioSD | Gen0    | Gen1    | Gen2    | Allocated | Alloc Ratio |
|------------------------------- |------- |--------------:|--------------:|--------------:|------:|--------:|--------:|--------:|--------:|----------:|------------:|
| **IterateUsingNormalForEachLoop**  | **10**     |      **11.33 ns** |      **0.260 ns** |      **0.278 ns** |  **1.00** |    **0.00** |       **-** |       **-** |       **-** |         **-** |          **NA** |
| IterateUsingNormalForLoop      | 10     |      11.64 ns |      0.244 ns |      0.228 ns |  1.03 |    0.03 |       - |       - |       - |         - |          NA |
| IterateUsingAsArrayForLoop     | 10     |      32.32 ns |      0.662 ns |      0.708 ns |  2.85 |    0.10 |  0.0241 |       - |       - |     104 B |          NA |
| IterateUsingAsArrayForEachLoop | 10     |      30.60 ns |      0.464 ns |      0.412 ns |  2.71 |    0.08 |  0.0241 |       - |       - |     104 B |          NA |
|                                |        |               |               |               |       |         |         |         |         |           |             |
| **IterateUsingNormalForEachLoop**  | **100000** | **377,455.36 ns** |  **7,405.602 ns** | **10,855.035 ns** |  **1.00** |    **0.00** |       **-** |       **-** |       **-** |         **-** |          **NA** |
| IterateUsingNormalForLoop      | 100000 | 387,424.17 ns |  7,680.880 ns | 10,253.754 ns |  1.02 |    0.04 |       - |       - |       - |         - |          NA |
| IterateUsingAsArrayForLoop     | 100000 | 619,061.90 ns | 11,678.030 ns | 11,992.477 ns |  1.63 |    0.06 | 79.1016 | 79.1016 | 79.1016 |  800054 B |          NA |
| IterateUsingAsArrayForEachLoop | 100000 | 608,716.38 ns |  8,379.425 ns |  7,428.142 ns |  1.60 |    0.05 | 78.1250 | 78.1250 | 78.1250 |  800045 B |          NA |
