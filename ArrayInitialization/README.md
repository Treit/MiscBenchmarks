# Initializing Multidimensional vs. Jagged arrays.


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                           Method | Size |         Mean |      Error |     StdDev |
|--------------------------------- |----- |-------------:|-----------:|-----------:|
|           **InitJaggedRandomValues** |  **100** |    **41.775 μs** |  **0.8302 μs** |  **2.0520 μs** |
| InitMultidimensionalRandomValues |  100 |    48.587 μs |  0.6195 μs |  0.7134 μs |
|             InitJaggedFixedValue |  100 |     8.415 μs |  0.1683 μs |  0.2467 μs |
|   InitMultidimensionalFixedValue |  100 |    26.939 μs |  0.5388 μs |  1.5371 μs |
|           **InitJaggedRandomValues** | **1024** | **8,583.438 μs** | **40.8345 μs** | **31.8809 μs** |
| InitMultidimensionalRandomValues | 1024 | 9,302.991 μs | 86.9615 μs | 77.0891 μs |
|             InitJaggedFixedValue | 1024 |   775.637 μs |  5.3668 μs |  5.0201 μs |
|   InitMultidimensionalFixedValue | 1024 | 2,589.272 μs |  4.9434 μs |  4.1280 μs |
