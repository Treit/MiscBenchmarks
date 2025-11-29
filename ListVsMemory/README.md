# List\<T> vs ReadOnlyMemory\<T> Benchmark

Comparing the performance of `List<T>` vs `ReadOnlyMemory<T>` and `Memory<T>` for various operations.




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                            | Job       | Runtime   | Count | Mean     | Error     | StdDev    | Gen0   | Gen1   | Allocated |
|---------------------------------- |---------- |---------- |------ |---------:|----------:|----------:|-------:|-------:|----------:|
| ReadList                          | .NET 10.0 | .NET 10.0 | 10000 | 6.231 μs | 0.0066 μs | 0.0059 μs |      - |      - |         - |
| ReadReadOnlyMemory                | .NET 10.0 | .NET 10.0 | 10000 | 3.270 μs | 0.0091 μs | 0.0080 μs |      - |      - |         - |
| ReadMemory                        | .NET 10.0 | .NET 10.0 | 10000 | 3.263 μs | 0.0027 μs | 0.0022 μs |      - |      - |         - |
| ReadListForeach                   | .NET 10.0 | .NET 10.0 | 10000 | 6.219 μs | 0.0116 μs | 0.0102 μs |      - |      - |         - |
| ReadReadOnlyMemoryForeach         | .NET 10.0 | .NET 10.0 | 10000 | 3.265 μs | 0.0077 μs | 0.0068 μs |      - |      - |         - |
| WriteList                         | .NET 10.0 | .NET 10.0 | 10000 | 6.445 μs | 0.0279 μs | 0.0261 μs |      - |      - |         - |
| WriteListLocalVariable            | .NET 10.0 | .NET 10.0 | 10000 | 6.301 μs | 0.0075 μs | 0.0070 μs |      - |      - |         - |
| WriteListCollectionsMarshalAsSpan | .NET 10.0 | .NET 10.0 | 10000 | 3.129 μs | 0.0055 μs | 0.0046 μs |      - |      - |         - |
| WriteMemory                       | .NET 10.0 | .NET 10.0 | 10000 | 3.134 μs | 0.0143 μs | 0.0134 μs |      - |      - |         - |
| RandomAccessList                  | .NET 10.0 | .NET 10.0 | 10000 | 9.352 μs | 0.0325 μs | 0.0304 μs |      - |      - |         - |
| RandomAccessReadOnlyMemory        | .NET 10.0 | .NET 10.0 | 10000 | 8.581 μs | 0.0244 μs | 0.0228 μs |      - |      - |         - |
| CreateList                        | .NET 10.0 | .NET 10.0 | 10000 | 9.162 μs | 0.0671 μs | 0.0628 μs | 2.3804 | 0.2899 |   40056 B |
| CreateReadOnlyMemory              | .NET 10.0 | .NET 10.0 | 10000 | 4.142 μs | 0.0657 μs | 0.0614 μs | 2.3804 | 0.3357 |   40024 B |
| ReadList                          | .NET 9.0  | .NET 9.0  | 10000 | 6.231 μs | 0.0124 μs | 0.0109 μs |      - |      - |         - |
| ReadReadOnlyMemory                | .NET 9.0  | .NET 9.0  | 10000 | 3.262 μs | 0.0029 μs | 0.0024 μs |      - |      - |         - |
| ReadMemory                        | .NET 9.0  | .NET 9.0  | 10000 | 3.264 μs | 0.0039 μs | 0.0031 μs |      - |      - |         - |
| ReadListForeach                   | .NET 9.0  | .NET 9.0  | 10000 | 6.219 μs | 0.0138 μs | 0.0129 μs |      - |      - |         - |
| ReadReadOnlyMemoryForeach         | .NET 9.0  | .NET 9.0  | 10000 | 3.264 μs | 0.0035 μs | 0.0033 μs |      - |      - |         - |
| WriteList                         | .NET 9.0  | .NET 9.0  | 10000 | 6.326 μs | 0.0311 μs | 0.0291 μs |      - |      - |         - |
| WriteListLocalVariable            | .NET 9.0  | .NET 9.0  | 10000 | 6.305 μs | 0.0059 μs | 0.0055 μs |      - |      - |         - |
| WriteListCollectionsMarshalAsSpan | .NET 9.0  | .NET 9.0  | 10000 | 3.131 μs | 0.0060 μs | 0.0050 μs |      - |      - |         - |
| WriteMemory                       | .NET 9.0  | .NET 9.0  | 10000 | 3.125 μs | 0.0054 μs | 0.0048 μs |      - |      - |         - |
| RandomAccessList                  | .NET 9.0  | .NET 9.0  | 10000 | 9.259 μs | 0.0132 μs | 0.0117 μs |      - |      - |         - |
| RandomAccessReadOnlyMemory        | .NET 9.0  | .NET 9.0  | 10000 | 8.554 μs | 0.0183 μs | 0.0171 μs |      - |      - |         - |
| CreateList                        | .NET 9.0  | .NET 9.0  | 10000 | 9.227 μs | 0.0729 μs | 0.0647 μs | 2.3804 | 0.2899 |   40056 B |
| CreateReadOnlyMemory              | .NET 9.0  | .NET 9.0  | 10000 | 4.161 μs | 0.0761 μs | 0.0712 μs | 2.3804 | 0.3357 |   40024 B |
