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
| **StaticLambda** | **100**    |     **61.49 ns** |   **0.616 ns** |   **0.576 ns** |         **-** |
| NormalLambda | 100    |     61.36 ns |   0.488 ns |   0.456 ns |         - |
| **StaticLambda** | **100000** | **55,472.76 ns** | **133.982 ns** | **118.771 ns** |         **-** |
| NormalLambda | 100000 | 54,807.67 ns | 221.444 ns | 207.138 ns |         - |
