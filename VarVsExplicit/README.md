## Compile times using var vs explicit type in C# code.

(Don't ask me why.)


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                        Method |    Mean |    Error |   StdDev | Ratio | RatioSD |
|------------------------------ |--------:|---------:|---------:|------:|--------:|
| BuildCodeThatUsesExplicitType | 2.333 s | 0.0289 s | 0.0256 s |  1.00 |    0.00 |
|          BuildCodeThatUsesVar | 2.597 s | 0.0454 s | 0.0425 s |  1.11 |    0.03 |
