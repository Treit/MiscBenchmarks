# Jagged array filled with a specific value






```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                    | ElementCount | Mean              | Error            | StdDev           | Ratio | RatioSD | Gen0       | Gen1       | Gen2      | Allocated   | Alloc Ratio |
|------------------------------------------ |------------- |------------------:|-----------------:|-----------------:|------:|--------:|-----------:|-----------:|----------:|------------:|------------:|
| **CreateJaggedArrayWithValueWithCancelCheck** | **10**           |         **197.18 ns** |         **2.021 ns** |         **1.890 ns** |  **2.69** |    **0.05** |     **0.0443** |          **-** |         **-** |       **744 B** |        **1.00** |
| CreateJaggedArrayWithValue                | 10           |         100.54 ns |         0.706 ns |         0.660 ns |  1.37 |    0.03 |     0.0445 |     0.0001 |         - |       744 B |        1.00 |
| CreateJaggedArrayWithValueWithArrayFill   | 10           |          73.25 ns |         1.387 ns |         1.297 ns |  1.00 |    0.02 |     0.0445 |     0.0001 |         - |       744 B |        1.00 |
|                                           |              |                   |                  |                  |       |         |            |            |           |             |             |
| **CreateJaggedArrayWithValueWithCancelCheck** | **100**          |      **14,027.26 ns** |        **75.800 ns** |        **67.195 ns** |  **4.97** |    **0.08** |     **2.5787** |     **0.3357** |         **-** |     **43224 B** |        **1.00** |
| CreateJaggedArrayWithValue                | 100          |       5,159.31 ns |       102.568 ns |       140.397 ns |  1.83 |    0.06 |     2.5787 |     0.3281 |         - |     43224 B |        1.00 |
| CreateJaggedArrayWithValueWithArrayFill   | 100          |       2,824.53 ns |        46.314 ns |        43.322 ns |  1.00 |    0.02 |     2.5826 |     0.3242 |         - |     43224 B |        1.00 |
|                                           |              |                   |                  |                  |       |         |            |            |           |             |             |
| **CreateJaggedArrayWithValueWithCancelCheck** | **10000**        | **259,084,550.00 ns** | **4,954,286.871 ns** | **4,865,772.157 ns** |  **2.09** |    **0.11** | **26500.0000** | **26000.0000** | **3000.0000** | **400321032 B** |        **1.00** |
| CreateJaggedArrayWithValue                | 10000        | 148,068,704.49 ns | 3,438,986.279 ns | 9,529,415.475 ns |  1.19 |    0.10 | 26000.0000 | 25666.6667 | 2333.3333 | 400320808 B |        1.00 |
| CreateJaggedArrayWithValueWithArrayFill   | 10000        | 124,339,100.30 ns | 2,465,189.383 ns | 5,858,783.824 ns |  1.00 |    0.07 | 26800.0000 | 26600.0000 | 3000.0000 | 400321032 B |        1.00 |
