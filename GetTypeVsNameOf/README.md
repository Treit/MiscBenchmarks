# GetType.Name vs. nameof

``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.25926.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.306
  [Host]     : .NET 7.0.9 (7.0.923.32018), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.9 (7.0.923.32018), X64 RyuJIT AVX2


```
|         Method |     Mean |     Error |    StdDev | Ratio | RatioSD | Allocated | Alloc Ratio |
|--------------- |---------:|----------:|----------:|------:|--------:|----------:|------------:|
|  NameViaNameOf | 1.155 ns | 0.0945 ns | 0.1952 ns |  1.00 |    0.00 |         - |          NA |
| NameViaGetType | 4.279 ns | 0.0937 ns | 0.0877 ns |  3.65 |    0.74 |         - |          NA |
