# Searching a list using Where().FirstOrDefault() vs. just FirstOrDefault()


```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26090.1)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-preview.2.24157.14
  [Host]     : .NET 9.0.0 (9.0.24.12805), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 9.0.0 (9.0.24.12805), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                  | Count   | Mean           | Error         | StdDev        | Median         | Ratio | RatioSD |
|------------------------ |-------- |---------------:|--------------:|--------------:|---------------:|------:|--------:|
| **WhereThenFirstOrDefault** | **100**     |       **355.6 ns** |       **6.49 ns** |      **17.78 ns** |       **353.0 ns** |  **1.00** |    **0.00** |
| FirstOrDefault          | 100     |       902.1 ns |      32.36 ns |      90.74 ns |       878.9 ns |  2.55 |    0.26 |
|                         |         |                |               |               |                |       |         |
| **WhereThenFirstOrDefault** | **1000000** | **4,152,374.9 ns** |  **77,586.48 ns** | **170,304.20 ns** | **4,087,004.7 ns** |  **1.00** |    **0.00** |
| FirstOrDefault          | 1000000 | 6,758,429.4 ns | 103,325.05 ns | 151,452.51 ns | 6,707,603.1 ns |  1.62 |    0.08 |
