# Lock vs. Interlocked.CompareExchange



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                     | Mean     | Error     | StdDev    |
|------------------------------------------- |---------:|----------:|----------:|
| ReadAndWriteWithLock                       | 6.517 ns | 0.0673 ns | 0.0630 ns |
| ReadAndWriteWithInterlockedCompareExchange | 1.089 ns | 0.0117 ns | 0.0110 ns |
