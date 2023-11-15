# Checking if something is one of two values. Yes, the hash table check really was found in production code.


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.25997.1010)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=8.0.100-rc.2.23502.2
  [Host]     : .NET 7.0.14 (7.0.1423.51910), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.14 (7.0.1423.51910), X64 RyuJIT AVX2


```
|                Method |       Mean |     Error |    StdDev | Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|---------------------- |-----------:|----------:|----------:|------:|--------:|-------:|----------:|------------:|
|     CheckWithSimpleIf |  0.8573 ns | 0.0511 ns | 0.0525 ns |  1.00 |    0.00 |      - |         - |          NA |
| CheckWithNewHashTable | 76.0926 ns | 1.5023 ns | 1.6698 ns | 89.01 |    5.51 | 0.0408 |     176 B |          NA |
