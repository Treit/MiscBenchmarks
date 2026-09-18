# String.Create versus interpolation

This benchmark compares three ways to create a query string that contains a capped positive page size and an escaped API version:

- Plain string interpolation
- `string.Create` with `CultureInfo.InvariantCulture`
- A dictionary passed to `FormUrlEncodedContent`, followed by `ReadAsStringAsync`

Each method executes its complete query construction inside the measured operation. The page-size parameters cover values below and above the cap.

```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.7582/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.401
  [Host]    : .NET 10.0.12 (10.0.1226.42308), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.12 (10.0.1226.42308), X64 RyuJIT AVX2

Job=.NET 10.0  Runtime=.NET 10.0  

```
| Method                          | PageSize | Mean      | Error     | StdDev    | Median    | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|-------------------------------- |--------- |----------:|----------:|----------:|----------:|------:|--------:|-------:|----------:|------------:|
| **PlainInterpolation**              | **25**       |  **56.68 ns** |  **1.196 ns** |  **3.374 ns** |  **56.91 ns** |  **1.00** |    **0.08** | **0.0091** |     **152 B** |        **1.00** |
| StringCreateInvariantCulture    | 25       |  59.16 ns |  1.828 ns |  5.067 ns |  57.60 ns |  1.05 |    0.11 | 0.0091 |     152 B |        1.00 |
| FormUrlEncodedContentDictionary | 25       | 459.80 ns | 14.361 ns | 42.345 ns | 451.42 ns |  8.14 |    0.89 | 0.0696 |    1168 B |        7.68 |
|                                 |          |           |           |           |           |       |         |        |           |             |
| **PlainInterpolation**              | **1000**     |  **58.45 ns** |  **2.384 ns** |  **6.992 ns** |  **57.37 ns** |  **1.01** |    **0.17** | **0.0091** |     **152 B** |        **1.00** |
| StringCreateInvariantCulture    | 1000     |  55.69 ns |  1.274 ns |  3.636 ns |  55.79 ns |  0.97 |    0.13 | 0.0091 |     152 B |        1.00 |
| FormUrlEncodedContentDictionary | 1000     | 455.67 ns | 11.135 ns | 32.831 ns | 451.09 ns |  7.90 |    1.05 | 0.0706 |    1184 B |        7.79 |
