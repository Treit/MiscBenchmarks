# Testing checking a property for equality vs. HashSet lookup.



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method            | Count | Mean       | Error     | StdDev    |
|------------------ |------ |-----------:|----------:|----------:|
| CheckUsingEquals  | 10000 |  0.5533 ns | 0.0113 ns | 0.0106 ns |
| CheckUsingHashset | 10000 | 25.0160 ns | 0.0356 ns | 0.0316 ns |
| CheckUsingEnum    | 10000 |  0.2702 ns | 0.0041 ns | 0.0038 ns |
