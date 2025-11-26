# Bubble sort




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                      | Count | Mean     | Error   | StdDev  |
|---------------------------- |------ |---------:|--------:|--------:|
| BubbleSortUsingTempVariable | 1000  | 524.9 μs | 3.69 μs | 3.46 μs |
| BubbleSortUsingSwapFunction | 1000  | 524.6 μs | 4.34 μs | 4.06 μs |
| BubbleSortUsingTupleToSwap  | 1000  | 526.3 μs | 4.57 μs | 4.27 μs |
