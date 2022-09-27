# Comparing two byte arrays

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.25206
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=7.0.100-preview.5.22307.18
  [Host]     : .NET Core 6.0.9 (CoreCLR 6.0.922.41905, CoreFX 6.0.922.41905), X64 RyuJIT
  DefaultJob : .NET Core 6.0.9 (CoreCLR 6.0.922.41905, CoreFX 6.0.922.41905), X64 RyuJIT


```
|                    Method | Count |       Mean |    Error |    StdDev | Ratio | Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------- |------ |-----------:|---------:|----------:|------:|------:|------:|------:|----------:|
|             CompareNormal | 10000 | 4,635.0 ns | 91.83 ns | 243.51 ns |  1.00 |     - |     - |     - |         - |
|   CompareUnsafeHandRolled | 10000 |   572.5 ns |  9.33 ns |   9.16 ns |  0.12 |     - |     - |     - |         - |
| CompareSpanSequenceEquals | 10000 |   198.3 ns |  3.65 ns |   7.12 ns |  0.04 |     - |     - |     - |         - |
