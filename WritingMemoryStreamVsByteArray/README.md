# Writing bytes to an array vs. memory stream







```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                    | Job       | Runtime   | Count  | Mean      | Error    | StdDev   |
|-------------------------- |---------- |---------- |------- |----------:|---------:|---------:|
| WriteArray                | .NET 10.0 | .NET 10.0 | 100000 | 108.10 μs | 0.679 μs | 0.635 μs |
| WriteArrayInChunks        | .NET 10.0 | .NET 10.0 | 100000 |  52.17 μs | 0.526 μs | 0.492 μs |
| WriteMemoryStream         | .NET 10.0 | .NET 10.0 | 100000 | 229.81 μs | 0.464 μs | 0.411 μs |
| WriteMemoryStreamInChunks | .NET 10.0 | .NET 10.0 | 100000 |  53.48 μs | 0.630 μs | 0.589 μs |
| WriteArray                | .NET 9.0  | .NET 9.0  | 100000 | 107.77 μs | 0.724 μs | 0.677 μs |
| WriteArrayInChunks        | .NET 9.0  | .NET 9.0  | 100000 |  51.83 μs | 0.644 μs | 0.602 μs |
| WriteMemoryStream         | .NET 9.0  | .NET 9.0  | 100000 | 228.16 μs | 0.677 μs | 0.566 μs |
| WriteMemoryStreamInChunks | .NET 9.0  | .NET 9.0  | 100000 |  53.21 μs | 0.333 μs | 0.312 μs |
