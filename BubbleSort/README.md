# Bubble sort

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.25140
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=7.0.100-preview.5.22307.18
  [Host]     : .NET Core 6.0.6 (CoreCLR 6.0.622.26707, CoreFX 6.0.622.26707), X64 RyuJIT
  DefaultJob : .NET Core 6.0.6 (CoreCLR 6.0.622.26707, CoreFX 6.0.622.26707), X64 RyuJIT


```
|                      Method | Count |       Mean |    Error |   StdDev |
|---------------------------- |------ |-----------:|---------:|---------:|
| BubbleSortUsingTempVariable |  1000 |   659.4 μs |  3.32 μs |  2.95 μs |
| BubbleSortUsingSwapFunction |  1000 |   636.1 μs | 10.68 μs |  9.99 μs |
|  BubbleSortUsingTupleToSwap |  1000 | 1,151.1 μs | 22.02 μs | 20.59 μs |
