# Counting strings using a for loop vs. a foreach loop.

``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.25915.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.306
  [Host]     : .NET 7.0.9 (7.0.923.32018), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.9 (7.0.923.32018), X64 RyuJIT AVX2


```
|           Method |  Count |           Mean |         Error |        StdDev |         Median | Code Size |
|----------------- |------- |---------------:|--------------:|--------------:|---------------:|----------:|
|     **ForLoopCount** |     **10** |       **9.697 ns** |     **0.2146 ns** |     **0.2204 ns** |       **9.622 ns** |      **62 B** |
| ForEachLoopCount |     10 |      10.271 ns |     0.9467 ns |     2.7914 ns |       8.406 ns |      57 B |
|     **ForLoopCount** |    **100** |      **98.072 ns** |     **0.8742 ns** |     **0.7750 ns** |      **98.184 ns** |      **62 B** |
| ForEachLoopCount |    100 |     100.193 ns |     1.4564 ns |     1.2911 ns |     100.345 ns |      57 B |
|     **ForLoopCount** | **100000** | **132,219.027 ns** | **2,626.7709 ns** | **6,780.5345 ns** | **132,031.274 ns** |      **62 B** |
| ForEachLoopCount | 100000 | 127,130.295 ns | 2,539.6310 ns | 6,690.4039 ns | 126,741.602 ns |      57 B |
