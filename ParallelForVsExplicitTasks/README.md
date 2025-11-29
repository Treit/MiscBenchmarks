# Concurrently reading dictionary entries





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                            | Job       | Runtime   | Count | Mean       | Error     | StdDev    | Median     | Gen0    | Gen1   | Allocated |
|---------------------------------- |---------- |---------- |------ |-----------:|----------:|----------:|-----------:|--------:|-------:|----------:|
| **ConcurrentReadsUsingParallelFor**   | **.NET 10.0** | **.NET 10.0** | **10**    |   **1.959 μs** | **0.0386 μs** | **0.0644 μs** |   **1.940 μs** |  **0.1373** |      **-** |   **2.24 KB** |
| ConcurrentReadsUsingExplicitTasks | .NET 10.0 | .NET 10.0 | 10    |   3.903 μs | 0.1736 μs | 0.5119 μs |   3.651 μs |  0.1144 |      - |   1.88 KB |
| ConcurrentReadsUsingParallelFor   | .NET 9.0  | .NET 9.0  | 10    |   1.918 μs | 0.0384 μs | 0.0620 μs |   1.901 μs |  0.1297 |      - |   2.23 KB |
| ConcurrentReadsUsingExplicitTasks | .NET 9.0  | .NET 9.0  | 10    |   3.648 μs | 0.0969 μs | 0.2734 μs |   3.614 μs |  0.1144 |      - |   1.88 KB |
| **ConcurrentReadsUsingParallelFor**   | **.NET 10.0** | **.NET 10.0** | **1000**  | **195.306 μs** | **3.8321 μs** | **4.8464 μs** | **196.605 μs** |       **-** |      **-** |   **3.92 KB** |
| ConcurrentReadsUsingExplicitTasks | .NET 10.0 | .NET 10.0 | 1000  | 207.750 μs | 4.1376 μs | 3.8703 μs | 206.635 μs |  9.7656 | 2.4414 | 164.36 KB |
| ConcurrentReadsUsingParallelFor   | .NET 9.0  | .NET 9.0  | 1000  | 190.672 μs | 3.8095 μs | 9.7653 μs | 191.597 μs |       - |      - |   3.87 KB |
| ConcurrentReadsUsingExplicitTasks | .NET 9.0  | .NET 9.0  | 1000  | 208.226 μs | 3.6145 μs | 3.3810 μs | 208.601 μs | 10.0098 | 2.9297 | 164.36 KB |
