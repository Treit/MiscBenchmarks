# Adding items to a list






```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                              | Count | Mean       | Error     | StdDev    | Median     | Ratio | RatioSD | Gen0    | Gen1    | Gen2    | Allocated | Alloc Ratio |
|------------------------------------ |------ |-----------:|----------:|----------:|-----------:|------:|--------:|--------:|--------:|--------:|----------:|------------:|
| AddValueTypesWithForEach            | 10000 |  95.730 μs | 2.3952 μs | 7.0247 μs |  98.220 μs |  1.01 |    0.12 | 41.6260 | 41.6260 | 41.6260 | 256.32 KB |        1.00 |
| AddReferenceTypesWithForEach        | 10000 | 115.736 μs | 2.2670 μs | 4.1453 μs | 116.727 μs |  1.22 |    0.12 | 41.6260 | 41.6260 | 41.6260 | 256.32 KB |        1.00 |
| AddValueTypesPresetCapacity         | 10000 |  16.631 μs | 0.2814 μs | 0.2632 μs |  16.593 μs |  0.17 |    0.02 |  4.7607 |  0.9460 |       - |  78.18 KB |        0.31 |
| AddReferenceTypesPresetCapacity     | 10000 |  34.497 μs | 0.6530 μs | 0.6706 μs |  34.634 μs |  0.36 |    0.03 |  4.7607 |  0.9155 |       - |  78.18 KB |        0.31 |
| AddValueTypesWithAddRange           | 10000 |   4.038 μs | 0.0803 μs | 0.1251 μs |   4.026 μs |  0.04 |    0.00 |  4.7607 |  0.9460 |       - |  78.18 KB |        0.31 |
| AddReferenceTypesWithAddRange       | 10000 |   4.076 μs | 0.0707 μs | 0.0662 μs |   4.059 μs |  0.04 |    0.00 |  4.7607 |  0.9460 |       - |  78.18 KB |        0.31 |
| ValueTypesToListWithConstructor     | 10000 |   3.912 μs | 0.0757 μs | 0.0743 μs |   3.939 μs |  0.04 |    0.00 |  4.7607 |  0.9499 |       - |  78.18 KB |        0.31 |
| ReferenceTypesToListWithConstructor | 10000 |   3.987 μs | 0.0782 μs | 0.1096 μs |   4.027 μs |  0.04 |    0.00 |  4.7607 |  0.9499 |       - |  78.18 KB |        0.31 |
