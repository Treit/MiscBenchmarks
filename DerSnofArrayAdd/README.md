# Array sum from der snof on the C# community discord




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                 | Mean     | Error   | StdDev  |
|----------------------- |---------:|--------:|--------:|
| DerSnofSumArrayManaged | 626.4 μs | 0.85 μs | 0.66 μs |
| DerSnofSumArrayUnsafe  | 318.9 μs | 0.89 μs | 0.75 μs |
| ArraySumLinq           | 181.2 μs | 0.52 μs | 0.48 μs |
