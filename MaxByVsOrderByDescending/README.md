# MaxBy() vs. OrderByDescending().First()



```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3296/23H2/2023Update/SunValley3)
13th Gen Intel Core i7-1370P, 1 CPU, 20 logical and 14 physical cores
.NET SDK 8.0.202
  [Host]     : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX2


```
| Method                 | Count  | Mean         | Error        | StdDev       | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|----------------------- |------- |-------------:|-------------:|-------------:|------:|--------:|-------:|----------:|------------:|
| **MaxBy**                  | **100**    |     **473.6 ns** |      **9.10 ns** |     **14.96 ns** |  **1.00** |    **0.00** | **0.0029** |      **40 B** |        **1.00** |
| OrderByDescendingFirst | 100    |     563.9 ns |      9.68 ns |     11.52 ns |  1.18 |    0.05 | 0.0105 |     136 B |        3.40 |
|                        |        |              |              |              |       |         |        |           |             |
| **MaxBy**                  | **100000** | **462,974.9 ns** |  **7,491.63 ns** |  **6,641.13 ns** |  **1.00** |    **0.00** |      **-** |      **40 B** |        **1.00** |
| OrderByDescendingFirst | 100000 | 642,095.5 ns | 12,479.95 ns | 15,783.14 ns |  1.38 |    0.03 |      - |     136 B |        3.40 |
