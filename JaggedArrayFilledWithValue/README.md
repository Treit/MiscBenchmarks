# Jagged array filled with a specific value




```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26063.1)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.200
  [Host]     : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                                    | ElementCount | Mean             | Error            | StdDev           | Median           | Ratio | RatioSD | Gen0       | Gen1       | Gen2      | Allocated   | Alloc Ratio |
|------------------------------------------ |------------- |-----------------:|-----------------:|-----------------:|-----------------:|------:|--------:|-----------:|-----------:|----------:|------------:|------------:|
| **CreateJaggedArrayWithValueWithCancelCheck** | **10**           |         **286.9 ns** |          **5.74 ns** |          **7.26 ns** |         **285.0 ns** |  **2.43** |    **0.05** |     **0.1721** |          **-** |         **-** |       **744 B** |        **1.00** |
| CreateJaggedArrayWithValue                | 10           |         134.0 ns |          2.66 ns |          2.84 ns |         133.5 ns |  1.13 |    0.05 |     0.1724 |          - |         - |       744 B |        1.00 |
| CreateJaggedArrayWithValueWithArrayFill   | 10           |         118.2 ns |          2.40 ns |          3.11 ns |         117.0 ns |  1.00 |    0.00 |     0.1724 |          - |         - |       744 B |        1.00 |
|                                           |              |                  |                  |                  |                  |       |         |            |            |           |             |             |
| **CreateJaggedArrayWithValueWithCancelCheck** | **100**          |      **22,073.5 ns** |        **391.41 ns** |        **842.55 ns** |      **21,728.1 ns** |  **5.52** |    **0.27** |    **10.0098** |     **0.0610** |         **-** |     **43224 B** |        **1.00** |
| CreateJaggedArrayWithValue                | 100          |       8,203.5 ns |        163.74 ns |        315.47 ns |       8,201.8 ns |  2.04 |    0.08 |    10.0098 |     0.0305 |         - |     43224 B |        1.00 |
| CreateJaggedArrayWithValueWithArrayFill   | 100          |       4,006.4 ns |         79.89 ns |        168.52 ns |       3,941.2 ns |  1.00 |    0.00 |    10.0174 |     0.0153 |         - |     43224 B |        1.00 |
|                                           |              |                  |                  |                  |                  |       |         |            |            |           |             |             |
| **CreateJaggedArrayWithValueWithCancelCheck** | **10000**        | **300,525,379.8 ns** | **10,101,207.42 ns** | **28,819,313.16 ns** | **308,766,700.0 ns** |  **2.02** |    **0.26** | **67000.0000** | **62500.0000** | **4000.0000** | **400321568 B** |        **1.00** |
| CreateJaggedArrayWithValue                | 10000        | 162,392,604.6 ns |  3,178,358.70 ns |  6,976,574.39 ns | 160,568,000.0 ns |  1.14 |    0.07 | 67000.0000 | 62666.6667 | 4000.0000 | 400321501 B |        1.00 |
| CreateJaggedArrayWithValueWithArrayFill   | 10000        | 142,687,436.4 ns |  2,738,120.44 ns |  5,275,428.51 ns | 142,401,850.0 ns |  1.00 |    0.00 | 67500.0000 | 63500.0000 | 4250.0000 | 400321552 B |        1.00 |
