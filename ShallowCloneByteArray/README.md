# Shallow copy an array of bytes.

```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26074.1)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.200
  [Host]     : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method             | Count  | Mean         | Error        | StdDev       | Median       | Ratio | RatioSD | Code Size |
|------------------- |------- |-------------:|-------------:|-------------:|-------------:|------:|--------:|----------:|
| **CloneWithToArray**   | **10**     |     **37.45 ns** |     **1.044 ns** |     **3.028 ns** |     **36.31 ns** |  **1.00** |    **0.00** |     **268 B** |
| CloneWithArrayCopy | 10     |     12.91 ns |     0.326 ns |     0.694 ns |     12.76 ns |  0.35 |    0.03 |     263 B |
| CloneWithOther     | 10     |     14.56 ns |     0.361 ns |     0.791 ns |     14.37 ns |  0.40 |    0.03 |     715 B |
|                    |        |              |              |              |              |       |         |           |
| **CloneWithToArray**   | **100000** | **66,454.30 ns** | **1,304.861 ns** | **1,829.233 ns** | **66,187.90 ns** |  **1.00** |    **0.00** |     **268 B** |
| CloneWithArrayCopy | 100000 | 66,109.75 ns | 1,206.685 ns | 1,128.734 ns | 65,902.05 ns |  0.99 |    0.03 |     263 B |
| CloneWithOther     | 100000 | 66,596.13 ns | 1,245.624 ns | 2,339.584 ns | 66,350.36 ns |  0.99 |    0.04 |     715 B |

## .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
```assembly
; Test.Benchmark.CloneWithToArray()
       mov       rcx,[rcx+8]
       jmp       qword ptr [7FF9B4B36C28]; System.Linq.Enumerable.ToArray[[System.Byte, System.Private.CoreLib]](System.Collections.Generic.IEnumerable`1<Byte>)
; Total bytes of code 10
```
```assembly
; System.Linq.Enumerable.ToArray[[System.Byte, System.Private.CoreLib]](System.Collections.Generic.IEnumerable`1<Byte>)
       push      rdi
       push      rsi
       push      rbx
       sub       rsp,50
       vxorps    xmm4,xmm4,xmm4
       vmovdqa   xmmword ptr [rsp+20],xmm4
       vmovdqa   xmmword ptr [rsp+30],xmm4
       vmovdqa   xmmword ptr [rsp+40],xmm4
       mov       rbx,rcx
       test      rbx,rbx
       je        near ptr M01_L02
       mov       rdx,rbx
       mov       rcx,offset MT_System.Linq.IIListProvider`1[[System.Byte, System.Private.CoreLib]]
       call      qword ptr [7FF9B46C4348]; System.Runtime.CompilerServices.CastHelpers.IsInstanceOfInterface(Void*, System.Object)
       test      rax,rax
       jne       short M01_L01
       mov       rdx,rbx
       mov       rcx,offset MT_System.Collections.Generic.ICollection`1[[System.Byte, System.Private.CoreLib]]
       call      qword ptr [7FF9B46C4348]; System.Runtime.CompilerServices.CastHelpers.IsInstanceOfInterface(Void*, System.Object)
       mov       rsi,rax
       test      rsi,rsi
       je        short M01_L04
       mov       rcx,rsi
       mov       r11,7FF9B4580500
       call      qword ptr [r11]
       test      eax,eax
       je        short M01_L03
       movsxd    rdx,eax
       mov       rcx,offset MT_System.Byte[]
       call      CORINFO_HELP_NEWARR_1_VC
       mov       rdi,rax
       mov       rcx,rsi
       mov       rdx,rdi
       mov       r11,7FF9B4580508
       xor       r8d,r8d
       call      qword ptr [r11]
       mov       rax,rdi
M01_L00:
       add       rsp,50
       pop       rbx
       pop       rsi
       pop       rdi
       ret
M01_L01:
       mov       rcx,rax
       mov       r11,7FF9B45804F8
       call      qword ptr [r11]
       nop
       add       rsp,50
       pop       rbx
       pop       rsi
       pop       rdi
       ret
M01_L02:
       mov       ecx,10
       call      qword ptr [7FF9B4957A08]
       int       3
M01_L03:
       mov       rax,1EE003067B8
       jmp       short M01_L00
M01_L04:
       lea       rcx,[rsp+20]
       mov       edx,7FFFFFFF
       call      qword ptr [7FF9B4B36FD0]
       lea       rcx,[rsp+20]
       mov       rdx,rbx
       call      qword ptr [7FF9B4B37030]
       lea       rcx,[rsp+20]
       call      qword ptr [7FF9B4B370C0]
       jmp       short M01_L00
; Total bytes of code 258
```

## .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
```assembly
; Test.Benchmark.CloneWithArrayCopy()
       push      rsi
       push      rbx
       sub       rsp,28
       mov       rbx,[rcx+8]
       mov       edx,[rbx+8]
       mov       rcx,offset MT_System.Byte[]
       call      CORINFO_HELP_NEWARR_1_VC
       mov       rsi,rax
       mov       r8d,[rbx+8]
       mov       rcx,rbx
       mov       rdx,rsi
       call      qword ptr [7FF9B4607738]; System.Array.Copy(System.Array, System.Array, Int32)
       mov       rax,rsi
       add       rsp,28
       pop       rbx
       pop       rsi
       ret
; Total bytes of code 57
```
```assembly
; System.Array.Copy(System.Array, System.Array, Int32)
       push      rdi
       push      rsi
       push      rbp
       push      rbx
       sub       rsp,38
       mov       rbx,rcx
       mov       rsi,rdx
       mov       edi,r8d
       test      rbx,rbx
       je        near ptr M01_L01
       test      rsi,rsi
       je        near ptr M01_L02
       mov       rcx,[rbx]
       cmp       rcx,[rsi]
       jne       short M01_L00
       cmp       dword ptr [rcx+4],18
       ja        short M01_L00
       cmp       edi,[rbx+8]
       ja        short M01_L00
       cmp       edi,[rsi+8]
       ja        short M01_L00
       mov       r8d,edi
       movzx     edx,word ptr [rcx]
       imul      r8,rdx
       lea       rdx,[rbx+10]
       add       rsi,10
       test      dword ptr [rcx],1000000
       jne       short M01_L03
       mov       rcx,rsi
       call      qword ptr [7FF9B4765B78]; System.Buffer.Memmove(Byte ByRef, Byte ByRef, UIntPtr)
       nop
       add       rsp,38
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       ret
M01_L00:
       mov       rcx,rbx
       xor       edx,edx
       call      qword ptr [7FF9B46075D0]; System.Array.GetLowerBound(Int32)
       mov       ebp,eax
       mov       rcx,rsi
       xor       edx,edx
       call      qword ptr [7FF9B46075D0]; System.Array.GetLowerBound(Int32)
       mov       r9d,eax
       mov       [rsp+20],edi
       xor       edx,edx
       mov       [rsp+28],edx
       mov       edx,ebp
       mov       r8,rsi
       mov       rcx,rbx
       call      qword ptr [7FF9B4607450]; System.Array.CopyImpl(System.Array, Int32, System.Array, Int32, Int32, Boolean)
       nop
       add       rsp,38
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       ret
M01_L01:
       mov       ecx,41
       call      qword ptr [7FF9B4945AE8]
       int       3
M01_L02:
       mov       ecx,43
       call      qword ptr [7FF9B4945AE8]
       int       3
M01_L03:
       mov       rcx,rsi
       add       rsp,38
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       jmp       qword ptr [7FF9B4765BC0]
; Total bytes of code 206
```

## .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
```assembly
; Test.Benchmark.CloneWithOther()
       push      rsi
       push      rbx
       sub       rsp,28
       mov       rbx,[rcx+8]
       mov       edx,[rbx+8]
       mov       rcx,offset MT_System.Byte[]
       call      CORINFO_HELP_NEWARR_1_VC
       mov       rsi,rax
       mov       ecx,[rbx+8]
       mov       [rsp+20],ecx
       mov       rcx,rbx
       mov       r8,rsi
       xor       edx,edx
       xor       r9d,r9d
       call      qword ptr [7FF9B4755AE8]; System.Buffer.BlockCopy(System.Array, Int32, System.Array, Int32, Int32)
       mov       rax,rsi
       add       rsp,28
       pop       rbx
       pop       rsi
       ret
; Total bytes of code 65
```
```assembly
; System.Buffer.BlockCopy(System.Array, Int32, System.Array, Int32, Int32)
       push      r15
       push      r14
       push      r13
       push      r12
       push      rdi
       push      rsi
       push      rbp
       push      rbx
       sub       rsp,28
       mov       rsi,rcx
       mov       edi,edx
       mov       rbx,r8
       mov       ebp,r9d
       mov       r14d,[rsp+90]
       test      rsi,rsi
       je        near ptr M01_L03
       test      rbx,rbx
       je        near ptr M01_L04
       mov       r15d,[rsi+8]
       mov       r13,offset MT_System.Byte[]
       cmp       [rsi],r13
       jne       near ptr M01_L05
M01_L00:
       mov       r12,r15
       cmp       rsi,rbx
       je        short M01_L01
       mov       r12d,[rbx+8]
       cmp       [rbx],r13
       jne       near ptr M01_L07
M01_L01:
       test      edi,edi
       jl        near ptr M01_L09
M01_L02:
       test      ebp,ebp
       jl        near ptr M01_L10
       test      r14d,r14d
       jl        near ptr M01_L11
       movsxd    r8,r14d
       movsxd    rdx,edi
       movsxd    rcx,ebp
       lea       rax,[rdx+r8]
       cmp       rax,r15
       ja        near ptr M01_L12
       lea       rax,[rcx+r8]
       cmp       rax,r12
       ja        near ptr M01_L12
       lea       rax,[rbx+8]
       mov       r10,[rbx]
       mov       r10d,[r10+4]
       add       r10,0FFFFFFFFFFFFFFF0
       add       rax,r10
       add       rcx,rax
       lea       rax,[rsi+8]
       mov       r10,[rsi]
       mov       r10d,[r10+4]
       add       r10,0FFFFFFFFFFFFFFF0
       add       r10,rax
       add       rdx,r10
       call      qword ptr [7FF9B4755B78]; System.Buffer.Memmove(Byte ByRef, Byte ByRef, UIntPtr)
       nop
       add       rsp,28
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r12
       pop       r13
       pop       r14
       pop       r15
       ret
M01_L03:
       mov       ecx,18F
       mov       rdx,7FF9B4554000
       call      CORINFO_HELP_STRCNS
       mov       rcx,rax
       call      qword ptr [7FF9B47C6790]
       int       3
M01_L04:
       mov       ecx,197
       mov       rdx,7FF9B4554000
       call      CORINFO_HELP_STRCNS
       mov       rcx,rax
       call      qword ptr [7FF9B47C6790]
       int       3
M01_L05:
       mov       rcx,rsi
       call      System.Array.GetCorElementTypeOfElementType()
       mov       ecx,1
       shlx      ecx,ecx,eax
       test      ecx,3003FFC
       jne       short M01_L06
       mov       rcx,offset MT_System.ArgumentException
       call      CORINFO_HELP_NEWSFAST
       mov       rsi,rax
       call      qword ptr [7FF9B4B1D9F8]
       mov       r15,rax
       mov       ecx,18F
       mov       rdx,7FF9B4554000
       call      CORINFO_HELP_STRCNS
       mov       r8,rax
       mov       rdx,r15
       mov       rcx,rsi
       call      qword ptr [7FF9B46AF750]
       mov       rcx,rsi
       call      CORINFO_HELP_THROW
M01_L06:
       mov       rcx,[rsi]
       movzx     ecx,word ptr [rcx]
       imul      r15,rcx
       jmp       near ptr M01_L00
M01_L07:
       mov       rcx,rbx
       call      System.Array.GetCorElementTypeOfElementType()
       mov       ecx,1
       shlx      ecx,ecx,eax
       test      ecx,3003FFC
       jne       short M01_L08
       mov       rcx,offset MT_System.ArgumentException
       call      CORINFO_HELP_NEWSFAST
       mov       rbx,rax
       call      qword ptr [7FF9B4B1D9F8]
       mov       r12,rax
       mov       ecx,197
       mov       rdx,7FF9B4554000
       call      CORINFO_HELP_STRCNS
       mov       r8,rax
       mov       rdx,r12
       mov       rcx,rbx
       call      qword ptr [7FF9B46AF750]
       mov       rcx,rbx
       call      CORINFO_HELP_THROW
M01_L08:
       mov       rcx,[rbx]
       movzx     ecx,word ptr [rcx]
       imul      r12,rcx
       test      edi,edi
       jge       near ptr M01_L02
M01_L09:
       mov       ecx,19F
       mov       rdx,7FF9B4554000
       call      CORINFO_HELP_STRCNS
       mov       rdx,rax
       mov       ecx,edi
       call      qword ptr [7FF9B4B47B58]
       int       3
M01_L10:
       mov       ecx,1B3
       mov       rdx,7FF9B4554000
       call      CORINFO_HELP_STRCNS
       mov       rdx,rax
       mov       ecx,ebp
       call      qword ptr [7FF9B4B47B58]
       int       3
M01_L11:
       mov       ecx,1C7
       mov       rdx,7FF9B4554000
       call      CORINFO_HELP_STRCNS
       mov       rdx,rax
       mov       ecx,r14d
       call      qword ptr [7FF9B4B47B58]
       int       3
M01_L12:
       mov       rcx,offset MT_System.ArgumentException
       call      CORINFO_HELP_NEWSFAST
       mov       rbx,rax
       call      qword ptr [7FF9B4B1EE20]
       mov       rdx,rax
       mov       rcx,rbx
       call      qword ptr [7FF9B46AF708]
       mov       rcx,rbx
       call      CORINFO_HELP_THROW
       int       3
; Total bytes of code 650
```

## .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
```assembly
; Test.Benchmark.CloneWithToArray()
       mov       rcx,[rcx+8]
       jmp       qword ptr [7FF9B4B26C28]; System.Linq.Enumerable.ToArray[[System.Byte, System.Private.CoreLib]](System.Collections.Generic.IEnumerable`1<Byte>)
; Total bytes of code 10
```
```assembly
; System.Linq.Enumerable.ToArray[[System.Byte, System.Private.CoreLib]](System.Collections.Generic.IEnumerable`1<Byte>)
       push      rdi
       push      rsi
       push      rbx
       sub       rsp,50
       vxorps    xmm4,xmm4,xmm4
       vmovdqa   xmmword ptr [rsp+20],xmm4
       vmovdqa   xmmword ptr [rsp+30],xmm4
       vmovdqa   xmmword ptr [rsp+40],xmm4
       mov       rbx,rcx
       test      rbx,rbx
       je        near ptr M01_L02
       mov       rdx,rbx
       mov       rcx,offset MT_System.Linq.IIListProvider`1[[System.Byte, System.Private.CoreLib]]
       call      qword ptr [7FF9B46B4348]; System.Runtime.CompilerServices.CastHelpers.IsInstanceOfInterface(Void*, System.Object)
       test      rax,rax
       jne       short M01_L01
       mov       rdx,rbx
       mov       rcx,offset MT_System.Collections.Generic.ICollection`1[[System.Byte, System.Private.CoreLib]]
       call      qword ptr [7FF9B46B4348]; System.Runtime.CompilerServices.CastHelpers.IsInstanceOfInterface(Void*, System.Object)
       mov       rsi,rax
       test      rsi,rsi
       je        short M01_L04
       mov       rcx,rsi
       mov       r11,7FF9B4570500
       call      qword ptr [r11]
       test      eax,eax
       je        short M01_L03
       movsxd    rdx,eax
       mov       rcx,offset MT_System.Byte[]
       call      CORINFO_HELP_NEWARR_1_VC
       mov       rdi,rax
       mov       rcx,rsi
       mov       rdx,rdi
       mov       r11,7FF9B4570508
       xor       r8d,r8d
       call      qword ptr [r11]
       mov       rax,rdi
M01_L00:
       add       rsp,50
       pop       rbx
       pop       rsi
       pop       rdi
       ret
M01_L01:
       mov       rcx,rax
       mov       r11,7FF9B45704F8
       call      qword ptr [r11]
       nop
       add       rsp,50
       pop       rbx
       pop       rsi
       pop       rdi
       ret
M01_L02:
       mov       ecx,10
       call      qword ptr [7FF9B4947A08]
       int       3
M01_L03:
       mov       rax,1A7802067B8
       jmp       short M01_L00
M01_L04:
       lea       rcx,[rsp+20]
       mov       edx,7FFFFFFF
       call      qword ptr [7FF9B4B26FD0]
       lea       rcx,[rsp+20]
       mov       rdx,rbx
       call      qword ptr [7FF9B4B27030]
       lea       rcx,[rsp+20]
       call      qword ptr [7FF9B4B270C0]
       jmp       short M01_L00
; Total bytes of code 258
```

## .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
```assembly
; Test.Benchmark.CloneWithArrayCopy()
       push      rsi
       push      rbx
       sub       rsp,28
       mov       rbx,[rcx+8]
       mov       edx,[rbx+8]
       mov       rcx,offset MT_System.Byte[]
       call      CORINFO_HELP_NEWARR_1_VC
       mov       rsi,rax
       mov       r8d,[rbx+8]
       mov       rcx,rbx
       mov       rdx,rsi
       call      qword ptr [7FF9B45E7738]; System.Array.Copy(System.Array, System.Array, Int32)
       mov       rax,rsi
       add       rsp,28
       pop       rbx
       pop       rsi
       ret
; Total bytes of code 57
```
```assembly
; System.Array.Copy(System.Array, System.Array, Int32)
       push      rdi
       push      rsi
       push      rbp
       push      rbx
       sub       rsp,38
       mov       rbx,rcx
       mov       rsi,rdx
       mov       edi,r8d
       test      rbx,rbx
       je        near ptr M01_L01
       test      rsi,rsi
       je        near ptr M01_L02
       mov       rcx,[rbx]
       cmp       rcx,[rsi]
       jne       short M01_L00
       cmp       dword ptr [rcx+4],18
       ja        short M01_L00
       cmp       edi,[rbx+8]
       ja        short M01_L00
       cmp       edi,[rsi+8]
       ja        short M01_L00
       mov       r8d,edi
       movzx     edx,word ptr [rcx]
       imul      r8,rdx
       lea       rdx,[rbx+10]
       add       rsi,10
       test      dword ptr [rcx],1000000
       jne       short M01_L03
       mov       rcx,rsi
       call      qword ptr [7FF9B4745B78]; System.Buffer.Memmove(Byte ByRef, Byte ByRef, UIntPtr)
       nop
       add       rsp,38
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       ret
M01_L00:
       mov       rcx,rbx
       xor       edx,edx
       call      qword ptr [7FF9B45E75D0]; System.Array.GetLowerBound(Int32)
       mov       ebp,eax
       mov       rcx,rsi
       xor       edx,edx
       call      qword ptr [7FF9B45E75D0]; System.Array.GetLowerBound(Int32)
       mov       r9d,eax
       mov       [rsp+20],edi
       xor       edx,edx
       mov       [rsp+28],edx
       mov       edx,ebp
       mov       r8,rsi
       mov       rcx,rbx
       call      qword ptr [7FF9B45E7450]; System.Array.CopyImpl(System.Array, Int32, System.Array, Int32, Int32, Boolean)
       nop
       add       rsp,38
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       ret
M01_L01:
       mov       ecx,41
       call      qword ptr [7FF9B4925AE8]
       int       3
M01_L02:
       mov       ecx,43
       call      qword ptr [7FF9B4925AE8]
       int       3
M01_L03:
       mov       rcx,rsi
       add       rsp,38
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       jmp       qword ptr [7FF9B4745BC0]
; Total bytes of code 206
```

## .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
```assembly
; Test.Benchmark.CloneWithOther()
       push      rsi
       push      rbx
       sub       rsp,28
       mov       rbx,[rcx+8]
       mov       edx,[rbx+8]
       mov       rcx,offset MT_System.Byte[]
       call      CORINFO_HELP_NEWARR_1_VC
       mov       rsi,rax
       mov       ecx,[rbx+8]
       mov       [rsp+20],ecx
       mov       rcx,rbx
       mov       r8,rsi
       xor       edx,edx
       xor       r9d,r9d
       call      qword ptr [7FF9B4785AE8]; System.Buffer.BlockCopy(System.Array, Int32, System.Array, Int32, Int32)
       mov       rax,rsi
       add       rsp,28
       pop       rbx
       pop       rsi
       ret
; Total bytes of code 65
```
```assembly
; System.Buffer.BlockCopy(System.Array, Int32, System.Array, Int32, Int32)
       push      r15
       push      r14
       push      r13
       push      r12
       push      rdi
       push      rsi
       push      rbp
       push      rbx
       sub       rsp,28
       mov       rbx,rcx
       mov       edi,edx
       mov       rsi,r8
       mov       ebp,r9d
       mov       r14d,[rsp+90]
       test      rbx,rbx
       je        near ptr M01_L03
       test      rsi,rsi
       je        near ptr M01_L04
       mov       r15d,[rbx+8]
       mov       r13,offset MT_System.Byte[]
       cmp       [rbx],r13
       jne       near ptr M01_L05
M01_L00:
       mov       r12,r15
       cmp       rbx,rsi
       je        short M01_L01
       mov       r12d,[rsi+8]
       cmp       [rsi],r13
       jne       near ptr M01_L07
M01_L01:
       test      edi,edi
       jl        near ptr M01_L09
M01_L02:
       test      ebp,ebp
       jl        near ptr M01_L10
       test      r14d,r14d
       jl        near ptr M01_L11
       movsxd    r8,r14d
       movsxd    rdx,edi
       movsxd    rcx,ebp
       lea       rax,[rdx+r8]
       cmp       rax,r15
       ja        near ptr M01_L12
       lea       rax,[rcx+r8]
       cmp       rax,r12
       ja        near ptr M01_L12
       lea       rax,[rsi+8]
       mov       r10,[rsi]
       mov       r10d,[r10+4]
       add       r10,0FFFFFFFFFFFFFFF0
       add       rax,r10
       add       rcx,rax
       lea       rax,[rbx+8]
       mov       r10,[rbx]
       mov       r10d,[r10+4]
       add       r10,0FFFFFFFFFFFFFFF0
       add       r10,rax
       add       rdx,r10
       call      qword ptr [7FF9B4785B78]; System.Buffer.Memmove(Byte ByRef, Byte ByRef, UIntPtr)
       nop
       add       rsp,28
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r12
       pop       r13
       pop       r14
       pop       r15
       ret
M01_L03:
       mov       ecx,18F
       mov       rdx,7FF9B4584000
       call      CORINFO_HELP_STRCNS
       mov       rcx,rax
       call      qword ptr [7FF9B47F6790]
       int       3
M01_L04:
       mov       ecx,197
       mov       rdx,7FF9B4584000
       call      CORINFO_HELP_STRCNS
       mov       rcx,rax
       call      qword ptr [7FF9B47F6790]
       int       3
M01_L05:
       mov       rcx,rbx
       call      System.Array.GetCorElementTypeOfElementType()
       mov       ecx,1
       shlx      ecx,ecx,eax
       test      ecx,3003FFC
       jne       short M01_L06
       mov       rcx,offset MT_System.ArgumentException
       call      CORINFO_HELP_NEWSFAST
       mov       rbx,rax
       call      qword ptr [7FF9B4B4D7A0]
       mov       r15,rax
       mov       ecx,18F
       mov       rdx,7FF9B4584000
       call      CORINFO_HELP_STRCNS
       mov       r8,rax
       mov       rdx,r15
       mov       rcx,rbx
       call      qword ptr [7FF9B46DF750]
       mov       rcx,rbx
       call      CORINFO_HELP_THROW
M01_L06:
       mov       rcx,[rbx]
       movzx     ecx,word ptr [rcx]
       imul      r15,rcx
       jmp       near ptr M01_L00
M01_L07:
       mov       rcx,rsi
       call      System.Array.GetCorElementTypeOfElementType()
       mov       ecx,1
       shlx      ecx,ecx,eax
       test      ecx,3003FFC
       jne       short M01_L08
       mov       rcx,offset MT_System.ArgumentException
       call      CORINFO_HELP_NEWSFAST
       mov       rsi,rax
       call      qword ptr [7FF9B4B4D7A0]
       mov       r12,rax
       mov       ecx,197
       mov       rdx,7FF9B4584000
       call      CORINFO_HELP_STRCNS
       mov       r8,rax
       mov       rdx,r12
       mov       rcx,rsi
       call      qword ptr [7FF9B46DF750]
       mov       rcx,rsi
       call      CORINFO_HELP_THROW
M01_L08:
       mov       rcx,[rsi]
       movzx     ecx,word ptr [rcx]
       imul      r12,rcx
       test      edi,edi
       jge       near ptr M01_L02
M01_L09:
       mov       ecx,19F
       mov       rdx,7FF9B4584000
       call      CORINFO_HELP_STRCNS
       mov       rdx,rax
       mov       ecx,edi
       call      qword ptr [7FF9B4B77B58]
       int       3
M01_L10:
       mov       ecx,1B3
       mov       rdx,7FF9B4584000
       call      CORINFO_HELP_STRCNS
       mov       rdx,rax
       mov       ecx,ebp
       call      qword ptr [7FF9B4B77B58]
       int       3
M01_L11:
       mov       ecx,1C7
       mov       rdx,7FF9B4584000
       call      CORINFO_HELP_STRCNS
       mov       rdx,rax
       mov       ecx,r14d
       call      qword ptr [7FF9B4B77B58]
       int       3
M01_L12:
       mov       rcx,offset MT_System.ArgumentException
       call      CORINFO_HELP_NEWSFAST
       mov       rbx,rax
       call      qword ptr [7FF9B4B4EBC8]
       mov       rdx,rax
       mov       rcx,rbx
       call      qword ptr [7FF9B46DF708]
       mov       rcx,rbx
       call      CORINFO_HELP_THROW
       int       3
; Total bytes of code 650
```

