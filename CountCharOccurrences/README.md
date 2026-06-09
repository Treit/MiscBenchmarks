# CharOccurrences

Compares three approaches for counting and ordering character occurrences in a string:

1. `GroupBy` + `Select` + `ToList` + `OrderBy` (the original LINQ-heavy version)
2. `CountBy` + `OrderBy` (.NET 9+)
3. A plain `Dictionary<char, int>` loop with `List.Sort`

```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.7079/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.204
  [Host]    : .NET 10.0.8 (10.0.826.23019), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.8 (10.0.826.23019), X64 RyuJIT AVX2

Job=.NET 10.0  Runtime=.NET 10.0  

```
| Method                    | Size | Mean      | Error     | StdDev    | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|-------------------------- |----- |----------:|----------:|----------:|------:|--------:|-------:|----------:|------------:|
| GroupByWithOccurencesItem | 500  | 11.761 μs | 0.2315 μs | 0.3738 μs |  1.00 |    0.04 | 0.7477 |  12.28 KB |        1.00 |
| CountBy                   | 500  |  4.566 μs | 0.0870 μs | 0.1100 μs |  0.39 |    0.02 | 0.1373 |   2.31 KB |        0.19 |
| DictionaryLoop            | 500  |  4.413 μs | 0.2389 μs | 0.7044 μs |  0.38 |    0.06 | 0.1297 |   2.16 KB |        0.18 |
