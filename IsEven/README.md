# Is it even?


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.25963.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=8.0.100-preview.7.23376.3
  [Host]     : .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2


```
|                               Method |  Count |           Mean |         Error |        StdDev |         Median |  Ratio | RatioSD | Code Size |       Gen0 |   Allocated | Alloc Ratio |
|------------------------------------- |------- |---------------:|--------------:|--------------:|---------------:|-------:|--------:|----------:|-----------:|------------:|------------:|
|                       IsEvenUsingMod | 100000 |     408.821 μs |     2.8832 μs |     2.4076 μs |     409.391 μs |   1.00 |    0.00 |      71 B |          - |           - |          NA |
|      IsEvenUsingINumberIsEvenInteger | 100000 |     420.859 μs |     8.3468 μs |    13.9456 μs |     416.700 μs |   1.05 |    0.03 |      71 B |          - |           - |          NA |
|                      IsEvenlyxerexyl | 100000 |   1,743.495 μs |    33.7738 μs |    42.7131 μs |   1,741.578 μs |   4.26 |    0.14 |     157 B |   263.6719 |   1142625 B |          NA |
|                       IsEvenMrCarrot | 100000 |     612.936 μs |    11.9798 μs |    11.2059 μs |     610.390 μs |   1.49 |    0.02 |      94 B |          - |           - |          NA |
|                          IsEvenAaron | 100000 |     404.617 μs |     8.0665 μs |    10.2016 μs |     404.359 μs |   0.98 |    0.03 |      85 B |          - |           - |          NA |
|        IsEvenAaronUnsafeBitConverter | 100000 |     679.468 μs |    13.3134 μs |    19.0936 μs |     677.299 μs |   1.68 |    0.05 |     115 B |          - |           - |          NA |
| IsEvenCrabFuelCursedRecursiveVersion | 100000 |   1,715.292 μs |    34.0678 μs |    61.4312 μs |   1,694.827 μs |   4.26 |    0.17 |     133 B |          - |         1 B |          NA |
|            IsEvenNotWorthUsingJester | 100000 | 120,771.511 μs | 3,168.5207 μs | 9,091.0797 μs | 117,054.600 μs | 289.19 |   14.10 |     456 B | 26000.0000 | 112742054 B |          NA |
|                         IsEvenAkseli | 100000 |      10.916 μs |     0.2163 μs |     0.3553 μs |      10.854 μs |   0.03 |    0.00 |     135 B |          - |           - |          NA |
|                       IsEvenAkseliV2 | 100000 |       4.329 μs |     0.0986 μs |     0.2798 μs |       4.241 μs |   0.01 |    0.00 |     262 B |          - |           - |          NA |

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
       call      qword ptr [7FF7CF747A50]; Test.Benchmark.<IsEvenlyxerexyl>g__IsEven|8_0(Int32)
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
       call      qword ptr [7FF7CF737A98]; Test.Benchmark.<IsEvenAaronUnsafeBitConverter>g__IsEven|11_0(Int32)
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
       call      qword ptr [7FF7CF727AB0]; Test.Benchmark.<IsEvenCrabFuelCursedRecursiveVersion>g__IsEven|12_0(Int32)
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
       call      qword ptr [7FF7CF727AB0]
       test      eax,eax
       sete      al
       movzx     eax,al
       add       rsp,28
       ret
; Total bytes of code 37
```

## .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.IsEvenNotWorthUsingJester()
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
       call      qword ptr [7FF7CF727AC8]; Test.Benchmark.<IsEvenNotWorthUsingJester>g__IsEven|13_0(Int32)
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
; Test.Benchmark.<IsEvenNotWorthUsingJester>g__IsEven|13_0(Int32)
       push      rdi
       push      rsi
       sub       rsp,38
       xor       eax,eax
       mov       [rsp+30],rax
       xor       edx,edx
       mov       [rsp+20],edx
       mov       edx,2
       mov       r8d,0FFFFFFFF
       mov       r9d,20
       call      qword ptr [7FF7CF85D138]; System.ParseNumbers.IntToString(Int32, Int32, Int32, Char, Int32)
       mov       rcx,rax
       mov       edx,20
       mov       r8d,30
       cmp       [rcx],ecx
       call      qword ptr [7FF7CF471F48]; System.String.PadLeft(Int32, Char)
       mov       rsi,rax
       mov       rcx,19AE68064D8
       mov       r8,[rcx]
       test      r8,r8
       jne       short M01_L00
       mov       rcx,offset MT_System.Func`2[[System.Char, System.Private.CoreLib],[System.String, System.Private.CoreLib]]
       call      CORINFO_HELP_NEWSFAST
       mov       rdi,rax
       mov       rdx,19AE68064D0
       mov       rdx,[rdx]
       lea       rcx,[rdi+8]
       call      CORINFO_HELP_ASSIGN_REF
       mov       rdx,7FF7CF85AFD8
       mov       [rdi+18],rdx
       mov       rcx,19AE68064D8
       mov       rdx,rdi
       call      CORINFO_HELP_ASSIGN_REF
       mov       r8,rdi
M01_L00:
       mov       rdx,rsi
       mov       rcx,offset MD_System.Linq.Enumerable.Select[[System.Char, System.Private.CoreLib],[System.String, System.Private.CoreLib]](System.Collections.Generic.IEnumerable`1<Char>, System.Func`2<Char,System.String>)
       call      qword ptr [7FF7CF85D060]; System.Linq.Enumerable.Select[[System.Char, System.Private.CoreLib],[System.__Canon, System.Private.CoreLib]](System.Collections.Generic.IEnumerable`1<Char>, System.Func`2<Char,System.__Canon>)
       mov       rsi,rax
       mov       rcx,19AE68064C8
       mov       r8,[rcx]
       test      r8,r8
       jne       short M01_L01
       mov       rcx,offset MT_System.Func`2[[System.String, System.Private.CoreLib],[System.Int32, System.Private.CoreLib]]
       call      CORINFO_HELP_NEWSFAST
       mov       rdi,rax
       lea       rcx,[rdi+8]
       mov       rdx,rdi
       call      CORINFO_HELP_ASSIGN_REF
       mov       rdx,7FF7CF22D180
       mov       [rdi+18],rdx
       mov       rdx,offset System.Int32.Parse(System.String)
       mov       [rdi+20],rdx
       mov       rcx,19AE68064C8
       mov       rdx,rdi
       call      CORINFO_HELP_ASSIGN_REF
       mov       r8,rdi
M01_L01:
       mov       rdx,rsi
       mov       rcx,offset MD_System.Linq.Enumerable.Select[[System.String, System.Private.CoreLib],[System.Int32, System.Private.CoreLib]](System.Collections.Generic.IEnumerable`1<System.String>, System.Func`2<System.String,Int32>)
       call      qword ptr [7FF7CF85D090]; System.Linq.Enumerable.Select[[System.__Canon, System.Private.CoreLib],[System.Int32, System.Private.CoreLib]](System.Collections.Generic.IEnumerable`1<System.__Canon>, System.Func`2<System.__Canon,Int32>)
       mov       rcx,rax
       lea       rdx,[rsp+30]
       call      qword ptr [7FF7CF881AF8]; System.Linq.Enumerable.TryGetLast[[System.Int32, System.Private.CoreLib]](System.Collections.Generic.IEnumerable`1<Int32>, Boolean ByRef)
       cmp       byte ptr [rsp+30],0
       je        short M01_L05
       test      eax,eax
       jl        short M01_L03
       test      eax,eax
       jg        short M01_L04
       xor       edx,edx
M01_L02:
       mov       eax,edx
       test      eax,eax
       sete      al
       movzx     eax,al
       add       rsp,38
       pop       rsi
       pop       rdi
       ret
M01_L03:
       mov       edx,0FFFFFFFF
       jmp       short M01_L02
M01_L04:
       mov       edx,1
       jmp       short M01_L02
M01_L05:
       call      qword ptr [7FF7CF6EF7E0]
       int       3
; Total bytes of code 367
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
       vmovupd   ymm1,[7FF7CF3F6B80]
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

## .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.IsEvenAkseliV2()
       sub       rsp,28
       vzeroupper
       mov       rdx,[rcx+8]
       lea       rcx,[rdx+10]
       xor       r8d,r8d
       vxorps    ymm0,ymm0,ymm0
       mov       r9d,[rdx+8]
       lea       eax,[r9-20]
       movsxd    r10,eax
       test      r10,r10
       jl        short M00_L01
       vmovupd   ymm1,[7FF7CF436DA0]
M00_L00:
       vpand     ymm2,ymm1,[rcx+r8*4]
       vpaddd    ymm0,ymm0,ymm2
       vpand     ymm2,ymm1,[rcx+r8*4+20]
       vpaddd    ymm0,ymm0,ymm2
       vpand     ymm2,ymm1,[rcx+r8*4+40]
       vpaddd    ymm0,ymm0,ymm2
       vpand     ymm2,ymm1,[rcx+r8*4+60]
       vpaddd    ymm0,ymm0,ymm2
       add       r8,20
       cmp       r10,r8
       jge       short M00_L00
M00_L01:
       lea       eax,[r9-10]
       cdqe
       cmp       rax,r8
       jl        short M00_L02
       vmovupd   ymm1,[7FF7CF436DA0]
       vpand     ymm2,ymm1,[rcx+r8*4]
       vpaddd    ymm0,ymm0,ymm2
       vpand     ymm1,ymm1,[rcx+r8*4+20]
       vpaddd    ymm0,ymm0,ymm1
       add       r8,10
M00_L02:
       lea       eax,[r9-8]
       cdqe
       cmp       rax,r8
       jl        short M00_L03
       vmovupd   ymm1,[7FF7CF436DA0]
       vpand     ymm1,ymm1,[rcx+r8*4]
       vpaddd    ymm0,ymm0,ymm1
       add       r8,8
M00_L03:
       vphaddd   ymm0,ymm0,ymm0
       vphaddd   ymm0,ymm0,ymm0
       vextractf128 xmm1,ymm0,1
       vpaddd    xmm0,xmm1,xmm0
       vmovd     eax,xmm0
       mov       ecx,r9d
       cmp       rcx,r8
       jle       short M00_L05
       nop       dword ptr [rax]
M00_L04:
       cmp       r8,rcx
       jae       short M00_L06
       add       eax,[rdx+r8*4+10]
       inc       r8
       cmp       rcx,r8
       jg        short M00_L04
M00_L05:
       sub       r9d,eax
       movsxd    rax,r9d
       vzeroupper
       add       rsp,28
       ret
M00_L06:
       call      CORINFO_HELP_RNGCHKFAIL
       int       3
; Total bytes of code 262
```

