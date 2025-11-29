# Bitsets





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method             | Job       | Runtime   | Count   | Mean             | Error         | StdDev        | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|------------------- |---------- |---------- |-------- |-----------------:|--------------:|--------------:|------:|--------:|-------:|----------:|------------:|
| **ReadCustomBitSet**   | **.NET 10.0** | **.NET 10.0** | **64**      |         **89.78 ns** |      **0.333 ns** |      **0.296 ns** |  **1.00** |    **0.00** |      **-** |         **-** |          **NA** |
| ReadBitArray       | .NET 10.0 | .NET 10.0 | 64      |         70.95 ns |      1.451 ns |      1.552 ns |  0.79 |    0.02 |      - |         - |          NA |
| ReadReacherBitSet  | .NET 10.0 | .NET 10.0 | 64      |         44.36 ns |      0.236 ns |      0.220 ns |  0.49 |    0.00 |      - |         - |          NA |
| WriteCustomBitSet  | .NET 10.0 | .NET 10.0 | 64      |        612.48 ns |      6.348 ns |      5.937 ns |  6.82 |    0.07 | 0.0181 |     304 B |          NA |
| WriteBitArray      | .NET 10.0 | .NET 10.0 | 64      |        560.29 ns |      4.835 ns |      4.286 ns |  6.24 |    0.05 | 0.0181 |     304 B |          NA |
| WriteReacherBitSet | .NET 10.0 | .NET 10.0 | 64      |        516.27 ns |      9.110 ns |      8.522 ns |  5.75 |    0.09 | 0.0181 |     304 B |          NA |
|                    |           |           |         |                  |               |               |       |         |        |           |             |
| ReadCustomBitSet   | .NET 9.0  | .NET 9.0  | 64      |         89.80 ns |      0.644 ns |      0.502 ns |  1.00 |    0.01 |      - |         - |          NA |
| ReadBitArray       | .NET 9.0  | .NET 9.0  | 64      |         64.55 ns |      0.832 ns |      0.738 ns |  0.72 |    0.01 |      - |         - |          NA |
| ReadReacherBitSet  | .NET 9.0  | .NET 9.0  | 64      |         44.49 ns |      0.329 ns |      0.291 ns |  0.50 |    0.00 |      - |         - |          NA |
| WriteCustomBitSet  | .NET 9.0  | .NET 9.0  | 64      |        596.12 ns |      6.132 ns |      5.120 ns |  6.64 |    0.07 | 0.0181 |     304 B |          NA |
| WriteBitArray      | .NET 9.0  | .NET 9.0  | 64      |        568.59 ns |      7.085 ns |      6.628 ns |  6.33 |    0.08 | 0.0181 |     304 B |          NA |
| WriteReacherBitSet | .NET 9.0  | .NET 9.0  | 64      |        533.70 ns |      5.991 ns |      5.604 ns |  5.94 |    0.07 | 0.0181 |     304 B |          NA |
|                    |           |           |         |                  |               |               |       |         |        |           |             |
| **ReadCustomBitSet**   | **.NET 10.0** | **.NET 10.0** | **1024**    |      **1,477.59 ns** |      **7.898 ns** |      **6.595 ns** |  **1.00** |    **0.01** |      **-** |         **-** |          **NA** |
| ReadBitArray       | .NET 10.0 | .NET 10.0 | 1024    |      1,048.94 ns |     10.485 ns |      9.808 ns |  0.71 |    0.01 |      - |         - |          NA |
| ReadReacherBitSet  | .NET 10.0 | .NET 10.0 | 1024    |        819.61 ns |      3.229 ns |      2.697 ns |  0.55 |    0.00 |      - |         - |          NA |
| WriteCustomBitSet  | .NET 10.0 | .NET 10.0 | 1024    |      5,188.68 ns |     30.216 ns |     26.785 ns |  3.51 |    0.02 | 0.0153 |     304 B |          NA |
| WriteBitArray      | .NET 10.0 | .NET 10.0 | 1024    |      4,552.86 ns |     52.308 ns |     48.929 ns |  3.08 |    0.03 | 0.0153 |     304 B |          NA |
| WriteReacherBitSet | .NET 10.0 | .NET 10.0 | 1024    |      3,637.24 ns |     18.570 ns |     17.370 ns |  2.46 |    0.02 | 0.0153 |     304 B |          NA |
|                    |           |           |         |                  |               |               |       |         |        |           |             |
| ReadCustomBitSet   | .NET 9.0  | .NET 9.0  | 1024    |      1,486.48 ns |      9.602 ns |      8.982 ns |  1.00 |    0.01 |      - |         - |          NA |
| ReadBitArray       | .NET 9.0  | .NET 9.0  | 1024    |      1,052.53 ns |     16.367 ns |     15.309 ns |  0.71 |    0.01 |      - |         - |          NA |
| ReadReacherBitSet  | .NET 9.0  | .NET 9.0  | 1024    |        818.81 ns |      3.682 ns |      3.264 ns |  0.55 |    0.00 |      - |         - |          NA |
| WriteCustomBitSet  | .NET 9.0  | .NET 9.0  | 1024    |      5,189.81 ns |     45.631 ns |     42.683 ns |  3.49 |    0.03 | 0.0153 |     304 B |          NA |
| WriteBitArray      | .NET 9.0  | .NET 9.0  | 1024    |      4,536.18 ns |     34.060 ns |     30.193 ns |  3.05 |    0.03 | 0.0153 |     304 B |          NA |
| WriteReacherBitSet | .NET 9.0  | .NET 9.0  | 1024    |      3,797.22 ns |     22.032 ns |     20.609 ns |  2.55 |    0.02 | 0.0153 |     304 B |          NA |
|                    |           |           |         |                  |               |               |       |         |        |           |             |
| **ReadCustomBitSet**   | **.NET 10.0** | **.NET 10.0** | **1000000** |  **5,648,890.47 ns** | **25,949.235 ns** | **24,272.931 ns** |  **1.00** |    **0.01** |      **-** |         **-** |          **NA** |
| ReadBitArray       | .NET 10.0 | .NET 10.0 | 1000000 |  5,458,957.03 ns | 34,831.306 ns | 32,581.225 ns |  0.97 |    0.01 |      - |         - |          NA |
| ReadReacherBitSet  | .NET 10.0 | .NET 10.0 | 1000000 |    797,119.67 ns |  2,789.357 ns |  2,609.166 ns |  0.14 |    0.00 |      - |         - |          NA |
| WriteCustomBitSet  | .NET 10.0 | .NET 10.0 | 1000000 | 12,692,743.30 ns | 64,773.575 ns | 57,420.087 ns |  2.25 |    0.01 |      - |     304 B |          NA |
| WriteBitArray      | .NET 10.0 | .NET 10.0 | 1000000 | 12,535,045.52 ns | 58,388.034 ns | 54,616.203 ns |  2.22 |    0.01 |      - |     304 B |          NA |
| WriteReacherBitSet | .NET 10.0 | .NET 10.0 | 1000000 | 12,127,293.75 ns | 61,445.082 ns | 57,475.768 ns |  2.15 |    0.01 |      - |     304 B |          NA |
|                    |           |           |         |                  |               |               |       |         |        |           |             |
| ReadCustomBitSet   | .NET 9.0  | .NET 9.0  | 1000000 |  5,642,560.57 ns | 29,079.020 ns | 27,200.534 ns |  1.00 |    0.01 |      - |         - |          NA |
| ReadBitArray       | .NET 9.0  | .NET 9.0  | 1000000 |  5,407,215.36 ns | 24,095.227 ns | 22,538.690 ns |  0.96 |    0.01 |      - |         - |          NA |
| ReadReacherBitSet  | .NET 9.0  | .NET 9.0  | 1000000 |    795,239.88 ns |  5,064.880 ns |  4,489.884 ns |  0.14 |    0.00 |      - |         - |          NA |
| WriteCustomBitSet  | .NET 9.0  | .NET 9.0  | 1000000 | 12,727,075.83 ns | 69,144.159 ns | 64,677.489 ns |  2.26 |    0.02 |      - |     304 B |          NA |
| WriteBitArray      | .NET 9.0  | .NET 9.0  | 1000000 | 12,506,340.68 ns | 63,753.037 ns | 59,634.630 ns |  2.22 |    0.01 |      - |     304 B |          NA |
| WriteReacherBitSet | .NET 9.0  | .NET 9.0  | 1000000 | 12,148,083.96 ns | 72,495.975 ns | 67,812.780 ns |  2.15 |    0.02 |      - |     304 B |          NA |
