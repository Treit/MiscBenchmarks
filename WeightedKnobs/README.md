# Test getting random weighted values




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  Job-KEOOAO : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2

OutlierMode=DontRemove  MemoryRandomization=True  

```
| Method                             | Count | Mean         | Error      | StdDev     | Ratio  | RatioSD | Gen0      | Gen1      | Gen2     | Allocated   | Alloc Ratio |
|----------------------------------- |------ |-------------:|-----------:|-----------:|-------:|--------:|----------:|----------:|---------:|------------:|------------:|
| GetRandomWeightedKnobsOriginal     | 5000  | 39,285.13 μs | 257.284 μs | 240.664 μs | 588.22 |    9.45 | 1076.9231 | 1000.0000 | 538.4615 | 13061.42 KB |      166.79 |
| GetRandomWeightedKnobsBinarySearch | 5000  |    135.11 μs |   2.084 μs |   1.949 μs |   2.02 |    0.04 |    4.6387 |    0.4883 |        - |    78.38 KB |        1.00 |
| GetRandomWeightedKnobsFenwickTree  | 5000  |     66.80 μs |   1.101 μs |   1.030 μs |   1.00 |    0.02 |    4.7607 |    0.4883 |        - |    78.31 KB |        1.00 |
