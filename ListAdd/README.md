# Adding items to a list




```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27783.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.102
  [Host]     : .NET 8.0.12 (8.0.1224.60305), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.12 (8.0.1224.60305), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                          | Count | Mean      | Error    | StdDev    | Median    | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|-------------------------------- |------ |----------:|---------:|----------:|----------:|------:|--------:|-------:|----------:|------------:|
| AddToListWithForEachLoop        | 100   | 462.36 ns | 9.412 ns | 27.306 ns | 450.34 ns | 10.21 |    0.70 | 0.2832 |    1224 B |        2.68 |
| AddToListPresetCapacity         | 100   | 331.27 ns | 6.493 ns |  6.947 ns | 331.88 ns |  7.00 |    0.31 | 0.1149 |     496 B |        1.09 |
| AddToListWithToListDotForEach   | 100   | 430.56 ns | 8.655 ns |  6.758 ns | 431.48 ns |  9.06 |    0.36 | 0.4005 |    1728 B |        3.79 |
| AddToListWithAddRange           | 100   |  47.96 ns | 0.937 ns |  0.920 ns |  47.83 ns |  1.02 |    0.06 | 0.1057 |     456 B |        1.00 |
| AddToListPresetCapacityAddRange | 100   |  48.19 ns | 0.985 ns |  1.413 ns |  47.84 ns |  1.03 |    0.05 | 0.1057 |     456 B |        1.00 |
| ToList                          | 100   |  53.83 ns | 1.099 ns |  2.009 ns |  53.56 ns |  1.17 |    0.05 | 0.1057 |     456 B |        1.00 |
| AddToListWithConstructor        | 100   |  46.27 ns | 0.967 ns |  2.221 ns |  45.87 ns |  1.00 |    0.00 | 0.1057 |     456 B |        1.00 |
