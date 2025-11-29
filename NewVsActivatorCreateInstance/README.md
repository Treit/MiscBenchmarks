# New vs. Activator.CreateInstance







```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                             | Job       | Runtime   | Count | Mean     | Error    | StdDev   | Gen0   | Gen1   | Allocated |
|----------------------------------- |---------- |---------- |------ |---------:|---------:|---------:|-------:|-------:|----------:|
| CreateUsingNew                     | .NET 10.0 | .NET 10.0 | 1000  | 34.62 μs | 0.197 μs | 0.184 μs | 5.7373 | 1.4038 |  94.34 KB |
| CreateUsingActivatorCreateInstance | .NET 10.0 | .NET 10.0 | 1000  | 30.35 μs | 0.136 μs | 0.113 μs | 5.7678 | 1.4343 |  94.34 KB |
| CreateUsingNew                     | .NET 9.0  | .NET 9.0  | 1000  | 30.56 μs | 0.315 μs | 0.263 μs | 5.7373 | 1.4038 |  94.34 KB |
| CreateUsingActivatorCreateInstance | .NET 9.0  | .NET 9.0  | 1000  | 30.34 μs | 0.217 μs | 0.192 μs | 5.7678 | 1.4343 |  94.34 KB |
