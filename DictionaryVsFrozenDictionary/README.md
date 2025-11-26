# Regular dictionary vs FrozeDictionary.






```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                            | Count | Mean     | Error     | StdDev    | Ratio | RatioSD | Allocated | Alloc Ratio |
|---------------------------------- |------ |---------:|----------:|----------:|------:|--------:|----------:|------------:|
| LookupUsingDictionaryInt          | 1000  | 3.077 ns | 0.0244 ns | 0.0203 ns |  1.00 |    0.01 |         - |          NA |
| LookupUsingFrozenDictionaryInt    | 1000  | 1.175 ns | 0.0333 ns | 0.0311 ns |  0.38 |    0.01 |         - |          NA |
| LookupUsingDictionaryString       | 1000  | 5.069 ns | 0.0661 ns | 0.0618 ns |  1.65 |    0.02 |         - |          NA |
| LookupUsingFrozenDictionaryString | 1000  | 6.621 ns | 0.0508 ns | 0.0475 ns |  2.15 |    0.02 |         - |          NA |
