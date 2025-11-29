# Finding an item





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                 | Job       | Runtime   | Iterations | Mean           | Error       | StdDev      | Allocated |
|----------------------- |---------- |---------- |----------- |---------------:|------------:|------------:|----------:|
| **LookupUsingHashSet**     | **.NET 10.0** | **.NET 10.0** | **1000**       |     **2,341.0 ns** |     **3.60 ns** |     **3.00 ns** |         **-** |
| LookupUsingList        | .NET 10.0 | .NET 10.0 | 1000       |     2,495.9 ns |     8.79 ns |     7.79 ns |         - |
| LookupUsingConditional | .NET 10.0 | .NET 10.0 | 1000       |       780.2 ns |     1.21 ns |     1.08 ns |         - |
| LookupUsingSwitch      | .NET 10.0 | .NET 10.0 | 1000       |       474.5 ns |     3.36 ns |     3.14 ns |         - |
| LookupUsingRange       | .NET 10.0 | .NET 10.0 | 1000       |       321.2 ns |     1.36 ns |     1.21 ns |         - |
| LookupUsingHashSet     | .NET 9.0  | .NET 9.0  | 1000       |     2,343.4 ns |    13.48 ns |    11.26 ns |         - |
| LookupUsingList        | .NET 9.0  | .NET 9.0  | 1000       |     2,491.2 ns |     3.79 ns |     3.36 ns |         - |
| LookupUsingConditional | .NET 9.0  | .NET 9.0  | 1000       |       781.3 ns |     2.64 ns |     2.34 ns |         - |
| LookupUsingSwitch      | .NET 9.0  | .NET 9.0  | 1000       |       475.9 ns |     3.63 ns |     3.39 ns |         - |
| LookupUsingRange       | .NET 9.0  | .NET 9.0  | 1000       |       322.6 ns |     2.97 ns |     2.63 ns |         - |
| **LookupUsingHashSet**     | **.NET 10.0** | **.NET 10.0** | **100000**     |   **231,056.9 ns** |   **552.91 ns** |   **431.67 ns** |         **-** |
| LookupUsingList        | .NET 10.0 | .NET 10.0 | 100000     |   248,601.9 ns |   496.20 ns |   414.35 ns |         - |
| LookupUsingConditional | .NET 10.0 | .NET 10.0 | 100000     |    77,504.4 ns |    76.23 ns |    63.66 ns |         - |
| LookupUsingSwitch      | .NET 10.0 | .NET 10.0 | 100000     |    46,775.6 ns |   163.34 ns |   152.79 ns |         - |
| LookupUsingRange       | .NET 10.0 | .NET 10.0 | 100000     |    31,347.2 ns |   400.31 ns |   354.86 ns |         - |
| LookupUsingHashSet     | .NET 9.0  | .NET 9.0  | 100000     |   231,846.6 ns | 1,317.26 ns | 1,167.72 ns |         - |
| LookupUsingList        | .NET 9.0  | .NET 9.0  | 100000     |   248,544.4 ns |   387.07 ns |   343.12 ns |         - |
| LookupUsingConditional | .NET 9.0  | .NET 9.0  | 100000     |    77,651.4 ns |   261.13 ns |   244.26 ns |         - |
| LookupUsingSwitch      | .NET 9.0  | .NET 9.0  | 100000     |    46,834.8 ns |   250.07 ns |   233.91 ns |         - |
| LookupUsingRange       | .NET 9.0  | .NET 9.0  | 100000     |    31,144.1 ns |   160.22 ns |   142.03 ns |         - |
| **LookupUsingHashSet**     | **.NET 10.0** | **.NET 10.0** | **1000000**    | **2,349,540.1 ns** | **3,464.15 ns** | **3,070.88 ns** |         **-** |
| LookupUsingList        | .NET 10.0 | .NET 10.0 | 1000000    | 2,483,309.1 ns | 2,431.96 ns | 1,898.71 ns |         - |
| LookupUsingConditional | .NET 10.0 | .NET 10.0 | 1000000    |   775,171.1 ns |   730.68 ns |   570.47 ns |         - |
| LookupUsingSwitch      | .NET 10.0 | .NET 10.0 | 1000000    |   469,904.8 ns | 1,905.07 ns | 1,688.79 ns |         - |
| LookupUsingRange       | .NET 10.0 | .NET 10.0 | 1000000    |   310,960.2 ns | 1,075.37 ns |   897.98 ns |         - |
| LookupUsingHashSet     | .NET 9.0  | .NET 9.0  | 1000000    | 2,312,034.3 ns | 5,470.35 ns | 5,116.97 ns |         - |
| LookupUsingList        | .NET 9.0  | .NET 9.0  | 1000000    | 2,486,845.6 ns | 3,425.55 ns | 3,204.26 ns |         - |
| LookupUsingConditional | .NET 9.0  | .NET 9.0  | 1000000    |   777,371.6 ns | 3,153.44 ns | 2,949.73 ns |         - |
| LookupUsingSwitch      | .NET 9.0  | .NET 9.0  | 1000000    |   468,989.3 ns | 2,981.34 ns | 2,788.75 ns |         - |
| LookupUsingRange       | .NET 9.0  | .NET 9.0  | 1000000    |   310,669.4 ns |   679.98 ns |   530.88 ns |         - |
