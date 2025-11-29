# Move a random item to the front of the list, leaving the rest in existing order






```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                         | Job       | Runtime   | Count   | Mean              | Error            | StdDev           | Ratio    | RatioSD | Gen0   | Allocated  | Alloc Ratio |
|----------------------------------------------- |---------- |---------- |-------- |------------------:|-----------------:|-----------------:|---------:|--------:|-------:|-----------:|------------:|
| **MoveUsingLinqOrderByRandomWithUnecessaryToList** | **.NET 10.0** | **.NET 10.0** | **5**       |         **511.96 ns** |         **3.062 ns** |         **2.715 ns** |    **21.53** |    **0.30** | **0.0505** |      **856 B** |          **NA** |
| MoveUsingRandomIndex                           | .NET 10.0 | .NET 10.0 | 5       |         362.50 ns |         2.255 ns |         1.883 ns |    15.24 |    0.21 | 0.0181 |      304 B |          NA |
| MoveUsingCollectionsMarshal                    | .NET 10.0 | .NET 10.0 | 5       |         344.97 ns |         1.394 ns |         1.235 ns |    14.51 |    0.20 | 0.0181 |      304 B |          NA |
| MoveUsingCollectionsMarshalAndSharedRandom     | .NET 10.0 | .NET 10.0 | 5       |          23.79 ns |         0.349 ns |         0.326 ns |     1.00 |    0.02 |      - |          - |          NA |
|                                                |           |           |         |                   |                  |                  |          |         |        |            |             |
| MoveUsingLinqOrderByRandomWithUnecessaryToList | .NET 9.0  | .NET 9.0  | 5       |         516.97 ns |         3.093 ns |         2.742 ns |    21.79 |    0.17 | 0.0505 |      856 B |          NA |
| MoveUsingRandomIndex                           | .NET 9.0  | .NET 9.0  | 5       |         367.82 ns |         3.194 ns |         2.987 ns |    15.50 |    0.15 | 0.0181 |      304 B |          NA |
| MoveUsingCollectionsMarshal                    | .NET 9.0  | .NET 9.0  | 5       |         340.46 ns |         1.711 ns |         1.517 ns |    14.35 |    0.10 | 0.0181 |      304 B |          NA |
| MoveUsingCollectionsMarshalAndSharedRandom     | .NET 9.0  | .NET 9.0  | 5       |          23.73 ns |         0.147 ns |         0.138 ns |     1.00 |    0.01 |      - |          - |          NA |
|                                                |           |           |         |                   |                  |                  |          |         |        |            |             |
| **MoveUsingLinqOrderByRandomWithUnecessaryToList** | **.NET 10.0** | **.NET 10.0** | **100**     |       **2,652.73 ns** |        **15.105 ns** |        **12.613 ns** |    **67.98** |    **0.47** | **0.1869** |     **3128 B** |          **NA** |
| MoveUsingRandomIndex                           | .NET 10.0 | .NET 10.0 | 100     |         340.83 ns |         1.908 ns |         1.785 ns |     8.73 |    0.06 | 0.0181 |      304 B |          NA |
| MoveUsingCollectionsMarshal                    | .NET 10.0 | .NET 10.0 | 100     |         319.73 ns |         2.075 ns |         1.840 ns |     8.19 |    0.06 | 0.0181 |      304 B |          NA |
| MoveUsingCollectionsMarshalAndSharedRandom     | .NET 10.0 | .NET 10.0 | 100     |          39.03 ns |         0.220 ns |         0.206 ns |     1.00 |    0.01 |      - |          - |          NA |
|                                                |           |           |         |                   |                  |                  |          |         |        |            |             |
| MoveUsingLinqOrderByRandomWithUnecessaryToList | .NET 9.0  | .NET 9.0  | 100     |       2,675.10 ns |        17.655 ns |        16.514 ns |    68.58 |    0.44 | 0.1869 |     3128 B |          NA |
| MoveUsingRandomIndex                           | .NET 9.0  | .NET 9.0  | 100     |         360.56 ns |         2.519 ns |         2.356 ns |     9.24 |    0.06 | 0.0181 |      304 B |          NA |
| MoveUsingCollectionsMarshal                    | .NET 9.0  | .NET 9.0  | 100     |         355.46 ns |         2.190 ns |         2.048 ns |     9.11 |    0.05 | 0.0181 |      304 B |          NA |
| MoveUsingCollectionsMarshalAndSharedRandom     | .NET 9.0  | .NET 9.0  | 100     |          39.01 ns |         0.101 ns |         0.090 ns |     1.00 |    0.00 |      - |          - |          NA |
|                                                |           |           |         |                   |                  |                  |          |         |        |            |             |
| **MoveUsingLinqOrderByRandomWithUnecessaryToList** | **.NET 10.0** | **.NET 10.0** | **1000000** | **161,148,179.17 ns** | **3,214,348.449 ns** | **4,179,561.282 ns** | **1,662.45** |   **44.17** |      **-** | **24000728 B** |          **NA** |
| MoveUsingRandomIndex                           | .NET 10.0 | .NET 10.0 | 1000000 |     380,412.66 ns |     1,666.918 ns |     1,559.236 ns |     3.92 |    0.03 |      - |      304 B |          NA |
| MoveUsingCollectionsMarshal                    | .NET 10.0 | .NET 10.0 | 1000000 |     190,010.29 ns |       782.661 ns |       732.102 ns |     1.96 |    0.02 |      - |      304 B |          NA |
| MoveUsingCollectionsMarshalAndSharedRandom     | .NET 10.0 | .NET 10.0 | 1000000 |      96,940.02 ns |       827.424 ns |       773.973 ns |     1.00 |    0.01 |      - |          - |          NA |
|                                                |           |           |         |                   |                  |                  |          |         |        |            |             |
| MoveUsingLinqOrderByRandomWithUnecessaryToList | .NET 9.0  | .NET 9.0  | 1000000 | 190,764,638.71 ns | 1,210,299.037 ns | 1,848,254.609 ns | 1,950.26 |   26.09 |      - | 24000728 B |          NA |
| MoveUsingRandomIndex                           | .NET 9.0  | .NET 9.0  | 1000000 |     382,355.45 ns |     1,578.469 ns |     1,399.271 ns |     3.91 |    0.04 |      - |      304 B |          NA |
| MoveUsingCollectionsMarshal                    | .NET 9.0  | .NET 9.0  | 1000000 |     189,409.13 ns |       705.309 ns |       625.238 ns |     1.94 |    0.02 |      - |      304 B |          NA |
| MoveUsingCollectionsMarshalAndSharedRandom     | .NET 9.0  | .NET 9.0  | 1000000 |      97,823.65 ns |     1,063.122 ns |       942.430 ns |     1.00 |    0.01 |      - |          - |          NA |
