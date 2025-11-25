# Looking up configured values for an ASP.NET Core Route


```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                        | Count | Mean     | Error    | StdDev   | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|------------------------------ |------ |---------:|---------:|---------:|------:|--------:|-------:|----------:|------------:|
| MatchUrlsUsingTemplateMatcher | 100   | 19.04 μs | 0.194 μs | 0.181 μs |  1.18 |    0.02 | 0.0916 |    1920 B |          NA |
| MatchUrlsUsingRegex           | 100   | 16.12 μs | 0.179 μs | 0.168 μs |  1.00 |    0.01 |      - |         - |          NA |
