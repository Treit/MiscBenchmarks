# Adding items to a list







```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                              | Count | Mean       | Error     | StdDev    | Ratio | RatioSD | Gen0    | Gen1    | Gen2    | Allocated | Alloc Ratio |
|------------------------------------ |------ |-----------:|----------:|----------:|------:|--------:|--------:|--------:|--------:|----------:|------------:|
| AddValueTypesWithForEach            | 10000 |  97.621 μs | 1.8911 μs | 1.7690 μs |  1.00 |    0.03 | 41.6260 | 41.6260 | 41.6260 | 256.32 KB |        1.00 |
| AddReferenceTypesWithForEach        | 10000 | 117.366 μs | 1.7618 μs | 1.6480 μs |  1.20 |    0.03 | 41.6260 | 41.6260 | 41.6260 | 256.32 KB |        1.00 |
| AddValueTypesPresetCapacity         | 10000 |  16.227 μs | 0.1787 μs | 0.1672 μs |  0.17 |    0.00 |  4.7607 |  0.9460 |       - |  78.18 KB |        0.31 |
| AddReferenceTypesPresetCapacity     | 10000 |  34.615 μs | 0.6159 μs | 0.5761 μs |  0.35 |    0.01 |  4.7607 |  0.9155 |       - |  78.18 KB |        0.31 |
| AddValueTypesWithAddRange           | 10000 |   4.097 μs | 0.0649 μs | 0.0575 μs |  0.04 |    0.00 |  4.7607 |  0.9460 |       - |  78.18 KB |        0.31 |
| AddReferenceTypesWithAddRange       | 10000 |   3.968 μs | 0.0734 μs | 0.0686 μs |  0.04 |    0.00 |  4.7607 |  0.9499 |       - |  78.18 KB |        0.31 |
| ValueTypesToListWithConstructor     | 10000 |   3.944 μs | 0.0782 μs | 0.0731 μs |  0.04 |    0.00 |  4.7607 |  0.9460 |       - |  78.18 KB |        0.31 |
| ReferenceTypesToListWithConstructor | 10000 |   4.069 μs | 0.0763 μs | 0.0750 μs |  0.04 |    0.00 |  4.7607 |  0.9460 |       - |  78.18 KB |        0.31 |
