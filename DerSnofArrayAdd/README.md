# Array sum from der snof on the C# community discord

```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.4602/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK 9.0.101
  [Host]     : .NET 8.0.11 (8.0.1124.51707), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.11 (8.0.1124.51707), X64 RyuJIT AVX2


```
| Method                 | Mean     | Error   | StdDev  |
|----------------------- |---------:|--------:|--------:|
| DerSnofSumArrayManaged | 628.4 μs | 1.58 μs | 1.23 μs |
| DerSnofSumArrayUnsafe  | 322.5 μs | 2.88 μs | 2.55 μs |
| ArraySumLinq           | 179.9 μs | 0.54 μs | 0.45 μs |