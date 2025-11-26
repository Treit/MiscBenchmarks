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
| **RotateLeftWithReverse**    | **1**      | **30.86 ns** | **0.276 ns** | **0.258 ns** |      **-** |         **-** |
| RotateLeftWithCopy       | 1      | 60.51 ns | 1.208 ns | 1.240 ns | 0.0048 |      80 B |
| RotateLeftWithJuggling   | 1      | 22.36 ns | 0.151 ns | 0.141 ns |      - |         - |
| RotateLeftArrayCopyAaron | 1      | 12.57 ns | 0.174 ns | 0.163 ns | 0.0048 |      80 B |
| **RotateLeftWithReverse**    | **4**      | **30.19 ns** | **0.259 ns** | **0.229 ns** |      **-** |         **-** |
| RotateLeftWithCopy       | 4      | 60.22 ns | 1.282 ns | 1.259 ns | 0.0048 |      80 B |
| RotateLeftWithJuggling   | 4      | 26.80 ns | 0.315 ns | 0.294 ns |      - |         - |
| RotateLeftArrayCopyAaron | 4      | 12.06 ns | 0.289 ns | 0.270 ns | 0.0048 |      80 B |
| **RotateLeftWithReverse**    | **16**     | **30.92 ns** | **0.366 ns** | **0.342 ns** |      **-** |         **-** |
| RotateLeftWithCopy       | 16     | 61.20 ns | 1.264 ns | 1.552 ns | 0.0048 |      80 B |
| RotateLeftWithJuggling   | 16     | 35.59 ns | 0.193 ns | 0.171 ns |      - |         - |
| RotateLeftArrayCopyAaron | 16     | 11.68 ns | 0.176 ns | 0.165 ns | 0.0048 |      80 B |
| **RotateLeftWithReverse**    | **24**     | **31.78 ns** | **0.252 ns** | **0.236 ns** |      **-** |         **-** |
| RotateLeftWithCopy       | 24     | 60.37 ns | 1.102 ns | 1.031 ns | 0.0048 |      80 B |
| RotateLeftWithJuggling   | 24     | 27.12 ns | 0.170 ns | 0.159 ns |      - |         - |
| RotateLeftArrayCopyAaron | 24     | 12.64 ns | 0.247 ns | 0.231 ns | 0.0048 |      80 B |
