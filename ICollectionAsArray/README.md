# Test the claim that converting an ICollection to an array yields better enumeration performance.




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                         | Count  | Mean           | Error         | StdDev        | Median         | Ratio | RatioSD | Gen0    | Gen1    | Gen2    | Allocated | Alloc Ratio |
|------------------------------- |------- |---------------:|--------------:|--------------:|---------------:|------:|--------:|--------:|--------:|--------:|----------:|------------:|
| **IterateUsingNormalForEachLoop**  | **10**     |       **8.637 ns** |     **0.0459 ns** |     **0.0359 ns** |       **8.635 ns** |  **1.00** |    **0.01** |       **-** |       **-** |       **-** |         **-** |          **NA** |
| IterateUsingNormalForLoop      | 10     |       8.431 ns |     0.1611 ns |     0.1507 ns |       8.388 ns |  0.98 |    0.02 |       - |       - |       - |         - |          NA |
| IterateUsingAsArrayForLoop     | 10     |      23.230 ns |     0.4925 ns |     1.0707 ns |      23.339 ns |  2.69 |    0.12 |  0.0062 |       - |       - |     104 B |          NA |
| IterateUsingAsArrayForEachLoop | 10     |      23.232 ns |     0.4909 ns |     1.0568 ns |      23.100 ns |  2.69 |    0.12 |  0.0062 |       - |       - |     104 B |          NA |
|                                |        |                |               |               |                |       |         |         |         |         |           |             |
| **IterateUsingNormalForEachLoop**  | **100000** | **142,693.240 ns** | **2,823.7764 ns** | **7,238.4189 ns** | **145,586.597 ns** |  **1.00** |    **0.08** |       **-** |       **-** |       **-** |         **-** |          **NA** |
| IterateUsingNormalForLoop      | 100000 | 140,921.331 ns | 3,133.3014 ns | 8,939.4860 ns | 144,447.998 ns |  0.99 |    0.08 |       - |       - |       - |         - |          NA |
| IterateUsingAsArrayForLoop     | 100000 | 281,756.615 ns | 3,395.9380 ns | 3,176.5626 ns | 281,874.561 ns |  1.98 |    0.11 | 66.8945 | 66.8945 | 66.8945 |  800040 B |          NA |
| IterateUsingAsArrayForEachLoop | 100000 | 280,435.861 ns | 2,463.8986 ns | 2,184.1820 ns | 280,474.512 ns |  1.97 |    0.11 | 65.9180 | 65.9180 | 65.9180 |  800039 B |          NA |
