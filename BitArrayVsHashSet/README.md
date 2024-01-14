## Looking up integer values in a bit array vs. a HashSet




``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|              Method |       Mean |   Error |  StdDev | Ratio |
|-------------------- |-----------:|--------:|--------:|------:|
|  LookupUsingHashSet | 2,418.9 ns | 3.80 ns | 3.37 ns |  1.00 |
| LookupUsingBitArray |   557.6 ns | 0.61 ns | 0.51 ns |  0.23 |
