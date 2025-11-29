# Overhead of thread creation.





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method  | Job       | Runtime   | Count | ThreadCount | Mean     | Error     | StdDev    | Gen0   | Allocated |
|-------- |---------- |---------- |------ |------------ |---------:|----------:|----------:|-------:|----------:|
| WaitAll | .NET 10.0 | .NET 10.0 | 1     | 16          | 5.857 μs | 0.1254 μs | 0.3496 μs | 0.1755 |   2.87 KB |
| WhenAll | .NET 10.0 | .NET 10.0 | 1     | 16          | 7.857 μs | 0.5287 μs | 1.5589 μs | 0.1678 |   2.83 KB |
| WaitAll | .NET 9.0  | .NET 9.0  | 1     | 16          | 6.059 μs | 0.1545 μs | 0.4382 μs | 0.1755 |   2.87 KB |
| WhenAll | .NET 9.0  | .NET 9.0  | 1     | 16          | 6.468 μs | 0.1285 μs | 0.2506 μs | 0.1678 |   2.83 KB |
