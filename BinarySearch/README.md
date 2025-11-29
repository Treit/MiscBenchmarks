# Binary search integer array






```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                        | Job       | Runtime   | Count   | Mean     | Error    | StdDev   | Ratio | RatioSD | Allocated | Alloc Ratio |
|------------------------------ |---------- |---------- |-------- |---------:|---------:|---------:|------:|--------:|----------:|------------:|
| BinarySearchWithDivide        | .NET 10.0 | .NET 10.0 | 1000000 | 33.19 ns | 0.351 ns | 0.329 ns |  1.52 |    0.02 |         - |          NA |
| BinarySearchWithShift         | .NET 10.0 | .NET 10.0 | 1000000 | 21.84 ns | 0.122 ns | 0.114 ns |  1.00 |    0.01 |         - |          NA |
| BinarySearchBCLImplementation | .NET 10.0 | .NET 10.0 | 1000000 | 36.34 ns | 0.617 ns | 0.577 ns |  1.66 |    0.03 |         - |          NA |
| BinarySearchGenericBCLImpl    | .NET 10.0 | .NET 10.0 | 1000000 | 24.91 ns | 0.288 ns | 0.270 ns |  1.14 |    0.01 |         - |          NA |
|                               |           |           |         |          |          |          |       |         |           |             |
| BinarySearchWithDivide        | .NET 9.0  | .NET 9.0  | 1000000 | 33.41 ns | 0.674 ns | 0.692 ns |  1.51 |    0.04 |         - |          NA |
| BinarySearchWithShift         | .NET 9.0  | .NET 9.0  | 1000000 | 22.11 ns | 0.446 ns | 0.348 ns |  1.00 |    0.02 |         - |          NA |
| BinarySearchBCLImplementation | .NET 9.0  | .NET 9.0  | 1000000 | 33.27 ns | 0.675 ns | 0.854 ns |  1.51 |    0.04 |         - |          NA |
| BinarySearchGenericBCLImpl    | .NET 9.0  | .NET 9.0  | 1000000 | 25.68 ns | 0.197 ns | 0.174 ns |  1.16 |    0.02 |         - |          NA |
