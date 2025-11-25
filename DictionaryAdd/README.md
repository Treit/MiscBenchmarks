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
| CopyDictWithForEachLoop         | 100   | 3,155.3 ns | 40.11 ns | 35.55 ns |  3.82 |    0.05 | 0.6065 | 0.0076 |   9.93 KB |        3.25 |
| CopyDictPresetCapacity          | 100   | 2,571.1 ns | 18.53 ns | 16.42 ns |  3.12 |    0.03 | 0.1831 |      - |   3.03 KB |        0.99 |
| CopyDictWithConstructor         | 100   |   825.2 ns |  8.48 ns |  7.93 ns |  1.00 |    0.01 | 0.1869 | 0.0010 |   3.05 KB |        1.00 |
| CopyDictWithToDictionaryLambdas | 100   | 2,645.0 ns | 17.36 ns | 15.39 ns |  3.21 |    0.03 | 0.1869 |      - |   3.11 KB |        1.02 |
| CopyDictWithToDictionary        | 100   |   831.9 ns |  4.76 ns |  4.45 ns |  1.01 |    0.01 | 0.1869 | 0.0010 |   3.05 KB |        1.00 |
