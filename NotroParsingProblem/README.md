## Text parsing problem from user Notro on the C# Discord

https://discord.com/channels/143867839282020352/751510709162213406/993957682543341589

The stated problem was to convert strings with this pattern:

"[on] [AdvancementsAddon] [player] advancement (award|get|complete)"

to this:

"on advancement complete"




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                   | Mean       | Error    | StdDev   | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|------------------------- |-----------:|---------:|---------:|------:|--------:|-------:|----------:|------------:|
| ParseUsingRegex          | 1,541.3 ns | 20.84 ns | 18.47 ns |  1.00 |    0.02 | 0.0229 |     408 B |        1.00 |
| ParseUsingCompiledRegex  |   474.1 ns |  8.50 ns |  7.54 ns |  0.31 |    0.01 | 0.0238 |     408 B |        1.00 |
| ParseUsingTokensViaSplit |   232.5 ns |  4.20 ns |  3.72 ns |  0.15 |    0.00 | 0.0315 |     528 B |        1.29 |
| ParseUsingStateMachine   |   153.6 ns |  2.97 ns |  3.42 ns |  0.10 |    0.00 | 0.0167 |     280 B |        0.69 |
| ParseUsingSpan           |   135.4 ns |  1.83 ns |  1.62 ns |  0.09 |    0.00 | 0.0091 |     152 B |        0.37 |
