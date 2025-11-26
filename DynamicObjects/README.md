# Dynamic vs regular C# types





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                 | Size | Mean      | Error     | StdDev    | Ratio | RatioSD | Gen0      | Gen1      | Gen2     | Allocated | Alloc Ratio |
|----------------------- |----- |----------:|----------:|----------:|------:|--------:|----------:|----------:|---------:|----------:|------------:|
| InitJaggedArray        | 1024 |  2.216 ms | 0.0531 ms | 0.1548 ms |  1.00 |    0.10 |   62.5000 |   27.3438 |        - |   1.03 MB |        1.00 |
| InitDynamicJaggedArray | 1024 | 63.475 ms | 1.2524 ms | 1.6719 ms | 28.78 |    2.17 | 2750.0000 | 2625.0000 | 750.0000 |  32.03 MB |       31.06 |
