# New vs. Activator.CreateInstance




```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26090.1)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-preview.2.24157.14
  [Host]     : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                             | Count | Mean     | Error    | StdDev   | Gen0    | Gen1   | Allocated |
|----------------------------------- |------ |---------:|---------:|---------:|--------:|-------:|----------:|
| CreateUsingNew                     | 1000  | 63.21 μs | 1.276 μs | 3.620 μs | 22.3389 | 4.8828 |  94.34 KB |
| CreateUsingActivatorCreateInstance | 1000  | 64.00 μs | 1.247 μs | 2.048 μs | 22.3389 | 4.8828 |  94.34 KB |
