# Bubble sort





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                      | Job       | Runtime   | Count | Mean     | Error   | StdDev  |
|---------------------------- |---------- |---------- |------ |---------:|--------:|--------:|
| BubbleSortUsingTempVariable | .NET 10.0 | .NET 10.0 | 1000  | 526.5 μs | 6.02 μs | 5.33 μs |
| BubbleSortUsingSwapFunction | .NET 10.0 | .NET 10.0 | 1000  | 524.9 μs | 4.81 μs | 4.50 μs |
| BubbleSortUsingTupleToSwap  | .NET 10.0 | .NET 10.0 | 1000  | 526.7 μs | 5.74 μs | 5.37 μs |
| BubbleSortUsingTempVariable | .NET 9.0  | .NET 9.0  | 1000  | 527.0 μs | 6.02 μs | 5.63 μs |
| BubbleSortUsingSwapFunction | .NET 9.0  | .NET 9.0  | 1000  | 525.8 μs | 4.33 μs | 4.05 μs |
| BubbleSortUsingTupleToSwap  | .NET 9.0  | .NET 9.0  | 1000  | 525.8 μs | 5.24 μs | 4.64 μs |
