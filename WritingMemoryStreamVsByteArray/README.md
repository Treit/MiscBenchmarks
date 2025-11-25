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
| WriteArray                | 100000 | 155.75 μs | 3.095 μs | 7.235 μs |
| WriteArrayInChunks        | 100000 |  81.97 μs | 1.677 μs | 4.237 μs |
| WriteMemoryStream         | 100000 | 257.25 μs | 5.040 μs | 6.374 μs |
| WriteMemoryStreamInChunks | 100000 |  81.81 μs | 1.984 μs | 5.789 μs |
