## Setting a property


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.25982.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=8.0.100-preview.7.23376.3
  [Host]     : .NET 7.0.12 (7.0.1223.47720), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.12 (7.0.1223.47720), X64 RyuJIT AVX2


```
|                     Method |     Mean |    Error |   StdDev |   Gen0 | Allocated |
|--------------------------- |---------:|---------:|---------:|-------:|----------:|
|        SetPropertyNormally | 24.23 ns | 0.550 ns | 1.379 ns | 0.0111 |      48 B |
|    SetPropertyUsingDynamic | 31.07 ns | 0.674 ns | 1.956 ns | 0.0111 |      48 B |
| SetPropertyUsingReflection | 84.42 ns | 1.759 ns | 2.225 ns | 0.0111 |      48 B |
