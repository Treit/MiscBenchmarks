# Regex parsing vs string.Split, as well as other techniques like using Span<T>.

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.22509
Unknown processor
.NET Core SDK=6.0.100
  [Host]     : .NET Core 5.0.12 (CoreCLR 5.0.1221.52207, CoreFX 5.0.1221.52207), X64 RyuJIT
  DefaultJob : .NET Core 5.0.12 (CoreCLR 5.0.1221.52207, CoreFX 5.0.1221.52207), X64 RyuJIT


```
|                      Method |  Count |               Mean |            Error |           StdDev | Ratio | RatioSD |      Gen 0 | Gen 1 | Gen 2 |  Allocated |
|---------------------------- |------- |-------------------:|-----------------:|-----------------:|------:|--------:|-----------:|------:|------:|-----------:|
|         **FindTokenUsingSplit** |     **10** |         **3,134.6 ns** |         **60.40 ns** |         **67.14 ns** |  **1.00** |    **0.00** |     **0.9727** |     **-** |     **-** |     **4200 B** |
|         FindTokenUsingRegex |     10 |        78,189.8 ns |      1,554.32 ns |      2,373.61 ns | 25.00 |    0.96 |     0.6104 |     - |     - |     2792 B |
| FindTokenUsingCompiledRegex |     10 |        22,266.2 ns |        441.88 ns |        661.38 ns |  7.15 |    0.30 |     0.6409 |     - |     - |     2792 B |
|          FindTokenUsingSpan |     10 |           329.8 ns |          6.62 ns |          9.06 ns |  0.11 |    0.00 |          - |     - |     - |          - |
|      FindTokenUsingTokenize |     10 |           553.4 ns |         10.12 ns |         16.34 ns |  0.18 |    0.01 |          - |     - |     - |          - |
|                             |        |                    |                  |                  |       |         |            |       |       |            |
|         **FindTokenUsingSplit** |    **100** |        **31,928.6 ns** |        **615.82 ns** |        **778.81 ns** |  **1.00** |    **0.00** |    **10.6201** |     **-** |     **-** |    **45960 B** |
|         FindTokenUsingRegex |    100 |     1,140,723.3 ns |     47,715.50 ns |    140,690.23 ns | 39.46 |    3.17 |     5.8594 |     - |     - |    27994 B |
| FindTokenUsingCompiledRegex |    100 |       299,624.1 ns |     15,375.96 ns |     45,336.38 ns |  8.74 |    1.52 |     6.3477 |     - |     - |    27994 B |
|          FindTokenUsingSpan |    100 |         4,521.8 ns |        190.09 ns |        560.49 ns |  0.14 |    0.02 |          - |     - |     - |          - |
|      FindTokenUsingTokenize |    100 |         5,854.4 ns |        114.42 ns |        164.10 ns |  0.18 |    0.01 |          - |     - |     - |          - |
|                             |        |                    |                  |                  |       |         |            |       |       |            |
|         **FindTokenUsingSplit** |   **1000** |       **310,426.7 ns** |      **6,175.20 ns** |     **15,940.16 ns** |  **1.00** |    **0.00** |   **107.4219** |     **-** |     **-** |   **463560 B** |
|         FindTokenUsingRegex |   1000 |     9,982,859.6 ns |    197,426.30 ns |    473,020.81 ns | 32.11 |    2.10 |    62.5000 |     - |     - |   280012 B |
| FindTokenUsingCompiledRegex |   1000 |     2,909,850.9 ns |     67,286.42 ns |    193,057.34 ns |  9.30 |    0.79 |    62.5000 |     - |     - |   280006 B |
|          FindTokenUsingSpan |   1000 |        45,505.2 ns |        903.19 ns |      1,295.33 ns |  0.15 |    0.01 |          - |     - |     - |          - |
|      FindTokenUsingTokenize |   1000 |        63,864.7 ns |      1,271.21 ns |      2,509.25 ns |  0.20 |    0.01 |          - |     - |     - |          - |
|                             |        |                    |                  |                  |       |         |            |       |       |            |
|         **FindTokenUsingSplit** | **100000** |    **36,078,276.7 ns** |    **716,286.19 ns** |  **1,587,240.71 ns** |  **1.00** |    **0.00** | **10733.3333** |     **-** |     **-** | **46400000 B** |
|         FindTokenUsingRegex | 100000 | 1,641,579,184.2 ns | 32,398,499.39 ns | 36,010,846.22 ns | 45.35 |    2.32 |  6000.0000 |     - |     - | 28001464 B |
| FindTokenUsingCompiledRegex | 100000 |   468,285,195.6 ns |  9,237,940.31 ns | 17,576,141.52 ns | 13.02 |    0.77 |  6000.0000 |     - |     - | 28001752 B |
|          FindTokenUsingSpan | 100000 |     6,643,850.3 ns |    130,031.45 ns |    220,803.27 ns |  0.19 |    0.01 |          - |     - |     - |          - |
|      FindTokenUsingTokenize | 100000 |     7,179,637.2 ns |    130,026.09 ns |    121,626.48 ns |  0.20 |    0.01 |          - |     - |     - |          - |
