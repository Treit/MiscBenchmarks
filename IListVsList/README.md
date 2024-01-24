# List<T> vs. IList<T>


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                 Method |  Count |          Mean |        Error |        StdDev |
|----------------------- |------- |--------------:|-------------:|--------------:|
|  **LookupElementWithList** |    **100** |      **64.11 ns** |     **1.303 ns** |      **1.338 ns** |
| LookupElementWithIList |    100 |      89.43 ns |     1.788 ns |      2.621 ns |
|  **LookupElementWithList** | **100000** | **483,274.37 ns** |   **424.870 ns** |    **376.636 ns** |
| LookupElementWithIList | 100000 | 454,096.88 ns | 9,067.329 ns | 11,135.495 ns |
