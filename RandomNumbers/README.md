# Random numbers



```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26240.5000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-preview.2.24157.14
  [Host]     : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method         | Count   | Mean      | Error     | StdDev    | Ratio | Allocated | Alloc Ratio |
|--------------- |-------- |----------:|----------:|----------:|------:|----------:|------------:|
| SystemRandom   | 1000000 | 11.186 ms | 0.1468 ms | 0.1373 ms |  1.00 |       6 B |        1.00 |
| XorShiftRandom | 1000000 |  2.575 ms | 0.0237 ms | 0.0210 ms |  0.23 |       2 B |        0.33 |
