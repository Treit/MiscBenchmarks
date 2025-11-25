# List<T> vs. IList<T>



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                 | Count  | Mean          | Error        | StdDev       |
|----------------------- |------- |--------------:|-------------:|-------------:|
| **LookupElementWithList**  | **100**    |      **69.84 ns** |     **0.883 ns** |     **0.783 ns** |
| LookupElementWithIList | 100    |      75.78 ns |     0.698 ns |     0.653 ns |
| **LookupElementWithList**  | **100000** | **405,761.40 ns** | **1,626.867 ns** | **1,521.773 ns** |
| LookupElementWithIList | 100000 | 458,404.31 ns | 1,368.745 ns | 1,280.325 ns |
