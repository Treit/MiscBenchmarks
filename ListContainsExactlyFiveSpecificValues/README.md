# Checking if a list contains exactly five pre-determined values in any order.

```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26090.1)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.202
  [Host]     : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  Job-RPYZJD : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX-512F+CD+BW+DQ+VL

InvocationCount=1  UnrollFactor=1  

```
| Method                                     | Count  | Mean       | Error     | StdDev    | Allocated |
|------------------------------------------- |------- |-----------:|----------:|----------:|----------:|
| ListIsExactlyFiveValuesHashSet             | 100000 |   503.2 ns |  26.64 ns |  76.43 ns |     400 B |
| ListIsExactlyFiveValuesSetEquals           | 100000 | 4,172.8 ns | 100.43 ns | 283.27 ns |     568 B |
| ListIsExactlyFiveValuesBitmaskSet          | 100000 | 5,230.1 ns | 145.88 ns | 413.83 ns |     616 B |
| ListIsExactlyFiveValuesPatternMatchingLulz | 100000 |   250.0 ns |   0.00 ns |   0.00 ns |     400 B |
