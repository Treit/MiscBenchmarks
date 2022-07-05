# Different methods of comparing strings

```ini
BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
AMD Ryzen 9 5950X, 1 CPU, 32 logical and 16 physical cores
.NET SDK=7.0.100-preview.4.22252.9
  [Host]     : .NET 7.0.0 (7.0.22.22904), X64 RyuJIT
  DefaultJob : .NET 7.0.0 (7.0.22.22904), X64 RyuJIT
```

```
|                      Method | numIterations |      Mean |    Error |   StdDev |
|---------------------------- |-------------- |----------:|---------:|---------:|
|                EqualsObject |            10 |  26.19 ns | 0.053 ns | 0.050 ns |
|                EqualsString |            10 |  21.56 ns | 0.103 ns | 0.097 ns |
| EqualsStringExplicitOrdinal |            10 |  33.87 ns | 0.098 ns | 0.092 ns |
|        EqualsStringOperator |            10 |  24.45 ns | 0.089 ns | 0.083 ns |
|                EqualsObject |           100 | 260.65 ns | 0.921 ns | 0.862 ns |
|                EqualsString |           100 | 219.07 ns | 0.834 ns | 0.780 ns |
| EqualsStringExplicitOrdinal |           100 | 345.83 ns | 0.539 ns | 0.478 ns |
|        EqualsStringOperator |           100 | 240.41 ns | 1.234 ns | 1.094 ns |
```
