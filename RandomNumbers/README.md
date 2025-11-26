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
| SystemRandomStaticInstanceWithSeed | 1000000 |     7.993 ms | 0.0124 ms | 0.0103 ms |   1.00 |    0.00 |          - |           - |          NA |
| SystemRandomLocalInstanceWithSeed  | 1000000 |     6.976 ms | 0.0430 ms | 0.0402 ms |   0.87 |    0.00 |          - |       304 B |          NA |
| SystemRandomDotShared              | 1000000 |     2.880 ms | 0.0150 ms | 0.0140 ms |   0.36 |    0.00 |          - |           - |          NA |
| SystemRandomStaticInstanceNoSeed   | 1000000 |     2.188 ms | 0.0163 ms | 0.0152 ms |   0.27 |    0.00 |          - |           - |          NA |
| SystemRandomLocalInstanceNoSeed    | 1000000 |     1.876 ms | 0.0065 ms | 0.0060 ms |   0.23 |    0.00 |          - |        72 B |          NA |
| SystemRandomWithLock               | 1000000 |    15.754 ms | 0.0453 ms | 0.0401 ms |   1.97 |    0.01 |          - |           - |          NA |
| SystemRandomNewInstanceEveryTime   | 1000000 | 1,179.864 ms | 6.7797 ms | 6.3418 ms | 147.61 |    0.79 | 18000.0000 | 304000000 B |          NA |
| SystemRandomThreadStatic           | 1000000 |     7.527 ms | 0.0686 ms | 0.0641 ms |   0.94 |    0.01 |          - |           - |          NA |
| XorShiftRandom                     | 1000000 |     1.875 ms | 0.0032 ms | 0.0030 ms |   0.23 |    0.00 |          - |           - |          NA |
