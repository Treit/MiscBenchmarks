# Counting strings trying to see the difference where bounds checks are elided vs. not.

Assigning a field to a local variable is supposed to be needed to have the bounds checks removed.

Also lulz variants to try optimizing the counting code by GrabYoutPitchforks.







```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                      | Job       | Runtime   | Count | Mean     | Error     | StdDev    | Ratio | RatioSD | Gen0     | Allocated | Alloc Ratio |
|---------------------------- |---------- |---------- |------ |---------:|----------:|----------:|------:|--------:|---------:|----------:|------------:|
| CheckUsingCharArrayVariable | .NET 10.0 | .NET 10.0 | 10000 | 7.057 ms | 0.0814 ms | 0.0762 ms |  1.16 |    0.02 | 523.4375 |   8.37 MB |        1.41 |
| CheckUsingEscapeAndReplace  | .NET 10.0 | .NET 10.0 | 10000 | 6.090 ms | 0.0700 ms | 0.0585 ms |  1.00 |    0.01 | 367.1875 |   5.94 MB |        1.00 |
| CheckUsingCharLookupTable   | .NET 10.0 | .NET 10.0 | 10000 | 5.805 ms | 0.0686 ms | 0.0608 ms |  0.95 |    0.01 | 390.6250 |   6.31 MB |        1.06 |
|                             |           |           |       |          |           |           |       |         |          |           |             |
| CheckUsingCharArrayVariable | .NET 9.0  | .NET 9.0  | 10000 | 7.216 ms | 0.0667 ms | 0.0591 ms |  1.15 |    0.01 | 562.5000 |   8.98 MB |        1.51 |
| CheckUsingEscapeAndReplace  | .NET 9.0  | .NET 9.0  | 10000 | 6.262 ms | 0.0383 ms | 0.0359 ms |  1.00 |    0.01 | 367.1875 |   5.94 MB |        1.00 |
| CheckUsingCharLookupTable   | .NET 9.0  | .NET 9.0  | 10000 | 5.555 ms | 0.0727 ms | 0.0680 ms |  0.89 |    0.01 | 390.6250 |   6.31 MB |        1.06 |
