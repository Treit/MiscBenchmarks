# Reading dictionary entries, both in thread safe and non-thread-safe ways.



``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                                       Method |  Count |      Mean |     Error |    StdDev |    Median | Ratio | RatioSD |
|--------------------------------------------- |------- |----------:|----------:|----------:|----------:|------:|--------:|
|                     KeyLookupUsingDictionary | 100000 |  4.583 ns | 0.0117 ns | 0.0104 ns |  4.580 ns |  1.00 |    0.00 |
|             KeyLookupUsingReadOnlyDictionary | 100000 |  5.120 ns | 0.0095 ns | 0.0079 ns |  5.119 ns |  1.12 |    0.00 |
| KeyLookupUsingDictionaryReaderWriterLockSlim | 100000 | 40.666 ns | 1.3328 ns | 3.9298 ns | 42.312 ns |  7.29 |    0.35 |
|     KeyLookupUsingDictionaryReaderWriterLock | 100000 | 28.814 ns | 0.0900 ns | 0.0798 ns | 28.791 ns |  6.29 |    0.02 |
|           KeyLookupUsingConcurrentDictionary | 100000 |  5.460 ns | 0.0123 ns | 0.0096 ns |  5.458 ns |  1.19 |    0.00 |
|                           KeyLookupUsingLock | 100000 | 11.519 ns | 0.0351 ns | 0.0293 ns | 11.523 ns |  2.51 |    0.01 |
