# Random numbers







```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27718.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-preview.6.24328.19
  [Host]     : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                             | Count   | Mean         | Error      | StdDev     | Ratio  | RatioSD | Gen0       | Allocated   | Alloc Ratio    |
|----------------------------------- |-------- |-------------:|-----------:|-----------:|-------:|--------:|-----------:|------------:|---------------:|
| SystemRandomStaticInstanceWithSeed | 1000000 |     9.026 ms |  0.0261 ms |  0.0204 ms |   1.00 |    0.00 |          - |         3 B |           1.00 |
| SystemRandomLocalInstanceWithSeed  | 1000000 |     7.809 ms |  0.1342 ms |  0.1120 ms |   0.87 |    0.01 |          - |       307 B |         102.33 |
| SystemRandomDotShared              | 1000000 |     4.464 ms |  0.0865 ms |  0.0889 ms |   0.50 |    0.01 |          - |         3 B |           1.00 |
| SystemRandomStaticInstanceNoSeed   | 1000000 |     2.974 ms |  0.0195 ms |  0.0182 ms |   0.33 |    0.00 |          - |         2 B |           0.67 |
| SystemRandomLocalInstanceNoSeed    | 1000000 |     2.413 ms |  0.0469 ms |  0.0730 ms |   0.27 |    0.01 |          - |        74 B |          24.67 |
| SystemRandomWithLock               | 1000000 |    19.153 ms |  0.3817 ms |  0.4084 ms |   2.13 |    0.05 |          - |        12 B |           4.00 |
| SystemRandomNewInstanceEveryTime   | 1000000 | 1,472.258 ms | 19.1034 ms | 15.9522 ms | 163.37 |    1.56 | 70000.0000 | 304000400 B | 101,333,466.67 |
| SystemRandomThreadStatic           | 1000000 |     8.920 ms |  0.1725 ms |  0.2529 ms |   1.00 |    0.03 |          - |         3 B |           1.00 |
| XorShiftRandom                     | 1000000 |     2.404 ms |  0.0126 ms |  0.0105 ms |   0.27 |    0.00 |          - |         3 B |           1.00 |
