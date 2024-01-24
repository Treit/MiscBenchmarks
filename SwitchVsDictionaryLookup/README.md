# Lookup by type using both dictionary and switch expressions


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                            Method |      Mean |     Error |    StdDev |   Gen0 | Allocated |
|---------------------------------- |----------:|----------:|----------:|-------:|----------:|
| LookupTypeUsingDictionary100Items |  2.155 μs | 0.0018 μs | 0.0016 μs | 0.0153 |     304 B |
|   LookupTypeUsingDictionary5Items |  2.136 μs | 0.0042 μs | 0.0035 μs | 0.0153 |     304 B |
|       LookupTypeUsingSwitch5Items |  1.252 μs | 0.0036 μs | 0.0032 μs | 0.0172 |     304 B |
|     LookupTypeUsingSwitch100Items | 10.801 μs | 0.0259 μs | 0.0230 μs | 0.0153 |     304 B |
