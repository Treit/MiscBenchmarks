## Compile times using var vs explicit type in C# code.

(Don't ask me why.)





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                        | Job       | Runtime   | Mean     | Error   | StdDev  | Ratio |
|------------------------------ |---------- |---------- |---------:|--------:|--------:|------:|
| BuildCodeThatUsesExplicitType | .NET 10.0 | .NET 10.0 | 117.8 ms | 0.70 ms | 0.62 ms |  1.00 |
| BuildCodeThatUsesVar          | .NET 10.0 | .NET 10.0 | 117.8 ms | 0.71 ms | 0.63 ms |  1.00 |
|                               |           |           |          |         |         |       |
| BuildCodeThatUsesExplicitType | .NET 9.0  | .NET 9.0  | 118.0 ms | 0.91 ms | 0.81 ms |  1.00 |
| BuildCodeThatUsesVar          | .NET 9.0  | .NET 9.0  | 118.0 ms | 1.06 ms | 0.83 ms |  1.00 |
