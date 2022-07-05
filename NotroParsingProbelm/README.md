## Text parsing problem from user Notro on the C# Discord

https://discord.com/channels/143867839282020352/751510709162213406/993957682543341589

The stated problem was to convert strings with this pattern:

"[on] [AdvancementsAddon] [player] advancement (award|get|complete)"

to this:

"on advancement complete"

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.25155
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=7.0.100-preview.5.22307.18
  [Host]     : .NET Core 5.0.17 (CoreCLR 5.0.1722.21314, CoreFX 5.0.1722.21314), X64 RyuJIT
  DefaultJob : .NET Core 5.0.17 (CoreCLR 5.0.1722.21314, CoreFX 5.0.1722.21314), X64 RyuJIT


```
|                   Method |       Mean |    Error |   StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |-----------:|---------:|---------:|------:|-------:|------:|------:|----------:|
|          ParseUsingRegex | 2,706.0 ns | 53.47 ns | 90.80 ns |  1.00 | 0.0916 |     - |     - |     408 B |
|  ParseUsingCompiledRegex |   961.2 ns | 15.40 ns | 14.40 ns |  0.36 | 0.0935 |     - |     - |     408 B |
| ParseUsingTokensViaSplit |   404.7 ns |  6.46 ns |  5.39 ns |  0.15 | 0.1369 |     - |     - |     592 B |
|   ParseUsingStateMachine |   317.6 ns |  6.09 ns |  5.40 ns |  0.12 | 0.0648 |     - |     - |     280 B |
