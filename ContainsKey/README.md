# Checking if a dictionary contains a key


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                              Method | Count |               Mean |           Error |          StdDev |
|------------------------------------ |------ |-------------------:|----------------:|----------------:|
|               **DictionaryContainsKey** |    **10** |           **619.7 ns** |         **2.26 ns** |         **2.12 ns** |
|     ConcurrentDictionaryContainsKey |    10 |           615.6 ns |         2.03 ns |         1.58 ns |
|           DictionaryKeysDotContains |    10 |           624.0 ns |         3.26 ns |         3.05 ns |
| ConcurrentDictionaryKeysDotContains |    10 |         2,468.1 ns |        16.88 ns |        15.79 ns |
|               **DictionaryContainsKey** | **10000** |       **412,762.4 ns** |     **1,805.72 ns** |     **1,689.07 ns** |
|     ConcurrentDictionaryContainsKey | 10000 |       370,226.1 ns |     1,651.52 ns |     1,544.84 ns |
|           DictionaryKeysDotContains | 10000 |       417,660.7 ns |     2,014.34 ns |     1,785.66 ns |
| ConcurrentDictionaryKeysDotContains | 10000 | 1,159,663,840.0 ns | 7,746,638.16 ns | 7,246,210.14 ns |
