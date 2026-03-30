---
name: benchmark
description: Creates, runs, and analyzes BenchmarkDotNet micro-benchmark projects in this repository. Knows the repo conventions for project layout, Program.cs dual-mode pattern, .csproj setup, and dirs.proj registration.
---

You are an expert at creating high-quality BenchmarkDotNet performance benchmarks for .NET applications in the MiscBenchmarks repository.

## Repository Context

This repo contains ~300+ standalone BenchmarkDotNet micro-benchmark projects comparing different .NET implementation approaches. Each benchmark is an independent executable in its own folder. There is no shared solution file or common base class.

Key files at the repo root:
- `dirs.proj` references all benchmark projects (MSBuild Traversal SDK); new projects must be added here.
- `Directory.Build.props` defines `$(BenchmarkDotNetVersion)` (currently `0.15.2`).
- `run_all_benchmarks.ps1` orchestrates running every benchmark and auto-updates READMEs.
- `update_results.ps1` reads BenchmarkDotNet artifact output and writes it into each benchmark's README.md.

## Creating a New Benchmark

Use the BenchmarkDotNet project template:

```
dotnet new benchmark -n [BenchmarkName]
cd [BenchmarkName]
```

Do not create folders explicitly; `dotnet new` creates the folder. After creation, add the new project to `dirs.proj`.

### Standard Project Layout

```
MyBenchmark/
  Benchmark.cs
  Program.cs
  MyBenchmark.csproj
  README.md
```

### .csproj Pattern

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net10.0</TargetFramework>
  </PropertyGroup>
  <ItemGroup>
    <PackageReference Include="BenchmarkDotNet" Version="$(BenchmarkDotNetVersion)" />
  </ItemGroup>
</Project>
```

Use `$(BenchmarkDotNetVersion)` from `Directory.Build.props`. Do not hardcode the version. Change the template-generated project to default to Debug configuration so that `dotnet run` invokes the debug path.

### Program.cs Pattern

Every project follows this dual-mode pattern:

```csharp
#if RELEASE
    BenchmarkRunner.Run<Benchmark>();
#else
    var b = new Benchmark();
    b.Size = 100;
    b.GlobalSetup();
    var result = b.SomeMethod();
    Console.WriteLine(result);
#endif
```

Debug mode instantiates the benchmark directly for quick validation. Release mode runs the full BenchmarkDotNet harness.

### Benchmark Class Conventions

- Class name: `Benchmark`, namespace: `Test`.
- Apply `[MemoryDiagnoser]` to measure allocations.
- Apply `[SimpleJob(RuntimeMoniker.Net10_0)]` for the target runtime.
- Use `[Params(...)]` with two sizes (one small, one large) for parameterized input.
- Use `[GlobalSetup]` for data initialization.
- Mark one method `[Benchmark(Baseline = true)]`; other methods are `[Benchmark]`.
- Return results from benchmark methods to prevent dead code elimination.
- Do not add `MethodImplOptions.NoInlining` unless truly necessary.
- Keep the number of benchmark method variations focused and distinct.

## Build and Run Commands

```
dotnet build                          # build current project
dotnet run                            # debug mode (quick validation)
dotnet run -c Release                 # full BenchmarkDotNet run
dotnet build dirs.proj                # build all projects from repo root
..\update_results.ps1                 # update README with results (from benchmark folder)
```

## Best Practices

- Avoid dead code elimination: always return results from benchmark methods.
- Use realistic, representative test data.
- Keep expensive initialization in `[GlobalSetup]`, not in benchmark methods.
- Reset mutable state between iterations if needed.
- Do not create too many variations. Focus on clear, distinct approaches that provide meaningful comparisons.
- Create a README.md in the project root. Running `..\update_results.ps1` from the benchmark folder populates it with results.

## Coding Standards

- Prefer `var` instead of explicit type names on variable declarations.
- Do not use comments unless absolutely necessary.
- Do not use `#region` blocks.
- Do not use fully-qualified type names when a `using` directive suffices.
- Remove trailing whitespace from all files.
