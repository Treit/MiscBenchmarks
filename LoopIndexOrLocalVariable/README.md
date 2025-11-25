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
| **LoopUsingIndex**    | **10**      |       **9.339 ns** |     **0.0753 ns** |     **0.0705 ns** |  **1.29** |    **0.02** |
| LoopUsingVariable | 10      |       7.232 ns |     0.1031 ns |     0.0914 ns |  1.00 |    0.02 |
|                   |         |                |               |               |       |         |
| **LoopUsingIndex**    | **100**     |      **98.585 ns** |     **0.3983 ns** |     **0.3326 ns** |  **1.42** |    **0.01** |
| LoopUsingVariable | 100     |      69.266 ns |     0.4897 ns |     0.4581 ns |  1.00 |    0.01 |
|                   |         |                |               |               |       |         |
| **LoopUsingIndex**    | **1000**    |     **940.107 ns** |     **1.9274 ns** |     **1.8029 ns** |  **1.49** |    **0.01** |
| LoopUsingVariable | 1000    |     631.340 ns |     3.5189 ns |     2.9384 ns |  1.00 |    0.01 |
|                   |         |                |               |               |       |         |
| **LoopUsingIndex**    | **100000**  |  **93,795.431 ns** |   **428.0413 ns** |   **379.4474 ns** |  **1.50** |    **0.01** |
| LoopUsingVariable | 100000  |  62,738.727 ns |   534.2914 ns |   499.7765 ns |  1.00 |    0.01 |
|                   |         |                |               |               |       |         |
| **LoopUsingIndex**    | **1000000** | **942,343.864 ns** | **2,732.3576 ns** | **2,133.2451 ns** |  **1.49** |    **0.01** |
| LoopUsingVariable | 1000000 | 633,970.805 ns | 5,114.0807 ns | 4,270.4890 ns |  1.00 |    0.01 |
