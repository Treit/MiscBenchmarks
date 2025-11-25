# Executing tasks simulating a slow 500 millisecond I/O task.



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                   | Count | Mean       | Error     | StdDev      | Median     | Ratio | RatioSD | Allocated | Alloc Ratio |
|------------------------- |------ |-----------:|----------:|------------:|-----------:|------:|--------:|----------:|------------:|
| **TaskRun**                  | **10**    |   **501.9 ms** |   **0.58 ms** |     **0.48 ms** |   **502.1 ms** |  **1.00** |    **0.00** |   **1.78 KB** |        **1.00** |
| AsyncTask                | 10    |   500.6 ms |   3.74 ms |     3.32 ms |   501.7 ms |  1.00 |    0.01 |   3.15 KB |        1.77 |
| TaskRunSetMinThreads100  | 10    |   501.8 ms |   1.32 ms |     1.03 ms |   501.6 ms |  1.00 |    0.00 |   1.78 KB |        1.00 |
| TaskRunSetMinThreads1000 | 10    |   501.7 ms |   1.75 ms |     1.37 ms |   501.4 ms |  1.00 |    0.00 |   1.78 KB |        1.00 |
|                          |       |            |           |             |            |       |         |           |             |
| **TaskRun**                  | **250**   | **2,384.3 ms** | **367.77 ms** | **1,031.27 ms** | **2,024.3 ms** |  **1.15** |    **0.64** |  **41.16 KB** |        **1.00** |
| AsyncTask                | 250   |   500.2 ms |   3.50 ms |     3.28 ms |   501.3 ms |  0.24 |    0.08 |  72.52 KB |        1.76 |
| TaskRunSetMinThreads100  | 250   | 1,521.3 ms |   4.71 ms |     4.18 ms | 1,523.1 ms |  0.74 |    0.24 |  41.16 KB |        1.00 |
| TaskRunSetMinThreads1000 | 250   |   513.5 ms |   1.40 ms |     1.31 ms |   514.0 ms |  0.25 |    0.08 |  41.16 KB |        1.00 |
|                          |       |            |           |             |            |       |         |           |             |
| **TaskRun**                  | **1000**  | **4,633.9 ms** | **908.53 ms** | **2,606.74 ms** | **3,533.5 ms** |  **1.25** |    **0.89** |  **164.2 KB** |        **1.00** |
| AsyncTask                | 1000  |   501.0 ms |   1.28 ms |     1.14 ms |   501.6 ms |  0.14 |    0.05 | 289.32 KB |        1.76 |
| TaskRunSetMinThreads100  | 1000  | 5,043.6 ms |   3.78 ms |     3.54 ms | 5,044.8 ms |  1.36 |    0.52 | 166.04 KB |        1.01 |
| TaskRunSetMinThreads1000 | 1000  |   521.4 ms |   1.16 ms |     0.97 ms |   521.6 ms |  0.14 |    0.05 |  164.2 KB |        1.00 |
