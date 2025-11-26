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
| CreateUsingNew                     | 1000  | 31.09 μs | 0.549 μs | 0.514 μs | 5.7373 | 1.4038 |  94.34 KB |
| CreateUsingActivatorCreateInstance | 1000  | 31.39 μs | 0.532 μs | 0.471 μs | 5.7373 | 1.4038 |  94.34 KB |
