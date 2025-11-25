# Jagged array filled with a specific value





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                    | ElementCount | Mean              | Error            | StdDev            | Ratio | RatioSD | Gen0       | Gen1       | Gen2      | Allocated   | Alloc Ratio |
|------------------------------------------ |------------- |------------------:|-----------------:|------------------:|------:|--------:|-----------:|-----------:|----------:|------------:|------------:|
| **CreateJaggedArrayWithValueWithCancelCheck** | **10**           |         **195.59 ns** |         **1.881 ns** |          **1.668 ns** |  **2.69** |    **0.05** |     **0.0443** |          **-** |         **-** |       **744 B** |        **1.00** |
| CreateJaggedArrayWithValue                | 10           |          99.65 ns |         1.046 ns |          0.979 ns |  1.37 |    0.03 |     0.0445 |     0.0001 |         - |       744 B |        1.00 |
| CreateJaggedArrayWithValueWithArrayFill   | 10           |          72.72 ns |         1.421 ns |          1.329 ns |  1.00 |    0.03 |     0.0445 |     0.0001 |         - |       744 B |        1.00 |
|                                           |              |                   |                  |                   |       |         |            |            |           |             |             |
| **CreateJaggedArrayWithValueWithCancelCheck** | **100**          |      **13,965.08 ns** |        **40.574 ns** |         **33.881 ns** |  **5.12** |    **0.08** |     **2.5787** |     **0.3357** |         **-** |     **43224 B** |        **1.00** |
| CreateJaggedArrayWithValue                | 100          |       5,295.90 ns |       105.273 ns |        136.885 ns |  1.94 |    0.06 |     2.5787 |     0.3281 |         - |     43224 B |        1.00 |
| CreateJaggedArrayWithValueWithArrayFill   | 100          |       2,726.55 ns |        48.530 ns |         43.020 ns |  1.00 |    0.02 |     2.5826 |     0.3242 |         - |     43224 B |        1.00 |
|                                           |              |                   |                  |                   |       |         |            |            |           |             |             |
| **CreateJaggedArrayWithValueWithCancelCheck** | **10000**        | **244,536,553.50 ns** | **5,234,468.872 ns** | **15,433,950.690 ns** |  **1.90** |    **0.13** | **26500.0000** | **26000.0000** | **3000.0000** | **400321032 B** |        **1.00** |
| CreateJaggedArrayWithValue                | 10000        | 155,018,432.66 ns | 4,358,759.060 ns | 12,783,486.721 ns |  1.20 |    0.10 | 26000.0000 | 25666.6667 | 2333.3333 | 400320808 B |        1.00 |
| CreateJaggedArrayWithValueWithArrayFill   | 10000        | 128,852,716.47 ns | 2,574,183.507 ns |  2,643,496.940 ns |  1.00 |    0.03 | 26800.0000 | 26600.0000 | 3000.0000 | 400321032 B |        1.00 |
