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
| **DictionaryContainsKey**               | **10**    |         **563.9 ns** |         **8.16 ns** |         **7.64 ns** |
| ConcurrentDictionaryContainsKey     | 10    |         562.8 ns |         5.23 ns |         4.89 ns |
| DictionaryKeysDotContains           | 10    |         573.6 ns |         6.96 ns |         5.81 ns |
| ConcurrentDictionaryKeysDotContains | 10    |       2,438.7 ns |        31.65 ns |        26.43 ns |
| **DictionaryContainsKey**               | **10000** |     **406,525.6 ns** |     **2,289.09 ns** |     **2,029.22 ns** |
| ConcurrentDictionaryContainsKey     | 10000 |     362,813.8 ns |     4,729.65 ns |     4,424.12 ns |
| DictionaryKeysDotContains           | 10000 |     407,380.2 ns |     3,326.24 ns |     3,111.37 ns |
| ConcurrentDictionaryKeysDotContains | 10000 | 861,314,273.3 ns | 7,317,567.14 ns | 6,844,856.85 ns |
