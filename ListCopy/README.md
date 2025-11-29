# Copying lists





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                  | Job       | Runtime   | Count   | Mean           | Error        | StdDev       | Ratio | RatioSD |
|------------------------ |---------- |---------- |-------- |---------------:|-------------:|-------------:|------:|--------:|
| **CopyWithListConstructor** | **.NET 10.0** | **.NET 10.0** | **1000**    |       **169.9 ns** |      **3.41 ns** |      **5.40 ns** |  **1.00** |    **0.05** |
| CopyWithToList          | .NET 10.0 | .NET 10.0 | 1000    |       169.3 ns |      3.33 ns |      3.12 ns |  1.00 |    0.04 |
| CopyExplicitly          | .NET 10.0 | .NET 10.0 | 1000    |     1,560.6 ns |     14.09 ns |     12.49 ns |  9.19 |    0.31 |
|                         |           |           |         |                |              |              |       |         |
| CopyWithListConstructor | .NET 9.0  | .NET 9.0  | 1000    |       167.8 ns |      3.36 ns |      5.97 ns |  1.00 |    0.05 |
| CopyWithToList          | .NET 9.0  | .NET 9.0  | 1000    |       169.4 ns |      3.36 ns |      5.03 ns |  1.01 |    0.05 |
| CopyExplicitly          | .NET 9.0  | .NET 9.0  | 1000    |     1,556.1 ns |     15.51 ns |     13.75 ns |  9.29 |    0.34 |
|                         |           |           |         |                |              |              |       |         |
| **CopyWithListConstructor** | **.NET 10.0** | **.NET 10.0** | **100000**  |   **139,432.4 ns** |  **2,416.65 ns** |  **2,260.54 ns** |  **1.00** |    **0.02** |
| CopyWithToList          | .NET 10.0 | .NET 10.0 | 100000  |   138,904.7 ns |  1,787.54 ns |  1,672.07 ns |  1.00 |    0.02 |
| CopyExplicitly          | .NET 10.0 | .NET 10.0 | 100000  |   266,359.1 ns |  2,735.90 ns |  2,559.16 ns |  1.91 |    0.03 |
|                         |           |           |         |                |              |              |       |         |
| CopyWithListConstructor | .NET 9.0  | .NET 9.0  | 100000  |   139,082.6 ns |  1,666.08 ns |  1,558.45 ns |  1.00 |    0.02 |
| CopyWithToList          | .NET 9.0  | .NET 9.0  | 100000  |   139,634.8 ns |  2,774.61 ns |  2,725.04 ns |  1.00 |    0.02 |
| CopyExplicitly          | .NET 9.0  | .NET 9.0  | 100000  |   267,355.5 ns |  3,496.17 ns |  3,270.32 ns |  1.92 |    0.03 |
|                         |           |           |         |                |              |              |       |         |
| **CopyWithListConstructor** | **.NET 10.0** | **.NET 10.0** | **1000000** |   **920,846.2 ns** |  **9,565.00 ns** |  **8,479.12 ns** |  **1.00** |    **0.01** |
| CopyWithToList          | .NET 10.0 | .NET 10.0 | 1000000 |   924,993.5 ns |  8,734.34 ns |  8,170.11 ns |  1.00 |    0.01 |
| CopyExplicitly          | .NET 10.0 | .NET 10.0 | 1000000 | 2,128,501.9 ns | 30,205.44 ns | 28,254.19 ns |  2.31 |    0.04 |
|                         |           |           |         |                |              |              |       |         |
| CopyWithListConstructor | .NET 9.0  | .NET 9.0  | 1000000 |   925,066.2 ns | 13,413.75 ns | 12,547.23 ns |  1.00 |    0.02 |
| CopyWithToList          | .NET 9.0  | .NET 9.0  | 1000000 |   918,728.5 ns | 10,077.81 ns |  9,426.79 ns |  0.99 |    0.02 |
| CopyExplicitly          | .NET 9.0  | .NET 9.0  | 1000000 | 2,117,486.8 ns | 32,203.13 ns | 28,547.23 ns |  2.29 |    0.04 |
