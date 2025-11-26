# List\<T> vs ReadOnlyMemory\<T> Benchmark

Comparing the performance of `List<T>` vs `ReadOnlyMemory<T>` and `Memory<T>` for various operations.



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                            | Count | Mean     | Error     | StdDev    | Gen0   | Gen1   | Allocated |
|---------------------------------- |------ |---------:|----------:|----------:|-------:|-------:|----------:|
| ReadList                          | 10000 | 6.274 μs | 0.0276 μs | 0.0258 μs |      - |      - |         - |
| ReadReadOnlyMemory                | 10000 | 3.286 μs | 0.0131 μs | 0.0123 μs |      - |      - |         - |
| ReadMemory                        | 10000 | 3.288 μs | 0.0118 μs | 0.0098 μs |      - |      - |         - |
| ReadListForeach                   | 10000 | 6.250 μs | 0.0218 μs | 0.0182 μs |      - |      - |         - |
| ReadReadOnlyMemoryForeach         | 10000 | 3.311 μs | 0.0336 μs | 0.0314 μs |      - |      - |         - |
| WriteList                         | 10000 | 6.369 μs | 0.0378 μs | 0.0353 μs |      - |      - |         - |
| WriteListLocalVariable            | 10000 | 6.346 μs | 0.0274 μs | 0.0243 μs |      - |      - |         - |
| WriteListCollectionsMarshalAsSpan | 10000 | 3.152 μs | 0.0111 μs | 0.0093 μs |      - |      - |         - |
| WriteMemory                       | 10000 | 3.150 μs | 0.0181 μs | 0.0161 μs |      - |      - |         - |
| RandomAccessList                  | 10000 | 9.336 μs | 0.0555 μs | 0.0519 μs |      - |      - |         - |
| RandomAccessReadOnlyMemory        | 10000 | 8.602 μs | 0.0540 μs | 0.0505 μs |      - |      - |         - |
| CreateList                        | 10000 | 9.297 μs | 0.1060 μs | 0.0992 μs | 2.3804 | 0.2899 |   40056 B |
| CreateReadOnlyMemory              | 10000 | 4.323 μs | 0.0721 μs | 0.0674 μs | 2.3804 | 0.3357 |   40024 B |
