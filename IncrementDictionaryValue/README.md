# Incrementing a value stored in a dictionary, or adding default value if not present





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
| IncrementUsingGetValueRefOrAddDefault | .NET 10.0 | .NET 10.0 | 100   |  7.734 ns | 0.1367 ns | 0.1279 ns |  1.00 |    0.02 |         - |          NA |
| IncrementUsingTryGetValue             | .NET 10.0 | .NET 10.0 | 100   | 11.538 ns | 0.0472 ns | 0.0419 ns |  1.49 |    0.02 |         - |          NA |
|                                       |           |           |       |           |           |           |       |         |           |             |
| IncrementUsingGetValueRefOrAddDefault | .NET 9.0  | .NET 9.0  | 100   |  7.663 ns | 0.0745 ns | 0.0697 ns |  1.00 |    0.01 |         - |          NA |
| IncrementUsingTryGetValue             | .NET 9.0  | .NET 9.0  | 100   | 11.532 ns | 0.0650 ns | 0.0576 ns |  1.50 |    0.02 |         - |          NA |
