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
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                   | Job       | Runtime   | Mean       | Error   | StdDev  | Ratio | Gen0   | Allocated | Alloc Ratio |
|------------------------- |---------- |---------- |-----------:|--------:|--------:|------:|-------:|----------:|------------:|
| ParseUsingRegex          | .NET 10.0 | .NET 10.0 | 1,445.1 ns | 5.93 ns | 4.95 ns |  1.00 | 0.0229 |     408 B |        1.00 |
| ParseUsingCompiledRegex  | .NET 10.0 | .NET 10.0 |   443.0 ns | 3.67 ns | 3.43 ns |  0.31 | 0.0243 |     408 B |        1.00 |
| ParseUsingTokensViaSplit | .NET 10.0 | .NET 10.0 |   205.3 ns | 1.41 ns | 1.31 ns |  0.14 | 0.0315 |     528 B |        1.29 |
| ParseUsingStateMachine   | .NET 10.0 | .NET 10.0 |   161.5 ns | 0.88 ns | 0.73 ns |  0.11 | 0.0167 |     280 B |        0.69 |
| ParseUsingSpan           | .NET 10.0 | .NET 10.0 |   135.9 ns | 0.73 ns | 0.64 ns |  0.09 | 0.0091 |     152 B |        0.37 |
|                          |           |           |            |         |         |       |        |           |             |
| ParseUsingRegex          | .NET 9.0  | .NET 9.0  | 1,455.0 ns | 6.46 ns | 5.73 ns |  1.00 | 0.0229 |     408 B |        1.00 |
| ParseUsingCompiledRegex  | .NET 9.0  | .NET 9.0  |   439.8 ns | 2.24 ns | 1.98 ns |  0.30 | 0.0243 |     408 B |        1.00 |
| ParseUsingTokensViaSplit | .NET 9.0  | .NET 9.0  |   212.4 ns | 1.90 ns | 1.78 ns |  0.15 | 0.0315 |     528 B |        1.29 |
| ParseUsingStateMachine   | .NET 9.0  | .NET 9.0  |   161.0 ns | 1.41 ns | 1.31 ns |  0.11 | 0.0167 |     280 B |        0.69 |
| ParseUsingSpan           | .NET 9.0  | .NET 9.0  |   136.1 ns | 0.93 ns | 0.87 ns |  0.09 | 0.0091 |     152 B |        0.37 |
