# Lock vs. Interlocked.CompareExchange





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                     | Job       | Runtime   | Mean     | Error     | StdDev    |
|------------------------------------------- |---------- |---------- |---------:|----------:|----------:|
| ReadAndWriteWithLock                       | .NET 10.0 | .NET 10.0 | 6.510 ns | 0.0117 ns | 0.0104 ns |
| ReadAndWriteWithInterlockedCompareExchange | .NET 10.0 | .NET 10.0 | 1.069 ns | 0.0100 ns | 0.0084 ns |
| ReadAndWriteWithLock                       | .NET 9.0  | .NET 9.0  | 6.508 ns | 0.0701 ns | 0.0585 ns |
| ReadAndWriteWithInterlockedCompareExchange | .NET 9.0  | .NET 9.0  | 1.081 ns | 0.0078 ns | 0.0073 ns |
