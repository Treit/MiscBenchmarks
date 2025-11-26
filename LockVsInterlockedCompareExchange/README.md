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
| ReadAndWriteWithLock                       | 6.524 ns | 0.0747 ns | 0.0698 ns |
| ReadAndWriteWithInterlockedCompareExchange | 1.074 ns | 0.0131 ns | 0.0122 ns |
