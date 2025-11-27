# Checking if a dictionary contains a key





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                              | Job       | Runtime   | Count | Mean             | Error           | StdDev          |
|------------------------------------ |---------- |---------- |------ |-----------------:|----------------:|----------------:|
| **DictionaryContainsKey**               | **.NET 10.0** | **.NET 10.0** | **10**    |         **568.6 ns** |         **6.74 ns** |         **6.30 ns** |
| ConcurrentDictionaryContainsKey     | .NET 10.0 | .NET 10.0 | 10    |         576.7 ns |         7.16 ns |         6.70 ns |
| DictionaryKeysDotContains           | .NET 10.0 | .NET 10.0 | 10    |         582.1 ns |         7.51 ns |         7.03 ns |
| ConcurrentDictionaryKeysDotContains | .NET 10.0 | .NET 10.0 | 10    |       2,330.4 ns |        28.67 ns |        26.82 ns |
| DictionaryContainsKey               | .NET 9.0  | .NET 9.0  | 10    |         603.2 ns |        12.11 ns |        19.22 ns |
| ConcurrentDictionaryContainsKey     | .NET 9.0  | .NET 9.0  | 10    |         578.6 ns |         8.71 ns |         8.15 ns |
| DictionaryKeysDotContains           | .NET 9.0  | .NET 9.0  | 10    |         585.6 ns |         7.44 ns |         6.96 ns |
| ConcurrentDictionaryKeysDotContains | .NET 9.0  | .NET 9.0  | 10    |       2,414.3 ns |        28.40 ns |        25.17 ns |
| **DictionaryContainsKey**               | **.NET 10.0** | **.NET 10.0** | **10000** |     **397,797.2 ns** |     **3,042.54 ns** |     **2,697.14 ns** |
| ConcurrentDictionaryContainsKey     | .NET 10.0 | .NET 10.0 | 10000 |     357,185.8 ns |     3,677.39 ns |     3,259.91 ns |
| DictionaryKeysDotContains           | .NET 10.0 | .NET 10.0 | 10000 |     404,656.3 ns |     3,032.38 ns |     2,836.49 ns |
| ConcurrentDictionaryKeysDotContains | .NET 10.0 | .NET 10.0 | 10000 | 863,471,753.3 ns | 7,017,427.39 ns | 6,564,105.94 ns |
| DictionaryContainsKey               | .NET 9.0  | .NET 9.0  | 10000 |     397,022.2 ns |     3,321.20 ns |     3,106.65 ns |
| ConcurrentDictionaryContainsKey     | .NET 9.0  | .NET 9.0  | 10000 |     356,088.1 ns |     3,646.70 ns |     3,045.16 ns |
| DictionaryKeysDotContains           | .NET 9.0  | .NET 9.0  | 10000 |     404,980.8 ns |     2,646.11 ns |     2,345.70 ns |
| ConcurrentDictionaryKeysDotContains | .NET 9.0  | .NET 9.0  | 10000 | 863,456,580.0 ns | 7,156,880.97 ns | 6,694,550.90 ns |
