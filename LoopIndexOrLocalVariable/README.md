# Loop using a variable vs index.





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method            | Job       | Runtime   | Count   | Mean           | Error         | StdDev        | Ratio | RatioSD |
|------------------ |---------- |---------- |-------- |---------------:|--------------:|--------------:|------:|--------:|
| **LoopUsingIndex**    | **.NET 10.0** | **.NET 10.0** | **10**      |       **9.081 ns** |     **0.2066 ns** |     **0.1933 ns** |  **1.31** |    **0.03** |
| LoopUsingVariable | .NET 10.0 | .NET 10.0 | 10      |       6.924 ns |     0.0149 ns |     0.0132 ns |  1.00 |    0.00 |
|                   |           |           |         |                |               |               |       |         |
| LoopUsingIndex    | .NET 9.0  | .NET 9.0  | 10      |       9.139 ns |     0.1981 ns |     0.1853 ns |  1.32 |    0.03 |
| LoopUsingVariable | .NET 9.0  | .NET 9.0  | 10      |       6.922 ns |     0.0125 ns |     0.0111 ns |  1.00 |    0.00 |
|                   |           |           |         |                |               |               |       |         |
| **LoopUsingIndex**    | **.NET 10.0** | **.NET 10.0** | **100**     |      **99.024 ns** |     **0.4358 ns** |     **0.3639 ns** |  **1.38** |    **0.02** |
| LoopUsingVariable | .NET 10.0 | .NET 10.0 | 100     |      71.814 ns |     1.0390 ns |     0.9719 ns |  1.00 |    0.02 |
|                   |           |           |         |                |               |               |       |         |
| LoopUsingIndex    | .NET 9.0  | .NET 9.0  | 100     |      98.889 ns |     0.1510 ns |     0.1339 ns |  1.39 |    0.01 |
| LoopUsingVariable | .NET 9.0  | .NET 9.0  | 100     |      71.249 ns |     0.2824 ns |     0.2641 ns |  1.00 |    0.01 |
|                   |           |           |         |                |               |               |       |         |
| **LoopUsingIndex**    | **.NET 10.0** | **.NET 10.0** | **1000**    |     **936.246 ns** |     **1.0795 ns** |     **0.9014 ns** |  **1.48** |    **0.00** |
| LoopUsingVariable | .NET 10.0 | .NET 10.0 | 1000    |     630.966 ns |     1.5428 ns |     1.4431 ns |  1.00 |    0.00 |
|                   |           |           |         |                |               |               |       |         |
| LoopUsingIndex    | .NET 9.0  | .NET 9.0  | 1000    |     937.555 ns |     2.7556 ns |     2.4428 ns |  1.48 |    0.01 |
| LoopUsingVariable | .NET 9.0  | .NET 9.0  | 1000    |     631.415 ns |     2.2307 ns |     2.0866 ns |  1.00 |    0.00 |
|                   |           |           |         |                |               |               |       |         |
| **LoopUsingIndex**    | **.NET 10.0** | **.NET 10.0** | **100000**  |  **93,331.672 ns** |    **84.0697 ns** |    **70.2020 ns** |  **1.49** |    **0.01** |
| LoopUsingVariable | .NET 10.0 | .NET 10.0 | 100000  |  62,500.875 ns |   429.0745 ns |   380.3634 ns |  1.00 |    0.01 |
|                   |           |           |         |                |               |               |       |         |
| LoopUsingIndex    | .NET 9.0  | .NET 9.0  | 100000  |  93,274.504 ns |    79.1387 ns |    66.0844 ns |  1.49 |    0.00 |
| LoopUsingVariable | .NET 9.0  | .NET 9.0  | 100000  |  62,449.670 ns |   178.8290 ns |   158.5272 ns |  1.00 |    0.00 |
|                   |           |           |         |                |               |               |       |         |
| **LoopUsingIndex**    | **.NET 10.0** | **.NET 10.0** | **1000000** | **938,008.255 ns** | **4,096.3728 ns** | **3,831.7497 ns** |  **1.50** |    **0.01** |
| LoopUsingVariable | .NET 10.0 | .NET 10.0 | 1000000 | 625,958.879 ns | 1,223.1080 ns | 1,021.3506 ns |  1.00 |    0.00 |
|                   |           |           |         |                |               |               |       |         |
| LoopUsingIndex    | .NET 9.0  | .NET 9.0  | 1000000 | 936,224.554 ns | 1,904.5139 ns | 1,688.3020 ns |  1.50 |    0.00 |
| LoopUsingVariable | .NET 9.0  | .NET 9.0  | 1000000 | 625,841.867 ns | 1,880.1746 ns | 1,666.7258 ns |  1.00 |    0.00 |
