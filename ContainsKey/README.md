# Checking if a dictionary contains a key




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                              | Count | Mean             | Error           | StdDev          |
|------------------------------------ |------ |-----------------:|----------------:|----------------:|
| **DictionaryContainsKey**               | **10**    |         **561.4 ns** |         **6.43 ns** |         **5.70 ns** |
| ConcurrentDictionaryContainsKey     | 10    |         559.1 ns |         6.43 ns |         6.01 ns |
| DictionaryKeysDotContains           | 10    |         574.2 ns |         5.47 ns |         4.85 ns |
| ConcurrentDictionaryKeysDotContains | 10    |       2,249.8 ns |        27.71 ns |        25.92 ns |
| **DictionaryContainsKey**               | **10000** |     **405,259.2 ns** |     **2,060.01 ns** |     **1,720.20 ns** |
| ConcurrentDictionaryContainsKey     | 10000 |     356,412.4 ns |     3,761.22 ns |     3,140.79 ns |
| DictionaryKeysDotContains           | 10000 |     408,904.1 ns |     3,739.13 ns |     3,497.58 ns |
| ConcurrentDictionaryKeysDotContains | 10000 | 877,167,533.3 ns | 7,088,152.62 ns | 6,630,262.37 ns |
