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
| **MoveUsingLinqOrderByRandomWithUnecessaryToList** | **5**       |         **538.79 ns** |         **5.278 ns** |         **4.937 ns** |    **22.82** |    **0.22** | **0.0505** |      **856 B** |          **NA** |
| MoveUsingRandomIndex                           | 5       |         376.50 ns |         3.857 ns |         3.608 ns |    15.94 |    0.16 | 0.0181 |      304 B |          NA |
| MoveUsingCollectionsMarshal                    | 5       |         361.63 ns |         2.950 ns |         2.759 ns |    15.31 |    0.13 | 0.0181 |      304 B |          NA |
| MoveUsingCollectionsMarshalAndSharedRandom     | 5       |          23.62 ns |         0.115 ns |         0.102 ns |     1.00 |    0.01 |      - |          - |          NA |
|                                                |         |                   |                  |                  |          |         |        |            |             |
| **MoveUsingLinqOrderByRandomWithUnecessaryToList** | **100**     |       **2,689.52 ns** |        **35.686 ns** |        **33.381 ns** |    **68.37** |    **0.91** | **0.1869** |     **3128 B** |          **NA** |
| MoveUsingRandomIndex                           | 100     |         372.99 ns |         3.232 ns |         2.699 ns |     9.48 |    0.09 | 0.0181 |      304 B |          NA |
| MoveUsingCollectionsMarshal                    | 100     |         360.62 ns |         3.249 ns |         2.880 ns |     9.17 |    0.09 | 0.0181 |      304 B |          NA |
| MoveUsingCollectionsMarshalAndSharedRandom     | 100     |          39.34 ns |         0.245 ns |         0.230 ns |     1.00 |    0.01 |      - |          - |          NA |
|                                                |         |                   |                  |                  |          |         |        |            |             |
| **MoveUsingLinqOrderByRandomWithUnecessaryToList** | **1000000** | **160,394,508.00 ns** | **1,029,874.964 ns** | **1,374,853.612 ns** | **1,629.41** |   **18.36** |      **-** | **24000728 B** |          **NA** |
| MoveUsingRandomIndex                           | 1000000 |     385,495.94 ns |     1,958.213 ns |     1,831.714 ns |     3.92 |    0.03 |      - |      304 B |          NA |
| MoveUsingCollectionsMarshal                    | 1000000 |     191,547.01 ns |       664.175 ns |       621.269 ns |     1.95 |    0.02 |      - |      304 B |          NA |
| MoveUsingCollectionsMarshalAndSharedRandom     | 1000000 |      98,442.53 ns |       810.390 ns |       758.039 ns |     1.00 |    0.01 |      - |          - |          NA |
