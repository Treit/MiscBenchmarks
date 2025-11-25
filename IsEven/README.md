# Is it even?






```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                               | Count | Mean           | Error       | StdDev      | Median         | Ratio  | RatioSD | Code Size | Gen0     | Allocated | Alloc Ratio |
|------------------------------------- |------ |---------------:|------------:|------------:|---------------:|-------:|--------:|----------:|---------:|----------:|------------:|
| IsEvenUsingMod                       | 10000 |     8,642.4 ns |    99.69 ns |    93.25 ns |     8,626.4 ns |   1.00 |    0.01 |      69 B |        - |         - |          NA |
| IsEvenUsingINumberIsEvenInteger      | 10000 |     8,589.3 ns |    57.00 ns |    44.50 ns |     8,610.3 ns |   0.99 |    0.01 |      69 B |        - |         - |          NA |
| IsEvenlyxerexyl                      | 10000 |    56,964.8 ns | 3,038.22 ns | 8,958.26 ns |    57,557.6 ns |   6.59 |    1.03 |     562 B |        - |         - |          NA |
| IsEvenMrCarrot                       | 10000 |     8,572.6 ns |    64.88 ns |    50.65 ns |     8,603.5 ns |   0.99 |    0.01 |      69 B |        - |         - |          NA |
| IsEvenAaron                          | 10000 |    10,903.3 ns |    61.31 ns |    54.35 ns |    10,924.5 ns |   1.26 |    0.01 |      87 B |        - |         - |          NA |
| IsEvenAaronUnsafeBitConverter        | 10000 |     9,881.6 ns |   345.36 ns |   979.72 ns |     9,610.2 ns |   1.14 |    0.11 |      92 B |        - |         - |          NA |
| IsEvenCrabFuelCursedRecursiveVersion | 10000 |   113,655.7 ns |   354.55 ns |   296.06 ns |   113,752.8 ns |  13.15 |    0.14 |     143 B |        - |         - |          NA |
| IsEvenNotWorthUsingJester            | 10000 | 1,159,039.0 ns | 9,664.59 ns | 8,567.40 ns | 1,160,634.0 ns | 134.13 |    1.69 |   2,349 B | 208.9844 | 3514272 B |          NA |
| IsEvenAkseli                         | 10000 |       431.4 ns |     1.64 ns |     1.37 ns |       431.9 ns |   0.05 |    0.00 |     158 B |        - |         - |          NA |
| IsEvenAkseliV2                       | 10000 |       398.1 ns |     0.98 ns |     0.91 ns |       398.3 ns |   0.05 |    0.00 |     262 B |        - |         - |          NA |
| IsEvenSandra                         | 10000 |       361.8 ns |     1.40 ns |     1.25 ns |       362.2 ns |   0.04 |    0.00 |     312 B |        - |         - |          NA |

## .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.IsEvenUsingMod()
       sub       rsp,28
       mov       rax,[rcx+8]
       mov       rcx,rax
       xor       edx,edx
       xor       r8d,r8d
       cmp       dword ptr [rax+8],0
       jle       short M00_L00
       mov       r10d,[rcx+8]
       jmp       short M00_L03
M00_L00:
       mov       rax,rdx
       add       rsp,28
       ret
M00_L01:
       inc       rdx
M00_L02:
       inc       r8d
       cmp       [rax+8],r8d
       jle       short M00_L00
M00_L03:
       cmp       r8d,r10d
       jae       short M00_L04
       test      byte ptr [rcx+r8*4+10],1
       jne       short M00_L02
       jmp       short M00_L01
M00_L04:
       call      CORINFO_HELP_RNGCHKFAIL
       int       3
; Total bytes of code 69
```

## .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.IsEvenUsingINumberIsEvenInteger()
       sub       rsp,28
       mov       rax,[rcx+8]
       mov       rcx,rax
       xor       edx,edx
       xor       r8d,r8d
       cmp       dword ptr [rax+8],0
       jle       short M00_L00
       mov       r10d,[rcx+8]
       jmp       short M00_L03
M00_L00:
       mov       rax,rdx
       add       rsp,28
       ret
M00_L01:
       inc       rdx
M00_L02:
       inc       r8d
       cmp       [rax+8],r8d
       jle       short M00_L00
M00_L03:
       cmp       r8d,r10d
       jae       short M00_L04
       test      byte ptr [rcx+r8*4+10],1
       jne       short M00_L02
       jmp       short M00_L01
M00_L04:
       call      CORINFO_HELP_RNGCHKFAIL
       int       3
; Total bytes of code 69
```

## .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
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
       jle       short M00_L03
       mov       r14d,[rsi+8]
       jmp       short M00_L02
M00_L00:
       inc       rdi
M00_L01:
       inc       ebp
       mov       rax,[rbx+8]
       cmp       [rax+8],ebp
       jle       short M00_L03
M00_L02:
       cmp       ebp,r14d
       jae       short M00_L04
       mov       ecx,[rsi+rbp*4+10]
       call      qword ptr [7FFAECAB5B00]; Test.Benchmark.<IsEvenlyxerexyl>g__IsEven|8_0(Int32)
       test      eax,eax
       je        short M00_L01
       jmp       short M00_L00
M00_L03:
       mov       rax,rdi
       add       rsp,20
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r14
       ret
M00_L04:
       call      CORINFO_HELP_RNGCHKFAIL
       int       3
; Total bytes of code 91
```
```assembly
; Test.Benchmark.<IsEvenlyxerexyl>g__IsEven|8_0(Int32)
       push      rdi
       push      rsi
       push      rbx
       sub       rsp,30
       xor       eax,eax
       mov       [rsp+28],rax
       mov       ebx,ecx
       test      ebx,ebx
       jl        short M01_L01
       cmp       ebx,12C
       jae       near ptr M01_L12
       mov       rcx,2A3EAC00168
       mov       rcx,[rcx]
       mov       eax,ebx
       mov       rax,[rcx+rax*8+10]
       test      rax,rax
       jne       short M01_L00
       mov       ecx,ebx
       call      qword ptr [7FFAEC607A50]; System.Number.<UInt32ToDecStrForKnownSmallNumber>g__CreateAndCacheString|50_0(UInt32)
M01_L00:
       jmp       near ptr M01_L08
M01_L01:
       call      qword ptr [7FFAEC885D70]; System.Globalization.NumberFormatInfo.get_CurrentInfo()
       mov       rsi,[rax+28]
       mov       edx,ebx
       neg       edx
       mov       ecx,edx
       or        ecx,1
       lzcnt     ecx,ecx
       xor       ecx,1F
       mov       rax,7FFADDA8C100
       add       rdx,[rax+rcx*8]
       sar       rdx,20
       mov       ecx,1
       cmp       edx,1
       cmovg     ecx,edx
       add       ecx,[rsi+8]
       movsxd    rdi,ecx
       mov       rdx,rdi
       mov       rcx,offset MT_System.String
       call      00007FFB4C248D20
       test      rax,rax
       je        short M01_L02
       lea       rcx,[rax+0C]
       mov       [rsp+28],rcx
       mov       rcx,[rsp+28]
       jmp       short M01_L03
M01_L02:
       xor       ecx,ecx
M01_L03:
       lea       rcx,[rcx+rdi*2]
       mov       edx,ebx
       neg       edx
       mov       r8d,1
       cmp       edx,64
       jb        short M01_L05
       jmp       near ptr M01_L10
M01_L04:
       dec       r8d
       mov       r10d,0CCCCCCCD
       mov       r9d,edx
       imul      r10,r9
       shr       r10,23
       lea       r9d,[r10+r10*4]
       add       r9d,r9d
       mov       r11d,edx
       sub       r11d,r9d
       mov       edx,r10d
       add       rcx,0FFFFFFFFFFFFFFFE
       add       r11d,30
       mov       [rcx],r11w
M01_L05:
       test      edx,edx
       jne       short M01_L04
       test      r8d,r8d
       jg        short M01_L04
       mov       edx,[rsi+8]
       dec       edx
       js        short M01_L07
       cmp       [rsi+8],edx
       jle       near ptr M01_L11
M01_L06:
       add       rcx,0FFFFFFFFFFFFFFFE
       mov       r8d,edx
       movzx     r8d,word ptr [rsi+r8*2+0C]
       mov       [rcx],r8w
       dec       edx
       jns       short M01_L06
M01_L07:
       xor       ecx,ecx
       mov       [rsp+28],rcx
M01_L08:
       mov       ecx,[rax+8]
       lea       edx,[rcx-1]
       cmp       edx,ecx
       jae       near ptr M01_L13
       mov       ecx,edx
       movzx     eax,word ptr [rax+rcx*2+0C]
       add       eax,0FFFFFFD0
       cmp       eax,8
       ja        short M01_L09
       mov       ecx,155
       bt        ecx,eax
       jae       short M01_L09
       mov       eax,1
       add       rsp,30
       pop       rbx
       pop       rsi
       pop       rdi
       ret
M01_L09:
       xor       eax,eax
       add       rsp,30
       pop       rbx
       pop       rsi
       pop       rdi
       ret
M01_L10:
       add       rcx,0FFFFFFFFFFFFFFFC
       add       r8d,0FFFFFFFE
       mov       r10d,edx
       imul      r10,51EB851F
       shr       r10,25
       imul      r9d,r10d,64
       sub       edx,r9d
       mov       r9,2A3CA471234
       shl       edx,2
       mov       edx,[r9+rdx]
       mov       [rcx],edx
       cmp       r10d,64
       mov       edx,r10d
       jae       short M01_L10
       jmp       near ptr M01_L05
M01_L11:
       add       rcx,0FFFFFFFFFFFFFFFE
       cmp       edx,[rsi+8]
       jae       short M01_L13
       mov       r8d,edx
       movzx     r8d,word ptr [rsi+r8*2+0C]
       mov       [rcx],r8w
       dec       edx
       jns       short M01_L11
       jmp       near ptr M01_L07
M01_L12:
       mov       ecx,ebx
       call      qword ptr [7FFAEC607A68]; System.Number.UInt32ToDecStr_NoSmallNumberCheck(UInt32)
       jmp       near ptr M01_L00
M01_L13:
       call      CORINFO_HELP_RNGCHKFAIL
       int       3
; Total bytes of code 471
```

## .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.IsEvenMrCarrot()
       sub       rsp,28
       mov       rax,[rcx+8]
       mov       rcx,rax
       xor       edx,edx
       xor       r8d,r8d
       cmp       dword ptr [rax+8],0
       jle       short M00_L00
       mov       r10d,[rcx+8]
       jmp       short M00_L03
M00_L00:
       mov       rax,rdx
       add       rsp,28
       ret
M00_L01:
       inc       rdx
M00_L02:
       inc       r8d
       cmp       [rax+8],r8d
       jle       short M00_L00
M00_L03:
       cmp       r8d,r10d
       jae       short M00_L04
       test      byte ptr [rcx+r8*4+10],1
       jne       short M00_L02
       jmp       short M00_L01
M00_L04:
       call      CORINFO_HELP_RNGCHKFAIL
       int       3
; Total bytes of code 69
```

## .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.IsEvenAaron()
       sub       rsp,28
       mov       rax,[rcx+8]
       mov       rcx,rax
       xor       edx,edx
       xor       r8d,r8d
       cmp       dword ptr [rax+8],0
       jle       short M00_L03
       mov       r10d,[rcx+8]
       jmp       short M00_L02
       nop       dword ptr [rax]
M00_L00:
       inc       rdx
M00_L01:
       inc       r8d
       cmp       [rax+8],r8d
       jle       short M00_L03
M00_L02:
       cmp       r8d,r10d
       jae       short M00_L04
       mov       r9d,[rcx+r8*4+10]
       mov       r11d,1
       andn      r9d,r9d,r11d
       cmp       r9d,1
       jne       short M00_L01
       jmp       short M00_L00
M00_L03:
       mov       rax,rdx
       add       rsp,28
       ret
M00_L04:
       call      CORINFO_HELP_RNGCHKFAIL
       int       3
; Total bytes of code 87
```

## .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.IsEvenAaronUnsafeBitConverter()
       sub       rsp,28
       mov       rax,[rcx+8]
       mov       rcx,rax
       xor       edx,edx
       xor       r8d,r8d
       cmp       dword ptr [rax+8],0
       jle       short M00_L00
       mov       r10d,[rcx+8]
       jmp       short M00_L03
M00_L00:
       mov       rax,rdx
       add       rsp,28
       ret
M00_L01:
       inc       rdx
M00_L02:
       inc       r8d
       cmp       [rax+8],r8d
       jle       short M00_L00
M00_L03:
       cmp       r8d,r10d
       jae       short M00_L04
       mov       r9d,[rcx+r8*4+10]
       mov       [rsp+24],r9d
       mov       r9d,[rsp+24]
       and       r9d,1
       mov       [rsp+24],r9d
       cmp       byte ptr [rsp+24],0
       jne       short M00_L02
       jmp       short M00_L01
M00_L04:
       call      CORINFO_HELP_RNGCHKFAIL
       int       3
; Total bytes of code 92
```

## .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
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
       jmp       short M00_L01
M00_L00:
       inc       ebp
       mov       rax,[rbx+8]
       cmp       [rax+8],ebp
       jle       short M00_L02
M00_L01:
       cmp       ebp,r14d
       jae       short M00_L03
       mov       ecx,[rsi+rbp*4+10]
       cmp       ecx,1
       je        short M00_L00
       dec       ecx
       call      qword ptr [7FFAECAD5AE8]; Test.Benchmark.<IsEvenCrabFuelCursedRecursiveVersion>g__IsEven|12_0(Int32)
       test      eax,eax
       jne       short M00_L00
       inc       rdi
       jmp       short M00_L00
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
; Total bytes of code 98
```
```assembly
; Test.Benchmark.<IsEvenCrabFuelCursedRecursiveVersion>g__IsEven|12_0(Int32)
M01_L00:
       sub       rsp,28
       cmp       ecx,1
       je        short M01_L02
       dec       ecx
       cmp       ecx,1
       je        short M01_L01
       dec       ecx
       call      qword ptr [7FFAECAD5AE8]
       test      eax,eax
       je        short M01_L02
M01_L01:
       mov       eax,1
       add       rsp,28
       ret
M01_L02:
       xor       eax,eax
       add       rsp,28
       ret
; Total bytes of code 45
```

## .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
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
       jle       short M00_L00
       mov       r14d,[rsi+8]
       jmp       short M00_L03
M00_L00:
       mov       rax,rdi
       add       rsp,20
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r14
       ret
M00_L01:
       inc       rdi
M00_L02:
       inc       ebp
       mov       rax,[rbx+8]
       cmp       [rax+8],ebp
       jle       short M00_L00
M00_L03:
       cmp       ebp,r14d
       jae       short M00_L04
       mov       ecx,[rsi+rbp*4+10]
       call      qword ptr [7FFAECAC5B00]; Test.Benchmark.<IsEvenNotWorthUsingJester>g__IsEven|13_0(Int32)
       test      eax,eax
       je        short M00_L02
       jmp       short M00_L01
M00_L04:
       call      CORINFO_HELP_RNGCHKFAIL
       int       3
; Total bytes of code 91
```
```assembly
; Test.Benchmark.<IsEvenNotWorthUsingJester>g__IsEven|13_0(Int32)
       push      rbp
       push      r15
       push      r14
       push      r13
       push      r12
       push      rdi
       push      rsi
       push      rbx
       sub       rsp,58
       lea       rbp,[rsp+90]
       vxorps    xmm4,xmm4,xmm4
       vmovdqu   ymmword ptr [rbp-60],ymm4
       xor       eax,eax
       mov       [rbp-40],rax
       mov       r9,267BB800100
       mov       r9,[r9]
       mov       edx,0FFFFFFFF
       mov       r8,287FF3BA690
       call      qword ptr [7FFAECAC5C08]; System.Number.<FormatInt32>g__FormatInt32Slow|21_0(Int32, Int32, System.String, System.IFormatProvider)
       mov       rbx,rax
       mov       rsi,rbx
       mov       edi,[rsi+8]
       mov       r14d,edi
       neg       r14d
       add       r14d,20
       test      r14d,r14d
       jle       near ptr M01_L21
       mov       rcx,offset MT_System.String
       mov       edx,20
       call      00007FFB4C248D20
       mov       r15,rax
       cmp       [r15],r15b
       lea       rcx,[r15+0C]
       mov       rdx,rcx
       mov       r8d,r14d
       cmp       r8,10
       jb        near ptr M01_L23
       lea       rdx,[r8+r8]
       mov       rax,rdx
       and       rax,0FFFFFFFFFFFFFFC0
       xor       r10d,r10d
       cmp       r8,20
       jae       near ptr M01_L22
M01_L00:
       test      dl,20
       je        short M01_L01
       vbroadcastss ymm0,dword ptr [7FFAEC6C0A78]
       vmovups   [rcx+r10],ymm0
M01_L01:
       vbroadcastss ymm0,dword ptr [7FFAEC6C0A78]
       vmovups   [rcx+rdx-20],ymm0
M01_L02:
       mov       ecx,r14d
       lea       rcx,[r15+rcx*2+0C]
       lea       rdx,[rsi+0C]
       mov       r8d,edi
       add       r8,r8
       call      qword ptr [7FFAEC615818]; System.SpanHelpers.Memmove(Byte ByRef, Byte ByRef, UIntPtr)
M01_L03:
       mov       rcx,267BB801490
       mov       rbx,[rcx]
       test      rbx,rbx
       je        near ptr M01_L28
M01_L04:
       mov       rsi,r15
       mov       rdx,offset MT_System.String
       cmp       [rsi],rdx
       jne       near ptr M01_L29
       xor       esi,esi
M01_L05:
       test      rsi,rsi
       jne       near ptr M01_L30
       mov       rsi,r15
       mov       rdx,offset MT_System.String
       cmp       [rsi],rdx
       jne       near ptr M01_L31
       xor       esi,esi
M01_L06:
       test      rsi,rsi
       jne       near ptr M01_L32
       mov       rcx,offset MT_System.Linq.Enumerable+IEnumerableSelectIterator<System.Char, System.String>
       call      CORINFO_HELP_NEWSFAST
       mov       rdi,rax
       call      CORINFO_HELP_GETCURRENTMANAGEDTHREADID
       mov       [rdi+10],eax
       lea       rcx,[rdi+18]
       mov       rdx,r15
       call      CORINFO_HELP_ASSIGN_REF
       lea       rcx,[rdi+20]
       mov       rdx,rbx
       call      CORINFO_HELP_ASSIGN_REF
M01_L07:
       mov       rcx,267BB801498
       mov       rbx,[rcx]
       test      rbx,rbx
       je        near ptr M01_L36
M01_L08:
       test      rdi,rdi
       je        near ptr M01_L42
       mov       rdx,rdi
       mov       rcx,offset MT_System.Linq.Enumerable+Iterator<System.String>
       call      System.Runtime.CompilerServices.CastHelpers.IsInstanceOfClass(Void*, System.Object)
       mov       rsi,rax
       test      rsi,rsi
       je        near ptr M01_L37
       mov       rcx,rsi
       mov       rdx,offset MT_System.Linq.Enumerable+Iterator<System.String>
       mov       r8,7FFAECAE92C0
       call      qword ptr [7FFAEC615920]; System.Runtime.CompilerServices.VirtualDispatchHelpers.VirtualFunctionPointer(System.Object, IntPtr, IntPtr)
       mov       rcx,rsi
       mov       rdx,rbx
       call      rax
       mov       rsi,rax
M01_L09:
       test      rsi,rsi
       je        near ptr M01_L42
       mov       rbx,rsi
       mov       rdx,offset MT_System.Linq.Enumerable+IEnumerableSelectIterator<System.Char, System.Int32>
       cmp       [rbx],rdx
       jne       near ptr M01_L43
M01_L10:
       test      rbx,rbx
       je        near ptr M01_L44
       mov       rcx,offset MT_System.Linq.Enumerable+IEnumerableSelectIterator<System.Char, System.Int32>
       cmp       [rbx],rcx
       jne       near ptr M01_L55
       mov       rcx,[rbx+18]
       mov       rdx,offset MT_System.String
       cmp       [rcx],rdx
       jne       near ptr M01_L45
       mov       rdx,offset MT_System.CharEnumerator
       mov       [rbp-60],rdx
       mov       dword ptr [rbp-50],0FFFFFFFF
       mov       [rbp-58],rcx
       lea       rcx,[rbp-60]
       mov       [rbp-48],rcx
       mov       ecx,[rbp-50]
       inc       ecx
       mov       rdx,[rbp-58]
       mov       esi,[rdx+8]
       cmp       ecx,esi
       jge       near ptr M01_L15
       mov       [rbp-50],ecx
       mov       dword ptr [rbp-40],1
       mov       ecx,[rbp-50]
       mov       rdx,[rbp-58]
       cmp       [rdx+8],ecx
       jbe       near ptr M01_L16
       movzx     edi,word ptr [rdx+rcx*2+0C]
       mov       ecx,[rbp-50]
       inc       ecx
       mov       rdx,[rbp-58]
       mov       edx,[rdx+8]
       cmp       ecx,edx
       jge       short M01_L12
M01_L11:
       mov       [rbp-50],ecx
       mov       ecx,[rbp-50]
       mov       edx,ecx
       mov       rax,[rbp-58]
       mov       r8,rax
       mov       r10d,[r8+8]
       cmp       r10d,edx
       jbe       short M01_L16
       movzx     edi,word ptr [r8+rdx*2+0C]
       inc       ecx
       mov       edx,[rax+8]
       cmp       ecx,edx
       jl        short M01_L11
M01_L12:
       mov       [rbp-50],edx
       mov       r14,[rbx+20]
       mov       rcx,offset System.Linq.Utilities+<>c__DisplayClass2_0`3[[System.Char, System.Private.CoreLib],[System.__Canon, System.Private.CoreLib],[System.Int32, System.Private.CoreLib]].<CombineSelectors>b__0(Char)
       cmp       [r14+18],rcx
       jne       short M01_L18
       mov       r15,[r14+8]
       mov       r13,[r15+8]
       mov       r12,[r15+10]
       mov       rcx,offset Test.Benchmark+<>c.<IsEvenNotWorthUsingJester>b__13_1(Char)
       cmp       [r12+18],rcx
       jne       short M01_L17
       mov       rcx,offset MT_System.String
       mov       edx,1
       call      00007FFB4C248D20
       mov       rdx,rax
       mov       [rdx+0C],di
M01_L13:
       mov       rcx,[r13+8]
       call      qword ptr [r13+18]
       mov       r12d,eax
M01_L14:
       jmp       short M01_L19
M01_L15:
       mov       [rbp-50],esi
       xor       ecx,ecx
       mov       [rbp-40],ecx
       xor       r12d,r12d
       jmp       short M01_L19
M01_L16:
       mov       ecx,[rbp-50]
       call      qword ptr [7FFAECACCE88]
       int       3
M01_L17:
       mov       edx,edi
       mov       rcx,[r12+8]
       call      qword ptr [r12+18]
       mov       rdx,rax
       jmp       short M01_L13
M01_L18:
       mov       edx,edi
       mov       rcx,[r14+8]
       call      qword ptr [r14+18]
       mov       r12d,eax
       jmp       short M01_L14
M01_L19:
       xor       ecx,ecx
       mov       [rbp-58],rcx
M01_L20:
       cmp       byte ptr [rbp-40],0
       je        near ptr M01_L56
       xor       eax,eax
       test      r12d,r12d
       setle     cl
       movzx     ecx,cl
       test      r12d,r12d
       cmovge    eax,ecx
       vzeroupper
       add       rsp,58
       pop       rbx
       pop       rsi
       pop       rdi
       pop       r12
       pop       r13
       pop       r14
       pop       r15
       pop       rbp
       ret
M01_L21:
       mov       r15,rbx
       jmp       near ptr M01_L03
M01_L22:
       vbroadcastss ymm0,dword ptr [7FFAEC6C0A78]
       vmovups   [rcx+r10],ymm0
       vmovups   [rcx+r10+20],ymm0
       add       r10,40
       cmp       r10,rax
       jb        short M01_L22
       jmp       near ptr M01_L00
M01_L23:
       xor       ecx,ecx
       cmp       r8,8
       jb        short M01_L25
       mov       rax,r8
       and       rax,0FFFFFFFFFFFFFFF8
M01_L24:
       mov       word ptr [rdx+rcx*2],30
       mov       word ptr [rdx+rcx*2+2],30
       mov       word ptr [rdx+rcx*2+4],30
       mov       word ptr [rdx+rcx*2+6],30
       mov       word ptr [rdx+rcx*2+8],30
       mov       word ptr [rdx+rcx*2+0A],30
       mov       word ptr [rdx+rcx*2+0C],30
       mov       word ptr [rdx+rcx*2+0E],30
       add       rcx,8
       cmp       rcx,rax
       jb        short M01_L24
M01_L25:
       test      r8b,4
       je        short M01_L26
       mov       word ptr [rdx+rcx*2],30
       mov       word ptr [rdx+rcx*2+2],30
       mov       word ptr [rdx+rcx*2+4],30
       mov       word ptr [rdx+rcx*2+6],30
       add       rcx,4
M01_L26:
       test      r8b,2
       je        short M01_L27
       mov       word ptr [rdx+rcx*2],30
       mov       word ptr [rdx+rcx*2+2],30
       add       rcx,2
M01_L27:
       test      r8b,1
       je        near ptr M01_L02
       mov       word ptr [rdx+rcx*2],30
       jmp       near ptr M01_L02
M01_L28:
       mov       rcx,offset MT_System.Func<System.Char, System.String>
       call      CORINFO_HELP_NEWSFAST
       mov       rbx,rax
       mov       rdx,267BB801488
       mov       rdx,[rdx]
       mov       rcx,rbx
       mov       r8,offset Test.Benchmark+<>c.<IsEvenNotWorthUsingJester>b__13_1(Char)
       call      qword ptr [7FFAEC616BB0]; System.MulticastDelegate.CtorClosed(System.Object, IntPtr)
       mov       rcx,267BB801490
       mov       rdx,rbx
       call      CORINFO_HELP_ASSIGN_REF
       jmp       near ptr M01_L04
M01_L29:
       mov       rdx,r15
       mov       rcx,offset MT_System.Linq.Enumerable+Iterator<System.Char>
       call      System.Runtime.CompilerServices.CastHelpers.IsInstanceOfClass(Void*, System.Object)
       mov       rsi,rax
       jmp       near ptr M01_L05
M01_L30:
       mov       rcx,rsi
       mov       rdx,offset MT_System.Linq.Enumerable+Iterator<System.Char>
       mov       r8,7FFAECB8C878
       call      qword ptr [7FFAEC615920]; System.Runtime.CompilerServices.VirtualDispatchHelpers.VirtualFunctionPointer(System.Object, IntPtr, IntPtr)
       mov       rcx,rsi
       mov       rdx,rbx
       call      rax
       mov       rdi,rax
       jmp       near ptr M01_L07
M01_L31:
       mov       rdx,r15
       mov       rcx,offset MT_System.Collections.Generic.IList<System.Char>
       call      System.Runtime.CompilerServices.CastHelpers.IsInstanceOfInterface(Void*, System.Object)
       mov       rsi,rax
       jmp       near ptr M01_L06
M01_L32:
       mov       rdx,r15
       mov       rcx,offset MT_System.Char[]
       call      System.Runtime.CompilerServices.CastHelpers.IsInstanceOfAny(Void*, System.Object)
       mov       r14,rax
       test      r14,r14
       je        short M01_L34
       cmp       dword ptr [r14+8],0
       jne       short M01_L33
       mov       rcx,offset MT_System.Array+EmptyArray<System.String>
       call      System.Runtime.CompilerServices.StaticsHelpers.GetGCStaticBase(System.Runtime.CompilerServices.MethodTable*)
       mov       rcx,267BB8014C0
       mov       rdi,[rcx]
       jmp       near ptr M01_L07
M01_L33:
       mov       rcx,offset MT_System.Linq.Enumerable+ArraySelectIterator<System.Char, System.String>
       call      CORINFO_HELP_NEWSFAST
       mov       rdi,rax
       mov       rcx,rdi
       mov       rdx,r14
       mov       r8,rbx
       call      qword ptr [7FFAECAC6E68]
       jmp       near ptr M01_L07
M01_L34:
       mov       rdx,r15
       mov       rcx,offset MT_System.Collections.Generic.List<System.Char>
       call      System.Runtime.CompilerServices.CastHelpers.IsInstanceOfClass(Void*, System.Object)
       mov       rdi,rax
       test      rdi,rdi
       je        short M01_L35
       mov       rcx,offset MT_System.Linq.Enumerable+ListSelectIterator<System.Char, System.String>
       call      CORINFO_HELP_NEWSFAST
       mov       rsi,rax
       mov       rcx,rsi
       mov       rdx,rdi
       mov       r8,rbx
       call      qword ptr [7FFAECAC6E80]
       mov       rdi,rsi
       jmp       near ptr M01_L07
M01_L35:
       mov       rcx,offset MT_System.Linq.Enumerable+IListSelectIterator<System.Char, System.String>
       call      CORINFO_HELP_NEWSFAST
       mov       rdi,rax
       mov       rcx,rdi
       mov       rdx,rsi
       mov       r8,rbx
       call      qword ptr [7FFAECAC6E98]
       jmp       near ptr M01_L07
M01_L36:
       mov       rcx,offset MT_System.Func<System.String, System.Int32>
       call      CORINFO_HELP_NEWSFAST
       mov       rbx,rax
       mov       rcx,rbx
       xor       edx,edx
       mov       r8,offset System.Int32.Parse(System.String)
       mov       r9,7FFAEC55D1A0
       call      qword ptr [7FFAEC616EB0]; System.MulticastDelegate.CtorOpened(System.Object, IntPtr, IntPtr)
       mov       rcx,267BB801498
       mov       rdx,rbx
       call      CORINFO_HELP_ASSIGN_REF
       jmp       near ptr M01_L08
M01_L37:
       mov       rdx,rdi
       mov       rcx,offset MT_System.Collections.Generic.IList<System.String>
       call      System.Runtime.CompilerServices.CastHelpers.IsInstanceOfInterface(Void*, System.Object)
       mov       r14,rax
       test      r14,r14
       je        near ptr M01_L41
       mov       rdx,rdi
       mov       rcx,offset MT_System.String[]
       call      System.Runtime.CompilerServices.CastHelpers.IsInstanceOfAny(Void*, System.Object)
       mov       r15,rax
       test      r15,r15
       je        short M01_L39
       cmp       dword ptr [r15+8],0
       jne       short M01_L38
       mov       rcx,offset MT_System.Array+EmptyArray<System.Int32>
       call      System.Runtime.CompilerServices.StaticsHelpers.GetGCStaticBase(System.Runtime.CompilerServices.MethodTable*)
       mov       rcx,267BB8014A0
       mov       rsi,[rcx]
       jmp       near ptr M01_L09
M01_L38:
       mov       rcx,offset MT_System.Linq.Enumerable+ArraySelectIterator<System.String, System.Int32>
       call      CORINFO_HELP_NEWSFAST
       mov       rsi,rax
       mov       rcx,rsi
       mov       rdx,r15
       mov       r8,rbx
       call      qword ptr [7FFAECACE088]
       jmp       near ptr M01_L09
M01_L39:
       mov       rdx,rdi
       mov       rcx,offset MT_System.Collections.Generic.List<System.String>
       call      System.Runtime.CompilerServices.CastHelpers.IsInstanceOfClass(Void*, System.Object)
       mov       rsi,rax
       test      rsi,rsi
       je        short M01_L40
       mov       rcx,offset MT_System.Linq.Enumerable+ListSelectIterator<System.String, System.Int32>
       call      CORINFO_HELP_NEWSFAST
       mov       r14,rax
       mov       rcx,r14
       mov       rdx,rsi
       mov       r8,rbx
       call      qword ptr [7FFAECACE0A0]
       mov       rsi,r14
       jmp       near ptr M01_L09
M01_L40:
       mov       rcx,offset MT_System.Linq.Enumerable+IListSelectIterator<System.String, System.Int32>
       call      CORINFO_HELP_NEWSFAST
       mov       rsi,rax
       mov       rcx,rsi
       mov       rdx,r14
       mov       r8,rbx
       call      qword ptr [7FFAECACE0B8]
       jmp       near ptr M01_L09
M01_L41:
       mov       rcx,offset MT_System.Linq.Enumerable+IEnumerableSelectIterator<System.String, System.Int32>
       call      CORINFO_HELP_NEWSFAST
       mov       rsi,rax
       mov       rcx,rsi
       mov       rdx,rdi
       mov       r8,rbx
       call      qword ptr [7FFAECACE0D0]
       jmp       near ptr M01_L09
M01_L42:
       mov       ecx,11
       call      qword ptr [7FFAEC897DF8]
       int       3
M01_L43:
       mov       rdx,rsi
       mov       rcx,offset MT_System.Linq.Enumerable+Iterator<System.Int32>
       call      System.Runtime.CompilerServices.CastHelpers.IsInstanceOfClass(Void*, System.Object)
       mov       rbx,rax
       jmp       near ptr M01_L10
M01_L44:
       lea       rdx,[rbp-40]
       mov       rcx,rsi
       call      qword ptr [7FFAECACD608]
       mov       r12d,eax
       jmp       near ptr M01_L20
M01_L45:
       mov       r11,7FFAEC560560
       call      qword ptr [r11]
       mov       r14,rax
       mov       [rbp-68],r14
       mov       rcx,[r14]
       mov       rcx,r14
       mov       r11,7FFAEC560568
       call      qword ptr [r11]
       test      eax,eax
       je        near ptr M01_L52
       mov       dword ptr [rbp-40],1
       mov       rcx,r14
       mov       r11,7FFAEC560570
       call      qword ptr [r11]
       mov       edi,eax
       jmp       short M01_L47
M01_L46:
       mov       rcx,[rbp-68]
       mov       r11,7FFAEC560580
       call      qword ptr [r11]
       mov       edi,eax
M01_L47:
       mov       rcx,[rbp-68]
       mov       r11,[rcx]
       mov       r11,7FFAEC560578
       call      qword ptr [r11]
       test      eax,eax
       jne       short M01_L46
       mov       r14,[rbx+20]
       mov       rcx,offset System.Linq.Utilities+<>c__DisplayClass2_0`3[[System.Char, System.Private.CoreLib],[System.__Canon, System.Private.CoreLib],[System.Int32, System.Private.CoreLib]].<CombineSelectors>b__0(Char)
       cmp       [r14+18],rcx
       jne       short M01_L50
       mov       r15,[r14+8]
       mov       r13,[r15+8]
       mov       r12,[r15+10]
       mov       rcx,offset Test.Benchmark+<>c.<IsEvenNotWorthUsingJester>b__13_1(Char)
       cmp       [r12+18],rcx
       jne       short M01_L48
       mov       rcx,offset MT_System.String
       mov       edx,1
       call      00007FFB4C248D20
       mov       rdx,rax
       mov       [rdx+0C],di
       jmp       short M01_L49
M01_L48:
       mov       edx,edi
       mov       rcx,[r12+8]
       call      qword ptr [r12+18]
       mov       rdx,rax
M01_L49:
       mov       rcx,[r13+8]
       call      qword ptr [r13+18]
       mov       r12d,eax
       jmp       short M01_L51
M01_L50:
       mov       edx,edi
       mov       rcx,[r14+8]
       call      qword ptr [r14+18]
       mov       r12d,eax
M01_L51:
       jmp       short M01_L54
M01_L52:
       xor       ecx,ecx
       mov       [rbp-40],ecx
       xor       r12d,r12d
       jmp       short M01_L54
M01_L53:
       mov       rcx,[rbp-68]
       mov       r11,7FFAEC560588
       call      qword ptr [r11]
       jmp       near ptr M01_L20
M01_L54:
       cmp       qword ptr [rbp-68],0
       je        near ptr M01_L20
       jmp       short M01_L53
M01_L55:
       lea       rdx,[rbp-40]
       mov       rcx,rbx
       mov       rax,[rbx]
       mov       rax,[rax+50]
       call      qword ptr [rax+28]
       mov       r12d,eax
       jmp       near ptr M01_L20
M01_L56:
       call      qword ptr [7FFAEC9EFAF8]
       int       3
       sub       rsp,28
       cmp       qword ptr [rbp-68],0
       je        short M01_L57
       mov       rcx,[rbp-68]
       mov       r11,7FFAEC560588
       call      qword ptr [r11]
M01_L57:
       nop
       vzeroupper
       add       rsp,28
       ret
       sub       rsp,28
       cmp       qword ptr [rbp-48],0
       je        short M01_L58
       xor       ecx,ecx
       mov       [rbp-58],rcx
M01_L58:
       vzeroupper
       add       rsp,28
       ret
; Total bytes of code 2258
```

## .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.IsEvenAkseli()
       sub       rsp,28
       mov       rax,[rcx+8]
       lea       rcx,[rax+10]
       xor       edx,edx
       vxorps    ymm0,ymm0,ymm0
       mov       r8d,[rax+8]
       lea       r10d,[r8-8]
       movsxd    r10,r10d
       test      r10,r10
       jl        short M00_L01
       vbroadcastss ymm1,dword ptr [7FFAEC699EC0]
M00_L00:
       vpand     ymm2,ymm1,[rcx+rdx*4]
       vpaddd    ymm0,ymm2,ymm0
       add       rdx,8
       cmp       r10,rdx
       jge       short M00_L00
M00_L01:
       vmovaps   ymm1,ymm0
       vextracti128 xmm0,ymm0,1
       vpaddd    xmm0,xmm0,xmm1
       vpsrldq   xmm1,xmm0,8
       vpaddd    xmm0,xmm1,xmm0
       vpsrldq   xmm1,xmm0,4
       vpaddd    xmm0,xmm1,xmm0
       vmovd     ecx,xmm0
       mov       r10d,r8d
       cmp       r10,rdx
       jg        short M00_L03
M00_L02:
       sub       r8d,ecx
       movsxd    rax,r8d
       vzeroupper
       add       rsp,28
       ret
M00_L03:
       mov       r10d,r8d
       cmp       rdx,r10
       jae       short M00_L04
       mov       r10d,[rax+rdx*4+10]
       and       r10d,1
       add       ecx,r10d
       inc       rdx
       mov       r10d,r8d
       cmp       r10,rdx
       jg        short M00_L03
       jmp       short M00_L02
M00_L04:
       call      CORINFO_HELP_RNGCHKFAIL
       int       3
; Total bytes of code 158
```

## .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.IsEvenAkseliV2()
       sub       rsp,28
       mov       rax,[rcx+8]
       lea       rcx,[rax+10]
       xor       edx,edx
       vxorps    ymm0,ymm0,ymm0
       mov       r8d,[rax+8]
       lea       r10d,[r8-20]
       movsxd    r10,r10d
       test      r10,r10
       jl        short M00_L01
       vbroadcastss ymm1,dword ptr [7FFAEC699FA8]
M00_L00:
       vpand     ymm2,ymm1,[rcx+rdx*4]
       vpaddd    ymm0,ymm2,ymm0
       vpand     ymm2,ymm1,[rcx+rdx*4+20]
       vpaddd    ymm0,ymm2,ymm0
       vpand     ymm2,ymm1,[rcx+rdx*4+40]
       vpaddd    ymm0,ymm2,ymm0
       vpand     ymm2,ymm1,[rcx+rdx*4+60]
       vpaddd    ymm0,ymm2,ymm0
       add       rdx,20
       cmp       r10,rdx
       jge       short M00_L00
M00_L01:
       lea       r10d,[r8-10]
       movsxd    r10,r10d
       cmp       r10,rdx
       jl        short M00_L02
       vbroadcastss ymm1,dword ptr [7FFAEC699FA8]
       vpand     ymm2,ymm1,[rcx+rdx*4]
       vpaddd    ymm0,ymm2,ymm0
       vpand     ymm1,ymm1,[rcx+rdx*4+20]
       vpaddd    ymm0,ymm1,ymm0
       add       rdx,10
M00_L02:
       lea       r10d,[r8-8]
       movsxd    r10,r10d
       cmp       r10,rdx
       jge       short M00_L05
M00_L03:
       vmovaps   ymm1,ymm0
       vextracti128 xmm0,ymm0,1
       vpaddd    xmm0,xmm0,xmm1
       vpsrldq   xmm1,xmm0,8
       vpaddd    xmm0,xmm1,xmm0
       vpsrldq   xmm1,xmm0,4
       vpaddd    xmm0,xmm1,xmm0
       vmovd     ecx,xmm0
       mov       r10d,r8d
       cmp       r10,rdx
       jg        short M00_L06
M00_L04:
       sub       r8d,ecx
       movsxd    rax,r8d
       vzeroupper
       add       rsp,28
       ret
M00_L05:
       vbroadcastss ymm1,dword ptr [7FFAEC699FA8]
       vpand     ymm1,ymm1,[rcx+rdx*4]
       vpaddd    ymm0,ymm1,ymm0
       add       rdx,8
       jmp       short M00_L03
M00_L06:
       cmp       rdx,r10
       jae       short M00_L07
       mov       r9d,[rax+rdx*4+10]
       and       r9d,1
       add       ecx,r9d
       inc       rdx
       cmp       r10,rdx
       jg        short M00_L06
       jmp       short M00_L04
M00_L07:
       call      CORINFO_HELP_RNGCHKFAIL
       int       3
; Total bytes of code 262
```

## .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.IsEvenSandra()
       sub       rsp,38
       vmovaps   [rsp+20],xmm6
       vmovaps   [rsp+10],xmm7
       vmovaps   [rsp],xmm8
       mov       rax,[rcx+8]
       lea       rcx,[rax+10]
       vxorps    ymm0,ymm0,ymm0
       vxorps    ymm1,ymm1,ymm1
       vxorps    ymm2,ymm2,ymm2
       vxorps    ymm3,ymm3,ymm3
       vbroadcastss ymm4,dword ptr [7FFAEC6CA2E0]
       mov       eax,[rax+8]
       mov       edx,eax
       xor       r8d,r8d
       lea       r10,[rdx-40]
       cmp       r8,r10
       jae       short M00_L01
M00_L00:
       vpand     ymm5,ymm4,[rcx+r8*4]
       vpand     ymm6,ymm4,[rcx+r8*4+20]
       vpaddd    ymm0,ymm0,ymm5
       vpaddd    ymm1,ymm1,ymm6
       vpand     ymm7,ymm4,[rcx+r8*4+40]
       vpand     ymm8,ymm4,[rcx+r8*4+60]
       vpaddd    ymm2,ymm2,ymm7
       vpaddd    ymm3,ymm3,ymm8
       vpand     ymm5,ymm4,[rcx+r8*4+80]
       vpand     ymm6,ymm4,[rcx+r8*4+0A0]
       vpaddd    ymm0,ymm0,ymm5
       vpaddd    ymm1,ymm1,ymm6
       vpand     ymm7,ymm4,[rcx+r8*4+0C0]
       vpand     ymm8,ymm4,[rcx+r8*4+0E0]
       vpaddd    ymm2,ymm2,ymm7
       vpaddd    ymm3,ymm3,ymm8
       add       r8,40
       cmp       r8,r10
       jb        short M00_L00
M00_L01:
       lea       r10,[rdx-8]
       cmp       r8,r10
       jae       short M00_L03
M00_L02:
       vpand     ymm5,ymm4,[rcx+r8*4]
       vpaddd    ymm0,ymm5,ymm0
       add       r8,8
       cmp       r8,r10
       jb        short M00_L02
M00_L03:
       vpaddd    ymm0,ymm0,ymm1
       vpaddd    ymm0,ymm0,ymm2
       vpaddd    ymm0,ymm0,ymm3
       vmovaps   ymm1,ymm0
       vextracti128 xmm0,ymm0,1
       vpaddd    xmm0,xmm0,xmm1
       vpsrldq   xmm1,xmm0,8
       vpaddd    xmm0,xmm1,xmm0
       vpsrldq   xmm1,xmm0,4
       vpaddd    xmm0,xmm1,xmm0
       vmovd     r10d,xmm0
       cmp       r8,rdx
       jae       short M00_L05
M00_L04:
       mov       r9d,[rcx+r8*4]
       and       r9d,1
       add       r10d,r9d
       inc       r8
       cmp       r8,rdx
       jb        short M00_L04
M00_L05:
       sub       eax,r10d
       cdqe
       vzeroupper
       vmovaps   xmm6,[rsp+20]
       vmovaps   xmm7,[rsp+10]
       vmovaps   xmm8,[rsp]
       add       rsp,38
       ret
; Total bytes of code 312
```

