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
| DerSnofSumArrayManaged | 630.8 μs | 5.07 μs | 4.23 μs |
| DerSnofSumArrayUnsafe  | 321.5 μs | 2.56 μs | 2.39 μs |
| ArraySumLinq           | 181.7 μs | 0.83 μs | 0.78 μs |
