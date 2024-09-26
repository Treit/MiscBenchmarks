# Looking up configured values for an ASP.NET Core Route

```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27713.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-preview.6.24328.19
  [Host]     : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                        | Count | Mean     | Error    | StdDev   | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|------------------------------ |------ |---------:|---------:|---------:|------:|--------:|-------:|----------:|------------:|
| MatchUrlsUsingTemplateMatcher | 100   | 52.50 μs | 1.621 μs | 4.493 μs |  2.40 |    0.19 | 0.4272 |    1920 B |       48.00 |
| MatchUrlsUsingRegex           | 100   | 23.61 μs | 0.404 μs | 0.449 μs |  1.00 |    0.00 |      - |      40 B |        1.00 |
