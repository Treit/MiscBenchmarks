# Getting the type


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                     Method | Count |      Mean |     Error |    StdDev | Allocated |
|--------------------------- |------ |----------:|----------:|----------:|----------:|
|       UsingSwitchAndTypeOf | 10000 |  8.599 μs | 0.0230 μs | 0.0204 μs |         - |
| UsingTypeOfExtensionMethod | 10000 |  6.226 μs | 0.0407 μs | 0.0381 μs |         - |
|               UsingGetType | 10000 | 18.817 μs | 0.0354 μs | 0.0331 μs |         - |
