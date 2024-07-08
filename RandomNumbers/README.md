# Random numbers





```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26252.5000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-preview.5.24307.3
  [Host]     : .NET 8.0.6 (8.0.624.26715), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.6 (8.0.624.26715), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                           | Count   | Mean         | Error     | StdDev    | Ratio  | RatioSD | Gen0       | Allocated   | Alloc Ratio    |
|--------------------------------- |-------- |-------------:|----------:|----------:|-------:|--------:|-----------:|------------:|---------------:|
| SystemRandomSingleInstance       | 1000000 |     9.201 ms | 0.1582 ms | 0.1480 ms |   1.00 |    0.00 |          - |         3 B |           1.00 |
| SystemRandomDotShared            | 1000000 |     4.651 ms | 0.0863 ms | 0.0720 ms |   0.51 |    0.01 |          - |         3 B |           1.00 |
| SystemRandomNewInstanceNoSeed    | 1000000 |     2.469 ms | 0.0485 ms | 0.0614 ms |   0.27 |    0.01 |          - |        74 B |          24.67 |
| SystemRandomWithLock             | 1000000 |    22.866 ms | 0.4632 ms | 1.3289 ms |   2.55 |    0.17 |          - |        12 B |           4.00 |
| SystemRandomNewInstanceEveryTime | 1000000 | 1,477.859 ms | 8.9619 ms | 7.9445 ms | 160.65 |    2.81 | 70000.0000 | 304000400 B | 101,333,466.67 |
| SystemRandomThreadStatic         | 1000000 |     8.937 ms | 0.0310 ms | 0.0290 ms |   0.97 |    0.02 |          - |         3 B |           1.00 |
| XorShiftRandom                   | 1000000 |     2.529 ms | 0.0398 ms | 0.0531 ms |   0.28 |    0.01 |          - |         2 B |           0.67 |
