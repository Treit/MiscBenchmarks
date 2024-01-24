# Adding items to a list


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  Job-UPNOOR : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2

InvocationCount=1  UnrollFactor=1  

```
|                  Method |   Count |           Mean |         Error |        StdDev |         Median | Allocated |
|------------------------ |-------- |---------------:|--------------:|--------------:|---------------:|----------:|
|         **AddToListNormal** |     **100** |     **3,830.0 ns** |     **713.22 ns** |   **2,102.93 ns** |     **2,500.0 ns** |         **-** |
| AddToListPresetCapacity |     100 |       800.0 ns |       0.00 ns |       0.00 ns |       800.0 ns |         - |
|         **AddToListNormal** |   **10000** |    **25,866.1 ns** |     **470.82 ns** |   **1,043.31 ns** |    **25,700.0 ns** |  **131432 B** |
| AddToListPresetCapacity |   10000 |    21,140.0 ns |     238.37 ns |     222.97 ns |    21,100.0 ns |         - |
|         **AddToListNormal** | **1000000** | **2,148,787.0 ns** | **200,093.72 ns** | **589,980.86 ns** | **2,076,200.0 ns** | **8389448 B** |
| AddToListPresetCapacity | 1000000 | 1,754,420.0 ns | 270,866.81 ns | 798,656.90 ns | 1,577,950.0 ns |         - |
