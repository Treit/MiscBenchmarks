# Looking up configured values for an ASP.NET Core Route




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                        | Job       | Runtime   | Count | Mean     | Error    | StdDev   | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|------------------------------ |---------- |---------- |------ |---------:|---------:|---------:|------:|--------:|-------:|----------:|------------:|
| MatchUrlsUsingTemplateMatcher | .NET 10.0 | .NET 10.0 | 100   | 18.86 μs | 0.159 μs | 0.149 μs |  1.17 |    0.01 | 0.0916 |    1920 B |          NA |
| MatchUrlsUsingRegex           | .NET 10.0 | .NET 10.0 | 100   | 16.15 μs | 0.179 μs | 0.167 μs |  1.00 |    0.01 |      - |         - |          NA |
|                               |           |           |       |          |          |          |       |         |        |           |             |
| MatchUrlsUsingTemplateMatcher | .NET 9.0  | .NET 9.0  | 100   | 19.24 μs | 0.210 μs | 0.196 μs |  1.16 |    0.02 | 0.0916 |    1920 B |          NA |
| MatchUrlsUsingRegex           | .NET 9.0  | .NET 9.0  | 100   | 16.64 μs | 0.165 μs | 0.146 μs |  1.00 |    0.01 |      - |         - |          NA |
