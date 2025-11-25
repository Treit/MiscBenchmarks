# Move a random item to the front of the list, leaving the rest in existing order




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                         | Count   | Mean              | Error            | StdDev           | Ratio    | RatioSD | Gen0   | Allocated  | Alloc Ratio |
|----------------------------------------------- |-------- |------------------:|-----------------:|-----------------:|---------:|--------:|-------:|-----------:|------------:|
| **MoveUsingLinqOrderByRandomWithUnecessaryToList** | **5**       |         **542.00 ns** |         **5.492 ns** |         **4.869 ns** |    **23.10** |    **0.21** | **0.0505** |      **856 B** |          **NA** |
| MoveUsingRandomIndex                           | 5       |         368.66 ns |         2.821 ns |         2.639 ns |    15.71 |    0.12 | 0.0181 |      304 B |          NA |
| MoveUsingCollectionsMarshal                    | 5       |         361.19 ns |         3.863 ns |         3.614 ns |    15.39 |    0.16 | 0.0181 |      304 B |          NA |
| MoveUsingCollectionsMarshalAndSharedRandom     | 5       |          23.46 ns |         0.079 ns |         0.074 ns |     1.00 |    0.00 |      - |          - |          NA |
|                                                |         |                   |                  |                  |          |         |        |            |             |
| **MoveUsingLinqOrderByRandomWithUnecessaryToList** | **100**     |       **2,644.98 ns** |        **21.202 ns** |        **19.832 ns** |    **67.52** |    **0.60** | **0.1869** |     **3128 B** |          **NA** |
| MoveUsingRandomIndex                           | 100     |         351.97 ns |         2.062 ns |         1.828 ns |     8.98 |    0.06 | 0.0181 |      304 B |          NA |
| MoveUsingCollectionsMarshal                    | 100     |         352.61 ns |         3.127 ns |         2.925 ns |     9.00 |    0.09 | 0.0181 |      304 B |          NA |
| MoveUsingCollectionsMarshalAndSharedRandom     | 100     |          39.17 ns |         0.217 ns |         0.203 ns |     1.00 |    0.01 |      - |          - |          NA |
|                                                |         |                   |                  |                  |          |         |        |            |             |
| **MoveUsingLinqOrderByRandomWithUnecessaryToList** | **1000000** | **167,426,817.20 ns** | **1,685,814.167 ns** | **2,574,416.494 ns** | **1,709.59** |   **28.17** |      **-** | **24000728 B** |          **NA** |
| MoveUsingRandomIndex                           | 1000000 |     385,315.21 ns |       718.790 ns |       637.189 ns |     3.93 |    0.03 |      - |      304 B |          NA |
| MoveUsingCollectionsMarshal                    | 1000000 |     189,088.00 ns |       765.163 ns |       678.297 ns |     1.93 |    0.01 |      - |      304 B |          NA |
| MoveUsingCollectionsMarshalAndSharedRandom     | 1000000 |      97,937.87 ns |       699.628 ns |       654.433 ns |     1.00 |    0.01 |      - |          - |          NA |
