# Executing tasks simulating a slow 500 millisecond I/O task.


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                   Method | Count |       Mean |     Error |    StdDev |     Median | Ratio | RatioSD | Allocated | Alloc Ratio |
|------------------------- |------ |-----------:|----------:|----------:|-----------:|------:|--------:|----------:|------------:|
|                  **TaskRun** |    **10** |   **512.4 ms** |   **3.40 ms** |   **3.18 ms** |   **512.5 ms** |  **1.00** |    **0.00** |         **-** |          **NA** |
|                AsyncTask |    10 |   505.6 ms |   1.79 ms |   1.67 ms |   505.3 ms |  0.99 |    0.01 |         - |          NA |
|  TaskRunSetMinThreads100 |    10 |   506.4 ms |   1.29 ms |   1.01 ms |   506.1 ms |  0.99 |    0.01 |         - |          NA |
| TaskRunSetMinThreads1000 |    10 |   505.5 ms |   2.42 ms |   2.15 ms |   506.2 ms |  0.99 |    0.01 |         - |          NA |
|                          |       |            |           |           |            |       |         |           |             |
|                  **TaskRun** |   **250** | **1,673.0 ms** | **147.80 ms** | **394.51 ms** | **1,521.4 ms** |  **1.00** |    **0.00** |   **43456 B** |        **1.00** |
|                AsyncTask |   250 |   506.2 ms |   2.58 ms |   2.28 ms |   506.9 ms |  0.22 |    0.03 |   74960 B |        1.72 |
|  TaskRunSetMinThreads100 |   250 | 1,519.1 ms |   2.67 ms |   2.37 ms | 1,519.1 ms |  0.67 |    0.08 |   42832 B |        0.99 |
| TaskRunSetMinThreads1000 |   250 |   513.4 ms |   5.28 ms |   4.93 ms |   515.5 ms |  0.23 |    0.03 |   43456 B |        1.00 |
|                          |       |            |           |           |            |       |         |           |             |
|                  **TaskRun** |  **1000** | **3,439.4 ms** | **334.86 ms** | **987.34 ms** | **3,043.9 ms** |  **1.00** |    **0.00** |  **168832 B** |        **1.00** |
|                AsyncTask |  1000 |   504.8 ms |   2.32 ms |   2.06 ms |   504.6 ms |  0.10 |    0.01 |  296936 B |        1.76 |
|  TaskRunSetMinThreads100 |  1000 | 3,174.5 ms | 246.60 ms | 727.10 ms | 3,037.4 ms |  0.94 |    0.08 |  168832 B |        1.00 |
| TaskRunSetMinThreads1000 |  1000 |   524.5 ms |   1.67 ms |   1.56 ms |   524.3 ms |  0.10 |    0.01 |  169456 B |        1.00 |
