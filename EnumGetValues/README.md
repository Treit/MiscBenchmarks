# Getting enum values



```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26096.1)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-preview.2.24157.14
  [Host]     : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method               | Mean      | Error     | StdDev   | Median    | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|--------------------- |----------:|----------:|---------:|----------:|------:|--------:|-------:|----------:|------------:|
| EnumGetValuesTypeof  | 173.59 ns | 12.438 ns | 36.67 ns | 162.11 ns |  2.74 |    0.94 | 0.0148 |      64 B |        1.00 |
| EnumGetValuesGeneric |  66.74 ns |  4.170 ns | 12.30 ns |  64.11 ns |  1.00 |    0.00 | 0.0148 |      64 B |        1.00 |
