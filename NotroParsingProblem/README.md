## Text parsing problem from user Notro on the C# Discord

https://discord.com/channels/143867839282020352/751510709162213406/993957682543341589

The stated problem was to convert strings with this pattern:

"[on] [AdvancementsAddon] [player] advancement (award|get|complete)"

to this:

"on advancement complete"


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                   Method |       Mean |   Error |  StdDev | Ratio |   Gen0 | Allocated | Alloc Ratio |
|------------------------- |-----------:|--------:|--------:|------:|-------:|----------:|------------:|
|          ParseUsingRegex | 1,480.7 ns | 5.02 ns | 4.69 ns |  1.00 | 0.0229 |     408 B |        1.00 |
|  ParseUsingCompiledRegex |   511.3 ns | 1.20 ns | 1.06 ns |  0.35 | 0.0238 |     408 B |        1.00 |
| ParseUsingTokensViaSplit |   265.2 ns | 1.33 ns | 1.18 ns |  0.18 | 0.0315 |     528 B |        1.29 |
|   ParseUsingStateMachine |   159.1 ns | 3.20 ns | 3.14 ns |  0.11 | 0.0167 |     280 B |        0.69 |
|           ParseUsingSpan |   158.3 ns | 0.60 ns | 0.56 ns |  0.11 | 0.0091 |     152 B |        0.37 |
