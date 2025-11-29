Scratchpad


```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method | PredicateCount | Mean     | Error     | StdDev    |
|------- |--------------- |---------:|----------:|----------:|
| **Test**   | **4**              | **1.713 ms** | **0.0321 ms** | **0.0846 ms** |
| **Test**   | **8**              | **3.775 ms** | **0.0752 ms** | **0.1586 ms** |
