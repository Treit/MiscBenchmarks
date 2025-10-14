# Adding items to a list





```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27971.1)
Unknown processor
.NET SDK 10.0.100-preview.6.25358.103
  [Host]     : .NET 9.0.8 (9.0.825.36511), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 9.0.8 (9.0.825.36511), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                              | Count | Mean       | Error     | StdDev    | Ratio | RatioSD | Gen0    | Gen1    | Gen2    | Allocated | Alloc Ratio |
|------------------------------------ |------ |-----------:|----------:|----------:|------:|--------:|--------:|--------:|--------:|----------:|------------:|
| AddValueTypesWithForEach            | 10000 | 117.487 μs | 2.3412 μs | 6.0850 μs |  1.00 |    0.00 | 41.6260 | 41.6260 | 41.6260 | 256.32 KB |        1.00 |
| AddReferenceTypesWithForEach        | 10000 | 123.823 μs | 2.3778 μs | 5.6971 μs |  1.05 |    0.08 | 41.6260 | 41.6260 | 41.6260 | 256.32 KB |        1.00 |
| AddValueTypesPresetCapacity         | 10000 |  21.398 μs | 0.4125 μs | 0.4413 μs |  0.19 |    0.01 | 18.4937 |  3.0823 |       - |  78.18 KB |        0.31 |
| AddReferenceTypesPresetCapacity     | 10000 |  36.223 μs | 0.6207 μs | 0.5806 μs |  0.31 |    0.02 | 18.4937 |  3.0518 |       - |  78.18 KB |        0.31 |
| AddValueTypesWithAddRange           | 10000 |   7.380 μs | 0.0925 μs | 0.0820 μs |  0.06 |    0.00 | 18.5165 |  3.0823 |       - |  78.18 KB |        0.31 |
| AddReferenceTypesWithAddRange       | 10000 |   9.362 μs | 0.1840 μs | 0.3364 μs |  0.08 |    0.00 | 18.5089 |  3.0823 |       - |  78.18 KB |        0.31 |
| ValueTypesToListWithConstructor     | 10000 |   7.795 μs | 0.1529 μs | 0.2380 μs |  0.07 |    0.00 | 18.5089 |  3.0823 |       - |  78.18 KB |        0.31 |
| ReferenceTypesToListWithConstructor | 10000 |   9.551 μs | 0.1868 μs | 0.2619 μs |  0.08 |    0.00 | 18.5089 |  3.0823 |       - |  78.18 KB |        0.31 |
