# Is it even?

``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.25963.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=8.0.100-preview.7.23376.3
  [Host]     : .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2


```
|                               Method |  Count |        Mean |     Error |    StdDev | Ratio | RatioSD | Code Size |     Gen0 | Allocated | Alloc Ratio |
|------------------------------------- |------- |------------:|----------:|----------:|------:|--------:|----------:|---------:|----------:|------------:|
|                       IsEvenUsingMod | 100000 |   394.65 μs |  3.853 μs |  3.604 μs |  1.00 |    0.00 |      71 B |        - |         - |          NA |
|      IsEvenUsingINumberIsEvenInteger | 100000 |   403.06 μs |  7.839 μs |  9.914 μs |  1.03 |    0.02 |      71 B |        - |         - |          NA |
|                      IsEvenlyxerexyl | 100000 | 1,636.90 μs | 32.687 μs | 46.879 μs |  4.22 |    0.11 |     157 B | 263.6719 | 1142625 B |          NA |
|                       IsEvenMrCarrot | 100000 |   596.13 μs | 11.887 μs | 14.598 μs |  1.52 |    0.04 |      94 B |        - |         - |          NA |
|                          IsEvenAaron | 100000 |   393.91 μs |  6.924 μs |  6.138 μs |  1.00 |    0.02 |      85 B |        - |         - |          NA |
|        IsEvenAaronUnsafeBitConverter | 100000 |   659.54 μs |  6.464 μs |  6.047 μs |  1.67 |    0.03 |     115 B |        - |         - |          NA |
| IsEvenCrabFuelCursedRecursiveVersion | 100000 | 1,654.18 μs | 29.477 μs | 26.131 μs |  4.19 |    0.08 |     133 B |        - |       2 B |          NA |
|                         IsEvenAkseli | 100000 |    10.33 μs |  0.133 μs |  0.111 μs |  0.03 |    0.00 |     135 B |        - |         - |          NA |


## .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.IsEvenUsingMod()
       sub       rsp,28
       mov       rdx,[rcx+8]
       mov       rcx,rdx
       xor       eax,eax
       xor       r8d,r8d
       cmp       dword ptr [rdx+8],0
       jle       short M00_L02
       mov       r9d,[rcx+8]
       nop       word ptr [rax+rax]
M00_L00:
       cmp       r8d,r9d
       jae       short M00_L03
       mov       r10d,r8d
       test      byte ptr [rcx+r10*4+10],1
       jne       short M00_L01
       inc       rax
M00_L01:
       inc       r8d
       cmp       [rdx+8],r8d
       jg        short M00_L00
M00_L02:
       add       rsp,28
       ret
M00_L03:
       call      CORINFO_HELP_RNGCHKFAIL
       int       3
; Total bytes of code 71
```

## .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.IsEvenUsingINumberIsEvenInteger()
       sub       rsp,28
       mov       rdx,[rcx+8]
       mov       rcx,rdx
       xor       eax,eax
       xor       r8d,r8d
       cmp       dword ptr [rdx+8],0
       jle       short M00_L02
       mov       r9d,[rcx+8]
       nop       word ptr [rax+rax]
M00_L00:
       cmp       r8d,r9d
       jae       short M00_L03
       mov       r10d,r8d
       test      byte ptr [rcx+r10*4+10],1
       jne       short M00_L01
       inc       rax
M00_L01:
       inc       r8d
       cmp       [rdx+8],r8d
       jg        short M00_L00
M00_L02:
       add       rsp,28
       ret
M00_L03:
       call      CORINFO_HELP_RNGCHKFAIL
       int       3
; Total bytes of code 71
```

## .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.IsEvenlyxerexyl()
       push      r14
       push      rdi
       push      rsi
       push      rbp
       push      rbx
       sub       rsp,20
       mov       rsi,rcx
       mov       rax,[rsi+8]
       mov       rdi,rax
       xor       ebx,ebx
       xor       ebp,ebp
       cmp       dword ptr [rax+8],0
       jle       short M00_L02
       mov       r14d,[rdi+8]
M00_L00:
       cmp       ebp,r14d
       jae       short M00_L03
       mov       ecx,ebp
       mov       ecx,[rdi+rcx*4+10]
       call      qword ptr [7FF7CF747A20]; Test.Benchmark.<IsEvenlyxerexyl>g__IsEven|8_0(Int32)
       test      eax,eax
       je        short M00_L01
       inc       rbx
M00_L01:
       inc       ebp
       mov       rax,[rsi+8]
       cmp       [rax+8],ebp
       jg        short M00_L00
M00_L02:
       mov       rax,rbx
       add       rsp,20
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r14
       ret
M00_L03:
       call      CORINFO_HELP_RNGCHKFAIL
       int       3
; Total bytes of code 89
```
```assembly
; Test.Benchmark.<IsEvenlyxerexyl>g__IsEven|8_0(Int32)
       sub       rsp,28
       call      qword ptr [7FF7CF527300]; System.Number.Int32ToDecStr(Int32)
       mov       edx,[rax+8]
       lea       ecx,[rdx-1]
       cmp       ecx,edx
       jae       short M01_L01
       mov       edx,ecx
       movzx     eax,word ptr [rax+rdx*2+0C]
       add       eax,0FFFFFFD0
       cmp       eax,8
       ja        short M01_L00
       mov       edx,155
       bt        edx,eax
       jae       short M01_L00
       mov       eax,1
       add       rsp,28
       ret
M01_L00:
       xor       eax,eax
       add       rsp,28
       ret
M01_L01:
       call      CORINFO_HELP_RNGCHKFAIL
       int       3
; Total bytes of code 68
```

## .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.IsEvenMrCarrot()
       sub       rsp,28
       mov       rdx,[rcx+8]
       mov       rcx,rdx
       xor       eax,eax
       xor       r8d,r8d
       cmp       dword ptr [rdx+8],0
       jle       short M00_L02
       mov       r9d,[rcx+8]
       nop       word ptr [rax+rax]
M00_L00:
       cmp       r8d,r9d
       jae       short M00_L03
       mov       r10d,r8d
       mov       r10d,[rcx+r10*4+10]
       mov       [rsp+24],r10d
       mov       r10d,[rsp+24]
       and       r10d,1
       mov       [rsp+24],r10d
       cmp       byte ptr [rsp+24],0
       jne       short M00_L01
       inc       rax
M00_L01:
       inc       r8d
       cmp       [rdx+8],r8d
       jg        short M00_L00
M00_L02:
       add       rsp,28
       ret
M00_L03:
       call      CORINFO_HELP_RNGCHKFAIL
       int       3
; Total bytes of code 94
```

## .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.IsEvenAaron()
       sub       rsp,28
       mov       rdx,[rcx+8]
       mov       rcx,rdx
       xor       eax,eax
       xor       r8d,r8d
       cmp       dword ptr [rdx+8],0
       jle       short M00_L02
       mov       r9d,[rcx+8]
       nop       word ptr [rax+rax]
M00_L00:
       cmp       r8d,r9d
       jae       short M00_L03
       mov       r10d,r8d
       mov       r10d,[rcx+r10*4+10]
       mov       r11d,1
       andn      r10d,r10d,r11d
       cmp       r10d,1
       jne       short M00_L01
       inc       rax
M00_L01:
       inc       r8d
       cmp       [rdx+8],r8d
       jg        short M00_L00
M00_L02:
       add       rsp,28
       ret
M00_L03:
       call      CORINFO_HELP_RNGCHKFAIL
       int       3
; Total bytes of code 85
```

## .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.IsEvenAaronUnsafeBitConverter()
       push      r14
       push      rdi
       push      rsi
       push      rbp
       push      rbx
       sub       rsp,20
       mov       rsi,rcx
       mov       rax,[rsi+8]
       mov       rdi,rax
       xor       ebx,ebx
       xor       ebp,ebp
       cmp       dword ptr [rax+8],0
       jle       short M00_L02
       mov       r14d,[rdi+8]
M00_L00:
       cmp       ebp,r14d
       jae       short M00_L03
       mov       ecx,ebp
       mov       ecx,[rdi+rcx*4+10]
       call      qword ptr [7FF7CF747A68]; Test.Benchmark.<IsEvenAaronUnsafeBitConverter>g__IsEven|11_0(Int32)
       test      eax,eax
       je        short M00_L01
       inc       rbx
M00_L01:
       inc       ebp
       mov       rax,[rsi+8]
       cmp       [rax+8],ebp
       jg        short M00_L00
M00_L02:
       mov       rax,rbx
       add       rsp,20
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r14
       ret
M00_L03:
       call      CORINFO_HELP_RNGCHKFAIL
       int       3
; Total bytes of code 89
```
```assembly
; Test.Benchmark.<IsEvenAaronUnsafeBitConverter>g__IsEven|11_0(Int32)
       mov       [rsp+8],ecx
       mov       eax,[rsp+8]
       and       eax,1
       mov       [rsp+8],eax
       xor       eax,eax
       cmp       byte ptr [rsp+8],0
       sete      al
       ret
; Total bytes of code 26
```

## .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.IsEvenCrabFuelCursedRecursiveVersion()
       push      r14
       push      rdi
       push      rsi
       push      rbp
       push      rbx
       sub       rsp,20
       mov       rsi,rcx
       mov       rax,[rsi+8]
       mov       rdi,rax
       xor       ebx,ebx
       xor       ebp,ebp
       cmp       dword ptr [rax+8],0
       jle       short M00_L02
       mov       r14d,[rdi+8]
M00_L00:
       cmp       ebp,r14d
       jae       short M00_L03
       mov       ecx,ebp
       mov       ecx,[rdi+rcx*4+10]
       cmp       ecx,1
       je        short M00_L01
       dec       ecx
       call      qword ptr [7FF7CF747A80]; Test.Benchmark.<IsEvenCrabFuelCursedRecursiveVersion>g__IsEven|12_0(Int32)
       test      eax,eax
       jne       short M00_L01
       inc       rbx
M00_L01:
       inc       ebp
       mov       rax,[rsi+8]
       cmp       [rax+8],ebp
       jg        short M00_L00
M00_L02:
       mov       rax,rbx
       add       rsp,20
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r14
       ret
M00_L03:
       call      CORINFO_HELP_RNGCHKFAIL
       int       3
; Total bytes of code 96
```
```assembly
; Test.Benchmark.<IsEvenCrabFuelCursedRecursiveVersion>g__IsEven|12_0(Int32)
M01_L00:
       sub       rsp,28
       cmp       ecx,1
       jne       short M01_L01
       xor       eax,eax
       add       rsp,28
       ret
M01_L01:
       dec       ecx
       call      qword ptr [7FF7CF747A80]
       test      eax,eax
       sete      al
       movzx     eax,al
       add       rsp,28
       ret
; Total bytes of code 37
```

## .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.IsEvenAkseli()
       sub       rsp,28
       vzeroupper
       mov       rdx,[rcx+8]
       lea       rcx,[rdx+10]
       xor       r8d,r8d
       vxorps    ymm0,ymm0,ymm0
       mov       r9d,[rdx+8]
       lea       eax,[r9-8]
       movsxd    r10,eax
       test      r10,r10
       jl        short M00_L01
       vmovupd   ymm1,[7FF7CF416B80]
M00_L00:
       vpand     ymm2,ymm1,[rcx+r8*4]
       vpaddd    ymm0,ymm0,ymm2
       add       r8,8
       cmp       r10,r8
       jge       short M00_L00
M00_L01:
       vphaddd   ymm0,ymm0,ymm0
       vphaddd   ymm0,ymm0,ymm0
       vextractf128 xmm1,ymm0,1
       vpaddd    xmm0,xmm1,xmm0
       vmovd     eax,xmm0
       mov       ecx,r9d
       cmp       rcx,r8
       jle       short M00_L03
M00_L02:
       cmp       r8,rcx
       jae       short M00_L04
       add       eax,[rdx+r8*4+10]
       inc       r8
       cmp       rcx,r8
       jg        short M00_L02
M00_L03:
       sub       r9d,eax
       movsxd    rax,r9d
       vzeroupper
       add       rsp,28
       ret
M00_L04:
       call      CORINFO_HELP_RNGCHKFAIL
       int       3
; Total bytes of code 135
```

