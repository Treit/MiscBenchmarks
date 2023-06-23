## Letting one through at a time using reset events and semaphores.

``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 11 (10.0.25393.1)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.300-preview.23179.2
  [Host]     : .NET 7.0.7 (7.0.723.27404), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.7 (7.0.723.27404), X64 RyuJIT AVX2


```
|                         Method | Count |      Mean |    Error |   StdDev |    Gen0 |   Gen1 | Allocated |
|------------------------------- |------ |----------:|---------:|---------:|--------:|-------:|----------:|
|             SemaphoreSlimAsync |   100 | 139.74 μs | 2.744 μs | 3.936 μs | 10.0098 | 0.4883 |  41.71 KB |
|            AsyncSemaphoreAsync |   100 | 182.31 μs | 3.612 μs | 4.568 μs | 12.2070 |      - |  51.15 KB |
|     AsyncManualResetEventAsync |   100 |  74.30 μs | 1.468 μs | 3.128 μs |  5.4932 |      - |  23.48 KB |
| AsyncManualResetEventNitoAsync |   100 |  67.07 μs | 1.325 μs | 2.737 μs |  5.4932 |      - |  23.46 KB |
