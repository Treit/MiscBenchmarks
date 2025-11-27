# Combining hashcodes





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                 | Job       | Runtime   | Count | Mean         | Error      | StdDev     | Median       |
|----------------------- |---------- |---------- |------ |-------------:|-----------:|-----------:|-------------:|
| **BuiltInHashCodeCombine** | **.NET 10.0** | **.NET 10.0** | **10**    |    **54.199 ns** |  **0.1499 ns** |  **0.1252 ns** |    **54.211 ns** |
| CustomHashCodeCombine  | .NET 10.0 | .NET 10.0 | 10    |     6.052 ns |  0.1156 ns |  0.1082 ns |     6.056 ns |
| BuiltInHashCodeCombine | .NET 9.0  | .NET 9.0  | 10    |    54.253 ns |  0.1867 ns |  0.1458 ns |    54.279 ns |
| CustomHashCodeCombine  | .NET 9.0  | .NET 9.0  | 10    |     6.020 ns |  0.0603 ns |  0.0564 ns |     6.013 ns |
| **BuiltInHashCodeCombine** | **.NET 10.0** | **.NET 10.0** | **1000**  | **7,760.214 ns** | **52.9107 ns** | **49.4927 ns** | **7,720.045 ns** |
| CustomHashCodeCombine  | .NET 10.0 | .NET 10.0 | 1000  |   931.021 ns |  0.9848 ns |  0.8730 ns |   931.053 ns |
| BuiltInHashCodeCombine | .NET 9.0  | .NET 9.0  | 1000  | 7,765.596 ns | 53.1641 ns | 49.7297 ns | 7,803.241 ns |
| CustomHashCodeCombine  | .NET 9.0  | .NET 9.0  | 1000  |   931.665 ns |  3.1047 ns |  2.7522 ns |   931.224 ns |
