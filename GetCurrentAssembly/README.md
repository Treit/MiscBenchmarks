# Getting the current assembly.

``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.25963.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=8.0.100-preview.7.23376.3
  [Host]     : .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2


```
|               Method |      Mean |     Error |    StdDev |    Median | Ratio |
|--------------------- |----------:|----------:|----------:|----------:|------:|
| GetExecutingAssembly | 766.99 ns | 15.418 ns | 43.234 ns | 752.20 ns |  1.00 |
|    TypeofDotAssembly |  10.50 ns |  0.282 ns |  0.648 ns |  10.30 ns |  0.01 |
