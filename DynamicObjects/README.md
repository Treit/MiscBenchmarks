# Dynamic vs regular C# types






```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                 | Job       | Runtime   | Size | Mean      | Error     | StdDev    | Ratio | RatioSD | Gen0      | Gen1      | Gen2     | Allocated | Alloc Ratio |
|----------------------- |---------- |---------- |----- |----------:|----------:|----------:|------:|--------:|----------:|----------:|---------:|----------:|------------:|
| InitJaggedArray        | .NET 10.0 | .NET 10.0 | 1024 |  2.492 ms | 0.0496 ms | 0.1332 ms |  1.00 |    0.08 |   64.4531 |   31.2500 |        - |   1.03 MB |        1.00 |
| InitDynamicJaggedArray | .NET 10.0 | .NET 10.0 | 1024 | 60.614 ms | 1.1246 ms | 0.9969 ms | 24.39 |    1.38 | 2777.7778 | 2666.6667 | 777.7778 |  32.03 MB |       31.06 |
|                        |           |           |      |           |           |           |       |         |           |           |          |           |             |
| InitJaggedArray        | .NET 9.0  | .NET 9.0  | 1024 |  2.302 ms | 0.0538 ms | 0.1587 ms |  1.00 |    0.10 |   62.5000 |   27.3438 |        - |   1.03 MB |        1.00 |
| InitDynamicJaggedArray | .NET 9.0  | .NET 9.0  | 1024 | 60.378 ms | 1.1633 ms | 1.1425 ms | 26.36 |    1.97 | 2777.7778 | 2666.6667 | 777.7778 |  32.03 MB |       31.06 |
