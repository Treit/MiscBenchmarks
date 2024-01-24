# Regular dictionary vs FrozeDictionary.



``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                      Method | Count |     Mean |     Error |    StdDev | Ratio | Allocated | Alloc Ratio |
|---------------------------- |------ |---------:|----------:|----------:|------:|----------:|------------:|
|       LookupUsingDictionary |  1000 | 4.228 ns | 0.0392 ns | 0.0348 ns |  1.00 |         - |          NA |
| LookupUsingFrozenDictionary |  1000 | 2.436 ns | 0.0077 ns | 0.0069 ns |  0.58 |         - |          NA |
