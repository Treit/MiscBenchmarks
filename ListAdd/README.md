# Adding items to a list



```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27703.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-preview.6.24328.19
  [Host]     : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                          | Count   | Mean            | Error         | StdDev         | Median          | Ratio | RatioSD | Gen0      | Gen1     | Gen2     | Allocated  | Alloc Ratio |
|-------------------------------- |-------- |----------------:|--------------:|---------------:|----------------:|------:|--------:|----------:|---------:|---------:|-----------:|------------:|
| **AddToListWithForEachLoop**        | **100**     |       **546.82 ns** |     **15.829 ns** |      **44.647 ns** |       **535.86 ns** | **10.72** |    **1.03** |    **0.2832** |        **-** |        **-** |     **1224 B** |        **2.68** |
| AddToListPresetCapacity         | 100     |       407.31 ns |     13.248 ns |      39.063 ns |       394.99 ns |  8.33 |    0.87 |    0.1149 |        - |        - |      496 B |        1.09 |
| AddToListWithToListDotForEach   | 100     |       472.55 ns |      7.960 ns |       7.056 ns |       471.70 ns |  9.47 |    0.55 |    0.4005 |        - |        - |     1728 B |        3.79 |
| AddToListWithAddRange           | 100     |        57.08 ns |      1.176 ns |       1.865 ns |        56.86 ns |  1.12 |    0.06 |    0.1057 |        - |        - |      456 B |        1.00 |
| AddToListPresetCapacityAddRange | 100     |        61.78 ns |      2.557 ns |       7.213 ns |        59.28 ns |  1.23 |    0.15 |    0.1057 |        - |        - |      456 B |        1.00 |
| AddToListWithConstructor        | 100     |        50.36 ns |      1.006 ns |       2.467 ns |        50.09 ns |  1.00 |    0.00 |    0.1057 |        - |        - |      456 B |        1.00 |
|                                 |         |                 |               |                |                 |       |         |           |          |          |            |             |
| **AddToListWithForEachLoop**        | **1000000** | **5,371,783.78 ns** | **91,542.159 ns** | **145,195.566 ns** | **5,328,656.25 ns** |  **5.19** |    **0.36** |  **523.4375** | **500.0000** | **492.1875** |  **8389274 B** |        **2.10** |
| AddToListPresetCapacity         | 1000000 | 3,100,586.15 ns | 59,028.354 ns |  70,269.056 ns | 3,110,784.57 ns |  3.03 |    0.22 |  324.2188 | 324.2188 | 324.2188 |  4001950 B |        1.00 |
| AddToListWithToListDotForEach   | 1000000 | 4,675,294.63 ns | 91,712.297 ns | 176,698.461 ns | 4,636,741.41 ns |  4.20 |    0.63 | 1015.6250 | 984.3750 | 984.3750 | 12389537 B |        3.10 |
| AddToListWithAddRange           | 1000000 | 1,121,702.76 ns | 49,732.723 ns | 146,638.056 ns | 1,077,549.71 ns |  0.97 |    0.10 |  330.0781 | 330.0781 | 330.0781 |  4000163 B |        1.00 |
| AddToListPresetCapacityAddRange | 1000000 | 1,263,598.35 ns | 61,436.573 ns | 181,147.122 ns | 1,294,988.18 ns |  1.10 |    0.22 |  314.4531 | 314.4531 | 314.4531 |  4000155 B |        1.00 |
| AddToListWithConstructor        | 1000000 | 1,166,665.42 ns | 47,424.777 ns | 139,833.024 ns | 1,164,812.50 ns |  1.00 |    0.00 |  326.1719 | 326.1719 | 326.1719 |  4000159 B |        1.00 |
