## Compile times using var vs explicit type in C# code.

(Don't ask me why.)

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.22455
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=6.0.100-preview.7.21379.14
  [Host]     : .NET Core 5.0.9 (CoreCLR 5.0.921.35908, CoreFX 5.0.921.35908), X64 RyuJIT
  DefaultJob : .NET Core 5.0.9 (CoreCLR 5.0.921.35908, CoreFX 5.0.921.35908), X64 RyuJIT


```
|                        Method |    Mean |    Error |   StdDev | Ratio | RatioSD |
|------------------------------ |--------:|---------:|---------:|------:|--------:|
| BuildCodeThatUsesExplicitType | 3.093 s | 0.0483 s | 0.0428 s |  1.00 |    0.00 |
|          BuildCodeThatUsesVar | 3.460 s | 0.0587 s | 0.0521 s |  1.12 |    0.03 |
