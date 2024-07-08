# Random numbers






```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26252.5000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-preview.5.24307.3
  [Host]     : .NET 8.0.6 (8.0.624.26715), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.6 (8.0.624.26715), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                             | Count   | Mean         | Error      | StdDev     | Ratio  | RatioSD | Gen0       | Allocated   | Alloc Ratio   |
|----------------------------------- |-------- |-------------:|-----------:|-----------:|-------:|--------:|-----------:|------------:|--------------:|
| SystemRandomStaticInstanceWithSeed | 1000000 |    11.403 ms |  0.2192 ms |  0.3143 ms |   1.00 |    0.00 |          - |         6 B |          1.00 |
| SystemRandomLocalInstanceWithSeed  | 1000000 |     9.692 ms |  0.1318 ms |  0.1168 ms |   0.85 |    0.03 |          - |       310 B |         51.67 |
| SystemRandomDotShared              | 1000000 |     6.746 ms |  0.0737 ms |  0.0690 ms |   0.59 |    0.02 |          - |         3 B |          0.50 |
| SystemRandomStaticInstanceNoSeed   | 1000000 |     5.175 ms |  0.1025 ms |  0.1595 ms |   0.46 |    0.02 |          - |         3 B |          0.50 |
| SystemRandomLocalInstanceNoSeed    | 1000000 |     3.307 ms |  0.0657 ms |  0.0877 ms |   0.29 |    0.01 |          - |        74 B |         12.33 |
| SystemRandomWithLock               | 1000000 |    30.142 ms |  0.3933 ms |  0.3679 ms |   2.65 |    0.07 |          - |        12 B |          2.00 |
| SystemRandomNewInstanceEveryTime   | 1000000 | 1,847.650 ms | 36.1360 ms | 43.0174 ms | 162.08 |    5.66 | 70000.0000 | 304000400 B | 50,666,733.33 |
| SystemRandomThreadStatic           | 1000000 |    10.704 ms |  0.1247 ms |  0.1105 ms |   0.94 |    0.03 |          - |         6 B |          1.00 |
| XorShiftRandom                     | 1000000 |     2.827 ms |  0.0319 ms |  0.0298 ms |   0.25 |    0.01 |          - |         2 B |          0.33 |
