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
| DateTimeNow            | 100000 | 10.324 ms | 0.0793 ms | 0.0742 ms |  2.05 |    0.05 |
| DateTimeUtcNow         | 100000 |  5.047 ms | 0.0994 ms | 0.1064 ms |  1.00 |    0.03 |
| DateTimeNowToString    | 100000 | 22.247 ms | 0.2260 ms | 0.2114 ms |  4.41 |    0.11 |
| DateTimeUtcNowToString | 100000 | 15.524 ms | 0.1335 ms | 0.1183 ms |  3.08 |    0.07 |
