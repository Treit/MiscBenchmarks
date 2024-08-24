# Binary search integer array



```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27691.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-preview.6.24328.19
  [Host]     : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                        | Count   | Mean     | Error    | StdDev   | Median   | Ratio | RatioSD | Allocated | Alloc Ratio |
|------------------------------ |-------- |---------:|---------:|---------:|---------:|------:|--------:|----------:|------------:|
| BinarySearchWithDivide        | 1000000 | 31.94 ns | 0.666 ns | 1.608 ns | 31.39 ns |  1.05 |    0.05 |         - |          NA |
| BinarySearchWithShift         | 1000000 | 31.27 ns | 0.654 ns | 0.873 ns | 30.94 ns |  1.00 |    0.00 |         - |          NA |
| BinarySearchBCLImplementation | 1000000 | 44.20 ns | 0.448 ns | 0.374 ns | 44.16 ns |  1.41 |    0.04 |         - |          NA |
| BinarySearchGenericBCLImpl    | 1000000 | 46.53 ns | 1.284 ns | 3.559 ns | 45.43 ns |  1.55 |    0.13 |         - |          NA |
