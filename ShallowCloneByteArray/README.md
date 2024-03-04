# Shallow copy an array of bytes.


```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26074.1)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.200
  [Host]     : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                   | Count | Mean       | Error      | StdDev     | Median     | Ratio | RatioSD | Code Size |
|------------------------- |------ |-----------:|-----------:|-----------:|-----------:|------:|--------:|----------:|
| **CloneWithToArray**         | **10**    |  **35.226 ns** |  **0.7559 ns** |  **0.6701 ns** |  **35.050 ns** |  **1.00** |    **0.00** |     **268 B** |
| CloneWithArrayCopy       | 10    |  12.470 ns |  0.3056 ns |  0.2709 ns |  12.381 ns |  0.35 |    0.01 |     263 B |
| CloneWithBufferBlockCopy | 10    |  14.306 ns |  0.3497 ns |  0.5547 ns |  14.138 ns |  0.41 |    0.02 |     715 B |
| CloneWithAsSpanToArray   | 10    |   9.211 ns |  0.2510 ns |  0.6203 ns |   9.005 ns |  0.27 |    0.02 |     353 B |
|                          |       |            |            |            |            |       |         |           |
| **CloneWithToArray**         | **100**   |  **42.711 ns** |  **0.8599 ns** |  **0.8831 ns** |  **42.999 ns** |  **1.00** |    **0.00** |     **268 B** |
| CloneWithArrayCopy       | 100   |  19.925 ns |  0.4664 ns |  0.9314 ns |  19.926 ns |  0.46 |    0.03 |     263 B |
| CloneWithBufferBlockCopy | 100   |  21.134 ns |  0.4851 ns |  0.4537 ns |  21.104 ns |  0.50 |    0.01 |     715 B |
| CloneWithAsSpanToArray   | 100   |  15.025 ns |  0.2681 ns |  0.3191 ns |  14.903 ns |  0.35 |    0.01 |     353 B |
|                          |       |            |            |            |            |       |         |           |
| **CloneWithToArray**         | **10000** | **663.527 ns** | **13.1058 ns** | **25.8695 ns** | **662.509 ns** |  **1.00** |    **0.00** |     **268 B** |
| CloneWithArrayCopy       | 10000 | 687.869 ns | 13.6609 ns | 24.9796 ns | 685.643 ns |  1.04 |    0.06 |     263 B |
| CloneWithBufferBlockCopy | 10000 | 694.922 ns | 13.7007 ns | 14.0696 ns | 693.978 ns |  1.04 |    0.05 |     715 B |
| CloneWithAsSpanToArray   | 10000 | 692.993 ns | 13.8754 ns | 27.0630 ns | 691.032 ns |  1.05 |    0.06 |     371 B |

## .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
```assembly
; Test.Benchmark.CloneWithToArray()
       mov       rcx,[rcx+8]
       jmp       qword ptr [7FF9A5AE69D0]; System.Linq.Enumerable.ToArray[[System.Byte, System.Private.CoreLib]](System.Collections.Generic.IEnumerable`1<Byte>)
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
       call      qword ptr [7FF9A5674348]; System.Runtime.CompilerServices.CastHelpers.IsInstanceOfInterface(Void*, System.Object)
       test      rax,rax
       jne       short M01_L01
       mov       rdx,rbx
       mov       rcx,offset MT_System.Collections.Generic.ICollection`1[[System.Byte, System.Private.CoreLib]]
       call      qword ptr [7FF9A5674348]; System.Runtime.CompilerServices.CastHelpers.IsInstanceOfInterface(Void*, System.Object)
       mov       rsi,rax
       test      rsi,rsi
       je        short M01_L04
       mov       rcx,rsi
       mov       r11,7FF9A5530500
       call      qword ptr [r11]
       test      eax,eax
       je        short M01_L03
       movsxd    rdx,eax
       mov       rcx,offset MT_System.Byte[]
       call      CORINFO_HELP_NEWARR_1_VC
       mov       rdi,rax
       mov       rcx,rsi
       mov       rdx,rdi
       mov       r11,7FF9A5530508
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
       mov       r11,7FF9A55304F8
       call      qword ptr [r11]
       nop
       add       rsp,50
       pop       rbx
       pop       rsi
       pop       rdi
       ret
M01_L02:
       mov       ecx,10
       call      qword ptr [7FF9A5907A08]
       int       3
M01_L03:
       mov       rax,1F2002067B8
       jmp       short M01_L00
M01_L04:
       lea       rcx,[rsp+20]
       mov       edx,7FFFFFFF
       call      qword ptr [7FF9A5AE6D78]
       lea       rcx,[rsp+20]
       mov       rdx,rbx
       call      qword ptr [7FF9A5AE6DD8]
       lea       rcx,[rsp+20]
       call      qword ptr [7FF9A5AE6E68]
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
       call      qword ptr [7FF9A55C7738]; System.Array.Copy(System.Array, System.Array, Int32)
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
       call      qword ptr [7FF9A5725B78]; System.Buffer.Memmove(Byte ByRef, Byte ByRef, UIntPtr)
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
       call      qword ptr [7FF9A55C75D0]; System.Array.GetLowerBound(Int32)
       mov       ebp,eax
       mov       rcx,rsi
       xor       edx,edx
       call      qword ptr [7FF9A55C75D0]; System.Array.GetLowerBound(Int32)
       mov       r9d,eax
       mov       [rsp+20],edi
       xor       edx,edx
       mov       [rsp+28],edx
       mov       edx,ebp
       mov       r8,rsi
       mov       rcx,rbx
       call      qword ptr [7FF9A55C7450]; System.Array.CopyImpl(System.Array, Int32, System.Array, Int32, Int32, Boolean)
       nop
       add       rsp,38
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       ret
M01_L01:
       mov       ecx,41
       call      qword ptr [7FF9A5905AE8]
       int       3
M01_L02:
       mov       ecx,43
       call      qword ptr [7FF9A5905AE8]
       int       3
M01_L03:
       mov       rcx,rsi
       add       rsp,38
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       jmp       qword ptr [7FF9A5725BC0]
; Total bytes of code 206
```

## .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
```assembly
; Test.Benchmark.CloneWithBufferBlockCopy()
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
       call      qword ptr [7FF9A5705AE8]; System.Buffer.BlockCopy(System.Array, Int32, System.Array, Int32, Int32)
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
       call      qword ptr [7FF9A5705B78]; System.Buffer.Memmove(Byte ByRef, Byte ByRef, UIntPtr)
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
       mov       rdx,7FF9A5504000
       call      CORINFO_HELP_STRCNS
       mov       rcx,rax
       call      qword ptr [7FF9A5776790]
       int       3
M01_L04:
       mov       ecx,197
       mov       rdx,7FF9A5504000
       call      CORINFO_HELP_STRCNS
       mov       rcx,rax
       call      qword ptr [7FF9A5776790]
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
       call      qword ptr [7FF9A5ACD9F8]
       mov       r15,rax
       mov       ecx,18F
       mov       rdx,7FF9A5504000
       call      CORINFO_HELP_STRCNS
       mov       r8,rax
       mov       rdx,r15
       mov       rcx,rsi
       call      qword ptr [7FF9A565F750]
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
       call      qword ptr [7FF9A5ACD9F8]
       mov       r12,rax
       mov       ecx,197
       mov       rdx,7FF9A5504000
       call      CORINFO_HELP_STRCNS
       mov       r8,rax
       mov       rdx,r12
       mov       rcx,rbx
       call      qword ptr [7FF9A565F750]
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
       mov       rdx,7FF9A5504000
       call      CORINFO_HELP_STRCNS
       mov       rdx,rax
       mov       ecx,edi
       call      qword ptr [7FF9A5AF7B58]
       int       3
M01_L10:
       mov       ecx,1B3
       mov       rdx,7FF9A5504000
       call      CORINFO_HELP_STRCNS
       mov       rdx,rax
       mov       ecx,ebp
       call      qword ptr [7FF9A5AF7B58]
       int       3
M01_L11:
       mov       ecx,1C7
       mov       rdx,7FF9A5504000
       call      CORINFO_HELP_STRCNS
       mov       rdx,rax
       mov       ecx,r14d
       call      qword ptr [7FF9A5AF7B58]
       int       3
M01_L12:
       mov       rcx,offset MT_System.ArgumentException
       call      CORINFO_HELP_NEWSFAST
       mov       rbx,rax
       call      qword ptr [7FF9A5ACEE20]
       mov       rdx,rax
       mov       rcx,rbx
       call      qword ptr [7FF9A565F708]
       mov       rcx,rbx
       call      CORINFO_HELP_THROW
       int       3
; Total bytes of code 650
```

## .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
```assembly
; Test.Benchmark.CloneWithAsSpanToArray()
       push      rdi
       push      rsi
       push      rbx
       sub       rsp,20
       mov       rdx,[rcx+8]
       test      rdx,rdx
       je        short M00_L02
       lea       rbx,[rdx+10]
       mov       esi,[rdx+8]
M00_L00:
       test      esi,esi
       je        short M00_L03
       movsxd    rdx,esi
       mov       rcx,offset MT_System.Byte[]
       call      CORINFO_HELP_NEWARR_1_VC
       mov       rdi,rax
       lea       rcx,[rdi+10]
       mov       r8d,esi
       mov       rdx,rbx
       call      qword ptr [7FF9A56F5B78]; System.Buffer.Memmove(Byte ByRef, Byte ByRef, UIntPtr)
       mov       rax,rdi
M00_L01:
       add       rsp,20
       pop       rbx
       pop       rsi
       pop       rdi
       ret
M00_L02:
       xor       ebx,ebx
       xor       esi,esi
       jmp       short M00_L00
M00_L03:
       mov       rax,29D802067B8
       jmp       short M00_L01
; Total bytes of code 93
```
```assembly
; System.Buffer.Memmove(Byte ByRef, Byte ByRef, UIntPtr)
       vzeroupper
       mov       rax,rcx
       sub       rax,rdx
       cmp       rax,r8
       jb        near ptr M01_L08
       mov       rax,rdx
       sub       rax,rcx
       cmp       rax,r8
       jb        near ptr M01_L08
       lea       rax,[rdx+r8]
       lea       r10,[rcx+r8]
       cmp       r8,10
       ja        short M01_L01
       test      r8b,18
       je        short M01_L04
       mov       r8,[rdx]
       mov       [rcx],r8
       mov       rdx,[rax-8]
       mov       [r10-8],rdx
M01_L00:
       vzeroupper
       ret
M01_L01:
       cmp       r8,40
       ja        short M01_L06
M01_L02:
       vmovups   xmm0,[rdx]
       vmovups   [rcx],xmm0
       cmp       r8,20
       jbe       short M01_L03
       vmovups   xmm0,[rdx+10]
       vmovups   [rcx+10],xmm0
       cmp       r8,30
       jbe       short M01_L03
       vmovups   xmm0,[rdx+20]
       vmovups   [rcx+20],xmm0
M01_L03:
       vmovups   xmm0,[rax-10]
       vmovups   [r10-10],xmm0
       jmp       short M01_L00
M01_L04:
       test      r8b,4
       je        short M01_L05
       mov       r8d,[rdx]
       mov       [rcx],r8d
       mov       eax,[rax-4]
       mov       [r10-4],eax
       jmp       short M01_L00
M01_L05:
       test      r8,r8
       je        short M01_L00
       movzx     edx,byte ptr [rdx]
       mov       [rcx],dl
       test      r8b,2
       je        short M01_L00
       movsx     r8,word ptr [rax-2]
       mov       [r10-2],r8w
       jmp       short M01_L00
M01_L06:
       cmp       r8,800
       ja        short M01_L09
       mov       r9,r8
       shr       r9,6
M01_L07:
       vmovdqu   ymm0,ymmword ptr [rdx]
       vmovdqu   ymmword ptr [rcx],ymm0
       vmovdqu   ymm0,ymmword ptr [rdx+20]
       vmovdqu   ymmword ptr [rcx+20],ymm0
       add       rcx,40
       add       rdx,40
       dec       r9
       jne       short M01_L07
       and       r8,3F
       cmp       r8,10
       ja        near ptr M01_L02
       jmp       short M01_L03
M01_L08:
       cmp       rcx,rdx
       je        near ptr M01_L00
M01_L09:
       vzeroupper
       jmp       qword ptr [7FF9A56F5B90]; System.Buffer._Memmove(Byte ByRef, Byte ByRef, UIntPtr)
; Total bytes of code 260
```

## .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
```assembly
; Test.Benchmark.CloneWithToArray()
       mov       rcx,[rcx+8]
       jmp       qword ptr [7FF9A5AD69D0]; System.Linq.Enumerable.ToArray[[System.Byte, System.Private.CoreLib]](System.Collections.Generic.IEnumerable`1<Byte>)
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
       call      qword ptr [7FF9A5664348]; System.Runtime.CompilerServices.CastHelpers.IsInstanceOfInterface(Void*, System.Object)
       test      rax,rax
       jne       short M01_L01
       mov       rdx,rbx
       mov       rcx,offset MT_System.Collections.Generic.ICollection`1[[System.Byte, System.Private.CoreLib]]
       call      qword ptr [7FF9A5664348]; System.Runtime.CompilerServices.CastHelpers.IsInstanceOfInterface(Void*, System.Object)
       mov       rsi,rax
       test      rsi,rsi
       je        short M01_L04
       mov       rcx,rsi
       mov       r11,7FF9A5520500
       call      qword ptr [r11]
       test      eax,eax
       je        short M01_L03
       movsxd    rdx,eax
       mov       rcx,offset MT_System.Byte[]
       call      CORINFO_HELP_NEWARR_1_VC
       mov       rdi,rax
       mov       rcx,rsi
       mov       rdx,rdi
       mov       r11,7FF9A5520508
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
       mov       r11,7FF9A55204F8
       call      qword ptr [r11]
       nop
       add       rsp,50
       pop       rbx
       pop       rsi
       pop       rdi
       ret
M01_L02:
       mov       ecx,10
       call      qword ptr [7FF9A58F7A08]
       int       3
M01_L03:
       mov       rax,242003067B8
       jmp       short M01_L00
M01_L04:
       lea       rcx,[rsp+20]
       mov       edx,7FFFFFFF
       call      qword ptr [7FF9A5AD6D78]
       lea       rcx,[rsp+20]
       mov       rdx,rbx
       call      qword ptr [7FF9A5AD6DD8]
       lea       rcx,[rsp+20]
       call      qword ptr [7FF9A5AD6E68]
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
       call      qword ptr [7FF9A55C7738]; System.Array.Copy(System.Array, System.Array, Int32)
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
       call      qword ptr [7FF9A5725B78]; System.Buffer.Memmove(Byte ByRef, Byte ByRef, UIntPtr)
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
       call      qword ptr [7FF9A55C75D0]; System.Array.GetLowerBound(Int32)
       mov       ebp,eax
       mov       rcx,rsi
       xor       edx,edx
       call      qword ptr [7FF9A55C75D0]; System.Array.GetLowerBound(Int32)
       mov       r9d,eax
       mov       [rsp+20],edi
       xor       edx,edx
       mov       [rsp+28],edx
       mov       edx,ebp
       mov       r8,rsi
       mov       rcx,rbx
       call      qword ptr [7FF9A55C7450]; System.Array.CopyImpl(System.Array, Int32, System.Array, Int32, Int32, Boolean)
       nop
       add       rsp,38
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       ret
M01_L01:
       mov       ecx,41
       call      qword ptr [7FF9A5905AE8]
       int       3
M01_L02:
       mov       ecx,43
       call      qword ptr [7FF9A5905AE8]
       int       3
M01_L03:
       mov       rcx,rsi
       add       rsp,38
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       jmp       qword ptr [7FF9A5725BC0]
; Total bytes of code 206
```

## .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
```assembly
; Test.Benchmark.CloneWithBufferBlockCopy()
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
       call      qword ptr [7FF9A5715AE8]; System.Buffer.BlockCopy(System.Array, Int32, System.Array, Int32, Int32)
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
       call      qword ptr [7FF9A5715B78]; System.Buffer.Memmove(Byte ByRef, Byte ByRef, UIntPtr)
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
       mov       rdx,7FF9A5514000
       call      CORINFO_HELP_STRCNS
       mov       rcx,rax
       call      qword ptr [7FF9A5786790]
       int       3
M01_L04:
       mov       ecx,197
       mov       rdx,7FF9A5514000
       call      CORINFO_HELP_STRCNS
       mov       rcx,rax
       call      qword ptr [7FF9A5786790]
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
       call      qword ptr [7FF9A5ADD9F8]
       mov       r15,rax
       mov       ecx,18F
       mov       rdx,7FF9A5514000
       call      CORINFO_HELP_STRCNS
       mov       r8,rax
       mov       rdx,r15
       mov       rcx,rsi
       call      qword ptr [7FF9A566F750]
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
       call      qword ptr [7FF9A5ADD9F8]
       mov       r12,rax
       mov       ecx,197
       mov       rdx,7FF9A5514000
       call      CORINFO_HELP_STRCNS
       mov       r8,rax
       mov       rdx,r12
       mov       rcx,rbx
       call      qword ptr [7FF9A566F750]
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
       mov       rdx,7FF9A5514000
       call      CORINFO_HELP_STRCNS
       mov       rdx,rax
       mov       ecx,edi
       call      qword ptr [7FF9A5B07B58]
       int       3
M01_L10:
       mov       ecx,1B3
       mov       rdx,7FF9A5514000
       call      CORINFO_HELP_STRCNS
       mov       rdx,rax
       mov       ecx,ebp
       call      qword ptr [7FF9A5B07B58]
       int       3
M01_L11:
       mov       ecx,1C7
       mov       rdx,7FF9A5514000
       call      CORINFO_HELP_STRCNS
       mov       rdx,rax
       mov       ecx,r14d
       call      qword ptr [7FF9A5B07B58]
       int       3
M01_L12:
       mov       rcx,offset MT_System.ArgumentException
       call      CORINFO_HELP_NEWSFAST
       mov       rbx,rax
       call      qword ptr [7FF9A5ADEE20]
       mov       rdx,rax
       mov       rcx,rbx
       call      qword ptr [7FF9A566F708]
       mov       rcx,rbx
       call      CORINFO_HELP_THROW
       int       3
; Total bytes of code 650
```

## .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
```assembly
; Test.Benchmark.CloneWithAsSpanToArray()
       push      rdi
       push      rsi
       push      rbx
       sub       rsp,20
       mov       rdx,[rcx+8]
       test      rdx,rdx
       je        short M00_L02
       lea       rbx,[rdx+10]
       mov       esi,[rdx+8]
M00_L00:
       test      esi,esi
       je        short M00_L03
       movsxd    rdx,esi
       mov       rcx,offset MT_System.Byte[]
       call      CORINFO_HELP_NEWARR_1_VC
       mov       rdi,rax
       lea       rcx,[rdi+10]
       mov       r8d,esi
       mov       rdx,rbx
       call      qword ptr [7FF9A5715B78]; System.Buffer.Memmove(Byte ByRef, Byte ByRef, UIntPtr)
       mov       rax,rdi
M00_L01:
       add       rsp,20
       pop       rbx
       pop       rsi
       pop       rdi
       ret
M00_L02:
       xor       ebx,ebx
       xor       esi,esi
       jmp       short M00_L00
M00_L03:
       mov       rax,18D802067B8
       jmp       short M00_L01
; Total bytes of code 93
```
```assembly
; System.Buffer.Memmove(Byte ByRef, Byte ByRef, UIntPtr)
       vzeroupper
       mov       rax,rcx
       sub       rax,rdx
       cmp       rax,r8
       jb        near ptr M01_L08
       mov       rax,rdx
       sub       rax,rcx
       cmp       rax,r8
       jb        near ptr M01_L08
       lea       rax,[rdx+r8]
       lea       r10,[rcx+r8]
       cmp       r8,10
       jbe       near ptr M01_L05
       cmp       r8,40
       jbe       short M01_L01
       cmp       r8,800
       ja        near ptr M01_L09
       mov       r9,r8
       shr       r9,6
M01_L00:
       vmovdqu   ymm0,ymmword ptr [rdx]
       vmovdqu   ymmword ptr [rcx],ymm0
       vmovdqu   ymm0,ymmword ptr [rdx+20]
       vmovdqu   ymmword ptr [rcx+20],ymm0
       add       rcx,40
       add       rdx,40
       dec       r9
       jne       short M01_L00
       and       r8,3F
       cmp       r8,10
       jbe       short M01_L02
M01_L01:
       vmovups   xmm0,[rdx]
       vmovups   [rcx],xmm0
       cmp       r8,20
       jbe       short M01_L02
       vmovups   xmm0,[rdx+10]
       vmovups   [rcx+10],xmm0
       cmp       r8,30
       ja        short M01_L04
M01_L02:
       vmovups   xmm0,[rax-10]
       vmovups   [r10-10],xmm0
M01_L03:
       vzeroupper
       ret
M01_L04:
       vmovups   xmm0,[rdx+20]
       vmovups   [rcx+20],xmm0
       jmp       short M01_L02
M01_L05:
       test      r8b,18
       je        short M01_L06
       mov       r8,[rdx]
       mov       [rcx],r8
       mov       rdx,[rax-8]
       mov       [r10-8],rdx
       jmp       short M01_L03
M01_L06:
       test      r8b,4
       je        short M01_L07
       mov       r8d,[rdx]
       mov       [rcx],r8d
       mov       eax,[rax-4]
       mov       [r10-4],eax
       jmp       short M01_L03
M01_L07:
       test      r8,r8
       je        short M01_L03
       movzx     edx,byte ptr [rdx]
       mov       [rcx],dl
       test      r8b,2
       je        short M01_L03
       movsx     rcx,word ptr [rax-2]
       mov       [r10-2],cx
       jmp       short M01_L03
M01_L08:
       cmp       rcx,rdx
       je        short M01_L03
M01_L09:
       vzeroupper
       jmp       qword ptr [7FF9A5715B90]; System.Buffer._Memmove(Byte ByRef, Byte ByRef, UIntPtr)
; Total bytes of code 260
```

## .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
```assembly
; Test.Benchmark.CloneWithToArray()
       mov       rcx,[rcx+8]
       jmp       qword ptr [7FF9A5AB69D0]; System.Linq.Enumerable.ToArray[[System.Byte, System.Private.CoreLib]](System.Collections.Generic.IEnumerable`1<Byte>)
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
       call      qword ptr [7FF9A5644348]; System.Runtime.CompilerServices.CastHelpers.IsInstanceOfInterface(Void*, System.Object)
       test      rax,rax
       jne       short M01_L01
       mov       rdx,rbx
       mov       rcx,offset MT_System.Collections.Generic.ICollection`1[[System.Byte, System.Private.CoreLib]]
       call      qword ptr [7FF9A5644348]; System.Runtime.CompilerServices.CastHelpers.IsInstanceOfInterface(Void*, System.Object)
       mov       rsi,rax
       test      rsi,rsi
       je        short M01_L04
       mov       rcx,rsi
       mov       r11,7FF9A5500500
       call      qword ptr [r11]
       test      eax,eax
       je        short M01_L03
       movsxd    rdx,eax
       mov       rcx,offset MT_System.Byte[]
       call      CORINFO_HELP_NEWARR_1_VC
       mov       rdi,rax
       mov       rcx,rsi
       mov       rdx,rdi
       mov       r11,7FF9A5500508
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
       mov       r11,7FF9A55004F8
       call      qword ptr [r11]
       nop
       add       rsp,50
       pop       rbx
       pop       rsi
       pop       rdi
       ret
M01_L02:
       mov       ecx,10
       call      qword ptr [7FF9A58D7A08]
       int       3
M01_L03:
       mov       rax,15A803067B8
       jmp       short M01_L00
M01_L04:
       lea       rcx,[rsp+20]
       mov       edx,7FFFFFFF
       call      qword ptr [7FF9A5AB6D78]
       lea       rcx,[rsp+20]
       mov       rdx,rbx
       call      qword ptr [7FF9A5AB6DD8]
       lea       rcx,[rsp+20]
       call      qword ptr [7FF9A5AB6E68]
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
       call      qword ptr [7FF9A55B7738]; System.Array.Copy(System.Array, System.Array, Int32)
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
       call      qword ptr [7FF9A5715B78]; System.Buffer.Memmove(Byte ByRef, Byte ByRef, UIntPtr)
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
       call      qword ptr [7FF9A55B75D0]; System.Array.GetLowerBound(Int32)
       mov       ebp,eax
       mov       rcx,rsi
       xor       edx,edx
       call      qword ptr [7FF9A55B75D0]; System.Array.GetLowerBound(Int32)
       mov       r9d,eax
       mov       [rsp+20],edi
       xor       edx,edx
       mov       [rsp+28],edx
       mov       edx,ebp
       mov       r8,rsi
       mov       rcx,rbx
       call      qword ptr [7FF9A55B7450]; System.Array.CopyImpl(System.Array, Int32, System.Array, Int32, Int32, Boolean)
       nop
       add       rsp,38
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       ret
M01_L01:
       mov       ecx,41
       call      qword ptr [7FF9A58F5AE8]
       int       3
M01_L02:
       mov       ecx,43
       call      qword ptr [7FF9A58F5AE8]
       int       3
M01_L03:
       mov       rcx,rsi
       add       rsp,38
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       jmp       qword ptr [7FF9A5715BC0]
; Total bytes of code 206
```

## .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
```assembly
; Test.Benchmark.CloneWithBufferBlockCopy()
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
       call      qword ptr [7FF9A5715AE8]; System.Buffer.BlockCopy(System.Array, Int32, System.Array, Int32, Int32)
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
       call      qword ptr [7FF9A5715B78]; System.Buffer.Memmove(Byte ByRef, Byte ByRef, UIntPtr)
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
       mov       rdx,7FF9A5514000
       call      CORINFO_HELP_STRCNS
       mov       rcx,rax
       call      qword ptr [7FF9A5786790]
       int       3
M01_L04:
       mov       ecx,197
       mov       rdx,7FF9A5514000
       call      CORINFO_HELP_STRCNS
       mov       rcx,rax
       call      qword ptr [7FF9A5786790]
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
       call      qword ptr [7FF9A5ADD6C8]
       mov       r15,rax
       mov       ecx,18F
       mov       rdx,7FF9A5514000
       call      CORINFO_HELP_STRCNS
       mov       r8,rax
       mov       rdx,r15
       mov       rcx,rbx
       call      qword ptr [7FF9A566F750]
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
       call      qword ptr [7FF9A5ADD6C8]
       mov       r12,rax
       mov       ecx,197
       mov       rdx,7FF9A5514000
       call      CORINFO_HELP_STRCNS
       mov       r8,rax
       mov       rdx,r12
       mov       rcx,rsi
       call      qword ptr [7FF9A566F750]
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
       mov       rdx,7FF9A5514000
       call      CORINFO_HELP_STRCNS
       mov       rdx,rax
       mov       ecx,edi
       call      qword ptr [7FF9A5B07B58]
       int       3
M01_L10:
       mov       ecx,1B3
       mov       rdx,7FF9A5514000
       call      CORINFO_HELP_STRCNS
       mov       rdx,rax
       mov       ecx,ebp
       call      qword ptr [7FF9A5B07B58]
       int       3
M01_L11:
       mov       ecx,1C7
       mov       rdx,7FF9A5514000
       call      CORINFO_HELP_STRCNS
       mov       rdx,rax
       mov       ecx,r14d
       call      qword ptr [7FF9A5B07B58]
       int       3
M01_L12:
       mov       rcx,offset MT_System.ArgumentException
       call      CORINFO_HELP_NEWSFAST
       mov       rbx,rax
       call      qword ptr [7FF9A5ADEAF0]
       mov       rdx,rax
       mov       rcx,rbx
       call      qword ptr [7FF9A566F708]
       mov       rcx,rbx
       call      CORINFO_HELP_THROW
       int       3
; Total bytes of code 650
```

## .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
```assembly
; Test.Benchmark.CloneWithAsSpanToArray()
       push      rdi
       push      rsi
       push      rbx
       sub       rsp,20
       mov       rdx,[rcx+8]
       test      rdx,rdx
       je        short M00_L02
       lea       rbx,[rdx+10]
       mov       esi,[rdx+8]
M00_L00:
       test      esi,esi
       je        short M00_L03
       movsxd    rdx,esi
       mov       rcx,offset MT_System.Byte[]
       call      CORINFO_HELP_NEWARR_1_VC
       mov       rdi,rax
       lea       rcx,[rdi+10]
       mov       r8d,esi
       mov       rdx,rbx
       call      qword ptr [7FF9A5725B78]; System.Buffer.Memmove(Byte ByRef, Byte ByRef, UIntPtr)
       mov       rax,rdi
M00_L01:
       add       rsp,20
       pop       rbx
       pop       rsi
       pop       rdi
       ret
M00_L02:
       xor       ebx,ebx
       xor       esi,esi
       jmp       short M00_L00
M00_L03:
       mov       rax,1AD802067B8
       jmp       short M00_L01
; Total bytes of code 93
```
```assembly
; System.Buffer.Memmove(Byte ByRef, Byte ByRef, UIntPtr)
       push      rsi
       push      rbx
       vzeroupper
       mov       rax,rcx
       sub       rax,rdx
       cmp       rax,r8
       jb        near ptr M01_L09
       mov       rax,rdx
       sub       rax,rcx
       cmp       rax,r8
       jb        near ptr M01_L09
       lea       rbx,[rdx+r8]
       lea       rsi,[rcx+r8]
       cmp       r8,10
       jbe       short M01_L04
       cmp       r8,40
       jbe       short M01_L02
       cmp       r8,800
       jbe       near ptr M01_L07
M01_L00:
       vzeroupper
       pop       rbx
       pop       rsi
       jmp       qword ptr [7FF9A5725B90]; System.Buffer._Memmove(Byte ByRef, Byte ByRef, UIntPtr)
M01_L01:
       vzeroupper
       pop       rbx
       pop       rsi
       ret
M01_L02:
       vmovups   xmm0,[rdx]
       vmovups   [rcx],xmm0
       cmp       r8,20
       jbe       short M01_L03
       vmovups   xmm0,[rdx+10]
       vmovups   [rcx+10],xmm0
       cmp       r8,30
       jbe       short M01_L03
       vmovups   xmm0,[rdx+20]
       vmovups   [rcx+20],xmm0
M01_L03:
       vmovups   xmm0,[rbx-10]
       vmovups   [rsi-10],xmm0
       jmp       short M01_L01
M01_L04:
       test      r8b,18
       je        short M01_L05
       mov       r8,[rdx]
       mov       [rcx],r8
       mov       rdx,[rbx-8]
       mov       [rsi-8],rdx
       jmp       short M01_L01
M01_L05:
       test      r8b,4
       je        short M01_L06
       mov       r8d,[rdx]
       mov       [rcx],r8d
       mov       edx,[rbx-4]
       mov       [rsi-4],edx
       jmp       short M01_L01
M01_L06:
       test      r8,r8
       je        short M01_L01
       movzx     edx,byte ptr [rdx]
       mov       [rcx],dl
       test      r8b,2
       je        short M01_L01
       movsx     r8,word ptr [rbx-2]
       mov       [rsi-2],r8w
       jmp       short M01_L01
M01_L07:
       mov       rax,r8
       shr       rax,6
M01_L08:
       vmovdqu   ymm0,ymmword ptr [rdx]
       vmovdqu   ymmword ptr [rcx],ymm0
       vmovdqu   ymm0,ymmword ptr [rdx+20]
       vmovdqu   ymmword ptr [rcx+20],ymm0
       add       rcx,40
       add       rdx,40
       dec       rax
       jne       short M01_L08
       and       r8,3F
       cmp       r8,10
       ja        near ptr M01_L02
       jmp       near ptr M01_L03
M01_L09:
       cmp       rcx,rdx
       je        near ptr M01_L01
       jmp       near ptr M01_L00
; Total bytes of code 278
```

