# Loop using a variable vs index.




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method            | Count   | Mean           | Error         | StdDev        | Ratio | RatioSD |
|------------------ |-------- |---------------:|--------------:|--------------:|------:|--------:|
| **LoopUsingIndex**    | **10**      |       **9.394 ns** |     **0.1659 ns** |     **0.1552 ns** |  **1.29** |    **0.03** |
| LoopUsingVariable | 10      |       7.299 ns |     0.1503 ns |     0.1406 ns |  1.00 |    0.03 |
|                   |         |                |               |               |       |         |
| **LoopUsingIndex**    | **100**     |      **98.754 ns** |     **0.4325 ns** |     **0.4046 ns** |  **1.42** |    **0.01** |
| LoopUsingVariable | 100     |      69.421 ns |     0.4044 ns |     0.3584 ns |  1.00 |    0.01 |
|                   |         |                |               |               |       |         |
| **LoopUsingIndex**    | **1000**    |     **943.718 ns** |     **4.0060 ns** |     **3.5512 ns** |  **1.49** |    **0.01** |
| LoopUsingVariable | 1000    |     634.720 ns |     4.6310 ns |     4.3319 ns |  1.00 |    0.01 |
|                   |         |                |               |               |       |         |
| **LoopUsingIndex**    | **100000**  |  **94,047.542 ns** |   **436.2963 ns** |   **386.7653 ns** |  **1.49** |    **0.01** |
| LoopUsingVariable | 100000  |  63,044.635 ns |   541.6641 ns |   506.6730 ns |  1.00 |    0.01 |
|                   |         |                |               |               |       |         |
| **LoopUsingIndex**    | **1000000** | **944,919.961 ns** | **5,522.6101 ns** | **5,165.8529 ns** |  **1.50** |    **0.01** |
| LoopUsingVariable | 1000000 | 629,680.130 ns | 5,054.9499 ns | 4,728.4033 ns |  1.00 |    0.01 |
