# Reading dictionary entries, both in thread safe and non-thread-safe ways.




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                       | Count  | Mean      | Error     | StdDev    | Ratio | RatioSD |
|--------------------------------------------- |------- |----------:|----------:|----------:|------:|--------:|
| KeyLookupUsingDictionary                     | 100000 |  3.372 ns | 0.0212 ns | 0.0199 ns |  1.00 |    0.01 |
| KeyLookupUsingReadOnlyDictionary             | 100000 |  3.661 ns | 0.0142 ns | 0.0133 ns |  1.09 |    0.01 |
| KeyLookupUsingDictionaryReaderWriterLockSlim | 100000 | 15.539 ns | 0.1039 ns | 0.0972 ns |  4.61 |    0.04 |
| KeyLookupUsingDictionaryReaderWriterLock     | 100000 | 22.087 ns | 0.1013 ns | 0.0898 ns |  6.55 |    0.05 |
| KeyLookupUsingConcurrentDictionary           | 100000 |  2.176 ns | 0.0257 ns | 0.0228 ns |  0.65 |    0.01 |
| KeyLookupUsingLock                           | 100000 |  9.919 ns | 0.0389 ns | 0.0364 ns |  2.94 |    0.02 |
