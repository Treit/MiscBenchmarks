## Letting one through at a time using reset events and semaphores.


```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                         | Count | Mean      | Error    | StdDev   | Gen0   | Gen1   | Allocated |
|------------------------------- |------ |----------:|---------:|---------:|-------:|-------:|----------:|
| SemaphoreSlimAsync             | 100   |  79.14 μs | 1.552 μs | 1.524 μs | 2.4414 | 0.1221 |  40.13 KB |
| AsyncSemaphoreAsync            | 100   | 100.94 μs | 1.901 μs | 1.686 μs | 2.9297 | 0.2441 |   50.1 KB |
| AsyncManualResetEventAsync     | 100   |  61.60 μs | 0.898 μs | 0.840 μs | 1.3428 |      - |  22.67 KB |
| AsyncManualResetEventNitoAsync | 100   |  52.03 μs | 0.482 μs | 0.451 μs | 1.3428 |      - |  22.67 KB |
