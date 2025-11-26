# Testing checking a property for equality vs. HashSet lookup.


```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method            | Count | Mean       | Error     | StdDev    | Median     |
|------------------ |------ |-----------:|----------:|----------:|-----------:|
| CheckUsingEquals  | 10000 |  0.5477 ns | 0.0193 ns | 0.0180 ns |  0.5499 ns |
| CheckUsingHashset | 10000 | 22.2657 ns | 0.1122 ns | 0.0937 ns | 22.3129 ns |
| CheckUsingEnum    | 10000 |  0.3362 ns | 0.0402 ns | 0.0914 ns |  0.2923 ns |
