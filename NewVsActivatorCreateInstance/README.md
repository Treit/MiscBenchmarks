# New vs. Activator.CreateInstance





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                             | Count | Mean     | Error    | StdDev   | Gen0   | Gen1   | Allocated |
|----------------------------------- |------ |---------:|---------:|---------:|-------:|-------:|----------:|
| CreateUsingNew                     | 1000  | 31.12 μs | 0.458 μs | 0.406 μs | 5.7373 | 1.4038 |  94.34 KB |
| CreateUsingActivatorCreateInstance | 1000  | 31.34 μs | 0.478 μs | 0.424 μs | 5.7373 | 1.4038 |  94.34 KB |
