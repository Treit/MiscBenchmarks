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
| EnumerateDictionaryKeys              | 1000  | 982.2 ns | 14.83 ns | 13.87 ns |  2.37 |    0.03 |         - |          NA |
| EnumerateDictionaryKeyValuePairs     | 1000  | 966.8 ns |  8.90 ns |  8.33 ns |  2.33 |    0.02 |         - |          NA |
| EnumerateDictionaryKeysCachedInArray | 1000  | 414.8 ns |  2.51 ns |  2.35 ns |  1.00 |    0.01 |         - |          NA |
