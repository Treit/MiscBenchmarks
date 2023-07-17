# Adding items to a list

``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.25905.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.300-preview.23179.2
  [Host]     : .NET 6.0.18 (6.0.1823.26907), X64 RyuJIT AVX2
  Job-QTLXZY : .NET 6.0.18 (6.0.1823.26907), X64 RyuJIT AVX2

InvocationCount=1  UnrollFactor=1  

```
|                  Method |   Count |           Mean |         Error |        StdDev |         Median | Allocated |
|------------------------ |-------- |---------------:|--------------:|--------------:|---------------:|----------:|
|         **AddToListNormal** |     **100** |     **2,990.7 ns** |     **157.10 ns** |     **455.77 ns** |     **3,000.0 ns** |    **1696 B** |
| AddToListPresetCapacity |     100 |       256.0 ns |      22.77 ns |      67.15 ns |       250.0 ns |     544 B |
|         **AddToListNormal** |   **10000** |    **29,873.7 ns** |   **1,403.82 ns** |   **4,117.15 ns** |    **27,900.0 ns** |  **131912 B** |
| AddToListPresetCapacity |   10000 |    15,281.2 ns |     311.18 ns |     751.52 ns |    15,100.0 ns |     544 B |
|         **AddToListNormal** | **1000000** | **3,122,931.0 ns** | **301,138.76 ns** | **887,914.44 ns** | **3,280,300.0 ns** | **8389592 B** |
| AddToListPresetCapacity | 1000000 | 2,379,170.0 ns | 313,845.21 ns | 925,379.67 ns | 2,541,350.0 ns |     544 B |
