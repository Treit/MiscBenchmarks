# Task.FromResult and Task.CompletedTask


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|        Method |      Mean |    Error |   StdDev |   Gen0 |   Gen1 |   Gen2 | Allocated |
|-------------- |----------:|---------:|---------:|-------:|-------:|-------:|----------:|
|   RegularLock |  23.03 μs | 0.187 μs | 0.166 μs | 0.1831 |      - |      - |   3.42 KB |
| SemaphoreSlim | 106.97 μs | 2.092 μs | 2.793 μs | 1.2207 | 0.9766 |      - |  23.26 KB |
|  AsyncMonitor | 204.74 μs | 4.056 μs | 5.129 μs | 3.9063 | 3.4180 | 0.9766 |  54.18 KB |
