# Counting strings trying to see the difference where bounds checks are elided vs. not.

Assigning a field to a local variable is supposed to be needed to have the bounds checks removed.

Also lulz variants to try optimizing the counting code by GrabYoutPitchforks.






```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                      | Count | Mean     | Error     | StdDev    | Ratio | Gen0     | Allocated | Alloc Ratio |
|---------------------------- |------ |---------:|----------:|----------:|------:|---------:|----------:|------------:|
| CheckUsingCharArrayVariable | 10000 | 6.844 ms | 0.0492 ms | 0.0436 ms |  1.13 | 523.4375 |   8.37 MB |        1.41 |
| CheckUsingEscapeAndReplace  | 10000 | 6.054 ms | 0.0554 ms | 0.0491 ms |  1.00 | 367.1875 |   5.94 MB |        1.00 |
| CheckUsingCharLookupTable   | 10000 | 5.321 ms | 0.0600 ms | 0.0562 ms |  0.88 | 390.6250 |   6.31 MB |        1.06 |
