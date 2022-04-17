# Checking if a dictionary contains a key

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.22000
AMD Ryzen Threadripper 3960X, 1 CPU, 48 logical and 24 physical cores
.NET Core SDK=6.0.201
  [Host]     : .NET Core 5.0.7 (CoreCLR 5.0.721.25508, CoreFX 5.0.721.25508), X64 RyuJIT
  DefaultJob : .NET Core 5.0.7 (CoreCLR 5.0.721.25508, CoreFX 5.0.721.25508), X64 RyuJIT


```
|                              Method | Count |               Mean |            Error |           StdDev |
|------------------------------------ |------ |-------------------:|-----------------:|-----------------:|
|               **DictionaryContainsKey** |    **10** |           **687.5 ns** |          **5.53 ns** |          **5.17 ns** |
|     ConcurrentDictionaryContainsKey |    10 |           798.0 ns |         14.40 ns |         13.47 ns |
|           DictionaryKeysDotContains |    10 |           715.3 ns |         10.18 ns |          9.52 ns |
| ConcurrentDictionaryKeysDotContains |    10 |         6,568.2 ns |         63.27 ns |         59.18 ns |
|               **DictionaryContainsKey** | **10000** |       **417,190.4 ns** |      **7,837.56 ns** |      **7,331.26 ns** |
|     ConcurrentDictionaryContainsKey | 10000 |       448,793.0 ns |      3,101.03 ns |      2,900.71 ns |
|           DictionaryKeysDotContains | 10000 |       443,778.2 ns |        901.14 ns |        798.84 ns |
| ConcurrentDictionaryKeysDotContains | 10000 | 1,753,222,520.0 ns | 17,785,566.39 ns | 16,636,629.83 ns |
