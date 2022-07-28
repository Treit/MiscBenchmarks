# Properties vs. Fields

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.25163
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=7.0.100-preview.5.22307.18
  [Host]     : .NET Core 6.0.7 (CoreCLR 6.0.722.32202, CoreFX 6.0.722.32202), X64 RyuJIT
  DefaultJob : .NET Core 6.0.7 (CoreCLR 6.0.722.32202, CoreFX 6.0.722.32202), X64 RyuJIT


```
|      Method |       Mean |    Error |    StdDev | Code Size |
|------------ |-----------:|---------:|----------:|----------:|
| GetProperty | 3,524.8 ns | 69.61 ns | 118.21 ns |     124 B |
|    GetField |   426.7 ns | 32.09 ns |  94.61 ns |      67 B |

## .NET Core 6.0.7 (CoreCLR 6.0.722.32202, CoreFX 6.0.722.32202), X64 RyuJIT
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
       cmp       dword ptr [rsi+18],0
       jle       short M00_L01
M00_L00:
       lea       rdx,[rsp+20]
       mov       rcx,rsi
       call      Test.Benchmark.DoGetProperty()
       inc       ebx
       cmp       ebx,[rsi+18]
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
; Total bytes of code 86
```
```assembly
; Test.Benchmark.DoGetProperty()
       push      rdi
       push      rsi
       mov       rsi,rdx
       mov       rdx,[rcx+8]
       mov       rcx,rdx
       mov       rdi,[rcx+10]
       mov       rdx,[rdx+8]
       mov       rcx,rsi
       call      CORINFO_HELP_CHECKED_ASSIGN_REF
       mov       [rsi+8],rdi
       mov       rax,rsi
       pop       rsi
       pop       rdi
       ret
; Total bytes of code 38
```

## .NET Core 6.0.7 (CoreCLR 6.0.722.32202, CoreFX 6.0.722.32202), X64 RyuJIT
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
       mov       ebp,[rcx+18]
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

