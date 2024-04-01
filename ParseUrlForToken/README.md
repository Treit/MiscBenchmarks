# Getting a token from the end of a URL path

```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26096.1)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-preview.2.24157.14
  [Host]     : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                                                       | Count | Mean      | Error    | StdDev   | Gen0     | Allocated |
|------------------------------------------------------------- |------ |----------:|---------:|---------:|---------:|----------:|
| GetTokenFromUrlToStringSplitWithLinqAndUnnecessaryNullChecks | 1000  | 257.65 μs | 4.834 μs | 7.668 μs | 116.2109 | 491.48 KB |
| GetTokenFromUrlToStringSplitWithLinq                         | 1000  | 245.75 μs | 4.677 μs | 3.906 μs | 116.2109 | 491.49 KB |
| GetTokenFromUrlToStringWithIndexOfAndSubstring               | 1000  |  25.19 μs | 0.419 μs | 0.665 μs |  11.5051 |  48.52 KB |
