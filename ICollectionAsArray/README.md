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
| **IterateUsingNormalForEachLoop**  | **10**     |       **8.597 ns** |     **0.0725 ns** |     **0.0606 ns** |       **8.619 ns** |  **1.00** |    **0.01** |       **-** |       **-** |       **-** |         **-** |          **NA** |
| IterateUsingNormalForLoop      | 10     |       8.368 ns |     0.1785 ns |     0.1670 ns |       8.393 ns |  0.97 |    0.02 |       - |       - |       - |         - |          NA |
| IterateUsingAsArrayForLoop     | 10     |      21.920 ns |     0.4668 ns |     0.8995 ns |      21.918 ns |  2.55 |    0.11 |  0.0062 |       - |       - |     104 B |          NA |
| IterateUsingAsArrayForEachLoop | 10     |      22.574 ns |     0.4767 ns |     0.9298 ns |      22.636 ns |  2.63 |    0.11 |  0.0062 |       - |       - |     104 B |          NA |
|                                |        |                |               |               |                |       |         |         |         |         |           |             |
| **IterateUsingNormalForEachLoop**  | **100000** | **143,650.622 ns** | **1,242.7590 ns** | **1,162.4775 ns** | **144,178.491 ns** |  **1.00** |    **0.01** |       **-** |       **-** |       **-** |         **-** |          **NA** |
| IterateUsingNormalForLoop      | 100000 | 139,882.154 ns | 2,792.9250 ns | 8,147.0940 ns | 142,428.430 ns |  0.97 |    0.06 |       - |       - |       - |         - |          NA |
| IterateUsingAsArrayForLoop     | 100000 | 279,272.781 ns | 5,496.2221 ns | 6,749.8550 ns | 278,581.372 ns |  1.94 |    0.05 | 65.9180 | 65.9180 | 65.9180 |  800039 B |          NA |
| IterateUsingAsArrayForEachLoop | 100000 | 282,539.191 ns | 4,877.4769 ns | 4,562.3949 ns | 282,288.159 ns |  1.97 |    0.03 | 66.8945 | 66.8945 | 66.8945 |  800040 B |          NA |
