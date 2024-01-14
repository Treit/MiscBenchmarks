# Comparing two byte arrays


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                   Method | Count |       Mean |    Error |   StdDev | Ratio | Allocated | Alloc Ratio |
|------------------------- |------ |-----------:|---------:|---------:|------:|----------:|------------:|
|            CompareNormal | 10000 | 3,117.8 ns | 16.02 ns | 14.20 ns |  1.00 |         - |          NA |
|  CompareUnsafeHandRolled | 10000 |   782.4 ns |  2.27 ns |  2.01 ns |  0.25 |         - |          NA |
| CompareSpanSequenceEqual | 10000 |   195.4 ns |  0.19 ns |  0.17 ns |  0.06 |         - |          NA |
