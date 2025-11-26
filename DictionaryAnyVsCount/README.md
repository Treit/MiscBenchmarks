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
| CheckDictionaryEmptyUsingCount | 1000  | 2.333 μs | 0.0496 μs | 0.1462 μs |  1.00 |    0.09 |         - |          NA |
| CheckDictionaryEmptyUsingAny   | 1000  | 3.940 μs | 0.0460 μs | 0.0384 μs |  1.70 |    0.11 |         - |          NA |
