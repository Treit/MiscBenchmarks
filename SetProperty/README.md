## Setting a property




``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                              Method |      Mean |     Error |    StdDev |   Gen0 | Allocated |
|------------------------------------ |----------:|----------:|----------:|-------:|----------:|
|                 SetPropertyNormally |  7.871 ns | 0.0360 ns | 0.0319 ns | 0.0014 |      24 B |
|             SetPropertyUsingDynamic | 12.707 ns | 0.0757 ns | 0.0708 ns | 0.0014 |      24 B |
|          SetPropertyUsingReflection | 43.126 ns | 0.0752 ns | 0.0628 ns | 0.0014 |      24 B |
| SetPropertyUsingNonGenericInterface | 12.008 ns | 0.0562 ns | 0.0469 ns | 0.0014 |      24 B |
