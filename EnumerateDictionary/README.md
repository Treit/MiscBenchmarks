# Enumerating dictionary keys.



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  Job-KEOOAO : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2

OutlierMode=DontRemove  MemoryRandomization=True  

```
| Method                               | Count | Mean     | Error    | StdDev   | Ratio | RatioSD | Allocated | Alloc Ratio |
|------------------------------------- |------ |---------:|---------:|---------:|------:|--------:|----------:|------------:|
| EnumerateDictionaryKeys              | 1000  | 984.1 ns | 14.86 ns | 13.90 ns |  2.38 |    0.03 |         - |          NA |
| EnumerateDictionaryKeyValuePairs     | 1000  | 974.7 ns | 16.02 ns | 14.99 ns |  2.35 |    0.04 |         - |          NA |
| EnumerateDictionaryKeysCachedInArray | 1000  | 414.2 ns |  1.41 ns |  1.32 ns |  1.00 |    0.00 |         - |          NA |
