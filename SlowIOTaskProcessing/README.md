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
| **TaskRun**                  | **10**    |   **507.7 ms** |   **7.13 ms** |     **6.67 ms** |   **502.6 ms** |  **1.00** |    **0.02** |   **1.78 KB** |        **1.00** |
| AsyncTask                | 10    |   501.3 ms |   3.09 ms |     2.89 ms |   502.4 ms |  0.99 |    0.01 |   3.15 KB |        1.77 |
| TaskRunSetMinThreads100  | 10    |   502.2 ms |   0.42 ms |     0.32 ms |   502.2 ms |  0.99 |    0.01 |   1.78 KB |        1.00 |
| TaskRunSetMinThreads1000 | 10    |   502.1 ms |   0.72 ms |     0.56 ms |   502.1 ms |  0.99 |    0.01 |   1.78 KB |        1.00 |
|                          |       |            |           |             |            |       |         |           |             |
| **TaskRun**                  | **250**   | **2,147.6 ms** | **327.93 ms** |   **930.29 ms** | **1,523.9 ms** |  **1.14** |    **0.62** |  **41.16 KB** |        **1.00** |
| AsyncTask                | 250   |   500.9 ms |   3.15 ms |     2.95 ms |   501.8 ms |  0.27 |    0.08 |  72.52 KB |        1.76 |
| TaskRunSetMinThreads100  | 250   | 1,522.1 ms |   1.44 ms |     1.34 ms | 1,522.3 ms |  0.81 |    0.24 |  41.16 KB |        1.00 |
| TaskRunSetMinThreads1000 | 250   |   513.3 ms |   1.67 ms |     1.39 ms |   513.6 ms |  0.27 |    0.08 |  41.16 KB |        1.00 |
|                          |       |            |           |             |            |       |         |           |             |
| **TaskRun**                  | **1000**  | **3,341.7 ms** | **407.99 ms** | **1,130.54 ms** | **3,030.2 ms** |  **1.08** |    **0.46** | **167.07 KB** |        **1.00** |
| AsyncTask                | 1000  |   501.2 ms |   1.41 ms |     1.25 ms |   501.3 ms |  0.16 |    0.04 | 289.32 KB |        1.73 |
| TaskRunSetMinThreads100  | 1000  | 3,247.9 ms | 313.77 ms |   925.15 ms | 2,531.0 ms |  1.05 |    0.40 |  164.2 KB |        0.98 |
| TaskRunSetMinThreads1000 | 1000  |   521.6 ms |   1.20 ms |     1.13 ms |   522.1 ms |  0.17 |    0.04 |  164.2 KB |        0.98 |
