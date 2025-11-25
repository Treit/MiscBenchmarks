# Rotating an array


```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                   | Amount | Mean     | Error    | StdDev   | Gen0   | Allocated |
|------------------------- |------- |---------:|---------:|---------:|-------:|----------:|
| **RotateLeftWithReverse**    | **1**      | **30.87 ns** | **0.321 ns** | **0.300 ns** |      **-** |         **-** |
| RotateLeftWithCopy       | 1      | 59.37 ns | 1.159 ns | 1.084 ns | 0.0048 |      80 B |
| RotateLeftWithJuggling   | 1      | 22.34 ns | 0.208 ns | 0.195 ns |      - |         - |
| RotateLeftArrayCopyAaron | 1      | 12.67 ns | 0.276 ns | 0.244 ns | 0.0048 |      80 B |
| **RotateLeftWithReverse**    | **4**      | **33.87 ns** | **0.347 ns** | **0.307 ns** |      **-** |         **-** |
| RotateLeftWithCopy       | 4      | 59.66 ns | 0.928 ns | 0.868 ns | 0.0048 |      80 B |
| RotateLeftWithJuggling   | 4      | 26.68 ns | 0.212 ns | 0.198 ns |      - |         - |
| RotateLeftArrayCopyAaron | 4      | 11.92 ns | 0.085 ns | 0.080 ns | 0.0048 |      80 B |
| **RotateLeftWithReverse**    | **16**     | **29.28 ns** | **0.311 ns** | **0.291 ns** |      **-** |         **-** |
| RotateLeftWithCopy       | 16     | 60.21 ns | 1.187 ns | 1.110 ns | 0.0048 |      80 B |
| RotateLeftWithJuggling   | 16     | 35.58 ns | 0.230 ns | 0.204 ns |      - |         - |
| RotateLeftArrayCopyAaron | 16     | 11.56 ns | 0.139 ns | 0.123 ns | 0.0048 |      80 B |
| **RotateLeftWithReverse**    | **24**     | **31.50 ns** | **0.272 ns** | **0.255 ns** |      **-** |         **-** |
| RotateLeftWithCopy       | 24     | 58.94 ns | 0.782 ns | 0.694 ns | 0.0048 |      80 B |
| RotateLeftWithJuggling   | 24     | 26.70 ns | 0.287 ns | 0.268 ns |      - |         - |
| RotateLeftArrayCopyAaron | 24     | 12.18 ns | 0.222 ns | 0.207 ns | 0.0048 |      80 B |
