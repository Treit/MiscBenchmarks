## Setting a property



``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.25982.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=8.0.100-preview.7.23376.3
  [Host]     : .NET 7.0.12 (7.0.1223.47720), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.12 (7.0.1223.47720), X64 RyuJIT AVX2


```
|                              Method |      Mean |     Error |    StdDev |   Gen0 | Allocated |
|------------------------------------ |----------:|----------:|----------:|-------:|----------:|
|                 SetPropertyNormally |  8.729 ns | 0.4682 ns | 1.3282 ns | 0.0055 |      24 B |
|             SetPropertyUsingDynamic | 18.029 ns | 0.2170 ns | 0.1812 ns | 0.0055 |      24 B |
|          SetPropertyUsingReflection | 70.170 ns | 1.4724 ns | 2.1116 ns | 0.0055 |      24 B |
| SetPropertyUsingNonGenericInterface | 15.461 ns | 0.1316 ns | 0.1166 ns | 0.0055 |      24 B |
