# Using unnecessary Select calls like `.Select(x => x)`





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                           | Count  | Mean         | Error        | StdDev       | Ratio | RatioSD | Gen0     | Gen1     | Gen2     | Allocated | Alloc Ratio |
|--------------------------------- |------- |-------------:|-------------:|-------------:|------:|--------:|---------:|---------:|---------:|----------:|------------:|
| **FilterWithJustWhere**              | **10**     |     **113.2 ns** |      **0.96 ns** |      **0.85 ns** |  **1.00** |    **0.01** |   **0.0124** |        **-** |        **-** |     **208 B** |        **1.00** |
| FilterWithUnnecessarySelectFirst | 10     |     159.2 ns |      2.25 ns |      2.00 ns |  1.41 |    0.02 |   0.0157 |        - |        - |     264 B |        1.27 |
|                                  |        |              |              |              |       |         |          |          |          |           |             |
| **FilterWithJustWhere**              | **100000** | **794,217.7 ns** |  **9,132.82 ns** |  **7,626.32 ns** |  **1.00** |    **0.01** | **133.7891** | **133.7891** | **133.7891** |  **801154 B** |        **1.00** |
| FilterWithUnnecessarySelectFirst | 100000 | 975,348.1 ns | 11,482.14 ns | 10,178.62 ns |  1.23 |    0.02 | 144.5313 | 144.5313 | 144.5313 |  801384 B |        1.00 |
