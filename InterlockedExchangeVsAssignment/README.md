# Interlocked.CompareExchange vs. Assignment





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                           | Job       | Runtime   | Mean      | Error     | StdDev    | Median    | Ratio | RatioSD | Code Size |
|--------------------------------- |---------- |---------- |----------:|----------:|----------:|----------:|------:|--------:|----------:|
| SetToZeroSimpleAssignment        | .NET 10.0 | .NET 10.0 | 0.0027 ns | 0.0034 ns | 0.0027 ns | 0.0027 ns |     ? |       ? |      11 B |
| SetToZeroWithInterlockedExchange | .NET 10.0 | .NET 10.0 | 1.0688 ns | 0.0124 ns | 0.0116 ns | 1.0723 ns |     ? |       ? |      14 B |
|                                  |           |           |           |           |           |           |       |         |           |
| SetToZeroSimpleAssignment        | .NET 9.0  | .NET 9.0  | 0.0137 ns | 0.0118 ns | 0.0110 ns | 0.0100 ns |     ? |       ? |      11 B |
| SetToZeroWithInterlockedExchange | .NET 9.0  | .NET 9.0  | 1.0565 ns | 0.0123 ns | 0.0115 ns | 1.0613 ns |     ? |       ? |      14 B |

## .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.SetToZeroSimpleAssignment()
       xor       eax,eax
       mov       [rcx+10],rax
       mov       rax,[rcx+10]
       ret
; Total bytes of code 11
```

## .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.SetToZeroWithInterlockedExchange()
       lea       rax,[rcx+10]
       xor       edx,edx
       xchg      rdx,[rax]
       mov       rax,[rcx+10]
       ret
; Total bytes of code 14
```

## .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.SetToZeroSimpleAssignment()
       xor       eax,eax
       mov       [rcx+10],rax
       mov       rax,[rcx+10]
       ret
; Total bytes of code 11
```

## .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.SetToZeroWithInterlockedExchange()
       lea       rax,[rcx+10]
       xor       edx,edx
       xchg      rdx,[rax]
       mov       rax,[rcx+10]
       ret
; Total bytes of code 14
```

