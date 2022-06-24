# Reading dictionary entries, both in thread safe and non-thread-safe ways.

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.25140
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=7.0.100-preview.5.22307.18
  [Host]     : .NET Core 6.0.6 (CoreCLR 6.0.622.26707, CoreFX 6.0.622.26707), X64 RyuJIT
  DefaultJob : .NET Core 6.0.6 (CoreCLR 6.0.622.26707, CoreFX 6.0.622.26707), X64 RyuJIT


```
|                                       Method |  Count |      Mean |     Error |   StdDev |    Median | Ratio | RatioSD |
|--------------------------------------------- |------- |----------:|----------:|---------:|----------:|------:|--------:|
|                     KeyLookupUsingDictionary | 100000 |  7.639 ns | 0.7370 ns | 2.173 ns |  7.489 ns |  1.00 |    0.00 |
| KeyLookupUsingDictionaryReaderWriterLockSlim | 100000 | 39.304 ns | 2.2580 ns | 6.587 ns | 36.992 ns |  5.52 |    1.49 |
|           KeyLookupUsingConcurrentDictionary | 100000 |  9.418 ns | 0.4166 ns | 1.195 ns |  9.029 ns |  1.34 |    0.38 |
