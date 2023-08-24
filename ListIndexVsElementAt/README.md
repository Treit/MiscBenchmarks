# List index vs. ElementAt

``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.25936.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.400
  [Host]     : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2


```
|                      Method |   Count |         Mean |      Error |     StdDev |
|---------------------------- |-------- |-------------:|-----------:|-----------:|
|  **LookupElementsWithIndexing** |   **10000** |     **41.24 μs** |   **0.586 μs** |   **0.519 μs** |
| LookupElementsWithElementAt |   10000 |    159.88 μs |   3.008 μs |   2.954 μs |
|  **LookupElementsWithIndexing** | **1000000** |  **4,620.15 μs** |  **91.280 μs** | **112.099 μs** |
| LookupElementsWithElementAt | 1000000 | 16,102.71 μs | 288.861 μs | 385.622 μs |
