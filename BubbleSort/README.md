# Bubble sort


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                      Method | Count |     Mean |   Error |  StdDev |
|---------------------------- |------ |---------:|--------:|--------:|
| BubbleSortUsingTempVariable |  1000 | 596.6 μs | 2.31 μs | 1.93 μs |
| BubbleSortUsingSwapFunction |  1000 | 523.2 μs | 0.68 μs | 0.60 μs |
|  BubbleSortUsingTupleToSwap |  1000 | 523.6 μs | 1.19 μs | 1.06 μs |
