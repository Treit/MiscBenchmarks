# DateTime.Now vs. DateTime.UtcNow



``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                 Method |  Count |      Mean |     Error |    StdDev | Ratio | RatioSD |
|----------------------- |------- |----------:|----------:|----------:|------:|--------:|
|            DateTimeNow | 100000 | 10.393 ms | 0.0724 ms | 0.0605 ms |  2.54 |    0.02 |
|         DateTimeUtcNow | 100000 |  4.090 ms | 0.0125 ms | 0.0117 ms |  1.00 |    0.00 |
|    DateTimeNowToString | 100000 | 24.273 ms | 0.3990 ms | 0.3732 ms |  5.93 |    0.09 |
| DateTimeUtcNowToString | 100000 | 21.455 ms | 0.4272 ms | 0.3787 ms |  5.24 |    0.09 |
