# Random numbers








```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                             | Count   | Mean         | Error     | StdDev    | Ratio  | RatioSD | Gen0       | Allocated   | Alloc Ratio |
|----------------------------------- |-------- |-------------:|----------:|----------:|-------:|--------:|-----------:|------------:|------------:|
| SystemRandomStaticInstanceWithSeed | 1000000 |     8.012 ms | 0.0069 ms | 0.0058 ms |   1.00 |    0.00 |          - |           - |          NA |
| SystemRandomLocalInstanceWithSeed  | 1000000 |     6.967 ms | 0.0149 ms | 0.0139 ms |   0.87 |    0.00 |          - |       304 B |          NA |
| SystemRandomDotShared              | 1000000 |     2.886 ms | 0.0154 ms | 0.0137 ms |   0.36 |    0.00 |          - |           - |          NA |
| SystemRandomStaticInstanceNoSeed   | 1000000 |     2.193 ms | 0.0177 ms | 0.0165 ms |   0.27 |    0.00 |          - |           - |          NA |
| SystemRandomLocalInstanceNoSeed    | 1000000 |     1.878 ms | 0.0042 ms | 0.0037 ms |   0.23 |    0.00 |          - |        72 B |          NA |
| SystemRandomWithLock               | 1000000 |    15.734 ms | 0.0172 ms | 0.0144 ms |   1.96 |    0.00 |          - |           - |          NA |
| SystemRandomNewInstanceEveryTime   | 1000000 | 1,179.508 ms | 2.8607 ms | 2.3888 ms | 147.22 |    0.31 | 18000.0000 | 304000000 B |          NA |
| SystemRandomThreadStatic           | 1000000 |     7.497 ms | 0.0148 ms | 0.0131 ms |   0.94 |    0.00 |          - |           - |          NA |
| XorShiftRandom                     | 1000000 |     1.879 ms | 0.0037 ms | 0.0033 ms |   0.23 |    0.00 |          - |           - |          NA |
