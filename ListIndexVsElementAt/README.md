# List index vs. ElementAt





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                      | Job       | Runtime   | Count   | Mean         | Error     | StdDev    |
|---------------------------- |---------- |---------- |-------- |-------------:|----------:|----------:|
| **LookupElementsWithIndexing**  | **.NET 10.0** | **.NET 10.0** | **10000**   |     **9.308 μs** | **0.0174 μs** | **0.0145 μs** |
| LookupElementsWithElementAt | .NET 10.0 | .NET 10.0 | 10000   |     9.377 μs | 0.0975 μs | 0.0762 μs |
| LookupElementsWithIndexing  | .NET 9.0  | .NET 9.0  | 10000   |     9.302 μs | 0.0254 μs | 0.0225 μs |
| LookupElementsWithElementAt | .NET 9.0  | .NET 9.0  | 10000   |     9.327 μs | 0.0375 μs | 0.0351 μs |
| **LookupElementsWithIndexing**  | **.NET 10.0** | **.NET 10.0** | **1000000** | **4,431.199 μs** | **5.9726 μs** | **5.5868 μs** |
| LookupElementsWithElementAt | .NET 10.0 | .NET 10.0 | 1000000 | 4,731.196 μs | 3.7010 μs | 3.0905 μs |
| LookupElementsWithIndexing  | .NET 9.0  | .NET 9.0  | 1000000 | 4,428.153 μs | 3.4679 μs | 3.0742 μs |
| LookupElementsWithElementAt | .NET 9.0  | .NET 9.0  | 1000000 | 4,740.594 μs | 3.5964 μs | 3.1881 μs |
