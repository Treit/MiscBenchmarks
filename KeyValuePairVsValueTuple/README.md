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
| **EnumerateValueTuplesUsingDestructuring** | **10**    |     **3.242 ns** |  **0.0443 ns** |  **0.0415 ns** |         **-** |
| EnumerateKvps                          | 10    |     3.540 ns |  0.0240 ns |  0.0224 ns |         - |
| EnumerateValueTuples                   | 10    |     3.561 ns |  0.0356 ns |  0.0333 ns |         - |
| **EnumerateValueTuplesUsingDestructuring** | **10000** | **3,163.984 ns** | **22.5429 ns** | **21.0866 ns** |         **-** |
| EnumerateKvps                          | 10000 | 3,156.103 ns | 17.7897 ns | 16.6405 ns |         - |
| EnumerateValueTuples                   | 10000 | 3,159.187 ns | 12.7064 ns | 10.6104 ns |         - |
