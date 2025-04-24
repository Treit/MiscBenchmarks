# Incrementing a value stored in a dictionary, or adding default value if not present


```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27842.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.203
  [Host]     : .NET 8.0.15 (8.0.1525.16413), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.15 (8.0.1525.16413), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                                | Count | Mean     | Error    | StdDev   | Ratio | RatioSD | Allocated | Alloc Ratio |
|-------------------------------------- |------ |---------:|---------:|---------:|------:|--------:|----------:|------------:|
| IncrementUsingGetValueRefOrAddDefault | 100   | 11.17 ns | 0.253 ns | 0.329 ns |  1.00 |    0.00 |         - |          NA |
| IncrementUsingTryGetValue             | 100   | 22.17 ns | 0.314 ns | 0.294 ns |  1.97 |    0.06 |         - |          NA |
