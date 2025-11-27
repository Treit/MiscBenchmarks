# Jagged array filled with a specific value







```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                    | Job       | Runtime   | ElementCount | Mean              | Error            | StdDev            | Median            | Ratio | RatioSD | Gen0       | Gen1       | Gen2       | Allocated   | Alloc Ratio |
|------------------------------------------ |---------- |---------- |------------- |------------------:|-----------------:|------------------:|------------------:|------:|--------:|-----------:|-----------:|-----------:|------------:|------------:|
| **CreateJaggedArrayWithValueWithCancelCheck** | **.NET 10.0** | **.NET 10.0** | **10**           |         **196.94 ns** |         **1.705 ns** |          **1.595 ns** |         **196.30 ns** |  **2.71** |    **0.05** |     **0.0443** |          **-** |          **-** |       **744 B** |        **1.00** |
| CreateJaggedArrayWithValue                | .NET 10.0 | .NET 10.0 | 10           |          99.34 ns |         1.322 ns |          1.237 ns |          99.10 ns |  1.37 |    0.03 |     0.0445 |     0.0001 |          - |       744 B |        1.00 |
| CreateJaggedArrayWithValueWithArrayFill   | .NET 10.0 | .NET 10.0 | 10           |          72.61 ns |         1.220 ns |          1.141 ns |          72.66 ns |  1.00 |    0.02 |     0.0445 |     0.0001 |          - |       744 B |        1.00 |
|                                           |           |           |              |                   |                  |                   |                   |       |         |            |            |            |             |             |
| CreateJaggedArrayWithValueWithCancelCheck | .NET 9.0  | .NET 9.0  | 10           |         198.07 ns |         3.689 ns |          3.451 ns |         197.54 ns |  2.78 |    0.07 |     0.0443 |          - |          - |       744 B |        1.00 |
| CreateJaggedArrayWithValue                | .NET 9.0  | .NET 9.0  | 10           |          99.21 ns |         1.500 ns |          1.403 ns |          99.24 ns |  1.39 |    0.03 |     0.0445 |     0.0001 |          - |       744 B |        1.00 |
| CreateJaggedArrayWithValueWithArrayFill   | .NET 9.0  | .NET 9.0  | 10           |          71.29 ns |         1.339 ns |          1.253 ns |          71.22 ns |  1.00 |    0.02 |     0.0445 |     0.0001 |          - |       744 B |        1.00 |
|                                           |           |           |              |                   |                  |                   |                   |       |         |            |            |            |             |             |
| **CreateJaggedArrayWithValueWithCancelCheck** | **.NET 10.0** | **.NET 10.0** | **100**          |      **14,055.41 ns** |        **95.658 ns** |         **89.478 ns** |      **14,080.64 ns** |  **5.20** |    **0.11** |     **2.5787** |     **0.3357** |          **-** |     **43224 B** |        **1.00** |
| CreateJaggedArrayWithValue                | .NET 10.0 | .NET 10.0 | 100          |       5,185.51 ns |       101.426 ns |        157.908 ns |       5,182.39 ns |  1.92 |    0.07 |     2.5787 |     0.3281 |          - |     43224 B |        1.00 |
| CreateJaggedArrayWithValueWithArrayFill   | .NET 10.0 | .NET 10.0 | 100          |       2,704.80 ns |        52.226 ns |         53.632 ns |       2,704.38 ns |  1.00 |    0.03 |     2.5826 |     0.3242 |          - |     43224 B |        1.00 |
|                                           |           |           |              |                   |                  |                   |                   |       |         |            |            |            |             |             |
| CreateJaggedArrayWithValueWithCancelCheck | .NET 9.0  | .NET 9.0  | 100          |      14,256.87 ns |       137.115 ns |        128.257 ns |      14,252.25 ns |  5.29 |    0.08 |     2.5787 |     0.3357 |          - |     43224 B |        1.00 |
| CreateJaggedArrayWithValue                | .NET 9.0  | .NET 9.0  | 100          |       5,198.81 ns |       103.049 ns |        141.055 ns |       5,182.53 ns |  1.93 |    0.06 |     2.5787 |     0.3281 |          - |     43224 B |        1.00 |
| CreateJaggedArrayWithValueWithArrayFill   | .NET 9.0  | .NET 9.0  | 100          |       2,695.55 ns |        37.821 ns |         35.378 ns |       2,696.31 ns |  1.00 |    0.02 |     2.5826 |     0.3242 |          - |     43224 B |        1.00 |
|                                           |           |           |              |                   |                  |                   |                   |       |         |            |            |            |             |             |
| **CreateJaggedArrayWithValueWithCancelCheck** | **.NET 10.0** | **.NET 10.0** | **10000**        | **319,770,538.64 ns** | **5,874,015.408 ns** |  **7,213,819.072 ns** | **318,812,700.00 ns** |  **1.47** |    **0.05** | **34000.0000** | **33000.0000** | **11000.0000** | **400323720 B** |        **1.00** |
| CreateJaggedArrayWithValue                | .NET 10.0 | .NET 10.0 | 10000        | 266,678,131.37 ns | 5,017,055.106 ns |  5,152,146.219 ns | 265,457,700.00 ns |  1.22 |    0.04 | 33333.3333 | 32666.6667 | 10333.3333 | 400323496 B |        1.00 |
| CreateJaggedArrayWithValueWithArrayFill   | .NET 10.0 | .NET 10.0 | 10000        | 218,188,938.89 ns | 3,902,895.986 ns |  5,074,867.647 ns | 218,634,000.00 ns |  1.00 |    0.03 | 33333.3333 | 32666.6667 | 10333.3333 | 400323496 B |        1.00 |
|                                           |           |           |              |                   |                  |                   |                   |       |         |            |            |            |             |             |
| CreateJaggedArrayWithValueWithCancelCheck | .NET 9.0  | .NET 9.0  | 10000        | 318,551,085.71 ns | 4,172,460.215 ns |  3,698,777.302 ns | 317,809,175.00 ns |  1.41 |    0.05 | 34000.0000 | 33000.0000 | 11000.0000 | 400323720 B |        1.00 |
| CreateJaggedArrayWithValue                | .NET 9.0  | .NET 9.0  | 10000        | 246,929,847.69 ns | 4,928,059.282 ns | 12,180,942.455 ns | 242,200,700.00 ns |  1.09 |    0.06 | 33333.3333 | 32666.6667 | 10333.3333 | 400323496 B |        1.00 |
| CreateJaggedArrayWithValueWithArrayFill   | .NET 9.0  | .NET 9.0  | 10000        | 226,225,954.90 ns | 4,392,935.176 ns |  7,093,772.033 ns | 227,009,116.67 ns |  1.00 |    0.04 | 33333.3333 | 32666.6667 | 10333.3333 | 400323496 B |        1.00 |
