# Finding an item




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                 | Iterations | Mean           | Error        | StdDev       | Allocated |
|----------------------- |----------- |---------------:|-------------:|-------------:|----------:|
| **LookupUsingHashSet**     | **1000**       |     **2,374.2 ns** |     **25.97 ns** |     **21.69 ns** |         **-** |
| LookupUsingList        | 1000       |     2,506.1 ns |     14.98 ns |     14.01 ns |         - |
| LookupUsingConditional | 1000       |       786.3 ns |      3.89 ns |      3.44 ns |         - |
| LookupUsingSwitch      | 1000       |       477.5 ns |      1.85 ns |      1.64 ns |         - |
| LookupUsingRange       | 1000       |       323.4 ns |      3.51 ns |      3.28 ns |         - |
| **LookupUsingHashSet**     | **100000**     |   **232,694.4 ns** |    **702.00 ns** |    **548.07 ns** |         **-** |
| LookupUsingList        | 100000     |   249,782.9 ns |  2,059.03 ns |  1,926.02 ns |         - |
| LookupUsingConditional | 100000     |    78,337.5 ns |    549.92 ns |    514.39 ns |         - |
| LookupUsingSwitch      | 100000     |    47,013.1 ns |    219.73 ns |    194.78 ns |         - |
| LookupUsingRange       | 100000     |    31,334.5 ns |    335.43 ns |    313.77 ns |         - |
| **LookupUsingHashSet**     | **1000000**    | **2,372,681.2 ns** | **16,876.99 ns** | **15,786.75 ns** |         **-** |
| LookupUsingList        | 1000000    | 2,501,196.2 ns | 16,986.00 ns | 15,888.71 ns |         - |
| LookupUsingConditional | 1000000    |   782,111.6 ns |  3,855.39 ns |  3,606.33 ns |         - |
| LookupUsingSwitch      | 1000000    |   472,094.5 ns |  2,756.07 ns |  2,578.03 ns |         - |
| LookupUsingRange       | 1000000    |   314,730.3 ns |  2,569.52 ns |  2,277.81 ns |         - |
