# Instance vs. Static fields.





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method             | Count | Mean        | Error     | StdDev    | Allocated |
|------------------- |------ |------------:|----------:|----------:|----------:|
| **ReadInstanceField**  | **1**     |   **0.0080 ns** | **0.0046 ns** | **0.0040 ns** |         **-** |
| ReadStaticField    | 1     |   0.3183 ns | 0.0176 ns | 0.0165 ns |         - |
| WriteInstanceField | 1     |   4.3851 ns | 0.0278 ns | 0.0247 ns |         - |
| WriteStaticField   | 1     |   4.6920 ns | 0.0239 ns | 0.0224 ns |         - |
| **ReadInstanceField**  | **100**   |  **46.1438 ns** | **0.4548 ns** | **0.4254 ns** |         **-** |
| ReadStaticField    | 100   |  38.8444 ns | 0.2632 ns | 0.2462 ns |         - |
| WriteInstanceField | 100   | 349.5806 ns | 2.0652 ns | 1.8308 ns |         - |
| WriteStaticField   | 100   | 350.2339 ns | 2.3605 ns | 2.2081 ns |         - |
