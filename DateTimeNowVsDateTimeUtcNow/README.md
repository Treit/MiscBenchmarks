# DateTime.Now vs. DateTime.UtcNow






```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                 | Job       | Runtime   | Count  | Mean      | Error     | StdDev    | Ratio | RatioSD |
|----------------------- |---------- |---------- |------- |----------:|----------:|----------:|------:|--------:|
| DateTimeNow            | .NET 10.0 | .NET 10.0 | 100000 |  9.869 ms | 0.0849 ms | 0.0794 ms |  2.07 |    0.02 |
| DateTimeUtcNow         | .NET 10.0 | .NET 10.0 | 100000 |  4.760 ms | 0.0324 ms | 0.0303 ms |  1.00 |    0.01 |
| DateTimeNowToString    | .NET 10.0 | .NET 10.0 | 100000 | 21.656 ms | 0.1871 ms | 0.1658 ms |  4.55 |    0.04 |
| DateTimeUtcNowToString | .NET 10.0 | .NET 10.0 | 100000 | 15.154 ms | 0.1525 ms | 0.1352 ms |  3.18 |    0.03 |
|                        |           |           |        |           |           |           |       |         |
| DateTimeNow            | .NET 9.0  | .NET 9.0  | 100000 |  9.850 ms | 0.0900 ms | 0.0842 ms |  2.09 |    0.02 |
| DateTimeUtcNow         | .NET 9.0  | .NET 9.0  | 100000 |  4.720 ms | 0.0343 ms | 0.0321 ms |  1.00 |    0.01 |
| DateTimeNowToString    | .NET 9.0  | .NET 9.0  | 100000 | 21.226 ms | 0.1663 ms | 0.1475 ms |  4.50 |    0.04 |
| DateTimeUtcNowToString | .NET 9.0  | .NET 9.0  | 100000 | 15.059 ms | 0.0831 ms | 0.0736 ms |  3.19 |    0.03 |
