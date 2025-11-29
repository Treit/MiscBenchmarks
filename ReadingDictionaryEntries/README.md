# Reading dictionary entries, both in thread safe and non-thread-safe ways.






```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                       | Job       | Runtime   | Count  | Mean      | Error     | StdDev    | Ratio | RatioSD |
|--------------------------------------------- |---------- |---------- |------- |----------:|----------:|----------:|------:|--------:|
| KeyLookupUsingDictionary                     | .NET 10.0 | .NET 10.0 | 100000 |  3.333 ns | 0.0057 ns | 0.0044 ns |  1.00 |    0.00 |
| KeyLookupUsingReadOnlyDictionary             | .NET 10.0 | .NET 10.0 | 100000 |  3.603 ns | 0.0083 ns | 0.0074 ns |  1.08 |    0.00 |
| KeyLookupUsingDictionaryReaderWriterLockSlim | .NET 10.0 | .NET 10.0 | 100000 | 14.535 ns | 0.0375 ns | 0.0333 ns |  4.36 |    0.01 |
| KeyLookupUsingDictionaryReaderWriterLock     | .NET 10.0 | .NET 10.0 | 100000 | 21.806 ns | 0.0409 ns | 0.0363 ns |  6.54 |    0.01 |
| KeyLookupUsingConcurrentDictionary           | .NET 10.0 | .NET 10.0 | 100000 |  2.141 ns | 0.0167 ns | 0.0139 ns |  0.64 |    0.00 |
| KeyLookupUsingLock                           | .NET 10.0 | .NET 10.0 | 100000 | 10.399 ns | 0.0162 ns | 0.0135 ns |  3.12 |    0.01 |
|                                              |           |           |        |           |           |           |       |         |
| KeyLookupUsingDictionary                     | .NET 9.0  | .NET 9.0  | 100000 |  3.340 ns | 0.0059 ns | 0.0046 ns |  1.00 |    0.00 |
| KeyLookupUsingReadOnlyDictionary             | .NET 9.0  | .NET 9.0  | 100000 |  4.041 ns | 0.0192 ns | 0.0180 ns |  1.21 |    0.01 |
| KeyLookupUsingDictionaryReaderWriterLockSlim | .NET 9.0  | .NET 9.0  | 100000 | 14.449 ns | 0.0212 ns | 0.0165 ns |  4.33 |    0.01 |
| KeyLookupUsingDictionaryReaderWriterLock     | .NET 9.0  | .NET 9.0  | 100000 | 21.806 ns | 0.1027 ns | 0.0857 ns |  6.53 |    0.03 |
| KeyLookupUsingConcurrentDictionary           | .NET 9.0  | .NET 9.0  | 100000 |  2.143 ns | 0.0065 ns | 0.0054 ns |  0.64 |    0.00 |
| KeyLookupUsingLock                           | .NET 9.0  | .NET 9.0  | 100000 |  9.800 ns | 0.0146 ns | 0.0122 ns |  2.93 |    0.01 |
