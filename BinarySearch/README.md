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
| BinarySearchWithDivide        | 1000000 | 32.87 ns | 0.240 ns | 0.224 ns |  1.50 |    0.02 |         - |          NA |
| BinarySearchWithShift         | 1000000 | 21.91 ns | 0.250 ns | 0.195 ns |  1.00 |    0.01 |         - |          NA |
| BinarySearchBCLImplementation | 1000000 | 36.89 ns | 0.256 ns | 0.239 ns |  1.68 |    0.02 |         - |          NA |
| BinarySearchGenericBCLImpl    | 1000000 | 25.15 ns | 0.142 ns | 0.133 ns |  1.15 |    0.01 |         - |          NA |
