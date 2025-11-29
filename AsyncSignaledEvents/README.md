## Letting one through at a time using reset events and semaphores.



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                         | Job       | Runtime   | Count | Mean     | Error    | StdDev   | Gen0   | Gen1   | Allocated |
|------------------------------- |---------- |---------- |------ |---------:|---------:|---------:|-------:|-------:|----------:|
| SemaphoreSlimAsync             | .NET 10.0 | .NET 10.0 | 100   | 64.21 μs | 1.261 μs | 2.000 μs | 2.0752 |      - |  34.59 KB |
| AsyncSemaphoreAsync            | .NET 10.0 | .NET 10.0 | 100   | 68.20 μs | 1.356 μs | 1.901 μs | 2.1973 | 0.1221 |  36.05 KB |
| AsyncManualResetEventAsync     | .NET 10.0 | .NET 10.0 | 100   | 44.13 μs | 0.597 μs | 0.558 μs | 1.3428 |      - |  22.68 KB |
| AsyncManualResetEventNitoAsync | .NET 10.0 | .NET 10.0 | 100   | 39.47 μs | 0.783 μs | 0.804 μs | 1.3428 |      - |  22.68 KB |
| SemaphoreSlimAsync             | .NET 9.0  | .NET 9.0  | 100   | 62.62 μs | 1.245 μs | 1.704 μs | 1.9531 |      - |  33.14 KB |
| AsyncSemaphoreAsync            | .NET 9.0  | .NET 9.0  | 100   | 66.75 μs | 1.737 μs | 4.871 μs | 2.4414 |      - |  42.57 KB |
| AsyncManualResetEventAsync     | .NET 9.0  | .NET 9.0  | 100   | 44.61 μs | 0.830 μs | 0.815 μs | 1.3428 |      - |  22.68 KB |
| AsyncManualResetEventNitoAsync | .NET 9.0  | .NET 9.0  | 100   | 38.81 μs | 0.744 μs | 0.796 μs | 1.3428 |      - |  22.68 KB |
