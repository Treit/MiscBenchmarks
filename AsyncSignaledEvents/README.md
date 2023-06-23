## Letting one through at a time using reset events and semaphores.

``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 11 (10.0.25393.1)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.300-preview.23179.2
  [Host]     : .NET 7.0.7 (7.0.723.27404), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.7 (7.0.723.27404), X64 RyuJIT AVX2


```
|                     Method | Count |      Mean |    Error |   StdDev |    Gen0 |   Gen1 | Allocated |
|--------------------------- |------ |----------:|---------:|---------:|--------:|-------:|----------:|
|         SemaphoreSlimAsync |   100 | 138.91 μs | 2.680 μs | 2.979 μs | 10.0098 | 0.4883 |  41.72 KB |
|        AsyncSemaphoreAsync |   100 | 187.32 μs | 3.724 μs | 5.221 μs | 12.2070 | 0.9766 |  51.04 KB |
| AsyncManualResetEventAsync |   100 |  72.84 μs | 1.402 μs | 1.920 μs |  5.4932 | 0.1221 |  23.49 KB |
