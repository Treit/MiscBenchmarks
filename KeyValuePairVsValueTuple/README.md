# Looping over KeyValuePair and ValueTuple, showing the effect of destructuring the ValueTuple.



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                 | Count | Mean         | Error      | StdDev     | Allocated |
|--------------------------------------- |------ |-------------:|-----------:|-----------:|----------:|
| **EnumerateValueTuplesUsingDestructuring** | **10**    |     **3.214 ns** |  **0.0214 ns** |  **0.0189 ns** |         **-** |
| EnumerateKvps                          | 10    |     3.539 ns |  0.0353 ns |  0.0330 ns |         - |
| EnumerateValueTuples                   | 10    |     3.582 ns |  0.0284 ns |  0.0252 ns |         - |
| **EnumerateValueTuplesUsingDestructuring** | **10000** | **3,154.975 ns** | **13.8504 ns** | **12.9557 ns** |         **-** |
| EnumerateKvps                          | 10000 | 3,144.122 ns | 12.6756 ns | 11.2366 ns |         - |
| EnumerateValueTuples                   | 10000 | 3,151.759 ns | 15.5040 ns | 14.5025 ns |         - |
