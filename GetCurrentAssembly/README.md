# Getting the current assembly.


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.25284.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.102
  [Host]     : .NET 7.0.2 (7.0.222.60605), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.2 (7.0.222.60605), X64 RyuJIT AVX2


```
|               Method |      Mean |     Error |    StdDev | Ratio |
|--------------------- |----------:|----------:|----------:|------:|
| GetExecutingAssembly | 735.59 ns | 20.831 ns | 59.093 ns |  1.00 |
|    TypeofDotAssembly |  10.52 ns |  0.289 ns |  0.821 ns |  0.01 |
