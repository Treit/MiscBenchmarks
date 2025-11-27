# Adding items to a list








```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                              | Job       | Runtime   | Count | Mean       | Error     | StdDev    | Ratio | RatioSD | Gen0     | Gen1     | Gen2    | Allocated | Alloc Ratio |
|------------------------------------ |---------- |---------- |------ |-----------:|----------:|----------:|------:|--------:|---------:|---------:|--------:|----------:|------------:|
| AddValueTypesWithForEach            | .NET 10.0 | .NET 10.0 | 10000 |  69.870 μs | 1.1022 μs | 1.0310 μs |  1.00 |    0.02 | 206.5430 | 206.5430 | 34.4238 | 256.32 KB |        1.00 |
| AddReferenceTypesWithForEach        | .NET 10.0 | .NET 10.0 | 10000 | 101.275 μs | 0.9465 μs | 0.7903 μs |  1.45 |    0.02 | 206.5430 | 206.5430 | 34.4238 | 256.32 KB |        1.00 |
| AddValueTypesPresetCapacity         | .NET 10.0 | .NET 10.0 | 10000 |  16.038 μs | 0.1806 μs | 0.1689 μs |  0.23 |    0.00 |   4.7607 |   0.9460 |       - |  78.18 KB |        0.31 |
| AddReferenceTypesPresetCapacity     | .NET 10.0 | .NET 10.0 | 10000 |  35.140 μs | 0.6885 μs | 0.8197 μs |  0.50 |    0.01 |   4.7607 |   0.9155 |       - |  78.18 KB |        0.31 |
| AddValueTypesWithAddRange           | .NET 10.0 | .NET 10.0 | 10000 |   3.882 μs | 0.0751 μs | 0.1213 μs |  0.06 |    0.00 |   4.7607 |   0.9460 |       - |  78.18 KB |        0.31 |
| AddReferenceTypesWithAddRange       | .NET 10.0 | .NET 10.0 | 10000 |   3.902 μs | 0.0740 μs | 0.0822 μs |  0.06 |    0.00 |   4.7607 |   0.9460 |       - |  78.18 KB |        0.31 |
| ValueTypesToListWithConstructor     | .NET 10.0 | .NET 10.0 | 10000 |   3.890 μs | 0.0764 μs | 0.0880 μs |  0.06 |    0.00 |   4.7607 |   0.9460 |       - |  78.18 KB |        0.31 |
| ReferenceTypesToListWithConstructor | .NET 10.0 | .NET 10.0 | 10000 |   3.914 μs | 0.0775 μs | 0.0922 μs |  0.06 |    0.00 |   4.7607 |   0.9460 |       - |  78.18 KB |        0.31 |
|                                     |           |           |       |            |           |           |       |         |          |          |         |           |             |
| AddValueTypesWithForEach            | .NET 9.0  | .NET 9.0  | 10000 |  70.608 μs | 0.7104 μs | 0.6645 μs |  1.00 |    0.01 | 206.5430 | 206.5430 | 34.4238 | 256.32 KB |        1.00 |
| AddReferenceTypesWithForEach        | .NET 9.0  | .NET 9.0  | 10000 | 100.698 μs | 0.8446 μs | 0.7900 μs |  1.43 |    0.02 | 206.5430 | 206.5430 | 34.4238 | 256.32 KB |        1.00 |
| AddValueTypesPresetCapacity         | .NET 9.0  | .NET 9.0  | 10000 |  15.952 μs | 0.1977 μs | 0.1850 μs |  0.23 |    0.00 |   4.7607 |   0.9460 |       - |  78.18 KB |        0.31 |
| AddReferenceTypesPresetCapacity     | .NET 9.0  | .NET 9.0  | 10000 |  36.397 μs | 0.3574 μs | 0.3343 μs |  0.52 |    0.01 |   4.7607 |   0.9155 |       - |  78.18 KB |        0.31 |
| AddValueTypesWithAddRange           | .NET 9.0  | .NET 9.0  | 10000 |   3.979 μs | 0.0785 μs | 0.1333 μs |  0.06 |    0.00 |   4.7607 |   0.9499 |       - |  78.18 KB |        0.31 |
| AddReferenceTypesWithAddRange       | .NET 9.0  | .NET 9.0  | 10000 |   3.853 μs | 0.0765 μs | 0.0995 μs |  0.05 |    0.00 |   4.7607 |   0.9499 |       - |  78.18 KB |        0.31 |
| ValueTypesToListWithConstructor     | .NET 9.0  | .NET 9.0  | 10000 |   3.787 μs | 0.0755 μs | 0.1240 μs |  0.05 |    0.00 |   4.7607 |   0.9460 |       - |  78.18 KB |        0.31 |
| ReferenceTypesToListWithConstructor | .NET 9.0  | .NET 9.0  | 10000 |   3.864 μs | 0.0768 μs | 0.1101 μs |  0.05 |    0.00 |   4.7607 |   0.9460 |       - |  78.18 KB |        0.31 |
