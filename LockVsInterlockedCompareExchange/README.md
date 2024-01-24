# Lock vs. Interlocked.CompareExchange


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                                     Method |     Mean |     Error |    StdDev |
|------------------------------------------- |---------:|----------:|----------:|
|                       ReadAndWriteWithLock | 7.343 ns | 0.0371 ns | 0.0328 ns |
| ReadAndWriteWithInterlockedCompareExchange | 1.100 ns | 0.0014 ns | 0.0012 ns |
