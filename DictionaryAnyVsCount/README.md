# Checking if dictionaries are empty





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                         | Job       | Runtime   | Count | Mean     | Error     | StdDev    | Ratio | RatioSD | Allocated | Alloc Ratio |
|------------------------------- |---------- |---------- |------ |---------:|----------:|----------:|------:|--------:|----------:|------------:|
| CheckDictionaryEmptyUsingCount | .NET 10.0 | .NET 10.0 | 1000  | 2.168 μs | 0.0432 μs | 0.0497 μs |  1.00 |    0.03 |         - |          NA |
| CheckDictionaryEmptyUsingAny   | .NET 10.0 | .NET 10.0 | 1000  | 4.002 μs | 0.0773 μs | 0.0891 μs |  1.85 |    0.06 |         - |          NA |
|                                |           |           |       |          |           |           |       |         |           |             |
| CheckDictionaryEmptyUsingCount | .NET 9.0  | .NET 9.0  | 1000  | 2.151 μs | 0.0407 μs | 0.0418 μs |  1.00 |    0.03 |         - |          NA |
| CheckDictionaryEmptyUsingAny   | .NET 9.0  | .NET 9.0  | 1000  | 3.914 μs | 0.0449 μs | 0.0420 μs |  1.82 |    0.04 |         - |          NA |
