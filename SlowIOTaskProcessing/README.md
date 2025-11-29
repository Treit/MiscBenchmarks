# Executing tasks simulating a slow 500 millisecond I/O task.





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                   | Job       | Runtime   | Count | Mean       | Error     | StdDev      | Median     | Ratio | RatioSD | Allocated | Alloc Ratio |
|------------------------- |---------- |---------- |------ |-----------:|----------:|------------:|-----------:|------:|--------:|----------:|------------:|
| **TaskRun**                  | **.NET 10.0** | **.NET 10.0** | **10**    |   **507.9 ms** |   **7.74 ms** |     **7.24 ms** |   **504.1 ms** |  **1.00** |    **0.02** |   **1.78 KB** |        **1.00** |
| AsyncTask                | .NET 10.0 | .NET 10.0 | 10    |   499.9 ms |   3.33 ms |     3.12 ms |   500.8 ms |  0.98 |    0.01 |   3.15 KB |        1.77 |
| TaskRunSetMinThreads100  | .NET 10.0 | .NET 10.0 | 10    |   505.8 ms |   7.27 ms |     6.80 ms |   501.4 ms |  1.00 |    0.02 |   1.78 KB |        1.00 |
| TaskRunSetMinThreads1000 | .NET 10.0 | .NET 10.0 | 10    |   510.9 ms |   7.13 ms |     6.67 ms |   515.4 ms |  1.01 |    0.02 |   1.78 KB |        1.00 |
|                          |           |           |       |            |           |             |            |       |         |           |             |
| TaskRun                  | .NET 9.0  | .NET 9.0  | 10    |   508.7 ms |   7.49 ms |     7.00 ms |   512.2 ms |  1.00 |    0.02 |   1.78 KB |        1.00 |
| AsyncTask                | .NET 9.0  | .NET 9.0  | 10    |   499.9 ms |   3.09 ms |     2.89 ms |   500.9 ms |  0.98 |    0.01 |   3.15 KB |        1.77 |
| TaskRunSetMinThreads100  | .NET 9.0  | .NET 9.0  | 10    |   508.4 ms |   7.40 ms |     6.92 ms |   505.2 ms |  1.00 |    0.02 |   1.78 KB |        1.00 |
| TaskRunSetMinThreads1000 | .NET 9.0  | .NET 9.0  | 10    |   506.9 ms |   7.55 ms |     7.06 ms |   502.1 ms |  1.00 |    0.02 |   1.78 KB |        1.00 |
|                          |           |           |       |            |           |             |            |       |         |           |             |
| **TaskRun**                  | **.NET 10.0** | **.NET 10.0** | **250**   | **2,238.6 ms** | **354.96 ms** | **1,012.73 ms** | **2,013.2 ms** |  **1.18** |    **0.73** |  **41.16 KB** |        **1.00** |
| AsyncTask                | .NET 10.0 | .NET 10.0 | 250   |   500.0 ms |   3.70 ms |     3.28 ms |   500.9 ms |  0.26 |    0.10 |  73.34 KB |        1.78 |
| TaskRunSetMinThreads100  | .NET 10.0 | .NET 10.0 | 250   | 1,519.0 ms |   1.53 ms |     1.43 ms | 1,519.3 ms |  0.80 |    0.31 |  41.16 KB |        1.00 |
| TaskRunSetMinThreads1000 | .NET 10.0 | .NET 10.0 | 250   |   512.9 ms |   1.06 ms |     0.99 ms |   513.1 ms |  0.27 |    0.10 |  41.16 KB |        1.00 |
|                          |           |           |       |            |           |             |            |       |         |           |             |
| TaskRun                  | .NET 9.0  | .NET 9.0  | 250   | 1,942.9 ms | 230.43 ms |   646.14 ms | 1,521.7 ms |  1.08 |    0.45 |  41.16 KB |        1.00 |
| AsyncTask                | .NET 9.0  | .NET 9.0  | 250   |   500.7 ms |   1.58 ms |     1.48 ms |   500.5 ms |  0.28 |    0.07 |  72.52 KB |        1.76 |
| TaskRunSetMinThreads100  | .NET 9.0  | .NET 9.0  | 250   | 1,519.3 ms |   4.29 ms |     4.01 ms | 1,520.3 ms |  0.85 |    0.20 |   53.2 KB |        1.29 |
| TaskRunSetMinThreads1000 | .NET 9.0  | .NET 9.0  | 250   |   512.9 ms |   1.09 ms |     1.02 ms |   513.1 ms |  0.29 |    0.07 |  41.16 KB |        1.00 |
|                          |           |           |       |            |           |             |            |       |         |           |             |
| **TaskRun**                  | **.NET 10.0** | **.NET 10.0** | **1000**  | **3,229.8 ms** | **390.50 ms** | **1,082.07 ms** | **2,526.1 ms** |  **1.08** |    **0.45** |  **164.2 KB** |        **1.00** |
| AsyncTask                | .NET 10.0 | .NET 10.0 | 1000  |   500.2 ms |   1.16 ms |     1.03 ms |   500.5 ms |  0.17 |    0.04 | 289.32 KB |        1.76 |
| TaskRunSetMinThreads100  | .NET 10.0 | .NET 10.0 | 1000  | 3,743.6 ms | 133.69 ms |   370.46 ms | 3,533.7 ms |  1.26 |    0.33 |  164.2 KB |        1.00 |
| TaskRunSetMinThreads1000 | .NET 10.0 | .NET 10.0 | 1000  |   521.1 ms |   1.30 ms |     1.09 ms |   521.5 ms |  0.17 |    0.04 |  164.2 KB |        1.00 |
|                          |           |           |       |            |           |             |            |       |         |           |             |
| TaskRun                  | .NET 9.0  | .NET 9.0  | 1000  | 3,466.1 ms | 250.13 ms |   684.72 ms | 3,522.9 ms |  1.03 |    0.28 |  164.2 KB |        1.00 |
| AsyncTask                | .NET 9.0  | .NET 9.0  | 1000  |   500.0 ms |   1.49 ms |     1.32 ms |   500.4 ms |  0.15 |    0.03 | 289.32 KB |        1.76 |
| TaskRunSetMinThreads100  | .NET 9.0  | .NET 9.0  | 1000  | 5,038.7 ms |   4.79 ms |     4.00 ms | 5,038.0 ms |  1.50 |    0.27 |  164.2 KB |        1.00 |
| TaskRunSetMinThreads1000 | .NET 9.0  | .NET 9.0  | 1000  |   521.3 ms |   1.21 ms |     1.08 ms |   521.3 ms |  0.16 |    0.03 |  164.2 KB |        1.00 |
