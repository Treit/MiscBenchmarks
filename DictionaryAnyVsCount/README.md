# Checking if dictionaries are empty



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                         | Count | Mean     | Error     | StdDev    | Ratio | RatioSD | Allocated | Alloc Ratio |
|------------------------------- |------ |---------:|----------:|----------:|------:|--------:|----------:|------------:|
| CheckDictionaryEmptyUsingCount | 1000  | 2.162 μs | 0.0428 μs | 0.0421 μs |  1.00 |    0.03 |         - |          NA |
| CheckDictionaryEmptyUsingAny   | 1000  | 3.944 μs | 0.0491 μs | 0.0436 μs |  1.82 |    0.04 |         - |          NA |
