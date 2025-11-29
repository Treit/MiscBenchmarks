# Simple dictionary lookup benchmark.





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                | Job       | Runtime   | Count | Mean      | Error     | StdDev    | Ratio | RatioSD | Allocated | Alloc Ratio |
|-------------------------------------- |---------- |---------- |------ |----------:|----------:|----------:|------:|--------:|----------:|------------:|
| LookupUsingDictionaryInt              | .NET 10.0 | .NET 10.0 | 1000  |  3.012 ns | 0.0714 ns | 0.0633 ns |  1.00 |    0.03 |         - |          NA |
| LookupUsingFrozenDictionaryInt        | .NET 10.0 | .NET 10.0 | 1000  |  1.221 ns | 0.0391 ns | 0.0326 ns |  0.41 |    0.01 |         - |          NA |
| LookupUsingConcurrentDictionaryInt    | .NET 10.0 | .NET 10.0 | 1000  |  2.149 ns | 0.1072 ns | 0.1191 ns |  0.71 |    0.04 |         - |          NA |
| LookupUsingLockedDictionaryInt        | .NET 10.0 | .NET 10.0 | 1000  |  9.787 ns | 0.1438 ns | 0.1345 ns |  3.25 |    0.08 |         - |          NA |
| LookupUsingReaderWriterLockInt        | .NET 10.0 | .NET 10.0 | 1000  | 16.891 ns | 0.1160 ns | 0.1085 ns |  5.61 |    0.12 |         - |          NA |
| LookupUsingReaderWriterLockSlimInt    | .NET 10.0 | .NET 10.0 | 1000  | 14.671 ns | 0.1666 ns | 0.1477 ns |  4.87 |    0.11 |         - |          NA |
| LookupUsingDictionaryString           | .NET 10.0 | .NET 10.0 | 1000  |  5.095 ns | 0.0880 ns | 0.0823 ns |  1.69 |    0.04 |         - |          NA |
| LookupUsingFrozenDictionaryString     | .NET 10.0 | .NET 10.0 | 1000  |  6.667 ns | 0.0605 ns | 0.0566 ns |  2.21 |    0.05 |         - |          NA |
| LookupUsingConcurrentDictionaryString | .NET 10.0 | .NET 10.0 | 1000  |  5.503 ns | 0.0544 ns | 0.0509 ns |  1.83 |    0.04 |         - |          NA |
| LookupUsingLockedDictionaryString     | .NET 10.0 | .NET 10.0 | 1000  | 11.704 ns | 0.2944 ns | 0.3272 ns |  3.89 |    0.13 |         - |          NA |
| LookupUsingReaderWriterLockString     | .NET 10.0 | .NET 10.0 | 1000  | 18.598 ns | 0.1025 ns | 0.0959 ns |  6.18 |    0.13 |         - |          NA |
| LookupUsingReaderWriterLockSlimString | .NET 10.0 | .NET 10.0 | 1000  | 16.647 ns | 0.1788 ns | 0.1673 ns |  5.53 |    0.12 |         - |          NA |
|                                       |           |           |       |           |           |           |       |         |           |             |
| LookupUsingDictionaryInt              | .NET 9.0  | .NET 9.0  | 1000  |  2.997 ns | 0.0271 ns | 0.0227 ns |  1.00 |    0.01 |         - |          NA |
| LookupUsingFrozenDictionaryInt        | .NET 9.0  | .NET 9.0  | 1000  |  1.279 ns | 0.0325 ns | 0.0304 ns |  0.43 |    0.01 |         - |          NA |
| LookupUsingConcurrentDictionaryInt    | .NET 9.0  | .NET 9.0  | 1000  |  2.018 ns | 0.0321 ns | 0.0250 ns |  0.67 |    0.01 |         - |          NA |
| LookupUsingLockedDictionaryInt        | .NET 9.0  | .NET 9.0  | 1000  |  9.757 ns | 0.2016 ns | 0.1683 ns |  3.26 |    0.06 |         - |          NA |
| LookupUsingReaderWriterLockInt        | .NET 9.0  | .NET 9.0  | 1000  | 17.692 ns | 0.1322 ns | 0.1237 ns |  5.90 |    0.06 |         - |          NA |
| LookupUsingReaderWriterLockSlimInt    | .NET 9.0  | .NET 9.0  | 1000  | 14.837 ns | 0.1614 ns | 0.1348 ns |  4.95 |    0.06 |         - |          NA |
| LookupUsingDictionaryString           | .NET 9.0  | .NET 9.0  | 1000  |  5.107 ns | 0.0663 ns | 0.0620 ns |  1.70 |    0.02 |         - |          NA |
| LookupUsingFrozenDictionaryString     | .NET 9.0  | .NET 9.0  | 1000  |  6.688 ns | 0.0627 ns | 0.0587 ns |  2.23 |    0.03 |         - |          NA |
| LookupUsingConcurrentDictionaryString | .NET 9.0  | .NET 9.0  | 1000  |  5.502 ns | 0.0752 ns | 0.0703 ns |  1.84 |    0.03 |         - |          NA |
| LookupUsingLockedDictionaryString     | .NET 9.0  | .NET 9.0  | 1000  | 11.654 ns | 0.2439 ns | 0.2282 ns |  3.89 |    0.08 |         - |          NA |
| LookupUsingReaderWriterLockString     | .NET 9.0  | .NET 9.0  | 1000  | 21.289 ns | 0.1633 ns | 0.1448 ns |  7.10 |    0.07 |         - |          NA |
| LookupUsingReaderWriterLockSlimString | .NET 9.0  | .NET 9.0  | 1000  | 16.759 ns | 0.1215 ns | 0.1136 ns |  5.59 |    0.06 |         - |          NA |
