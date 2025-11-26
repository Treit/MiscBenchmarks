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
| KeyLookupUsingDictionary                     | 100000 |  3.384 ns | 0.0122 ns | 0.0108 ns |  1.00 |    0.00 |
| KeyLookupUsingReadOnlyDictionary             | 100000 |  3.620 ns | 0.0292 ns | 0.0273 ns |  1.07 |    0.01 |
| KeyLookupUsingDictionaryReaderWriterLockSlim | 100000 | 14.592 ns | 0.1273 ns | 0.1128 ns |  4.31 |    0.03 |
| KeyLookupUsingDictionaryReaderWriterLock     | 100000 | 21.986 ns | 0.1357 ns | 0.1270 ns |  6.50 |    0.04 |
| KeyLookupUsingConcurrentDictionary           | 100000 |  2.171 ns | 0.0271 ns | 0.0253 ns |  0.64 |    0.01 |
| KeyLookupUsingLock                           | 100000 |  9.865 ns | 0.0459 ns | 0.0407 ns |  2.92 |    0.01 |
