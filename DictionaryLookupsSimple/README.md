# Simple dictionary lookup benchmark.




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                | Count | Mean      | Error     | StdDev    | Ratio | RatioSD | Allocated | Alloc Ratio |
|-------------------------------------- |------ |----------:|----------:|----------:|------:|--------:|----------:|------------:|
| LookupUsingDictionaryInt              | 1000  |  3.001 ns | 0.0210 ns | 0.0197 ns |  1.00 |    0.01 |         - |          NA |
| LookupUsingFrozenDictionaryInt        | 1000  |  1.245 ns | 0.0259 ns | 0.0242 ns |  0.41 |    0.01 |         - |          NA |
| LookupUsingConcurrentDictionaryInt    | 1000  |  2.049 ns | 0.0228 ns | 0.0190 ns |  0.68 |    0.01 |         - |          NA |
| LookupUsingLockedDictionaryInt        | 1000  |  9.638 ns | 0.0663 ns | 0.0517 ns |  3.21 |    0.03 |         - |          NA |
| LookupUsingReaderWriterLockInt        | 1000  | 16.916 ns | 0.1121 ns | 0.1048 ns |  5.64 |    0.05 |         - |          NA |
| LookupUsingReaderWriterLockSlimInt    | 1000  | 15.803 ns | 0.1801 ns | 0.1596 ns |  5.27 |    0.06 |         - |          NA |
| LookupUsingDictionaryString           | 1000  |  5.000 ns | 0.0668 ns | 0.0592 ns |  1.67 |    0.02 |         - |          NA |
| LookupUsingFrozenDictionaryString     | 1000  |  6.665 ns | 0.0457 ns | 0.0427 ns |  2.22 |    0.02 |         - |          NA |
| LookupUsingConcurrentDictionaryString | 1000  |  5.480 ns | 0.0586 ns | 0.0548 ns |  1.83 |    0.02 |         - |          NA |
| LookupUsingLockedDictionaryString     | 1000  | 11.479 ns | 0.0809 ns | 0.0756 ns |  3.83 |    0.03 |         - |          NA |
| LookupUsingReaderWriterLockString     | 1000  | 19.952 ns | 0.1590 ns | 0.1488 ns |  6.65 |    0.06 |         - |          NA |
| LookupUsingReaderWriterLockSlimString | 1000  | 17.644 ns | 0.1174 ns | 0.1041 ns |  5.88 |    0.05 |         - |          NA |
