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
| **LookupElementWithList**  | **100**    |      **68.35 ns** |     **1.115 ns** |     **1.043 ns** |
| LookupElementWithIList | 100    |      75.93 ns |     1.488 ns |     1.392 ns |
| **LookupElementWithList**  | **100000** | **406,709.85 ns** | **1,424.110 ns** | **1,332.114 ns** |
| LookupElementWithIList | 100000 | 458,126.92 ns | 2,277.891 ns | 2,130.741 ns |
