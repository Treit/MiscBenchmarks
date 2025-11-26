# DateTime.Now vs. DateTime.UtcNow





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                 | Count  | Mean      | Error     | StdDev    | Ratio | RatioSD |
|----------------------- |------- |----------:|----------:|----------:|------:|--------:|
| DateTimeNow            | 100000 | 10.404 ms | 0.0576 ms | 0.0511 ms |  2.05 |    0.02 |
| DateTimeUtcNow         | 100000 |  5.087 ms | 0.0501 ms | 0.0468 ms |  1.00 |    0.01 |
| DateTimeNowToString    | 100000 | 21.389 ms | 0.1482 ms | 0.1314 ms |  4.20 |    0.05 |
| DateTimeUtcNowToString | 100000 | 16.128 ms | 0.2622 ms | 0.2453 ms |  3.17 |    0.05 |
