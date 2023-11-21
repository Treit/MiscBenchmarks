## Looking up integer values in a bit array vs. a HashSet



``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.26002.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=8.0.100-rc.2.23502.2
  [Host]     : .NET 7.0.14 (7.0.1423.51910), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.14 (7.0.1423.51910), X64 RyuJIT AVX2


```
|              Method |       Mean |    Error |    StdDev | Ratio |
|-------------------- |-----------:|---------:|----------:|------:|
|  LookupUsingHashSet | 3,206.1 ns | 63.86 ns | 123.04 ns |  1.00 |
| LookupUsingBitArray |   723.3 ns | 14.24 ns |  23.80 ns |  0.22 |
