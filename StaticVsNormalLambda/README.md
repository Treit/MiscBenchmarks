# Calling static vs. normal lambda.





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method       | Job       | Runtime   | Count  | Mean         | Error      | StdDev     | Allocated |
|------------- |---------- |---------- |------- |-------------:|-----------:|-----------:|----------:|
| **StaticLambda** | **.NET 10.0** | **.NET 10.0** | **100**    |     **60.99 ns** |   **0.030 ns** |   **0.023 ns** |         **-** |
| NormalLambda | .NET 10.0 | .NET 10.0 | 100    |     61.01 ns |   0.065 ns |   0.058 ns |         - |
| StaticLambda | .NET 9.0  | .NET 9.0  | 100    |     61.02 ns |   0.052 ns |   0.046 ns |         - |
| NormalLambda | .NET 9.0  | .NET 9.0  | 100    |     60.96 ns |   0.038 ns |   0.032 ns |         - |
| **StaticLambda** | **.NET 10.0** | **.NET 10.0** | **100000** | **54,909.84 ns** | **145.078 ns** | **135.706 ns** |         **-** |
| NormalLambda | .NET 10.0 | .NET 10.0 | 100000 | 54,908.44 ns |  83.342 ns |  77.958 ns |         - |
| StaticLambda | .NET 9.0  | .NET 9.0  | 100000 | 54,637.42 ns | 110.632 ns |  92.383 ns |         - |
| NormalLambda | .NET 9.0  | .NET 9.0  | 100000 | 54,603.63 ns | 155.890 ns | 145.820 ns |         - |
