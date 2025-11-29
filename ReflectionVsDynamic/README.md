

```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                | Mean      | Error     | StdDev    | Ratio | Gen0   | Allocated | Alloc Ratio |
|---------------------- |----------:|----------:|----------:|------:|-------:|----------:|------------:|
| Reflection            | 62.084 ns | 0.2871 ns | 0.2241 ns |  1.00 | 0.0067 |     112 B |        1.00 |
| ReflectionCached      | 39.395 ns | 0.2563 ns | 0.2272 ns |  0.63 | 0.0067 |     112 B |        1.00 |
| ReflectionCachedFully | 24.680 ns | 0.1004 ns | 0.0890 ns |  0.40 | 0.0014 |      24 B |        0.21 |
| WithSpanInvoker       |  4.280 ns | 0.0098 ns | 0.0082 ns |  0.07 |      - |         - |        0.00 |
| GeneratedFunc         |  1.783 ns | 0.0038 ns | 0.0031 ns |  0.03 |      - |         - |        0.00 |
| Dynamic               |  9.445 ns | 0.0411 ns | 0.0364 ns |  0.15 | 0.0014 |      24 B |        0.21 |
