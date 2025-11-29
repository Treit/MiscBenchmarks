# Looping over KeyValuePair and ValueTuple, showing the effect of destructuring the ValueTuple.





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                 | Job       | Runtime   | Count | Mean         | Error      | StdDev     | Allocated |
|--------------------------------------- |---------- |---------- |------ |-------------:|-----------:|-----------:|----------:|
| **EnumerateValueTuplesUsingDestructuring** | **.NET 10.0** | **.NET 10.0** | **10**    |     **3.197 ns** |  **0.0352 ns** |  **0.0294 ns** |         **-** |
| EnumerateKvps                          | .NET 10.0 | .NET 10.0 | 10    |     3.561 ns |  0.0397 ns |  0.0352 ns |         - |
| EnumerateValueTuples                   | .NET 10.0 | .NET 10.0 | 10    |     3.562 ns |  0.0358 ns |  0.0317 ns |         - |
| EnumerateValueTuplesUsingDestructuring | .NET 9.0  | .NET 9.0  | 10    |     3.207 ns |  0.0384 ns |  0.0340 ns |         - |
| EnumerateKvps                          | .NET 9.0  | .NET 9.0  | 10    |     3.555 ns |  0.0312 ns |  0.0291 ns |         - |
| EnumerateValueTuples                   | .NET 9.0  | .NET 9.0  | 10    |     3.566 ns |  0.0334 ns |  0.0313 ns |         - |
| **EnumerateValueTuplesUsingDestructuring** | **.NET 10.0** | **.NET 10.0** | **10000** | **3,176.007 ns** | **33.2442 ns** | **31.0966 ns** |         **-** |
| EnumerateKvps                          | .NET 10.0 | .NET 10.0 | 10000 | 3,173.071 ns | 29.4849 ns | 26.1376 ns |         - |
| EnumerateValueTuples                   | .NET 10.0 | .NET 10.0 | 10000 | 3,186.377 ns | 16.8529 ns | 14.9397 ns |         - |
| EnumerateValueTuplesUsingDestructuring | .NET 9.0  | .NET 9.0  | 10000 | 3,184.054 ns | 19.7329 ns | 17.4927 ns |         - |
| EnumerateKvps                          | .NET 9.0  | .NET 9.0  | 10000 | 3,168.850 ns | 16.8195 ns | 14.9100 ns |         - |
| EnumerateValueTuples                   | .NET 9.0  | .NET 9.0  | 10000 | 3,161.654 ns | 13.6661 ns | 12.7833 ns |         - |
