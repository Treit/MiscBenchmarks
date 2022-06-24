# Reading dictionary entries, both in thread safe and non-thread-safe ways.

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.25140
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=7.0.100-preview.5.22307.18
  [Host]     : .NET Core 6.0.6 (CoreCLR 6.0.622.26707, CoreFX 6.0.622.26707), X64 RyuJIT
  DefaultJob : .NET Core 6.0.6 (CoreCLR 6.0.622.26707, CoreFX 6.0.622.26707), X64 RyuJIT


```
|                                       Method |  Count |      Mean |     Error |    StdDev |    Median | Ratio | RatioSD |
|--------------------------------------------- |------- |----------:|----------:|----------:|----------:|------:|--------:|
|                     KeyLookupUsingDictionary | 100000 |  5.474 ns | 0.2608 ns | 0.7483 ns |  5.121 ns |  1.00 |    0.00 |
| KeyLookupUsingDictionaryReaderWriterLockSlim | 100000 | 38.311 ns | 1.2713 ns | 3.6476 ns | 37.797 ns |  7.11 |    1.12 |
|     KeyLookupUsingDictionaryReaderWriterLock | 100000 | 53.673 ns | 2.2354 ns | 6.3777 ns | 52.309 ns |  9.95 |    1.63 |
|           KeyLookupUsingConcurrentDictionary | 100000 |  8.041 ns | 0.4415 ns | 1.2524 ns |  7.710 ns |  1.48 |    0.23 |
|                           KeyLookupUsingLock | 100000 | 22.156 ns | 0.5937 ns | 1.6746 ns | 21.534 ns |  4.10 |    0.60 |
