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
|                   Method |       Mean |    Error |    StdDev |     Median | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |-----------:|---------:|----------:|-----------:|------:|-------:|------:|------:|----------:|
|          ParseUsingRegex | 2,748.5 ns | 54.72 ns | 101.42 ns | 2,732.2 ns |  1.00 | 0.0916 |     - |     - |     408 B |
| ParseUsingTokensViaSplit |   409.9 ns |  8.27 ns |  14.26 ns |   407.5 ns |  0.15 | 0.1369 |     - |     - |     592 B |
|   ParseUsingStateMachine |   301.8 ns |  6.08 ns |  13.84 ns |   296.9 ns |  0.11 | 0.0648 |     - |     - |     280 B |
