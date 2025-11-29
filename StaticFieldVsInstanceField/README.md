# Instance vs. Static fields.






```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method             | Job       | Runtime   | Count | Mean        | Error     | StdDev    | Median      | Allocated |
|------------------- |---------- |---------- |------ |------------:|----------:|----------:|------------:|----------:|
| **ReadInstanceField**  | **.NET 10.0** | **.NET 10.0** | **1**     |   **0.0067 ns** | **0.0051 ns** | **0.0046 ns** |   **0.0052 ns** |         **-** |
| ReadStaticField    | .NET 10.0 | .NET 10.0 | 1     |   0.3159 ns | 0.0028 ns | 0.0024 ns |   0.3153 ns |         - |
| WriteInstanceField | .NET 10.0 | .NET 10.0 | 1     |   3.7219 ns | 0.0039 ns | 0.0035 ns |   3.7204 ns |         - |
| WriteStaticField   | .NET 10.0 | .NET 10.0 | 1     |   3.7821 ns | 0.0088 ns | 0.0078 ns |   3.7783 ns |         - |
| ReadInstanceField  | .NET 9.0  | .NET 9.0  | 1     |   0.0073 ns | 0.0030 ns | 0.0027 ns |   0.0062 ns |         - |
| ReadStaticField    | .NET 9.0  | .NET 9.0  | 1     |   0.3221 ns | 0.0045 ns | 0.0035 ns |   0.3220 ns |         - |
| WriteInstanceField | .NET 9.0  | .NET 9.0  | 1     |   4.3433 ns | 0.0044 ns | 0.0042 ns |   4.3432 ns |         - |
| WriteStaticField   | .NET 9.0  | .NET 9.0  | 1     |   4.6582 ns | 0.0110 ns | 0.0092 ns |   4.6555 ns |         - |
| **ReadInstanceField**  | **.NET 10.0** | **.NET 10.0** | **100**   |  **46.2654 ns** | **0.4907 ns** | **0.4590 ns** |  **46.3243 ns** |         **-** |
| ReadStaticField    | .NET 10.0 | .NET 10.0 | 100   |  38.5307 ns | 0.0543 ns | 0.0453 ns |  38.5155 ns |         - |
| WriteInstanceField | .NET 10.0 | .NET 10.0 | 100   | 347.8694 ns | 0.8070 ns | 0.6739 ns | 347.6254 ns |         - |
| WriteStaticField   | .NET 10.0 | .NET 10.0 | 100   | 347.4583 ns | 0.6289 ns | 0.5575 ns | 347.4517 ns |         - |
| ReadInstanceField  | .NET 9.0  | .NET 9.0  | 100   |  46.2939 ns | 0.3546 ns | 0.3317 ns |  46.2565 ns |         - |
| ReadStaticField    | .NET 9.0  | .NET 9.0  | 100   |  38.5628 ns | 0.0680 ns | 0.0603 ns |  38.5513 ns |         - |
| WriteInstanceField | .NET 9.0  | .NET 9.0  | 100   | 347.8268 ns | 0.5667 ns | 0.5024 ns | 347.8602 ns |         - |
| WriteStaticField   | .NET 9.0  | .NET 9.0  | 100   | 347.2029 ns | 0.9250 ns | 0.7724 ns | 346.9510 ns |         - |
