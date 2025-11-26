# Adding items to a dictionary




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                          | Count | Mean       | Error    | StdDev   | Ratio | RatioSD | Gen0   | Gen1   | Allocated | Alloc Ratio |
|-------------------------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|-------:|----------:|------------:|
| CopyDictWithForEachLoop         | 100   | 3,203.9 ns | 46.97 ns | 43.93 ns |  4.02 |    0.07 | 0.6065 | 0.0076 |   9.93 KB |        3.25 |
| CopyDictPresetCapacity          | 100   | 2,582.1 ns | 26.61 ns | 24.89 ns |  3.24 |    0.04 | 0.1831 |      - |   3.03 KB |        0.99 |
| CopyDictWithConstructor         | 100   |   796.5 ns |  8.79 ns |  8.22 ns |  1.00 |    0.01 | 0.1869 | 0.0010 |   3.05 KB |        1.00 |
| CopyDictWithToDictionaryLambdas | 100   | 2,648.2 ns | 22.32 ns | 20.88 ns |  3.33 |    0.04 | 0.1869 |      - |   3.11 KB |        1.02 |
| CopyDictWithToDictionary        | 100   |   836.5 ns |  9.17 ns |  8.13 ns |  1.05 |    0.01 | 0.1869 | 0.0010 |   3.05 KB |        1.00 |
