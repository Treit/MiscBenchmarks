# Rotating an array




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                   | Job       | Runtime   | Amount | Mean     | Error    | StdDev   | Gen0   | Allocated |
|------------------------- |---------- |---------- |------- |---------:|---------:|---------:|-------:|----------:|
| **RotateLeftWithReverse**    | **.NET 10.0** | **.NET 10.0** | **1**      | **34.25 ns** | **0.450 ns** | **0.399 ns** |      **-** |         **-** |
| RotateLeftWithCopy       | .NET 10.0 | .NET 10.0 | 1      | 59.48 ns | 1.032 ns | 0.915 ns | 0.0048 |      80 B |
| RotateLeftWithJuggling   | .NET 10.0 | .NET 10.0 | 1      | 22.48 ns | 0.239 ns | 0.224 ns |      - |         - |
| RotateLeftArrayCopyAaron | .NET 10.0 | .NET 10.0 | 1      | 12.52 ns | 0.151 ns | 0.141 ns | 0.0048 |      80 B |
| RotateLeftWithReverse    | .NET 9.0  | .NET 9.0  | 1      | 33.80 ns | 0.255 ns | 0.226 ns |      - |         - |
| RotateLeftWithCopy       | .NET 9.0  | .NET 9.0  | 1      | 59.84 ns | 1.206 ns | 1.128 ns | 0.0048 |      80 B |
| RotateLeftWithJuggling   | .NET 9.0  | .NET 9.0  | 1      | 22.39 ns | 0.157 ns | 0.147 ns |      - |         - |
| RotateLeftArrayCopyAaron | .NET 9.0  | .NET 9.0  | 1      | 12.94 ns | 0.206 ns | 0.193 ns | 0.0048 |      80 B |
| **RotateLeftWithReverse**    | **.NET 10.0** | **.NET 10.0** | **4**      | **33.91 ns** | **0.355 ns** | **0.332 ns** |      **-** |         **-** |
| RotateLeftWithCopy       | .NET 10.0 | .NET 10.0 | 4      | 60.16 ns | 1.134 ns | 1.061 ns | 0.0048 |      80 B |
| RotateLeftWithJuggling   | .NET 10.0 | .NET 10.0 | 4      | 28.11 ns | 0.329 ns | 0.308 ns |      - |         - |
| RotateLeftArrayCopyAaron | .NET 10.0 | .NET 10.0 | 4      | 11.83 ns | 0.241 ns | 0.226 ns | 0.0048 |      80 B |
| RotateLeftWithReverse    | .NET 9.0  | .NET 9.0  | 4      | 34.01 ns | 0.324 ns | 0.303 ns |      - |         - |
| RotateLeftWithCopy       | .NET 9.0  | .NET 9.0  | 4      | 59.61 ns | 0.749 ns | 0.664 ns | 0.0048 |      80 B |
| RotateLeftWithJuggling   | .NET 9.0  | .NET 9.0  | 4      | 27.43 ns | 0.316 ns | 0.296 ns |      - |         - |
| RotateLeftArrayCopyAaron | .NET 9.0  | .NET 9.0  | 4      | 11.96 ns | 0.208 ns | 0.184 ns | 0.0048 |      80 B |
| **RotateLeftWithReverse**    | **.NET 10.0** | **.NET 10.0** | **16**     | **29.48 ns** | **0.329 ns** | **0.308 ns** |      **-** |         **-** |
| RotateLeftWithCopy       | .NET 10.0 | .NET 10.0 | 16     | 59.77 ns | 1.090 ns | 0.910 ns | 0.0048 |      80 B |
| RotateLeftWithJuggling   | .NET 10.0 | .NET 10.0 | 16     | 37.03 ns | 0.265 ns | 0.234 ns |      - |         - |
| RotateLeftArrayCopyAaron | .NET 10.0 | .NET 10.0 | 16     | 11.80 ns | 0.254 ns | 0.212 ns | 0.0048 |      80 B |
| RotateLeftWithReverse    | .NET 9.0  | .NET 9.0  | 16     | 29.45 ns | 0.393 ns | 0.368 ns |      - |         - |
| RotateLeftWithCopy       | .NET 9.0  | .NET 9.0  | 16     | 60.37 ns | 1.216 ns | 1.302 ns | 0.0048 |      80 B |
| RotateLeftWithJuggling   | .NET 9.0  | .NET 9.0  | 16     | 35.90 ns | 0.480 ns | 0.426 ns |      - |         - |
| RotateLeftArrayCopyAaron | .NET 9.0  | .NET 9.0  | 16     | 11.64 ns | 0.192 ns | 0.180 ns | 0.0048 |      80 B |
| **RotateLeftWithReverse**    | **.NET 10.0** | **.NET 10.0** | **24**     | **37.99 ns** | **0.391 ns** | **0.365 ns** |      **-** |         **-** |
| RotateLeftWithCopy       | .NET 10.0 | .NET 10.0 | 24     | 60.21 ns | 1.276 ns | 1.418 ns | 0.0048 |      80 B |
| RotateLeftWithJuggling   | .NET 10.0 | .NET 10.0 | 24     | 26.52 ns | 0.371 ns | 0.329 ns |      - |         - |
| RotateLeftArrayCopyAaron | .NET 10.0 | .NET 10.0 | 24     | 11.84 ns | 0.213 ns | 0.189 ns | 0.0048 |      80 B |
| RotateLeftWithReverse    | .NET 9.0  | .NET 9.0  | 24     | 37.89 ns | 0.444 ns | 0.393 ns |      - |         - |
| RotateLeftWithCopy       | .NET 9.0  | .NET 9.0  | 24     | 59.74 ns | 0.753 ns | 0.668 ns | 0.0048 |      80 B |
| RotateLeftWithJuggling   | .NET 9.0  | .NET 9.0  | 24     | 26.55 ns | 0.343 ns | 0.321 ns |      - |         - |
| RotateLeftArrayCopyAaron | .NET 9.0  | .NET 9.0  | 24     | 11.84 ns | 0.217 ns | 0.193 ns | 0.0048 |      80 B |
