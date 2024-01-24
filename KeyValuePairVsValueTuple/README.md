# Looping over KeyValuePair and ValueTuple, showing the effect of destructuring the ValueTuple.


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                                 Method | Count |         Mean |      Error |     StdDev | Allocated |
|--------------------------------------- |------ |-------------:|-----------:|-----------:|----------:|
| **EnumerateValueTuplesUsingDestructuring** |    **10** |     **3.925 ns** |  **0.0140 ns** |  **0.0124 ns** |         **-** |
|                          EnumerateKvps |    10 |     3.876 ns |  0.0080 ns |  0.0075 ns |         - |
|                   EnumerateValueTuples |    10 |     3.876 ns |  0.0182 ns |  0.0161 ns |         - |
| **EnumerateValueTuplesUsingDestructuring** | **10000** | **8,039.377 ns** |  **3.2398 ns** |  **3.0305 ns** |         **-** |
|                          EnumerateKvps | 10000 | 7,713.213 ns | 15.4282 ns | 12.0453 ns |         - |
|                   EnumerateValueTuples | 10000 | 7,629.945 ns |  4.8757 ns |  4.5608 ns |         - |
