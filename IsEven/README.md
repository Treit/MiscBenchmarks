# Is it even?




```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26096.1)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-preview.2.24157.14
  [Host]     : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                               | Count | Mean            | Error         | StdDev          | Median          | Ratio  | RatioSD | Code Size | Gen0      | Allocated  | Alloc Ratio |
|------------------------------------- |------ |----------------:|--------------:|----------------:|----------------:|-------:|--------:|----------:|----------:|-----------:|------------:|
| IsEvenUsingMod                       | 10000 |     43,257.2 ns |     858.43 ns |     2,504.08 ns |     42,786.1 ns |   1.00 |    0.00 |      76 B |         - |          - |          NA |
| IsEvenUsingINumberIsEvenInteger      | 10000 |     41,733.1 ns |     760.23 ns |     1,668.73 ns |     41,255.7 ns |   0.96 |    0.06 |      76 B |         - |          - |          NA |
| IsEvenlyxerexyl                      | 10000 |     96,203.6 ns |   1,908.69 ns |     5,257.10 ns |     95,088.6 ns |   2.23 |    0.18 |     236 B |         - |          - |          NA |
| IsEvenMrCarrot                       | 10000 |     41,215.0 ns |     814.87 ns |     1,550.38 ns |     40,590.2 ns |   0.95 |    0.07 |      76 B |         - |          - |          NA |
| IsEvenAaron                          | 10000 |     39,044.3 ns |     779.65 ns |     1,118.14 ns |     38,564.8 ns |   0.90 |    0.05 |      90 B |         - |          - |          NA |
| IsEvenAaronUnsafeBitConverter        | 10000 |     60,946.4 ns |   1,207.36 ns |     3,159.46 ns |     60,756.3 ns |   1.40 |    0.12 |      99 B |         - |          - |          NA |
| IsEvenCrabFuelCursedRecursiveVersion | 10000 |    136,227.0 ns |   2,662.78 ns |     2,360.48 ns |    135,710.9 ns |   3.25 |    0.13 |     153 B |         - |          - |          NA |
| IsEvenNotWorthUsingJester            | 10000 | 10,676,524.3 ns | 632,235.97 ns | 1,814,003.52 ns | 10,202,451.6 ns | 248.28 |   49.66 |     536 B | 2609.3750 | 11274284 B |          NA |
| IsEvenAkseli                         | 10000 |        849.9 ns |      23.92 ns |        70.54 ns |        831.5 ns |   0.02 |    0.00 |     141 B |         - |          - |          NA |
| IsEvenAkseliV2                       | 10000 |        741.2 ns |      22.28 ns |        65.69 ns |        767.9 ns |   0.02 |    0.00 |     262 B |         - |          - |          NA |

## .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
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
       jae       short M00_L04
       mov       r9d,r8d
       test      byte ptr [rcx+r9*4+10],1
       je        short M00_L03
M00_L01:
       inc       r8d
       cmp       [rax+8],r8d
       jg        short M00_L00
M00_L02:
       mov       rax,rdx
       add       rsp,28
       ret
M00_L03:
       inc       rdx
       jmp       short M00_L01
M00_L04:
       call      CORINFO_HELP_RNGCHKFAIL
       int       3
; Total bytes of code 76
```

## .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
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
       jae       short M00_L04
       mov       r9d,r8d
       test      byte ptr [rcx+r9*4+10],1
       je        short M00_L03
M00_L01:
       inc       r8d
       cmp       [rax+8],r8d
       jg        short M00_L00
M00_L02:
       mov       rax,rdx
       add       rsp,28
       ret
M00_L03:
       inc       rdx
       jmp       short M00_L01
M00_L04:
       call      CORINFO_HELP_RNGCHKFAIL
       int       3
; Total bytes of code 76
```

## .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
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
       call      qword ptr [7FF9128BEEE0]; Test.Benchmark.<IsEvenlyxerexyl>g__IsEven|8_0(Int32)
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
       mov       rcx,204C4C00260
       mov       rcx,[rcx]
       mov       eax,ebx
       mov       rax,[rcx+rax*8+10]
       test      rax,rax
       jne       short M01_L00
       mov       ecx,ebx
       call      qword ptr [7FF912744F00]; System.Number.<UInt32ToDecStrForKnownSmallNumber>g__CreateAndCacheString|70_0(UInt32)
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
       call      qword ptr [7FF91281E370]; System.Globalization.NumberFormatInfo.get_CurrentInfo()
       mov       r8,[rax+28]
       mov       ecx,ebx
       mov       edx,0FFFFFFFF
       call      qword ptr [7FF912744318]
       jmp       short M01_L00
M01_L04:
       mov       ecx,ebx
       call      qword ptr [7FF912744498]; System.Number.UInt32ToDecStr_NoSmallNumberCheck(UInt32)
       jmp       short M01_L00
M01_L05:
       call      CORINFO_HELP_RNGCHKFAIL
       int       3
; Total bytes of code 147
```

## .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
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
       jae       short M00_L04
       mov       r9d,r8d
       test      byte ptr [rcx+r9*4+10],1
       je        short M00_L03
M00_L01:
       inc       r8d
       cmp       [rax+8],r8d
       jg        short M00_L00
M00_L02:
       mov       rax,rdx
       add       rsp,28
       ret
M00_L03:
       inc       rdx
       jmp       short M00_L01
M00_L04:
       call      CORINFO_HELP_RNGCHKFAIL
       int       3
; Total bytes of code 76
```

## .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
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
       jae       short M00_L04
       mov       r9d,r8d
       mov       r9d,[rcx+r9*4+10]
       mov       r11d,1
       andn      r9d,r9d,r11d
       cmp       r9d,1
       je        short M00_L03
M00_L01:
       inc       r8d
       cmp       [rax+8],r8d
       jg        short M00_L00
M00_L02:
       mov       rax,rdx
       add       rsp,28
       ret
M00_L03:
       inc       rdx
       jmp       short M00_L01
M00_L04:
       call      CORINFO_HELP_RNGCHKFAIL
       int       3
; Total bytes of code 90
```

## .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
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
       jae       short M00_L04
       mov       r9d,r8d
       mov       r9d,[rcx+r9*4+10]
       mov       [rsp+24],r9d
       mov       r9d,[rsp+24]
       and       r9d,1
       mov       [rsp+24],r9d
       cmp       byte ptr [rsp+24],0
       je        short M00_L03
M00_L01:
       inc       r8d
       cmp       [rax+8],r8d
       jg        short M00_L00
M00_L02:
       mov       rax,rdx
       add       rsp,28
       ret
M00_L03:
       inc       rdx
       jmp       short M00_L01
M00_L04:
       call      CORINFO_HELP_RNGCHKFAIL
       int       3
; Total bytes of code 99
```

## .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
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
       call      qword ptr [7FF91288EF40]; Test.Benchmark.<IsEvenCrabFuelCursedRecursiveVersion>g__IsEven|12_0(Int32)
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
       call      qword ptr [7FF91288EF40]
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

## .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
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
       call      qword ptr [7FF9128BEF58]; Test.Benchmark.<IsEvenNotWorthUsingJester>g__IsEven|13_0(Int32)
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
       mov       r9,1CBBA400428
       mov       r9,[r9]
       mov       r8,1CB8020AC90
       mov       edx,0FFFFFFFF
       call      qword ptr [7FF912744DE0]; System.Number.<FormatInt32>g__FormatInt32Slow|41_0(Int32, Int32, System.String, System.IFormatProvider)
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
       call      qword ptr [7FF912A465B0]; System.SpanHelpers.Fill[[System.Char, System.Private.CoreLib]](Char ByRef, UIntPtr, Char)
       movsxd    r8,edi
       lea       rcx,[rbp+r8*2+0C]
       lea       rdx,[rbx+0C]
       movsxd    r8,esi
       add       r8,r8
       call      qword ptr [7FF9126D5B78]; System.Buffer.Memmove(Byte ByRef, Byte ByRef, UIntPtr)
M01_L00:
       mov       r8,1CBBA4061C8
       mov       r8,[r8]
       test      r8,r8
       je        near ptr M01_L05
M01_L01:
       mov       rdx,rbp
       mov       rcx,offset MD_System.Linq.Enumerable.Select[[System.Char, System.Private.CoreLib],[System.String, System.Private.CoreLib]](System.Collections.Generic.IEnumerable`1<Char>, System.Func`2<Char,System.String>)
       call      qword ptr [7FF912A96E50]; System.Linq.Enumerable.Select[[System.Char, System.Private.CoreLib],[System.__Canon, System.Private.CoreLib]](System.Collections.Generic.IEnumerable`1<Char>, System.Func`2<Char,System.__Canon>)
       mov       rsi,rax
       mov       r8,1CBBA4061B8
       mov       r8,[r8]
       test      r8,r8
       je        near ptr M01_L06
M01_L02:
       mov       rdx,rsi
       mov       rcx,offset MD_System.Linq.Enumerable.Select[[System.String, System.Private.CoreLib],[System.Int32, System.Private.CoreLib]](System.Collections.Generic.IEnumerable`1<System.String>, System.Func`2<System.String,Int32>)
       call      qword ptr [7FF912A96E80]; System.Linq.Enumerable.Select[[System.__Canon, System.Private.CoreLib],[System.Int32, System.Private.CoreLib]](System.Collections.Generic.IEnumerable`1<System.__Canon>, System.Func`2<System.__Canon,Int32>)
       mov       rcx,rax
       lea       rdx,[rsp+20]
       call      qword ptr [7FF912A9E478]; System.Linq.Enumerable.TryGetLast[[System.Int32, System.Private.CoreLib]](System.Collections.Generic.IEnumerable`1<Int32>, Boolean ByRef)
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
       mov       rdx,1CBBA4061C0
       mov       rdx,[rdx]
       mov       rcx,rsi
       mov       r8,7FF912A92DD8
       call      qword ptr [7FF912624210]; System.MulticastDelegate.CtorClosed(System.Object, IntPtr)
       mov       rcx,1CBBA4061C8
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
       mov       r9,7FF9124DD170
       call      qword ptr [7FF912624258]; System.MulticastDelegate.CtorOpened(System.Object, IntPtr, IntPtr)
       mov       rcx,1CBBA4061B8
       mov       rdx,rdi
       call      CORINFO_HELP_ASSIGN_REF
       mov       r8,rdi
       jmp       near ptr M01_L02
M01_L07:
       call      qword ptr [7FF9128B7A68]
       int       3
M01_L08:
       mov       edi,0FFFFFFFF
       jmp       near ptr M01_L03
; Total bytes of code 447
```

## .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
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
       vmovups   ymm1,[7FF912628700]
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
       mov       r9d,[rax+rdx*4+10]
       and       r9d,1
       add       ecx,r9d
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
; Total bytes of code 141
```

## .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
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
       vmovups   ymm1,[7FF912628820]
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
       jl        short M00_L02
       vmovups   ymm1,[7FF912628820]
       vpand     ymm2,ymm1,[rdx+r8*4]
       vpaddd    ymm0,ymm0,ymm2
       vpand     ymm1,ymm1,[rdx+r8*4+20]
       vpaddd    ymm0,ymm0,ymm1
       add       r8,10
M00_L02:
       lea       eax,[r10-8]
       cdqe
       cmp       rax,r8
       jge       short M00_L06
M00_L03:
       vphaddd   ymm0,ymm0,ymm0
       vphaddd   ymm0,ymm0,ymm0
       vextracti128 xmm1,ymm0,1
       vpaddd    xmm0,xmm1,xmm0
       vmovd     edx,xmm0
       mov       eax,r10d
       cmp       rax,r8
       jg        short M00_L05
M00_L04:
       sub       r10d,edx
       movsxd    rax,r10d
       vzeroupper
       add       rsp,28
       ret
M00_L05:
       mov       eax,r10d
       cmp       r8,rax
       jae       short M00_L07
       mov       eax,[rcx+r8*4+10]
       and       eax,1
       add       edx,eax
       inc       r8
       mov       eax,r10d
       cmp       rax,r8
       jg        short M00_L05
       jmp       short M00_L04
M00_L06:
       vmovups   ymm1,[7FF912628820]
       vpand     ymm1,ymm1,[rdx+r8*4]
       vpaddd    ymm0,ymm0,ymm1
       add       r8,8
       jmp       short M00_L03
M00_L07:
       call      CORINFO_HELP_RNGCHKFAIL
       int       3
; Total bytes of code 262
```

