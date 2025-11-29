# Adding items to a dictionary





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                          | Job       | Runtime   | Count | Mean       | Error    | StdDev   | Ratio | RatioSD | Gen0   | Gen1   | Allocated | Alloc Ratio |
|-------------------------------- |---------- |---------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|-------:|----------:|------------:|
| CopyDictWithForEachLoop         | .NET 10.0 | .NET 10.0 | 100   | 3,198.8 ns | 32.55 ns | 28.85 ns |  4.27 |    0.10 | 0.6065 | 0.0076 |   9.93 KB |        3.25 |
| CopyDictPresetCapacity          | .NET 10.0 | .NET 10.0 | 100   | 2,712.4 ns | 19.50 ns | 18.24 ns |  3.62 |    0.08 | 0.1831 |      - |   3.03 KB |        0.99 |
| CopyDictWithConstructor         | .NET 10.0 | .NET 10.0 | 100   |   750.0 ns | 13.93 ns | 16.58 ns |  1.00 |    0.03 | 0.1869 | 0.0010 |   3.05 KB |        1.00 |
| CopyDictWithToDictionaryLambdas | .NET 10.0 | .NET 10.0 | 100   | 2,674.6 ns | 29.05 ns | 27.18 ns |  3.57 |    0.08 | 0.1869 |      - |   3.11 KB |        1.02 |
| CopyDictWithToDictionary        | .NET 10.0 | .NET 10.0 | 100   |   840.8 ns |  9.07 ns |  8.48 ns |  1.12 |    0.03 | 0.1869 | 0.0010 |   3.05 KB |        1.00 |
|                                 |           |           |       |            |          |          |       |         |        |        |           |             |
| CopyDictWithForEachLoop         | .NET 9.0  | .NET 9.0  | 100   | 3,148.3 ns | 31.72 ns | 28.12 ns |  4.43 |    0.09 | 0.6065 | 0.0076 |   9.93 KB |        3.25 |
| CopyDictPresetCapacity          | .NET 9.0  | .NET 9.0  | 100   | 2,607.1 ns | 23.18 ns | 21.68 ns |  3.67 |    0.07 | 0.1831 |      - |   3.03 KB |        0.99 |
| CopyDictWithConstructor         | .NET 9.0  | .NET 9.0  | 100   |   711.5 ns | 13.93 ns | 13.68 ns |  1.00 |    0.03 | 0.1869 | 0.0010 |   3.05 KB |        1.00 |
| CopyDictWithToDictionaryLambdas | .NET 9.0  | .NET 9.0  | 100   | 2,717.7 ns | 23.52 ns | 22.00 ns |  3.82 |    0.08 | 0.1869 |      - |   3.11 KB |        1.02 |
| CopyDictWithToDictionary        | .NET 9.0  | .NET 9.0  | 100   |   824.9 ns |  7.61 ns |  6.75 ns |  1.16 |    0.02 | 0.1869 | 0.0010 |   3.05 KB |        1.00 |
