# Concurrently reading dictionary entries



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                            | Count | Mean       | Error     | StdDev    | Gen0   | Gen1   | Allocated |
|---------------------------------- |------ |-----------:|----------:|----------:|-------:|-------:|----------:|
| **ConcurrentReadsUsingParallelFor**   | **10**    |   **1.890 μs** | **0.0373 μs** | **0.0591 μs** | **0.1297** |      **-** |   **2.23 KB** |
| ConcurrentReadsUsingExplicitTasks | 10    |   2.881 μs | 0.0559 μs | 0.0467 μs | 0.1144 |      - |   1.88 KB |
| **ConcurrentReadsUsingParallelFor**   | **1000**  | **243.449 μs** | **4.6683 μs** | **4.5849 μs** |      **-** |      **-** |   **4.25 KB** |
| ConcurrentReadsUsingExplicitTasks | 1000  | 252.848 μs | 1.4487 μs | 1.2842 μs | 9.7656 | 2.4414 | 164.36 KB |
