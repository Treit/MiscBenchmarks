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
| LookupUsingDictionaryInt              | 1000  |  2.960 ns | 0.0187 ns | 0.0156 ns |  1.00 |    0.01 |         - |          NA |
| LookupUsingFrozenDictionaryInt        | 1000  |  1.291 ns | 0.0311 ns | 0.0290 ns |  0.44 |    0.01 |         - |          NA |
| LookupUsingConcurrentDictionaryInt    | 1000  |  2.043 ns | 0.0310 ns | 0.0275 ns |  0.69 |    0.01 |         - |          NA |
| LookupUsingLockedDictionaryInt        | 1000  |  9.585 ns | 0.0471 ns | 0.0394 ns |  3.24 |    0.02 |         - |          NA |
| LookupUsingReaderWriterLockInt        | 1000  | 16.637 ns | 0.1225 ns | 0.1146 ns |  5.62 |    0.05 |         - |          NA |
| LookupUsingReaderWriterLockSlimInt    | 1000  | 20.169 ns | 0.1068 ns | 0.0999 ns |  6.81 |    0.05 |         - |          NA |
| LookupUsingDictionaryString           | 1000  |  5.000 ns | 0.0598 ns | 0.0560 ns |  1.69 |    0.02 |         - |          NA |
| LookupUsingFrozenDictionaryString     | 1000  |  6.687 ns | 0.0746 ns | 0.0698 ns |  2.26 |    0.03 |         - |          NA |
| LookupUsingConcurrentDictionaryString | 1000  |  5.472 ns | 0.0609 ns | 0.0540 ns |  1.85 |    0.02 |         - |          NA |
| LookupUsingLockedDictionaryString     | 1000  | 11.493 ns | 0.1629 ns | 0.1444 ns |  3.88 |    0.05 |         - |          NA |
| LookupUsingReaderWriterLockString     | 1000  | 18.659 ns | 0.1190 ns | 0.1113 ns |  6.30 |    0.05 |         - |          NA |
| LookupUsingReaderWriterLockSlimString | 1000  | 16.394 ns | 0.1088 ns | 0.0909 ns |  5.54 |    0.04 |         - |          NA |
