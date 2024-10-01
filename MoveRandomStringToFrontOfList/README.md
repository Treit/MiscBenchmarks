# Move a random item to the front of the list, leaving the rest in existing order



```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27718.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-preview.6.24328.19
  [Host]     : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                                         | Count   | Mean              | Error            | StdDev            | Median            | Ratio    | RatioSD | Gen0   | Allocated  | Alloc Ratio |
|----------------------------------------------- |-------- |------------------:|-----------------:|------------------:|------------------:|---------:|--------:|-------:|-----------:|------------:|
| **MoveUsingLinqOrderByRandomWithUnecessaryToList** | **5**       |         **829.62 ns** |        **16.554 ns** |         **39.981 ns** |         **818.46 ns** |    **31.38** |    **2.01** | **0.1907** |      **824 B** |          **NA** |
| MoveUsingRandomIndex                           | 5       |         530.43 ns |         7.098 ns |          6.640 ns |         527.53 ns |    19.83 |    0.79 | 0.0696 |      304 B |          NA |
| MoveUsingCollectionsMarshal                    | 5       |         528.83 ns |        10.594 ns |         10.404 ns |         529.49 ns |    19.78 |    0.77 | 0.0696 |      304 B |          NA |
| MoveUsingCollectionsMarshalAndSharedRandom     | 5       |          26.59 ns |         0.601 ns |          0.936 ns |          26.27 ns |     1.00 |    0.00 |      - |          - |          NA |
|                                                |         |                   |                  |                   |                   |          |         |        |            |             |
| **MoveUsingLinqOrderByRandomWithUnecessaryToList** | **100**     |       **4,494.08 ns** |        **89.452 ns** |        **241.840 ns** |       **4,457.41 ns** |    **99.86** |    **3.76** | **0.7172** |     **3096 B** |          **NA** |
| MoveUsingRandomIndex                           | 100     |         583.39 ns |        11.588 ns |         23.932 ns |         583.14 ns |    13.56 |    0.42 | 0.0696 |      304 B |          NA |
| MoveUsingCollectionsMarshal                    | 100     |         528.62 ns |         9.175 ns |         10.566 ns |         530.06 ns |    12.26 |    0.33 | 0.0696 |      304 B |          NA |
| MoveUsingCollectionsMarshalAndSharedRandom     | 100     |          43.05 ns |         0.781 ns |          0.652 ns |          43.02 ns |     1.00 |    0.00 |      - |          - |          NA |
|                                                |         |                   |                  |                   |                   |          |         |        |            |             |
| **MoveUsingLinqOrderByRandomWithUnecessaryToList** | **1000000** | **239,864,207.53 ns** | **6,095,922.145 ns** | **17,293,116.494 ns** | **231,849,066.67 ns** | **1,182.39** |  **108.84** |      **-** | **24000733 B** |          **NA** |
| MoveUsingRandomIndex                           | 1000000 |     910,403.01 ns |    29,666.038 ns |     83,673.587 ns |     903,627.49 ns |     4.51 |    0.51 |      - |      304 B |          NA |
| MoveUsingCollectionsMarshal                    | 1000000 |     488,304.22 ns |     9,050.197 ns |     13,545.909 ns |     486,468.75 ns |     2.33 |    0.20 |      - |      304 B |          NA |
| MoveUsingCollectionsMarshalAndSharedRandom     | 1000000 |     202,910.59 ns |     4,458.490 ns |     12,354.454 ns |     198,901.00 ns |     1.00 |    0.00 |      - |          - |          NA |
