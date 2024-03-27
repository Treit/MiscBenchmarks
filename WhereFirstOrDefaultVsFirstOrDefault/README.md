# Searching a list using Where().FirstOrDefault() vs. just FirstOrDefault()

```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26090.1)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.202
  [Host]     : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                  | Count   | Mean           | Error         | StdDev        | Ratio | RatioSD |
|------------------------ |-------- |---------------:|--------------:|--------------:|------:|--------:|
| **WhereThenFirstOrDefault** | **100**     |       **558.1 ns** |       **8.58 ns** |       **7.61 ns** |  **0.88** |    **0.02** |
| FirstOrDefault          | 100     |       632.9 ns |      12.66 ns |      11.84 ns |  1.00 |    0.00 |
|                         |         |                |               |               |       |         |
| **WhereThenFirstOrDefault** | **1000000** | **5,857,355.3 ns** |  **83,710.68 ns** | **142,147.09 ns** |  **0.79** |    **0.03** |
| FirstOrDefault          | 1000000 | 7,451,626.7 ns | 148,085.36 ns | 226,141.98 ns |  1.00 |    0.00 |
