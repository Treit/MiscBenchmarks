# Looping over KeyValuePair and ValueTuple, showing the effect of destructuring the ValueTuple.

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.22593
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=6.0.201
  [Host]     : .NET Core 6.0.3 (CoreCLR 6.0.322.12309, CoreFX 6.0.322.12309), X64 RyuJIT
  DefaultJob : .NET Core 6.0.3 (CoreCLR 6.0.322.12309, CoreFX 6.0.322.12309), X64 RyuJIT


``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.22593
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=6.0.201
  [Host]     : .NET Core 6.0.3 (CoreCLR 6.0.322.12309, CoreFX 6.0.322.12309), X64 RyuJIT
  DefaultJob : .NET Core 6.0.3 (CoreCLR 6.0.322.12309, CoreFX 6.0.322.12309), X64 RyuJIT


```
|                                 Method | Count |         Mean |       Error |      StdDev | Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------------------------- |------ |-------------:|------------:|------------:|------:|------:|------:|----------:|
| **EnumerateValueTuplesUsingDestructuring** |    **10** |     **5.716 ns** |   **0.1504 ns** |   **0.2554 ns** |     **-** |     **-** |     **-** |         **-** |
|                          EnumerateKvps |    10 |     9.331 ns |   0.2212 ns |   0.3874 ns |     - |     - |     - |         - |
|                   EnumerateValueTuples |    10 |     9.124 ns |   0.2184 ns |   0.4103 ns |     - |     - |     - |         - |
| **EnumerateValueTuplesUsingDestructuring** | **10000** | **7,103.284 ns** | **140.7134 ns** | **201.8069 ns** |     **-** |     **-** |     **-** |         **-** |
|                          EnumerateKvps | 10000 | 9,428.267 ns | 173.9791 ns | 243.8944 ns |     - |     - |     - |         - |
|                   EnumerateValueTuples | 10000 | 9,716.942 ns | 192.1029 ns | 379.1924 ns |     - |     - |     - |         - |
