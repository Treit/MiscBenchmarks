## Counting digits

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.22543
Unknown processor
.NET Core SDK=6.0.101
  [Host]     : .NET Core 5.0.12 (CoreCLR 5.0.1221.52207, CoreFX 5.0.1221.52207), X64 RyuJIT
  DefaultJob : .NET Core 5.0.12 (CoreCLR 5.0.1221.52207, CoreFX 5.0.1221.52207), X64 RyuJIT


```
|                              Method |  Count |           Mean |        Error |        StdDev |         Median | Ratio | RatioSD |     Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |------- |---------------:|-------------:|--------------:|---------------:|------:|--------:|----------:|------:|------:|----------:|
|                **CountDigitsUsingMath** |    **100** |       **966.2 ns** |     **18.86 ns** |      **31.51 ns** |       **966.1 ns** |  **1.00** |    **0.00** |         **-** |     **-** |     **-** |         **-** |
|  CountDigitsUsingMathIncludingFloor |    100 |     1,042.1 ns |     20.71 ns |      50.02 ns |     1,047.9 ns |  1.08 |    0.06 |         - |     - |     - |         - |
|              CountDigitsUsingString |    100 |     2,825.9 ns |     56.02 ns |      92.05 ns |     2,842.5 ns |  2.93 |    0.14 |    1.0223 |     - |     - |    4424 B |
|            CountDigitsUsingMaxMahem |    100 |     5,088.2 ns |    101.73 ns |     251.46 ns |     5,074.5 ns |  5.18 |    0.30 |         - |     - |     - |         - |
|         CountDigitsUsingLookupTable |    100 |       382.5 ns |      7.68 ns |      12.83 ns |       382.0 ns |  0.40 |    0.02 |         - |     - |     - |         - |
| CountDigitsUsingIfGreaterThanChecks |    100 |       373.0 ns |      7.47 ns |      15.09 ns |       369.8 ns |  0.39 |    0.02 |         - |     - |     - |         - |
|                                     |        |                |              |               |                |       |         |           |       |       |           |
|                **CountDigitsUsingMath** |   **1000** |     **9,499.9 ns** |    **187.45 ns** |     **268.83 ns** |     **9,538.7 ns** |  **1.00** |    **0.00** |         **-** |     **-** |     **-** |         **-** |
|  CountDigitsUsingMathIncludingFloor |   1000 |    10,358.9 ns |    223.84 ns |     627.66 ns |    10,266.5 ns |  1.10 |    0.07 |         - |     - |     - |         - |
|              CountDigitsUsingString |   1000 |    29,449.2 ns |    582.41 ns |     973.07 ns |    29,312.3 ns |  3.11 |    0.14 |   10.2844 |     - |     - |   44376 B |
|            CountDigitsUsingMaxMahem |   1000 |    49,760.7 ns |    971.27 ns |   2,364.21 ns |    49,797.1 ns |  5.36 |    0.32 |         - |     - |     - |         - |
|         CountDigitsUsingLookupTable |   1000 |     3,692.0 ns |     71.32 ns |      87.59 ns |     3,703.0 ns |  0.39 |    0.01 |         - |     - |     - |         - |
| CountDigitsUsingIfGreaterThanChecks |   1000 |     3,704.5 ns |     74.02 ns |     140.84 ns |     3,696.6 ns |  0.39 |    0.02 |         - |     - |     - |         - |
|                                     |        |                |              |               |                |       |         |           |       |       |           |
|                **CountDigitsUsingMath** | **100000** |   **946,424.9 ns** | **18,687.04 ns** |  **34,170.31 ns** |   **947,913.9 ns** |  **1.00** |    **0.00** |         **-** |     **-** |     **-** |         **-** |
|  CountDigitsUsingMathIncludingFloor | 100000 | 1,027,580.0 ns | 20,551.43 ns |  52,309.95 ns | 1,032,557.0 ns |  1.08 |    0.06 |         - |     - |     - |         - |
|              CountDigitsUsingString | 100000 | 3,055,300.0 ns | 64,296.30 ns | 177,090.69 ns | 2,990,586.9 ns |  3.27 |    0.26 | 1023.4375 |     - |     - | 4426136 B |
|            CountDigitsUsingMaxMahem | 100000 | 4,900,691.6 ns | 96,874.38 ns | 184,313.58 ns | 4,898,947.7 ns |  5.18 |    0.27 |         - |     - |     - |         - |
|         CountDigitsUsingLookupTable | 100000 |   370,280.7 ns |  7,189.95 ns |  17,226.67 ns |   365,752.6 ns |  0.39 |    0.02 |         - |     - |     - |         - |
| CountDigitsUsingIfGreaterThanChecks | 100000 |   365,690.8 ns |  7,286.02 ns |  12,173.31 ns |   366,350.9 ns |  0.39 |    0.02 |         - |     - |     - |         - |
