# List<T> vs. IList<T>





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                 | Job       | Runtime   | Count  | Mean          | Error        | StdDev       |
|----------------------- |---------- |---------- |------- |--------------:|-------------:|-------------:|
| **LookupElementWithList**  | **.NET 10.0** | **.NET 10.0** | **100**    |      **67.70 ns** |     **0.902 ns** |     **0.800 ns** |
| LookupElementWithIList | .NET 10.0 | .NET 10.0 | 100    |      75.87 ns |     1.024 ns |     0.958 ns |
| LookupElementWithList  | .NET 9.0  | .NET 9.0  | 100    |      67.34 ns |     1.064 ns |     0.888 ns |
| LookupElementWithIList | .NET 9.0  | .NET 9.0  | 100    |      74.98 ns |     1.338 ns |     1.251 ns |
| **LookupElementWithList**  | **.NET 10.0** | **.NET 10.0** | **100000** | **407,030.48 ns** | **1,765.269 ns** | **1,564.865 ns** |
| LookupElementWithIList | .NET 10.0 | .NET 10.0 | 100000 | 435,037.85 ns | 2,593.868 ns | 2,426.306 ns |
| LookupElementWithList  | .NET 9.0  | .NET 9.0  | 100000 | 406,854.42 ns | 2,005.540 ns | 1,674.717 ns |
| LookupElementWithIList | .NET 9.0  | .NET 9.0  | 100000 | 452,315.32 ns | 1,987.813 ns | 1,859.401 ns |
