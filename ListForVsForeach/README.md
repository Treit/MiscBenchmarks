# Counting strings in a list using different types of loops.


``` ini

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22621.3737/22H2/2022Update/SunValley2)
AMD Ryzen 9 5950X, 1 CPU, 32 logical and 16 physical cores
.NET SDK 8.0.300
  [Host]     : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX2


```
| Method                                   | Count   | Mean             | Error          | StdDev         | Median           | Ratio | RatioSD |
|----------------------------------------- |-------- |-----------------:|---------------:|---------------:|-----------------:|------:|--------:|
| ForLoopCount                             | 10      |         5.417 ns |      0.1258 ns |      0.1398 ns |         5.344 ns |  0.85 |    0.02 |
| ForEachLoopCount                         | 10      |         6.366 ns |      0.0751 ns |      0.0702 ns |         6.360 ns |  1.00 |    0.00 |
| ForEachLoopCountCollectionsMarshalAsSpan | 10      |         3.664 ns |      0.0382 ns |      0.0357 ns |         3.662 ns |  0.58 |    0.01 |
| ListDotForEachLoopCount                  | 10      |        16.288 ns |      0.3502 ns |      1.0326 ns |        15.877 ns |  2.79 |    0.11 |
| ListExplicitEnumeratorCount              | 10      |         6.233 ns |      0.0715 ns |      0.0597 ns |         6.200 ns |  0.98 |    0.01 |
|                                          |         |                  |                |                |                  |       |         |
| ForLoopCount                             | 1000    |       551.896 ns |      7.7284 ns |      7.2292 ns |       553.143 ns |  0.97 |    0.02 |
| ForEachLoopCount                         | 1000    |       567.754 ns |      9.0915 ns |      8.5042 ns |       564.903 ns |  1.00 |    0.00 |
| ForEachLoopCountCollectionsMarshalAsSpan | 1000    |       312.821 ns |      6.2216 ns |      6.3892 ns |       313.339 ns |  0.55 |    0.01 |
| ListDotForEachLoopCount                  | 1000    |       750.051 ns |      6.8144 ns |      6.3742 ns |       751.437 ns |  1.32 |    0.02 |
| ListExplicitEnumeratorCount              | 1000    |       563.815 ns |      5.8169 ns |      5.4412 ns |       563.557 ns |  0.99 |    0.02 |
|                                          |         |                  |                |                |                  |       |         |
| ForLoopCount                             | 1000000 | 1,456,250.579 ns | 29,065.0520 ns | 27,187.4677 ns | 1,461,995.215 ns |  0.97 |    0.02 |
| ForEachLoopCount                         | 1000000 | 1,498,270.195 ns | 21,420.8591 ns | 20,037.0849 ns | 1,501,322.266 ns |  1.00 |    0.00 |
| ForEachLoopCountCollectionsMarshalAsSpan | 1000000 | 1,262,601.055 ns | 16,024.7643 ns | 14,989.5745 ns | 1,260,369.531 ns |  0.84 |    0.01 |
| ListDotForEachLoopCount                  | 1000000 | 1,635,871.177 ns | 32,122.9391 ns | 46,069.7594 ns | 1,616,172.266 ns |  1.10 |    0.03 |
| ListExplicitEnumeratorCount              | 1000000 | 1,486,582.380 ns | 13,707.3991 ns | 12,151.2523 ns | 1,482,133.496 ns |  0.99 |    0.01 |
