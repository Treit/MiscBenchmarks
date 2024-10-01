# Move a random item to the front of the list, leaving the rest in existing order


```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27718.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-preview.6.24328.19
  [Host]     : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                                         | Count   | Mean             | Error            | StdDev           | Median           | Ratio  | RatioSD | Gen0   | Allocated  | Alloc Ratio |
|----------------------------------------------- |-------- |-----------------:|-----------------:|-----------------:|-----------------:|-------:|--------:|-------:|-----------:|------------:|
| **MoveUsingRandomIndex**                           | **5**       |         **537.9 ns** |         **10.52 ns** |         **12.52 ns** |         **533.6 ns** |   **1.00** |    **0.00** | **0.0696** |      **304 B** |        **1.00** |
| MoveUsingLinqOrderByRandomWithUnecessaryToList | 5       |         769.5 ns |          8.71 ns |          6.80 ns |         766.3 ns |   1.43 |    0.03 | 0.1907 |      824 B |        2.71 |
| MoveUsingCollectionsMarshal                    | 5       |         515.4 ns |          5.50 ns |          5.14 ns |         514.1 ns |   0.95 |    0.03 | 0.0696 |      304 B |        1.00 |
|                                                |         |                  |                  |                  |                  |        |         |        |            |             |
| **MoveUsingRandomIndex**                           | **100**     |         **546.6 ns** |          **5.95 ns** |          **5.56 ns** |         **546.9 ns** |   **1.00** |    **0.00** | **0.0696** |      **304 B** |        **1.00** |
| MoveUsingLinqOrderByRandomWithUnecessaryToList | 100     |       4,239.9 ns |         81.08 ns |         67.71 ns |       4,218.5 ns |   7.75 |    0.13 | 0.7172 |     3096 B |       10.18 |
| MoveUsingCollectionsMarshal                    | 100     |         514.8 ns |          6.04 ns |          5.35 ns |         513.8 ns |   0.94 |    0.01 | 0.0696 |      304 B |        1.00 |
|                                                |         |                  |                  |                  |                  |        |         |        |            |             |
| **MoveUsingRandomIndex**                           | **1000000** |     **929,834.9 ns** |     **51,352.98 ns** |    **148,165.09 ns** |     **873,086.0 ns** |   **1.00** |    **0.00** |      **-** |      **304 B** |        **1.00** |
| MoveUsingLinqOrderByRandomWithUnecessaryToList | 1000000 | 271,516,547.9 ns | 14,439,200.07 ns | 41,195,850.29 ns | 257,470,300.0 ns | 296.55 |   56.51 |      - | 24000829 B |   78,950.10 |
| MoveUsingCollectionsMarshal                    | 1000000 |     503,043.2 ns |     14,105.15 ns |     38,849.67 ns |     496,153.2 ns |   0.55 |    0.09 |      - |      304 B |        1.00 |
