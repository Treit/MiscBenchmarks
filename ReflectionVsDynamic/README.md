
```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                | Mean      | Error     | StdDev    | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|---------------------- |----------:|----------:|----------:|------:|--------:|-------:|----------:|------------:|
| Reflection            | 64.155 ns | 1.0278 ns | 0.9614 ns |  1.00 |    0.02 | 0.0067 |     112 B |        1.00 |
| ReflectionCached      | 37.580 ns | 0.5302 ns | 0.4960 ns |  0.59 |    0.01 | 0.0067 |     112 B |        1.00 |
| ReflectionCachedFully | 28.764 ns | 0.1983 ns | 0.1855 ns |  0.45 |    0.01 | 0.0014 |      24 B |        0.21 |
| WithSpanInvoker       |  4.328 ns | 0.0250 ns | 0.0222 ns |  0.07 |    0.00 |      - |         - |        0.00 |
| GeneratedFunc         |  1.831 ns | 0.0387 ns | 0.0362 ns |  0.03 |    0.00 |      - |         - |        0.00 |
| Dynamic               |  9.672 ns | 0.1164 ns | 0.1089 ns |  0.15 |    0.00 | 0.0014 |      24 B |        0.21 |
