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
| **ReadInstanceField**  | **1**     |   **0.0075 ns** | **0.0056 ns** | **0.0053 ns** |         **-** |
| ReadStaticField    | 1     |   0.3319 ns | 0.0171 ns | 0.0160 ns |         - |
| WriteInstanceField | 1     |   3.7620 ns | 0.0323 ns | 0.0286 ns |         - |
| WriteStaticField   | 1     |   4.0677 ns | 0.0304 ns | 0.0270 ns |         - |
| **ReadInstanceField**  | **100**   |  **46.1268 ns** | **0.3619 ns** | **0.3385 ns** |         **-** |
| ReadStaticField    | 100   |  38.8417 ns | 0.2443 ns | 0.2285 ns |         - |
| WriteInstanceField | 100   | 349.9609 ns | 2.4756 ns | 2.1945 ns |         - |
| WriteStaticField   | 100   | 349.8675 ns | 1.7679 ns | 1.3803 ns |         - |
