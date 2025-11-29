# Reading many small files vs. one large file.




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method         | Job       | Runtime   | Count | Mean         | Error      | StdDev     | Gen0     | Allocated  |
|--------------- |---------- |---------- |------ |-------------:|-----------:|-----------:|---------:|-----------:|
| ManySmallFiles | .NET 10.0 | .NET 10.0 | 1000  | 69,018.91 μs | 693.901 μs | 615.125 μs | 375.0000 |    7943 KB |
| OneBigFile     | .NET 10.0 | .NET 10.0 | 1000  |     97.83 μs |   0.397 μs |   0.310 μs |   2.1973 |   38.98 KB |
| ManySmallFiles | .NET 9.0  | .NET 9.0  | 1000  | 70,480.28 μs | 975.945 μs | 912.900 μs | 375.0000 | 7935.97 KB |
| OneBigFile     | .NET 9.0  | .NET 9.0  | 1000  |     97.23 μs |   0.885 μs |   0.828 μs |   2.1973 |   38.97 KB |
