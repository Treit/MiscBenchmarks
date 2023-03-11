# Lookup by type using both dictionary and switch expressions

``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.25305.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.201
  [Host]     : .NET 7.0.3 (7.0.323.6910), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.3 (7.0.323.6910), X64 RyuJIT AVX2


```
|                            Method |      Mean |     Error |    StdDev |   Gen0 | Allocated |
|---------------------------------- |----------:|----------:|----------:|-------:|----------:|
| LookupTypeUsingDictionary100Items |  3.698 μs | 0.0725 μs | 0.1170 μs | 0.0687 |     304 B |
|   LookupTypeUsingDictionary5Items |  3.603 μs | 0.0699 μs | 0.0858 μs | 0.0687 |     304 B |
|       LookupTypeUsingSwitch5Items |  1.747 μs | 0.0342 μs | 0.0336 μs | 0.0687 |     304 B |
|     LookupTypeUsingSwitch100Items | 13.601 μs | 0.2301 μs | 0.2152 μs | 0.0610 |     304 B |
