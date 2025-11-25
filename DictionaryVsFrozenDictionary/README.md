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
| LookupUsingDictionaryInt          | 1000  | 3.059 ns | 0.0255 ns | 0.0226 ns |  1.00 |    0.01 |         - |          NA |
| LookupUsingFrozenDictionaryInt    | 1000  | 1.186 ns | 0.0437 ns | 0.0409 ns |  0.39 |    0.01 |         - |          NA |
| LookupUsingDictionaryString       | 1000  | 5.075 ns | 0.0302 ns | 0.0283 ns |  1.66 |    0.01 |         - |          NA |
| LookupUsingFrozenDictionaryString | 1000  | 6.602 ns | 0.0804 ns | 0.0753 ns |  2.16 |    0.03 |         - |          NA |
