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
| **ConcurrentReadsUsingParallelFor**   | **10**    |   **2.082 μs** | **0.0407 μs** | **0.0724 μs** | **0.1373** |      **-** |   **2.24 KB** |
| ConcurrentReadsUsingExplicitTasks | 10    |   3.889 μs | 0.0871 μs | 0.2384 μs | 0.1144 |      - |   1.88 KB |
| **ConcurrentReadsUsingParallelFor**   | **1000**  | **221.078 μs** | **4.3909 μs** | **8.0290 μs** |      **-** |      **-** |   **3.93 KB** |
| ConcurrentReadsUsingExplicitTasks | 1000  | 217.731 μs | 4.1217 μs | 4.2326 μs | 9.7656 | 2.4414 | 164.36 KB |
