# Prime testing

Compares unary-regex prime detection with trial division, odd-only trial division, 6k +/- 1 wheel trial division, and deterministic Miller-Rabin. Each method tests batches of 100 known primes and 100 nearby composite controls.

```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.7376/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.302
  [Host]    : .NET 10.0.10 (10.0.1026.32716), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.10 (10.0.1026.32716), X64 RyuJIT AVX2

Job=.NET 10.0  Runtime=.NET 10.0  

```
| Method             | Input      | Mean            | Error        | StdDev       | Ratio    | RatioSD | Gen0   | Allocated | Alloc Ratio |
|------------------- |----------- |----------------:|-------------:|-------------:|---------:|--------:|-------:|----------:|------------:|
| **TrialDivision**      | **Primes**     |     **4,838.01 ns** |     **7.051 ns** |     **6.595 ns** |     **4.23** |    **0.01** |      **-** |         **-** |          **NA** |
| OddTrialDivision   | Primes     |     2,328.61 ns |     8.120 ns |     7.596 ns |     2.04 |    0.01 |      - |         - |          NA |
| WheelTrialDivision | Primes     |     1,143.85 ns |     1.239 ns |     1.099 ns |     1.00 |    0.00 |      - |         - |          NA |
| MillerRabin        | Primes     |    12,201.97 ns |    10.696 ns |     8.350 ns |    10.67 |    0.01 |      - |         - |          NA |
| UnaryRegex         | Primes     | 1,126,737.11 ns | 4,063.189 ns | 3,601.911 ns |   985.04 |    3.18 | 1.9531 |   50680 B |          NA |
|                    |            |                 |              |              |          |         |        |           |             |
| **TrialDivision**      | **Composites** |       **184.08 ns** |     **0.214 ns** |     **0.200 ns** |     **2.56** |    **0.01** |      **-** |         **-** |          **NA** |
| OddTrialDivision   | Composites |        70.55 ns |     0.134 ns |     0.105 ns |     0.98 |    0.00 |      - |         - |          NA |
| WheelTrialDivision | Composites |        71.85 ns |     0.392 ns |     0.348 ns |     1.00 |    0.01 |      - |         - |          NA |
| MillerRabin        | Composites |       254.78 ns |     2.160 ns |     1.804 ns |     3.55 |    0.03 |      - |         - |          NA |
| UnaryRegex         | Composites |    75,274.68 ns | 1,299.856 ns | 1,547.387 ns | 1,047.75 |   21.61 | 3.0518 |   51056 B |          NA |
