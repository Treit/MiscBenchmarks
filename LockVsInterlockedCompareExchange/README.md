# Lock vs. Interlocked.CompareExchange

``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.25936.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.400
  [Host]     : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2


```
|                                     Method |      Mean |     Error |    StdDev |
|------------------------------------------- |----------:|----------:|----------:|
|                       ReadAndWriteWithLock | 16.048 ns | 0.3519 ns | 0.3292 ns |
| ReadAndWriteWithInterlockedCompareExchange |  7.906 ns | 0.0764 ns | 0.0714 ns |
