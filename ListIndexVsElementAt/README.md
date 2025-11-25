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
| **LookupElementsWithIndexing**  | **10000**   |     **9.344 μs** |  **0.0487 μs** |  **0.0456 μs** |
| LookupElementsWithElementAt | 10000   |     9.375 μs |  0.0682 μs |  0.0638 μs |
| **LookupElementsWithIndexing**  | **1000000** | **4,458.619 μs** | **26.7988 μs** | **25.0676 μs** |
| LookupElementsWithElementAt | 1000000 | 4,861.369 μs | 45.6255 μs | 42.6782 μs |
