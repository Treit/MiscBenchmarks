# Binary search integer array




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                        | Count   | Mean     | Error    | StdDev   | Ratio | RatioSD | Allocated | Alloc Ratio |
|------------------------------ |-------- |---------:|---------:|---------:|------:|--------:|----------:|------------:|
| BinarySearchWithDivide        | 1000000 | 32.87 ns | 0.188 ns | 0.176 ns |  1.61 |    0.01 |         - |          NA |
| BinarySearchWithShift         | 1000000 | 20.40 ns | 0.100 ns | 0.089 ns |  1.00 |    0.01 |         - |          NA |
| BinarySearchBCLImplementation | 1000000 | 33.06 ns | 0.689 ns | 1.170 ns |  1.62 |    0.06 |         - |          NA |
| BinarySearchGenericBCLImpl    | 1000000 | 25.36 ns | 0.178 ns | 0.167 ns |  1.24 |    0.01 |         - |          NA |
