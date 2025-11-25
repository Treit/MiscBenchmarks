# Using unnecessary Select calls like `.Select(x => x)`




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                           | Count  | Mean           | Error        | StdDev       | Ratio | RatioSD | Gen0     | Gen1     | Gen2     | Allocated | Alloc Ratio |
|--------------------------------- |------- |---------------:|-------------:|-------------:|------:|--------:|---------:|---------:|---------:|----------:|------------:|
| **FilterWithJustWhere**              | **10**     |       **107.6 ns** |      **0.67 ns** |      **0.59 ns** |  **1.00** |    **0.01** |   **0.0124** |        **-** |        **-** |     **208 B** |        **1.00** |
| FilterWithUnnecessarySelectFirst | 10     |       155.4 ns |      1.50 ns |      1.33 ns |  1.44 |    0.01 |   0.0157 |        - |        - |     264 B |        1.27 |
|                                  |        |                |              |              |       |         |          |          |          |           |             |
| **FilterWithJustWhere**              | **100000** |   **780,057.5 ns** | **14,701.18 ns** | **13,751.49 ns** |  **1.00** |    **0.02** | **128.9063** | **128.9063** | **128.9063** |  **801156 B** |        **1.00** |
| FilterWithUnnecessarySelectFirst | 100000 | 1,012,127.4 ns | 20,240.14 ns | 22,496.86 ns |  1.30 |    0.04 | 144.5313 | 144.5313 | 144.5313 |  801335 B |        1.00 |
