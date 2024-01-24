# Checking if dictionaries are empty


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                         Method | Count |     Mean |     Error |    StdDev |   Median | Ratio | RatioSD | Allocated | Alloc Ratio |
|------------------------------- |------ |---------:|----------:|----------:|---------:|------:|--------:|----------:|------------:|
| CheckDictionaryEmptyUsingCount |  1000 | 2.162 μs | 0.0431 μs | 0.0788 μs | 2.127 μs |  1.00 |    0.00 |         - |          NA |
|   CheckDictionaryEmptyUsingAny |  1000 | 5.144 μs | 0.0996 μs | 0.1147 μs | 5.152 μs |  2.38 |    0.13 |         - |          NA |
