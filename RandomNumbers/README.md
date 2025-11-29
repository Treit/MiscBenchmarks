# Random numbers










```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                             | Job       | Runtime   | Count   | Mean         | Error     | StdDev    | Ratio  | RatioSD | Gen0       | Allocated   | Alloc Ratio |
|----------------------------------- |---------- |---------- |-------- |-------------:|----------:|----------:|-------:|--------:|-----------:|------------:|------------:|
| SystemRandomStaticInstanceWithSeed | .NET 10.0 | .NET 10.0 | 1000000 |     7.943 ms | 0.0095 ms | 0.0079 ms |   1.00 |    0.00 |          - |           - |          NA |
| SystemRandomLocalInstanceWithSeed  | .NET 10.0 | .NET 10.0 | 1000000 |     6.924 ms | 0.0253 ms | 0.0225 ms |   0.87 |    0.00 |          - |       304 B |          NA |
| SystemRandomDotShared              | .NET 10.0 | .NET 10.0 | 1000000 |     2.849 ms | 0.0080 ms | 0.0071 ms |   0.36 |    0.00 |          - |           - |          NA |
| SystemRandomStaticInstanceNoSeed   | .NET 10.0 | .NET 10.0 | 1000000 |     2.180 ms | 0.0125 ms | 0.0117 ms |   0.27 |    0.00 |          - |           - |          NA |
| SystemRandomLocalInstanceNoSeed    | .NET 10.0 | .NET 10.0 | 1000000 |     1.864 ms | 0.0030 ms | 0.0028 ms |   0.23 |    0.00 |          - |        72 B |          NA |
| SystemRandomWithLock               | .NET 10.0 | .NET 10.0 | 1000000 |    15.681 ms | 0.0825 ms | 0.0689 ms |   1.97 |    0.01 |          - |           - |          NA |
| SystemRandomNewInstanceEveryTime   | .NET 10.0 | .NET 10.0 | 1000000 | 1,179.417 ms | 6.1948 ms | 5.7946 ms | 148.48 |    0.72 | 18000.0000 | 304000000 B |          NA |
| SystemRandomThreadStatic           | .NET 10.0 | .NET 10.0 | 1000000 |     7.423 ms | 0.0090 ms | 0.0084 ms |   0.93 |    0.00 |          - |           - |          NA |
| XorShiftRandom                     | .NET 10.0 | .NET 10.0 | 1000000 |     1.865 ms | 0.0007 ms | 0.0006 ms |   0.23 |    0.00 |          - |           - |          NA |
|                                    |           |           |         |              |           |           |        |         |            |             |             |
| SystemRandomStaticInstanceWithSeed | .NET 9.0  | .NET 9.0  | 1000000 |     7.942 ms | 0.0050 ms | 0.0046 ms |   1.00 |    0.00 |          - |           - |          NA |
| SystemRandomLocalInstanceWithSeed  | .NET 9.0  | .NET 9.0  | 1000000 |     6.917 ms | 0.0092 ms | 0.0082 ms |   0.87 |    0.00 |          - |       304 B |          NA |
| SystemRandomDotShared              | .NET 9.0  | .NET 9.0  | 1000000 |     2.848 ms | 0.0053 ms | 0.0041 ms |   0.36 |    0.00 |          - |           - |          NA |
| SystemRandomStaticInstanceNoSeed   | .NET 9.0  | .NET 9.0  | 1000000 |     2.172 ms | 0.0024 ms | 0.0019 ms |   0.27 |    0.00 |          - |           - |          NA |
| SystemRandomLocalInstanceNoSeed    | .NET 9.0  | .NET 9.0  | 1000000 |     1.863 ms | 0.0024 ms | 0.0022 ms |   0.23 |    0.00 |          - |        72 B |          NA |
| SystemRandomWithLock               | .NET 9.0  | .NET 9.0  | 1000000 |    15.772 ms | 0.1502 ms | 0.1405 ms |   1.99 |    0.02 |          - |           - |          NA |
| SystemRandomNewInstanceEveryTime   | .NET 9.0  | .NET 9.0  | 1000000 | 1,177.228 ms | 2.9077 ms | 2.7198 ms | 148.23 |    0.34 | 18000.0000 | 304000000 B |          NA |
| SystemRandomThreadStatic           | .NET 9.0  | .NET 9.0  | 1000000 |     7.431 ms | 0.0170 ms | 0.0150 ms |   0.94 |    0.00 |          - |           - |          NA |
| XorShiftRandom                     | .NET 9.0  | .NET 9.0  | 1000000 |     1.865 ms | 0.0007 ms | 0.0006 ms |   0.23 |    0.00 |          - |           - |          NA |
