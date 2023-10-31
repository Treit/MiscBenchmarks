# Calling methods on sealed vs non-sealed classes.



``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.25987.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=8.0.100-preview.7.23376.3
  [Host]     : .NET 8.0.0 (8.0.23.37506), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.0 (8.0.23.37506), X64 RyuJIT AVX2


```
|  Method |     Mean |    Error |   StdDev |
|-------- |---------:|---------:|---------:|
| Classes | 977.2 ns | 12.49 ns | 11.07 ns |
| Records | 980.0 ns | 15.56 ns | 14.55 ns |
