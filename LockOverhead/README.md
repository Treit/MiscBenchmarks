# Reading and writing a string field with and without locking to demonstrate lock overhead.

``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.25931.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.306
  [Host]     : .NET 6.0.20 (6.0.2023.32017), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.20 (6.0.2023.32017), X64 RyuJIT AVX2


```
|        Method |       Mean |     Error |    StdDev |
|-------------- |-----------:|----------:|----------:|
|  ReadWithLock | 17.3991 ns | 0.2344 ns | 0.2193 ns |
|          Read |  0.1801 ns | 0.0251 ns | 0.0209 ns |
| WriteWithLock | 17.4761 ns | 0.3055 ns | 0.2858 ns |
|         Write |  1.2007 ns | 0.0354 ns | 0.0295 ns |
