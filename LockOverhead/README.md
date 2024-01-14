# Reading and writing a string field with and without locking to demonstrate lock overhead.


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|        Method |      Mean |     Error |    StdDev |
|-------------- |----------:|----------:|----------:|
|  ReadWithLock | 7.0211 ns | 0.0572 ns | 0.0507 ns |
|          Read | 0.3850 ns | 0.0084 ns | 0.0074 ns |
| WriteWithLock | 8.1861 ns | 0.0369 ns | 0.0327 ns |
|         Write | 2.4764 ns | 0.0022 ns | 0.0019 ns |
