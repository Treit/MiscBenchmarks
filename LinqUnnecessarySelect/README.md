# Linq 'All' vs 'Except' to find if one list is a subset of another



```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3447/23H2/2023Update/SunValley3)
13th Gen Intel Core i7-1370P, 1 CPU, 20 logical and 14 physical cores
.NET SDK 8.0.204
  [Host]     : .NET 8.0.4 (8.0.424.16909), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.4 (8.0.424.16909), X64 RyuJIT AVX2


```
| Method                           | Count  | Mean            | Error         | StdDev        | Ratio | RatioSD | Gen0     | Gen1     | Gen2     | Allocated | Alloc Ratio |
|--------------------------------- |------- |----------------:|--------------:|--------------:|------:|--------:|---------:|---------:|---------:|----------:|------------:|
| **FilterWithJustWhere**              | **10**     |        **84.28 ns** |      **1.645 ns** |      **1.538 ns** |  **1.00** |    **0.00** |   **0.0318** |        **-** |        **-** |     **400 B** |        **1.00** |
| FilterWithUnnecessarySelectFirst | 10     |       157.72 ns |      3.024 ns |      2.829 ns |  1.87 |    0.05 |   0.0362 |        - |        - |     456 B |        1.14 |
|                                  |        |                 |               |               |       |         |          |          |          |           |             |
| **FilterWithJustWhere**              | **100000** |   **494,782.60 ns** |  **7,018.747 ns** |  **6,565.341 ns** |  **1.00** |    **0.00** | **257.8125** | **247.0703** | **247.0703** | **2099084 B** |        **1.00** |
| FilterWithUnnecessarySelectFirst | 100000 | 1,110,371.27 ns | 21,040.221 ns | 25,839.281 ns |  2.24 |    0.07 | 335.9375 | 328.1250 | 326.1719 | 2097780 B |        1.00 |
