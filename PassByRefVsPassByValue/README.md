# Passing classes vs. structs.





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                 | Job       | Runtime   | Count | Mean      | Error     | StdDev    | Median    | Ratio | RatioSD | Allocated | Alloc Ratio |
|----------------------- |---------- |---------- |------ |----------:|----------:|----------:|----------:|------:|--------:|----------:|------------:|
| Pass16ByteStructByRef  | .NET 10.0 | .NET 10.0 | 10000 |  9.543 μs | 0.0180 μs | 0.0140 μs |  9.541 μs |  0.27 |    0.02 |         - |          NA |
| Pass16ByteStruct       | .NET 10.0 | .NET 10.0 | 10000 |  9.561 μs | 0.0303 μs | 0.0269 μs |  9.555 μs |  0.27 |    0.02 |         - |          NA |
| Pass128ByteStructByRef | .NET 10.0 | .NET 10.0 | 10000 | 17.652 μs | 0.0669 μs | 0.0626 μs | 17.659 μs |  0.50 |    0.04 |         - |          NA |
| Pass32ByteStruct       | .NET 10.0 | .NET 10.0 | 10000 | 20.044 μs | 0.1610 μs | 0.1506 μs | 20.080 μs |  0.57 |    0.05 |         - |          NA |
| Pass32ByteClass        | .NET 10.0 | .NET 10.0 | 10000 | 20.101 μs | 0.1057 μs | 0.0989 μs | 20.087 μs |  0.57 |    0.05 |         - |          NA |
| Pass32ByteStructByRef  | .NET 10.0 | .NET 10.0 | 10000 | 20.119 μs | 0.1307 μs | 0.1222 μs | 20.175 μs |  0.57 |    0.05 |         - |          NA |
| Pass16ByteClass        | .NET 10.0 | .NET 10.0 | 10000 | 20.152 μs | 0.0651 μs | 0.0577 μs | 20.160 μs |  0.57 |    0.05 |         - |          NA |
| Pass128ByteStruct      | .NET 10.0 | .NET 10.0 | 10000 | 20.193 μs | 0.8192 μs | 2.4155 μs | 21.278 μs |  0.57 |    0.08 |         - |          NA |
| Pass128ByteClass       | .NET 10.0 | .NET 10.0 | 10000 | 35.538 μs | 0.8711 μs | 2.5686 μs | 36.517 μs |  1.01 |    0.11 |         - |          NA |
|                        |           |           |       |           |           |           |           |       |         |           |             |
| Pass16ByteStruct       | .NET 9.0  | .NET 9.0  | 10000 |  9.515 μs | 0.0148 μs | 0.0124 μs |  9.510 μs |  0.29 |    0.04 |         - |          NA |
| Pass16ByteStructByRef  | .NET 9.0  | .NET 9.0  | 10000 |  9.566 μs | 0.0680 μs | 0.0568 μs |  9.556 μs |  0.29 |    0.04 |         - |          NA |
| Pass16ByteClass        | .NET 9.0  | .NET 9.0  | 10000 | 19.896 μs | 0.0750 μs | 0.0702 μs | 19.888 μs |  0.61 |    0.08 |         - |          NA |
| Pass32ByteStructByRef  | .NET 9.0  | .NET 9.0  | 10000 | 19.991 μs | 0.1132 μs | 0.1059 μs | 20.025 μs |  0.61 |    0.08 |         - |          NA |
| Pass32ByteStruct       | .NET 9.0  | .NET 9.0  | 10000 | 20.198 μs | 0.0860 μs | 0.0804 μs | 20.218 μs |  0.62 |    0.08 |         - |          NA |
| Pass32ByteClass        | .NET 9.0  | .NET 9.0  | 10000 | 20.205 μs | 0.1258 μs | 0.1177 μs | 20.243 μs |  0.62 |    0.08 |         - |          NA |
| Pass128ByteStructByRef | .NET 9.0  | .NET 9.0  | 10000 | 20.421 μs | 0.8345 μs | 2.4607 μs | 21.484 μs |  0.62 |    0.11 |         - |          NA |
| Pass128ByteStruct      | .NET 9.0  | .NET 9.0  | 10000 | 21.493 μs | 0.7129 μs | 2.1021 μs | 22.666 μs |  0.65 |    0.11 |         - |          NA |
| Pass128ByteClass       | .NET 9.0  | .NET 9.0  | 10000 | 33.343 μs | 1.3545 μs | 3.9938 μs | 36.122 μs |  1.02 |    0.18 |         - |          NA |
