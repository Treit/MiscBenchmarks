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
| Method                   | Mean       | Error    | StdDev   | Ratio | Gen0   | Allocated | Alloc Ratio |
|------------------------- |-----------:|---------:|---------:|------:|-------:|----------:|------------:|
| ParseUsingRegex          | 1,504.3 ns | 11.30 ns | 10.01 ns |  1.00 | 0.0229 |     408 B |        1.00 |
| ParseUsingCompiledRegex  |   456.4 ns |  1.80 ns |  1.60 ns |  0.30 | 0.0243 |     408 B |        1.00 |
| ParseUsingTokensViaSplit |   225.3 ns |  1.69 ns |  1.49 ns |  0.15 | 0.0315 |     528 B |        1.29 |
| ParseUsingStateMachine   |   168.3 ns |  1.52 ns |  1.42 ns |  0.11 | 0.0167 |     280 B |        0.69 |
| ParseUsingSpan           |   137.5 ns |  1.02 ns |  0.91 ns |  0.09 | 0.0091 |     152 B |        0.37 |
