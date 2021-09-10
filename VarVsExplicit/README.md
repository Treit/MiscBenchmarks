## Compile times using var vs explicit type in C# code.

(Don't ask me why.)

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.22455
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=6.0.100-preview.7.21379.14
  [Host]   : .NET Core 5.0.9 (CoreCLR 5.0.921.35908, CoreFX 5.0.921.35908), X64 RyuJIT
  ShortRun : .NET Core 5.0.9 (CoreCLR 5.0.921.35908, CoreFX 5.0.921.35908), X64 RyuJIT

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
|                        Method |    Mean |    Error |   StdDev | Ratio | Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------ |--------:|---------:|---------:|------:|------:|------:|------:|----------:|
| BuildCodeThatUsesExplicitType | 3.092 s | 1.1912 s | 0.0653 s |  1.00 |     - |     - |     - |  77.39 KB |
|          BuildCodeThatUsesVar | 3.350 s | 0.6151 s | 0.0337 s |  1.08 |     - |     - |     - |   77.3 KB |
