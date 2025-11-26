# Calling static vs. normal lambda.




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method       | Count  | Mean         | Error      | StdDev     | Allocated |
|------------- |------- |-------------:|-----------:|-----------:|----------:|
| **StaticLambda** | **100**    |     **61.40 ns** |   **0.406 ns** |   **0.379 ns** |         **-** |
| NormalLambda | 100    |     61.41 ns |   0.466 ns |   0.436 ns |         - |
| **StaticLambda** | **100000** | **54,982.51 ns** | **164.372 ns** | **145.712 ns** |         **-** |
| NormalLambda | 100000 | 55,309.49 ns | 204.819 ns | 191.588 ns |         - |
