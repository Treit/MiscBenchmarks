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
| BinarySearchWithDivide        | 1000000 | 29.43 ns | 0.645 ns | 0.816 ns | 28.91 ns |  0.93 |    0.04 |         - |          NA |
| BinarySearchWithShift         | 1000000 | 31.63 ns | 0.648 ns | 0.575 ns | 31.50 ns |  1.00 |    0.00 |         - |          NA |
| BinarySearchBCLImplementation | 1000000 | 44.12 ns | 0.266 ns | 0.236 ns | 44.13 ns |  1.40 |    0.02 |         - |          NA |
