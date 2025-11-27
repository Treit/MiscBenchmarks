# Enumerating dictionary keys.





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2

OutlierMode=DontRemove  MemoryRandomization=True  

```
| Method                               | Job       | Runtime   | Count | Mean       | Error    | StdDev   | Ratio | RatioSD | Allocated | Alloc Ratio |
|------------------------------------- |---------- |---------- |------ |-----------:|---------:|---------:|------:|--------:|----------:|------------:|
| EnumerateDictionaryKeys              | .NET 10.0 | .NET 10.0 | 1000  |   987.4 ns | 15.95 ns | 14.92 ns |  2.36 |    0.04 |         - |          NA |
| EnumerateDictionaryKeyValuePairs     | .NET 10.0 | .NET 10.0 | 1000  | 1,010.2 ns | 11.67 ns | 10.91 ns |  2.41 |    0.03 |         - |          NA |
| EnumerateDictionaryKeysCachedInArray | .NET 10.0 | .NET 10.0 | 1000  |   418.4 ns |  3.36 ns |  3.14 ns |  1.00 |    0.01 |         - |          NA |
|                                      |           |           |       |            |          |          |       |         |           |             |
| EnumerateDictionaryKeys              | .NET 9.0  | .NET 9.0  | 1000  |   991.1 ns | 19.80 ns | 41.77 ns |  2.36 |    0.10 |         - |          NA |
| EnumerateDictionaryKeyValuePairs     | .NET 9.0  | .NET 9.0  | 1000  | 1,011.6 ns | 14.39 ns | 13.46 ns |  2.41 |    0.04 |         - |          NA |
| EnumerateDictionaryKeysCachedInArray | .NET 9.0  | .NET 9.0  | 1000  |   420.4 ns |  3.43 ns |  3.21 ns |  1.00 |    0.01 |         - |          NA |
