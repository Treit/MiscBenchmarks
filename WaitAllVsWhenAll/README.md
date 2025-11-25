# Overhead of thread creation.



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method  | Count | ThreadCount | Mean     | Error     | StdDev    | Gen0   | Allocated |
|-------- |------ |------------ |---------:|----------:|----------:|-------:|----------:|
| WaitAll | 1     | 16          | 4.070 μs | 0.0781 μs | 0.0836 μs | 0.1755 |   2.87 KB |
| WhenAll | 1     | 16          | 4.056 μs | 0.0791 μs | 0.0972 μs | 0.1678 |   2.82 KB |
