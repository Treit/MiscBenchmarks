# Reading dictionary entries, both in thread safe and non-thread-safe ways.


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.25997.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=8.0.100-rc.2.23502.2
  [Host]     : .NET 7.0.13 (7.0.1323.51816), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.13 (7.0.1323.51816), X64 RyuJIT AVX2


```
|                                       Method |  Count |      Mean |     Error |    StdDev |    Median | Ratio | RatioSD |
|--------------------------------------------- |------- |----------:|----------:|----------:|----------:|------:|--------:|
|                     KeyLookupUsingDictionary | 100000 |  6.112 ns | 0.4766 ns | 1.3752 ns |  5.557 ns |  1.00 |    0.00 |
|             KeyLookupUsingReadOnlyDictionary | 100000 |  8.217 ns | 0.5018 ns | 1.4234 ns |  7.806 ns |  1.39 |    0.34 |
| KeyLookupUsingDictionaryReaderWriterLockSlim | 100000 | 36.460 ns | 0.8043 ns | 1.7823 ns | 36.061 ns |  6.16 |    1.38 |
|     KeyLookupUsingDictionaryReaderWriterLock | 100000 | 50.413 ns | 1.6568 ns | 4.6458 ns | 48.674 ns |  8.53 |    1.68 |
|           KeyLookupUsingConcurrentDictionary | 100000 |  9.017 ns | 0.2445 ns | 0.2287 ns |  9.007 ns |  1.55 |    0.39 |
|                           KeyLookupUsingLock | 100000 | 23.086 ns | 0.7406 ns | 2.1722 ns | 22.352 ns |  3.95 |    0.85 |
