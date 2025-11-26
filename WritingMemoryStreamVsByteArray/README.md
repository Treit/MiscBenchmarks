# Writing bytes to an array vs. memory stream






```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                    | Count  | Mean      | Error    | StdDev   |
|-------------------------- |------- |----------:|---------:|---------:|
| WriteArray                | 100000 | 142.14 μs | 2.498 μs | 2.215 μs |
| WriteArrayInChunks        | 100000 |  53.99 μs | 0.668 μs | 0.625 μs |
| WriteMemoryStream         | 100000 | 234.53 μs | 1.350 μs | 1.263 μs |
| WriteMemoryStreamInChunks | 100000 |  54.53 μs | 0.688 μs | 0.610 μs |
