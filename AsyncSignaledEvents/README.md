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
|             SemaphoreAsync |   100 | 128.17 μs | 2.562 μs | 3.147 μs |  9.7656 | 0.2441 |  41.07 KB |
|        AsyncSemaphoreAsync |   100 | 184.71 μs | 3.689 μs | 6.838 μs | 11.7188 | 0.2441 |  49.04 KB |
| AsyncManualResetEventAsync |   100 |  75.16 μs | 1.489 μs | 1.829 μs |  5.4932 |      - |  23.48 KB |
