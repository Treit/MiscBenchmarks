# Properties vs. Fields

``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.25915.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.306
  [Host]     : .NET 7.0.9 (7.0.923.32018), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.9 (7.0.923.32018), X64 RyuJIT AVX2


```
|                        Method |       Mean |    Error |   StdDev |     Median | Code Size |
|------------------------------ |-----------:|---------:|---------:|-----------:|----------:|
|                   GetProperty | 3,175.2 ns | 62.16 ns | 51.91 ns | 3,160.7 ns |     122 B |
| GetPropertyAggressiveInlining |   395.1 ns |  9.84 ns | 27.74 ns |   387.2 ns |      71 B |
|                      GetField |   318.2 ns |  6.43 ns | 11.10 ns |   316.2 ns |      67 B |

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.25163
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=7.0.100-preview.5.22307.18
  [Host]     : .NET Core 6.0.7 (CoreCLR 6.0.722.32202, CoreFX 6.0.722.32202), X64 RyuJIT
  DefaultJob : .NET Core 6.0.7 (CoreCLR 6.0.722.32202, CoreFX 6.0.722.32202), X64 RyuJIT


## .NET 7.0.9 (7.0.923.32018), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.GetProperty()
       push      rdi
       push      rsi
       push      rbx
       sub       rsp,30
       xor       eax,eax
       mov       [rsp+20],rax
       mov       [rsp+28],rax
       mov       rsi,rcx
       mov       rdi,rdx
       xor       ebx,ebx
       cmp       dword ptr [rsi+10],0
       jle       short M00_L01
M00_L00:
       lea       rdx,[rsp+20]
       mov       rcx,rsi
       call      qword ptr [7FFF2ACC7948]; Test.Benchmark.DoGetProperty()
       inc       ebx
       cmp       ebx,[rsi+10]
       jl        short M00_L00
M00_L01:
       mov       rdx,[rsp+20]
       mov       rcx,rdi
       call      CORINFO_HELP_CHECKED_ASSIGN_REF
       mov       rax,[rsp+28]
       mov       [rdi+8],rax
       mov       rax,rdi
       add       rsp,30
       pop       rbx
       pop       rsi
       pop       rdi
       ret
; Total bytes of code 87
```
```assembly
; Test.Benchmark.DoGetProperty()
       push      rdi
       push      rsi
       mov       rsi,rdx
       mov       rdx,[rcx+8]
       mov       rdi,[rdx+10]
       mov       rdx,[rdx+8]
       mov       rcx,rsi
       call      CORINFO_HELP_CHECKED_ASSIGN_REF
       mov       [rsi+8],rdi
       mov       rax,rsi
       pop       rsi
       pop       rdi
       ret
; Total bytes of code 35
```

## .NET 7.0.9 (7.0.923.32018), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.GetPropertyAggressiveInlining()
       push      rdi
       push      rsi
       push      rbp
       push      rbx
       mov       rsi,rdx
       xor       edx,edx
       xor       edi,edi
       xor       ebx,ebx
       mov       ebp,[rcx+10]
       test      ebp,ebp
       jle       short M00_L01
       mov       rax,[rcx+8]
       mov       rdx,[rax+10]
       nop       dword ptr [rax]
M00_L00:
       mov       rdi,rdx
       mov       rcx,rax
       mov       rcx,[rcx+8]
       inc       ebx
       cmp       ebx,ebp
       jl        short M00_L00
       mov       rdx,rcx
M00_L01:
       mov       rcx,rsi
       call      CORINFO_HELP_CHECKED_ASSIGN_REF
       mov       [rsi+8],rdi
       mov       rax,rsi
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       ret
; Total bytes of code 71
```

## .NET 7.0.9 (7.0.923.32018), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.GetField()
       push      rdi
       push      rsi
       push      rbp
       push      rbx
       mov       rsi,rdx
       xor       edx,edx
       xor       edi,edi
       xor       ebx,ebx
       mov       ebp,[rcx+10]
       test      ebp,ebp
       jle       short M00_L01
       mov       rax,[rcx+8]
       mov       rdx,[rax+10]
       mov       rax,[rax+8]
M00_L00:
       mov       rdi,rdx
       mov       rcx,rax
       inc       ebx
       cmp       ebx,ebp
       jl        short M00_L00
       mov       rdx,rcx
M00_L01:
       mov       rcx,rsi
       call      CORINFO_HELP_CHECKED_ASSIGN_REF
       mov       [rsi+8],rdi
       mov       rax,rsi
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       ret
; Total bytes of code 67
```

