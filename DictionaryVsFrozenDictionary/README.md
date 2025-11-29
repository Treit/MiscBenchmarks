# Regular dictionary vs FrozeDictionary.







```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                            | Job       | Runtime   | Count | Mean     | Error     | StdDev    | Ratio | RatioSD | Allocated | Alloc Ratio |
|---------------------------------- |---------- |---------- |------ |---------:|----------:|----------:|------:|--------:|----------:|------------:|
| LookupUsingDictionaryInt          | .NET 10.0 | .NET 10.0 | 1000  | 3.086 ns | 0.0349 ns | 0.0309 ns |  1.00 |    0.01 |         - |          NA |
| LookupUsingFrozenDictionaryInt    | .NET 10.0 | .NET 10.0 | 1000  | 1.166 ns | 0.0374 ns | 0.0350 ns |  0.38 |    0.01 |         - |          NA |
| LookupUsingDictionaryString       | .NET 10.0 | .NET 10.0 | 1000  | 5.437 ns | 0.0782 ns | 0.0731 ns |  1.76 |    0.03 |         - |          NA |
| LookupUsingFrozenDictionaryString | .NET 10.0 | .NET 10.0 | 1000  | 6.674 ns | 0.0839 ns | 0.0655 ns |  2.16 |    0.03 |         - |          NA |
|                                   |           |           |       |          |           |           |       |         |           |             |
| LookupUsingDictionaryInt          | .NET 9.0  | .NET 9.0  | 1000  | 3.094 ns | 0.0357 ns | 0.0334 ns |  1.00 |    0.01 |         - |          NA |
| LookupUsingFrozenDictionaryInt    | .NET 9.0  | .NET 9.0  | 1000  | 1.208 ns | 0.0493 ns | 0.0461 ns |  0.39 |    0.02 |         - |          NA |
| LookupUsingDictionaryString       | .NET 9.0  | .NET 9.0  | 1000  | 5.060 ns | 0.0657 ns | 0.0615 ns |  1.64 |    0.03 |         - |          NA |
| LookupUsingFrozenDictionaryString | .NET 9.0  | .NET 9.0  | 1000  | 6.639 ns | 0.0574 ns | 0.0537 ns |  2.15 |    0.03 |         - |          NA |
