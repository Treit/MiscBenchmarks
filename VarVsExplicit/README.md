## Compile times using var vs explicit type in C# code.

(Don't ask me why.)



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                        | Mean    | Error    | StdDev   | Ratio | RatioSD |
|------------------------------ |--------:|---------:|---------:|------:|--------:|
| BuildCodeThatUsesExplicitType | 2.387 s | 0.0353 s | 0.0330 s |  1.00 |    0.02 |
| BuildCodeThatUsesVar          | 2.688 s | 0.0371 s | 0.0328 s |  1.13 |    0.02 |
