# List<T> vs. IList<T>

``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.25936.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.400
  [Host]     : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2


```
|                 Method |  Count |          Mean |        Error |        StdDev |
|----------------------- |------- |--------------:|-------------:|--------------:|
|  **LookupElementWithList** |    **100** |      **78.72 ns** |     **0.591 ns** |      **0.524 ns** |
| LookupElementWithIList |    100 |     256.65 ns |     1.324 ns |      1.174 ns |
|  **LookupElementWithList** | **100000** | **438,874.77 ns** | **8,271.519 ns** | **13,819.850 ns** |
| LookupElementWithIList | 100000 | 667,049.70 ns | 2,481.699 ns |  2,072.331 ns |
