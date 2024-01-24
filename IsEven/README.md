# Is it even?



``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                               Method |  Count |          Mean |       Error |      StdDev |  Ratio | RatioSD | Code Size |      Gen0 |   Allocated | Alloc Ratio |
|------------------------------------- |------- |--------------:|------------:|------------:|-------:|--------:|----------:|----------:|------------:|------------:|
|                       IsEvenUsingMod | 100000 |    393.659 μs |   7.7923 μs |   8.9737 μs |   1.00 |    0.00 |      74 B |         - |           - |          NA |
|      IsEvenUsingINumberIsEvenInteger | 100000 |    389.137 μs |   4.5960 μs |   3.5883 μs |   0.99 |    0.03 |      74 B |         - |           - |          NA |
|                      IsEvenlyxerexyl | 100000 |    909.729 μs |   0.6912 μs |   0.6127 μs |   2.32 |    0.05 |     236 B |         - |           - |          NA |
|                       IsEvenMrCarrot | 100000 |    389.472 μs |   3.3301 μs |   2.9521 μs |   0.99 |    0.02 |      74 B |         - |           - |          NA |
|                          IsEvenAaron | 100000 |    393.427 μs |   6.0610 μs |   5.6695 μs |   1.00 |    0.03 |      88 B |         - |           - |          NA |
|        IsEvenAaronUnsafeBitConverter | 100000 |    550.735 μs |   0.5483 μs |   0.4579 μs |   1.40 |    0.03 |      97 B |         - |           - |          NA |
| IsEvenCrabFuelCursedRecursiveVersion | 100000 |  1,211.545 μs |   0.9120 μs |   0.8084 μs |   3.08 |    0.06 |     153 B |         - |           - |          NA |
|            IsEvenNotWorthUsingJester | 100000 | 61,711.031 μs | 431.8164 μs | 382.7940 μs | 157.05 |    3.41 |     536 B | 6666.6667 | 112741972 B |          NA |
|                         IsEvenAkseli | 100000 |      4.600 μs |   0.0069 μs |   0.0054 μs |   0.01 |    0.00 |     133 B |         - |           - |          NA |
|                       IsEvenAkseliV2 | 100000 |      4.261 μs |   0.0116 μs |   0.0109 μs |   0.01 |    0.00 |     269 B |         - |           - |          NA |

## .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.IsEvenUsingMod()
       sub       rsp,28
       mov       rax,[rcx+8]
       mov       rcx,rax
       xor       edx,edx
       xor       r8d,r8d
       cmp       dword ptr [rax+8],0
       jle       short M00_L02
       mov       r10d,[rcx+8]
       nop       word ptr [rax+rax]
M00_L00:
       cmp       r8d,r10d
       jae       short M00_L03
       mov       r9d,r8d
       test      byte ptr [rcx+r9*4+10],1
       jne       short M00_L01
       inc       rdx
M00_L01:
       inc       r8d
       cmp       [rax+8],r8d
       jg        short M00_L00
M00_L02:
       mov       rax,rdx
       add       rsp,28
       ret
M00_L03:
       call      CORINFO_HELP_RNGCHKFAIL
       int       3
; Total bytes of code 74
```

## .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.IsEvenUsingINumberIsEvenInteger()
       sub       rsp,28
       mov       rax,[rcx+8]
       mov       rcx,rax
       xor       edx,edx
       xor       r8d,r8d
       cmp       dword ptr [rax+8],0
       jle       short M00_L02
       mov       r10d,[rcx+8]
       nop       word ptr [rax+rax]
M00_L00:
       cmp       r8d,r10d
       jae       short M00_L03
       mov       r9d,r8d
       test      byte ptr [rcx+r9*4+10],1
       jne       short M00_L01
       inc       rdx
M00_L01:
       inc       r8d
       cmp       [rax+8],r8d
       jg        short M00_L00
M00_L02:
       mov       rax,rdx
       add       rsp,28
       ret
M00_L03:
       call      CORINFO_HELP_RNGCHKFAIL
       int       3
; Total bytes of code 74
```

## .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.IsEvenlyxerexyl()
       push      r14
       push      rdi
       push      rsi
       push      rbp
       push      rbx
       sub       rsp,20
       mov       rbx,rcx
       mov       rcx,[rbx+8]
       mov       rsi,rcx
       xor       edi,edi
       xor       ebp,ebp
       cmp       dword ptr [rcx+8],0
       jle       short M00_L02
       mov       r14d,[rsi+8]
M00_L00:
       cmp       ebp,r14d
       jae       short M00_L03
       mov       ecx,ebp
       mov       ecx,[rsi+rcx*4+10]
       call      qword ptr [7FFBFDCBEEE0]; Test.Benchmark.<IsEvenlyxerexyl>g__IsEven|8_0(Int32)
       test      eax,eax
       je        short M00_L01
       inc       rdi
M00_L01:
       inc       ebp
       mov       rax,[rbx+8]
       cmp       [rax+8],ebp
       jg        short M00_L00
M00_L02:
       mov       rax,rdi
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
       push      rbx
       sub       rsp,20
       mov       ebx,ecx
       test      ebx,ebx
       jl        short M01_L03
       cmp       ebx,12C
       jae       short M01_L04
       mov       rcx,288D9000260
       mov       rcx,[rcx]
       mov       eax,ebx
       mov       rax,[rcx+rax*8+10]
       test      rax,rax
       jne       short M01_L00
       mov       ecx,ebx
       call      qword ptr [7FFBFDB44F00]
M01_L00:
       mov       ecx,[rax+8]
       lea       edx,[rcx-1]
       cmp       edx,ecx
       jae       short M01_L05
       mov       ecx,edx
       movzx     eax,word ptr [rax+rcx*2+0C]
       add       eax,0FFFFFFD0
       cmp       eax,8
       ja        short M01_L01
       mov       ecx,155
       bt        ecx,eax
       jb        short M01_L02
M01_L01:
       xor       eax,eax
       add       rsp,20
       pop       rbx
       ret
M01_L02:
       mov       eax,1
       add       rsp,20
       pop       rbx
       ret
M01_L03:
       call      qword ptr [7FFBFDC1E370]
       mov       r8,[rax+28]
       mov       ecx,ebx
       mov       edx,0FFFFFFFF
       call      qword ptr [7FFBFDB44318]
       jmp       short M01_L00
M01_L04:
       mov       ecx,ebx
       call      qword ptr [7FFBFDB44498]
       jmp       short M01_L00
M01_L05:
       call      CORINFO_HELP_RNGCHKFAIL
       int       3
; Total bytes of code 147
```

## .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.IsEvenMrCarrot()
       sub       rsp,28
       mov       rax,[rcx+8]
       mov       rcx,rax
       xor       edx,edx
       xor       r8d,r8d
       cmp       dword ptr [rax+8],0
       jle       short M00_L02
       mov       r10d,[rcx+8]
       nop       word ptr [rax+rax]
M00_L00:
       cmp       r8d,r10d
       jae       short M00_L03
       mov       r9d,r8d
       test      byte ptr [rcx+r9*4+10],1
       jne       short M00_L01
       inc       rdx
M00_L01:
       inc       r8d
       cmp       [rax+8],r8d
       jg        short M00_L00
M00_L02:
       mov       rax,rdx
       add       rsp,28
       ret
M00_L03:
       call      CORINFO_HELP_RNGCHKFAIL
       int       3
; Total bytes of code 74
```

## .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.IsEvenAaron()
       sub       rsp,28
       mov       rax,[rcx+8]
       mov       rcx,rax
       xor       edx,edx
       xor       r8d,r8d
       cmp       dword ptr [rax+8],0
       jle       short M00_L02
       mov       r10d,[rcx+8]
       nop       word ptr [rax+rax]
M00_L00:
       cmp       r8d,r10d
       jae       short M00_L03
       mov       r9d,r8d
       mov       r9d,[rcx+r9*4+10]
       mov       r11d,1
       andn      r9d,r9d,r11d
       cmp       r9d,1
       jne       short M00_L01
       inc       rdx
M00_L01:
       inc       r8d
       cmp       [rax+8],r8d
       jg        short M00_L00
M00_L02:
       mov       rax,rdx
       add       rsp,28
       ret
M00_L03:
       call      CORINFO_HELP_RNGCHKFAIL
       int       3
; Total bytes of code 88
```

## .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.IsEvenAaronUnsafeBitConverter()
       sub       rsp,28
       mov       rax,[rcx+8]
       mov       rcx,rax
       xor       edx,edx
       xor       r8d,r8d
       cmp       dword ptr [rax+8],0
       jle       short M00_L02
       mov       r10d,[rcx+8]
       nop       word ptr [rax+rax]
M00_L00:
       cmp       r8d,r10d
       jae       short M00_L03
       mov       r9d,r8d
       mov       r9d,[rcx+r9*4+10]
       mov       [rsp+24],r9d
       mov       r9d,[rsp+24]
       and       r9d,1
       mov       [rsp+24],r9d
       cmp       byte ptr [rsp+24],0
       jne       short M00_L01
       inc       rdx
M00_L01:
       inc       r8d
       cmp       [rax+8],r8d
       jg        short M00_L00
M00_L02:
       mov       rax,rdx
       add       rsp,28
       ret
M00_L03:
       call      CORINFO_HELP_RNGCHKFAIL
       int       3
; Total bytes of code 97
```

## .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.IsEvenCrabFuelCursedRecursiveVersion()
       push      r14
       push      rdi
       push      rsi
       push      rbp
       push      rbx
       sub       rsp,20
       mov       rbx,rcx
       mov       rcx,[rbx+8]
       mov       rsi,rcx
       xor       edi,edi
       xor       ebp,ebp
       cmp       dword ptr [rcx+8],0
       jle       short M00_L02
       mov       r14d,[rsi+8]
M00_L00:
       cmp       ebp,r14d
       jae       short M00_L03
       mov       ecx,ebp
       mov       ecx,[rsi+rcx*4+10]
       cmp       ecx,1
       je        short M00_L01
       dec       ecx
       call      qword ptr [7FFBFDCCEF40]; Test.Benchmark.<IsEvenCrabFuelCursedRecursiveVersion>g__IsEven|12_0(Int32)
       test      eax,eax
       jne       short M00_L01
       inc       rdi
M00_L01:
       inc       ebp
       mov       rax,[rbx+8]
       cmp       [rax+8],ebp
       jg        short M00_L00
M00_L02:
       mov       rax,rdi
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
       push      rbx
       sub       rsp,20
       cmp       ecx,1
       je        short M01_L02
       dec       ecx
       cmp       ecx,1
       je        short M01_L03
       dec       ecx
       call      qword ptr [7FFBFDCCEF40]
       xor       ebx,ebx
       test      eax,eax
       sete      bl
M01_L01:
       xor       eax,eax
       test      ebx,ebx
       sete      al
       add       rsp,20
       pop       rbx
       ret
M01_L02:
       xor       eax,eax
       add       rsp,20
       pop       rbx
       ret
M01_L03:
       xor       ebx,ebx
       jmp       short M01_L01
; Total bytes of code 57
```

## .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.IsEvenNotWorthUsingJester()
       push      r14
       push      rdi
       push      rsi
       push      rbp
       push      rbx
       sub       rsp,20
       mov       rbx,rcx
       mov       rcx,[rbx+8]
       mov       rsi,rcx
       xor       edi,edi
       xor       ebp,ebp
       cmp       dword ptr [rcx+8],0
       jle       short M00_L02
       mov       r14d,[rsi+8]
M00_L00:
       cmp       ebp,r14d
       jae       short M00_L03
       mov       ecx,ebp
       mov       ecx,[rsi+rcx*4+10]
       call      qword ptr [7FFBFDCAEF58]; Test.Benchmark.<IsEvenNotWorthUsingJester>g__IsEven|13_0(Int32)
       test      eax,eax
       je        short M00_L01
       inc       rdi
M00_L01:
       inc       ebp
       mov       rax,[rbx+8]
       cmp       [rax+8],ebp
       jg        short M00_L00
M00_L02:
       mov       rax,rdi
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
       push      rbp
       push      rbx
       sub       rsp,28
       xor       eax,eax
       mov       [rsp+20],rax
       mov       r9,231DD000428
       mov       r9,[r9]
       mov       r8,2318030A738
       mov       edx,0FFFFFFFF
       call      qword ptr [7FFBFDB34DE0]; System.Number.<FormatInt32>g__FormatInt32Slow|41_0(Int32, Int32, System.String, System.IFormatProvider)
       mov       rbx,rax
       mov       esi,[rbx+8]
       mov       edi,esi
       neg       edi
       add       edi,20
       test      edi,edi
       jle       near ptr M01_L04
       mov       ecx,20
       call      System.String.FastAllocateString(Int32)
       mov       rbp,rax
       cmp       [rbp],bpl
       lea       rcx,[rbp+0C]
       mov       edx,edi
       mov       r8d,30
       call      qword ptr [7FFBFDE1C780]; System.SpanHelpers.Fill[[System.Char, System.Private.CoreLib]](Char ByRef, UIntPtr, Char)
       movsxd    r8,edi
       lea       rcx,[rbp+r8*2+0C]
       lea       rdx,[rbx+0C]
       movsxd    r8,esi
       add       r8,r8
       call      qword ptr [7FFBFDAC5B78]; System.Buffer.Memmove(Byte ByRef, Byte ByRef, UIntPtr)
M01_L00:
       mov       r8,231DD006058
       mov       r8,[r8]
       test      r8,r8
       je        near ptr M01_L05
M01_L01:
       mov       rdx,rbp
       mov       rcx,offset MD_System.Linq.Enumerable.Select[[System.Char, System.Private.CoreLib],[System.String, System.Private.CoreLib]](System.Collections.Generic.IEnumerable`1<Char>, System.Func`2<Char,System.String>)
       call      qword ptr [7FFBFDE5D428]; System.Linq.Enumerable.Select[[System.Char, System.Private.CoreLib],[System.__Canon, System.Private.CoreLib]](System.Collections.Generic.IEnumerable`1<Char>, System.Func`2<Char,System.__Canon>)
       mov       rsi,rax
       mov       r8,231DD006048
       mov       r8,[r8]
       test      r8,r8
       je        near ptr M01_L06
M01_L02:
       mov       rdx,rsi
       mov       rcx,offset MD_System.Linq.Enumerable.Select[[System.String, System.Private.CoreLib],[System.Int32, System.Private.CoreLib]](System.Collections.Generic.IEnumerable`1<System.String>, System.Func`2<System.String,Int32>)
       call      qword ptr [7FFBFDE5D458]; System.Linq.Enumerable.Select[[System.__Canon, System.Private.CoreLib],[System.Int32, System.Private.CoreLib]](System.Collections.Generic.IEnumerable`1<System.__Canon>, System.Func`2<System.__Canon,Int32>)
       mov       rcx,rax
       lea       rdx,[rsp+20]
       call      qword ptr [7FFBFDE84858]; System.Linq.Enumerable.TryGetLast[[System.Int32, System.Private.CoreLib]](System.Collections.Generic.IEnumerable`1<Int32>, Boolean ByRef)
       cmp       byte ptr [rsp+20],0
       je        near ptr M01_L07
       test      eax,eax
       jl        near ptr M01_L08
       xor       edi,edi
       test      eax,eax
       setg      dil
M01_L03:
       xor       eax,eax
       test      edi,edi
       sete      al
       add       rsp,28
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       ret
M01_L04:
       mov       rbp,rbx
       jmp       near ptr M01_L00
M01_L05:
       mov       rcx,offset MT_System.Func`2[[System.Char, System.Private.CoreLib],[System.String, System.Private.CoreLib]]
       call      CORINFO_HELP_NEWSFAST
       mov       rsi,rax
       mov       rdx,231DD006050
       mov       rdx,[rdx]
       mov       rcx,rsi
       mov       r8,7FFBFDE593B0
       call      qword ptr [7FFBFDA14210]; System.MulticastDelegate.CtorClosed(System.Object, IntPtr)
       mov       rcx,231DD006058
       mov       rdx,rsi
       call      CORINFO_HELP_ASSIGN_REF
       mov       r8,rsi
       jmp       near ptr M01_L01
M01_L06:
       mov       rcx,offset MT_System.Func`2[[System.String, System.Private.CoreLib],[System.Int32, System.Private.CoreLib]]
       call      CORINFO_HELP_NEWSFAST
       mov       rdi,rax
       mov       rcx,rdi
       xor       edx,edx
       mov       r8,offset System.Int32.Parse(System.String)
       mov       r9,7FFBFD8CD170
       call      qword ptr [7FFBFDA14258]
       mov       rcx,231DD006048
       mov       rdx,rdi
       call      CORINFO_HELP_ASSIGN_REF
       mov       r8,rdi
       jmp       near ptr M01_L02
M01_L07:
       call      qword ptr [7FFBFDCA7A68]
       int       3
M01_L08:
       mov       edi,0FFFFFFFF
       jmp       near ptr M01_L03
; Total bytes of code 447
```

## .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.IsEvenAkseli()
       sub       rsp,28
       vzeroupper
       mov       rax,[rcx+8]
       lea       rcx,[rax+10]
       xor       edx,edx
       vxorps    ymm0,ymm0,ymm0
       mov       r8d,[rax+8]
       lea       r10d,[r8-8]
       movsxd    r10,r10d
       test      r10,r10
       jl        short M00_L01
       vmovups   ymm1,[7FFBFDA47200]
M00_L00:
       vpand     ymm2,ymm1,[rcx+rdx*4]
       vpaddd    ymm0,ymm0,ymm2
       add       rdx,8
       cmp       r10,rdx
       jge       short M00_L00
M00_L01:
       vphaddd   ymm0,ymm0,ymm0
       vphaddd   ymm0,ymm0,ymm0
       vextracti128 xmm1,ymm0,1
       vpaddd    xmm0,xmm1,xmm0
       vmovd     ecx,xmm0
       mov       r10d,r8d
       cmp       r10,rdx
       jle       short M00_L03
       nop
M00_L02:
       cmp       rdx,r10
       jae       short M00_L04
       add       ecx,[rax+rdx*4+10]
       inc       rdx
       cmp       r10,rdx
       jg        short M00_L02
M00_L03:
       sub       r8d,ecx
       movsxd    rax,r8d
       vzeroupper
       add       rsp,28
       ret
M00_L04:
       call      CORINFO_HELP_RNGCHKFAIL
       int       3
; Total bytes of code 133
```

## .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.IsEvenAkseliV2()
       sub       rsp,28
       vzeroupper
       mov       rcx,[rcx+8]
       lea       rdx,[rcx+10]
       xor       r8d,r8d
       vxorps    ymm0,ymm0,ymm0
       mov       r10d,[rcx+8]
       lea       eax,[r10-20]
       cdqe
       test      rax,rax
       jl        short M00_L01
       vmovups   ymm1,[7FFBFDA47600]
       nop       dword ptr [rax]
M00_L00:
       vpand     ymm2,ymm1,[rdx+r8*4]
       vpaddd    ymm0,ymm0,ymm2
       vpand     ymm2,ymm1,[rdx+r8*4+20]
       vpaddd    ymm0,ymm0,ymm2
       vpand     ymm2,ymm1,[rdx+r8*4+40]
       vpaddd    ymm0,ymm0,ymm2
       vpand     ymm2,ymm1,[rdx+r8*4+60]
       vpaddd    ymm0,ymm0,ymm2
       add       r8,20
       cmp       rax,r8
       jge       short M00_L00
M00_L01:
       lea       eax,[r10-10]
       cdqe
       cmp       rax,r8
       jge       short M00_L05
       lea       eax,[r10-8]
       cdqe
       cmp       rax,r8
       jge       short M00_L06
M00_L02:
       vphaddd   ymm1,ymm0,ymm0
       vphaddd   ymm0,ymm1,ymm1
       vextracti128 xmm1,ymm0,1
       vpaddd    xmm0,xmm1,xmm0
       vmovd     eax,xmm0
       mov       edx,r10d
       cmp       rdx,r8
       jle       short M00_L04
       nop       word ptr [rax+rax]
M00_L03:
       cmp       r8,rdx
       jae       short M00_L07
       add       eax,[rcx+r8*4+10]
       inc       r8
       cmp       rdx,r8
       jg        short M00_L03
M00_L04:
       sub       r10d,eax
       movsxd    rax,r10d
       vzeroupper
       add       rsp,28
       ret
M00_L05:
       vmovups   ymm1,[7FFBFDA47600]
       vpand     ymm2,ymm1,[rdx+r8*4]
       vpaddd    ymm0,ymm0,ymm2
       vpand     ymm1,ymm1,[rdx+r8*4+20]
       vpaddd    ymm0,ymm0,ymm1
       add       r8,10
       lea       eax,[r10-8]
       cdqe
       cmp       rax,r8
       jl        short M00_L02
M00_L06:
       vmovups   ymm1,[7FFBFDA47600]
       vpand     ymm1,ymm1,[rdx+r8*4]
       vpaddd    ymm0,ymm0,ymm1
       add       r8,8
       jmp       near ptr M00_L02
M00_L07:
       call      CORINFO_HELP_RNGCHKFAIL
       int       3
; Total bytes of code 269
```

