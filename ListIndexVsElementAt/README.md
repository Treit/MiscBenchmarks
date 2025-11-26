# List index vs. ElementAt




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                      | Count   | Mean         | Error      | StdDev     |
|---------------------------- |-------- |-------------:|-----------:|-----------:|
| **LookupElementsWithIndexing**  | **10000**   |     **9.347 μs** |  **0.0597 μs** |  **0.0529 μs** |
| LookupElementsWithElementAt | 10000   |     9.379 μs |  0.0672 μs |  0.0629 μs |
| **LookupElementsWithIndexing**  | **1000000** | **4,456.176 μs** | **28.9066 μs** | **27.0393 μs** |
| LookupElementsWithElementAt | 1000000 | 4,787.752 μs | 37.1568 μs | 34.7565 μs |
