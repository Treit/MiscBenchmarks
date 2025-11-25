# Linq 'All' vs 'Except' to find if one list is a subset of another



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                      | Count | Mean             | Error           | StdDev        | Ratio  | RatioSD | Gen0    | Gen1    | Gen2    | Allocated | Alloc Ratio |
|---------------------------- |------ |-----------------:|----------------:|--------------:|-------:|--------:|--------:|--------:|--------:|----------:|------------:|
| **VerifySubsetUsingLinqAll**    | **10**    |         **267.2 ns** |         **3.15 ns** |       **2.79 ns** |   **0.82** |    **0.01** |  **0.0577** |       **-** |       **-** |     **968 B** |        **2.05** |
| VerifySubsetUsingLinqExcept | 10    |         326.4 ns |         2.76 ns |       2.45 ns |   1.00 |    0.01 |  0.0281 |       - |       - |     472 B |        1.00 |
|                             |       |                  |                 |               |        |         |         |         |         |           |             |
| **VerifySubsetUsingLinqAll**    | **1000**  |   **1,151,149.1 ns** |     **9,928.31 ns** |   **9,286.95 ns** |  **42.34** |    **0.43** |  **3.9063** |       **-** |       **-** |   **88088 B** |        **3.95** |
| VerifySubsetUsingLinqExcept | 1000  |      27,187.1 ns |       196.35 ns |     183.66 ns |   1.00 |    0.01 |  1.3123 |  0.0916 |       - |   22312 B |        1.00 |
|                             |       |                  |                 |               |        |         |         |         |         |           |             |
| **VerifySubsetUsingLinqAll**    | **10000** | **131,011,409.6 ns** | **1,020,596.30 ns** | **852,244.13 ns** | **259.96** |    **9.05** |       **-** |       **-** |       **-** |  **880088 B** |        **4.35** |
| VerifySubsetUsingLinqExcept | 10000 |     504,494.8 ns |     9,975.27 ns |  15,821.84 ns |   1.00 |    0.05 | 49.8047 | 49.8047 | 49.8047 |  202329 B |        1.00 |
