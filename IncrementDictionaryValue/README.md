# Incrementing a value stored in a dictionary, or adding default value if not present




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                | Count | Mean      | Error     | StdDev    | Ratio | Allocated | Alloc Ratio |
|-------------------------------------- |------ |----------:|----------:|----------:|------:|----------:|------------:|
| IncrementUsingGetValueRefOrAddDefault | 100   |  7.634 ns | 0.0573 ns | 0.0536 ns |  1.00 |         - |          NA |
| IncrementUsingTryGetValue             | 100   | 11.495 ns | 0.0411 ns | 0.0364 ns |  1.51 |         - |          NA |
