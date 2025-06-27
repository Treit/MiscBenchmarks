# List\<T> vs ReadOnlyMemory\<T> Benchmark

Comparing the performance of `List<T>` vs `ReadOnlyMemory<T>` and `Memory<T>` for various operations.


```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.27887.1000)
Unknown processor
.NET SDK 9.0.301
  [Host]     : .NET 9.0.6 (9.0.625.26613), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 9.0.6 (9.0.625.26613), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                            | Count | Mean      | Error     | StdDev    | Median    | Gen0   | Gen1   | Allocated |
|---------------------------------- |------ |----------:|----------:|----------:|----------:|-------:|-------:|----------:|
| ReadList                          | 10000 |  5.613 μs | 0.1102 μs | 0.1225 μs |  5.604 μs |      - |      - |         - |
| ReadReadOnlyMemory                | 10000 |  3.687 μs | 0.0358 μs | 0.0279 μs |  3.686 μs |      - |      - |         - |
| ReadMemory                        | 10000 |  4.477 μs | 0.2683 μs | 0.7912 μs |  4.265 μs |      - |      - |         - |
| ReadListForeach                   | 10000 |  5.937 μs | 0.1204 μs | 0.3357 μs |  5.833 μs |      - |      - |         - |
| ReadReadOnlyMemoryForeach         | 10000 |  3.803 μs | 0.0735 μs | 0.0786 μs |  3.794 μs |      - |      - |         - |
| WriteList                         | 10000 | 13.116 μs | 0.1582 μs | 0.1403 μs | 13.085 μs |      - |      - |         - |
| WriteListLocalVariable            | 10000 | 12.508 μs | 0.1363 μs | 0.1208 μs | 12.498 μs |      - |      - |         - |
| WriteListCollectionsMarshalAsSpan | 10000 |  3.767 μs | 0.0841 μs | 0.2400 μs |  3.688 μs |      - |      - |         - |
| WriteMemory                       | 10000 |  3.717 μs | 0.0708 μs | 0.1611 μs |  3.644 μs |      - |      - |         - |
| RandomAccessList                  | 10000 | 10.150 μs | 0.1908 μs | 0.2121 μs | 10.133 μs |      - |      - |         - |
| RandomAccessReadOnlyMemory        | 10000 | 10.288 μs | 0.0906 μs | 0.0707 μs | 10.280 μs |      - |      - |         - |
| CreateList                        | 10000 | 17.496 μs | 0.3369 μs | 0.3309 μs | 17.456 μs | 9.2468 | 1.0071 |   40056 B |
| CreateReadOnlyMemory              | 10000 |  6.314 μs | 0.1214 μs | 0.1398 μs |  6.306 μs | 9.1705 | 1.1444 |   40024 B |
