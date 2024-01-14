# Ordinal vs OrdinalIgnoreCase


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                       Method | Count |      Mean |     Error |    StdDev | Ratio | Code Size |
|----------------------------- |------ |----------:|----------:|----------:|------:|----------:|
|                      Ordinal |  1000 |  4.674 μs | 0.0135 μs | 0.0120 μs |  1.00 |     916 B |
|            OrdinalIgnoreCase |  1000 |  6.365 μs | 0.0126 μs | 0.0112 μs |  1.36 |   1,308 B |
|           OrdinalLongStrings |  1000 |  9.665 μs | 0.0313 μs | 0.0292 μs |  2.07 |     923 B |
| OrdinalIgnoreCaseLongStrings |  1000 | 11.645 μs | 0.0113 μs | 0.0101 μs |  2.49 |   1,281 B |

## .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.Ordinal()
       push      rdi
       push      rsi
       push      rbx
       sub       rsp,20
       mov       rbx,[rcx+8]
       xor       esi,esi
       mov       edi,[rbx+8]
       test      edi,edi
       jle       short M00_L02
M00_L00:
       mov       ecx,esi
       mov       rcx,[rbx+rcx*8+10]
       mov       edx,[rcx+8]
       add       rcx,0C
       mov       r8,1EE8020AAB4
       mov       r9d,7
       call      qword ptr [7FFBFDAB51A0]; System.SpanHelpers.IndexOf(Char ByRef, Int32, Char ByRef, Int32)
       test      eax,eax
       jge       short M00_L01
       inc       esi
       cmp       edi,esi
       jle       short M00_L02
       jmp       short M00_L00
M00_L01:
       mov       eax,esi
       add       rsp,20
       pop       rbx
       pop       rsi
       pop       rdi
       ret
M00_L02:
       mov       eax,0FFFFFFFF
       add       rsp,20
       pop       rbx
       pop       rsi
       pop       rdi
       ret
; Total bytes of code 91
```
```assembly
; System.SpanHelpers.IndexOf(Char ByRef, Int32, Char ByRef, Int32)
       push      r15
       push      r14
       push      r13
       push      r12
       push      rdi
       push      rsi
       push      rbp
       push      rbx
       sub       rsp,78
       vzeroupper
       vmovaps   [rsp+60],xmm6
       vmovaps   [rsp+50],xmm7
       vmovaps   [rsp+40],xmm8
       vmovaps   [rsp+30],xmm9
       mov       rdi,rcx
       mov       rbx,r8
       mov       esi,r9d
       mov       r8d,edx
       test      esi,esi
       je        near ptr M01_L07
       lea       ebp,[rsi-1]
       test      ebp,ebp
       je        near ptr M01_L08
       xor       r14d,r14d
       movzx     r15d,word ptr [rbx]
       mov       r13d,r8d
       sub       r13d,ebp
       cmp       r13d,8
       jge       short M01_L01
       add       rbx,2
       test      r13d,r13d
       jg        near ptr M01_L11
M01_L00:
       mov       eax,0FFFFFFFF
       vmovaps   xmm6,[rsp+60]
       vmovaps   xmm7,[rsp+50]
       vmovaps   xmm8,[rsp+40]
       vmovaps   xmm9,[rsp+30]
       vzeroupper
       add       rsp,78
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r12
       pop       r13
       pop       r14
       pop       r15
       ret
M01_L01:
       lea       ecx,[r13-10]
       test      ecx,ecx
       jl        near ptr M01_L17
       movsxd    r12,ebp
       movzx     eax,word ptr [rbx+r12*2]
       cmp       eax,r15d
       je        near ptr M01_L14
M01_L02:
       vmovd     xmm6,r15d
       vpbroadcastw ymm6,xmm6
       vmovd     xmm7,eax
       vpbroadcastw ymm7,xmm7
       movsxd    rbp,r13d
       add       rbp,0FFFFFFFFFFFFFFF0
M01_L03:
       vpcmpeqw  ymm0,ymm6,[rdi+r14*2]
       lea       rcx,[r14+r12]
       vpcmpeqw  ymm1,ymm7,[rdi+rcx*2]
       vpand     ymm0,ymm0,ymm1
       vptest    ymm0,ymm0
       je        near ptr M01_L15
       vpmovmskb r15d,ymm0
M01_L04:
       xor       ecx,ecx
       tzcnt     ecx,r15d
       shr       ecx,1
       mov       eax,ecx
       mov       [rsp+28],rax
       cmp       esi,2
       je        short M01_L05
       lea       rcx,[r14+rax]
       lea       rcx,[rdi+rcx*2]
       mov       r8d,esi
       add       r8,r8
       mov       rdx,rbx
       vextractf128 xmm8,ymm6,1
       vextractf128 xmm9,ymm7,1
       call      qword ptr [7FFBFDAB5068]; System.SpanHelpers.SequenceEqual(Byte ByRef, Byte ByRef, UIntPtr)
       test      eax,eax
       vinsertf128 ymm6,ymm6,xmm8,1
       vinsertf128 ymm7,ymm7,xmm9,1
       mov       rax,[rsp+28]
       je        near ptr M01_L16
M01_L05:
       add       eax,r14d
M01_L06:
       vmovaps   xmm6,[rsp+60]
       vmovaps   xmm7,[rsp+50]
       vmovaps   xmm8,[rsp+40]
       vmovaps   xmm9,[rsp+30]
       vzeroupper
       add       rsp,78
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r12
       pop       r13
       pop       r14
       pop       r15
       ret
M01_L07:
       xor       eax,eax
       vmovaps   xmm6,[rsp+60]
       vmovaps   xmm7,[rsp+50]
       vmovaps   xmm8,[rsp+40]
       vmovaps   xmm9,[rsp+30]
       vzeroupper
       add       rsp,78
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r12
       pop       r13
       pop       r14
       pop       r15
       ret
M01_L08:
       movsx     rdx,word ptr [rbx]
       movzx     ecx,dx
       dec       ecx
       cmp       ecx,0FE
       jae       short M01_L09
       movzx     edx,dx
       movsx     rdx,dx
       mov       rcx,rdi
       call      qword ptr [7FFBFDB7DE00]
       jmp       short M01_L10
M01_L09:
       mov       rcx,rdi
       call      qword ptr [7FFBFDE16B98]
M01_L10:
       jmp       near ptr M01_L06
M01_L11:
       lea       rcx,[rdi+r14*2]
       movsx     rdx,r15w
       mov       r8d,r13d
       call      qword ptr [7FFBFDE16B98]
       test      eax,eax
       jl        near ptr M01_L00
       sub       r13d,eax
       movsxd    rcx,eax
       add       r14,rcx
       test      r13d,r13d
       jle       near ptr M01_L00
       lea       rcx,[rdi+r14*2+2]
       mov       r8d,ebp
       add       r8,r8
       mov       rdx,rbx
       call      qword ptr [7FFBFDAB5068]; System.SpanHelpers.SequenceEqual(Byte ByRef, Byte ByRef, UIntPtr)
       test      eax,eax
       je        short M01_L12
       mov       eax,r14d
       jmp       near ptr M01_L06
M01_L12:
       dec       r13d
       inc       r14
       test      r13d,r13d
       jg        short M01_L11
       jmp       near ptr M01_L00
M01_L13:
       dec       r12
       movzx     eax,word ptr [rbx+r12*2]
       cmp       eax,r15d
       jne       near ptr M01_L02
M01_L14:
       cmp       r12,1
       jg        short M01_L13
       jmp       near ptr M01_L02
M01_L15:
       add       r14,10
       movsxd    rcx,r13d
       cmp       r14,rcx
       je        near ptr M01_L00
       cmp       r14,rbp
       jle       near ptr M01_L03
       mov       r14,rbp
       jmp       near ptr M01_L03
M01_L16:
       blsr      ecx,r15d
       blsr      r15d,ecx
       jne       near ptr M01_L04
       jmp       short M01_L15
M01_L17:
       movsxd    r12,ebp
       movzx     ecx,word ptr [rbx+r12*2]
       mov       rbp,r12
       jmp       short M01_L19
M01_L18:
       dec       rbp
       movzx     ecx,word ptr [rbx+rbp*2]
M01_L19:
       cmp       ecx,r15d
       jne       short M01_L20
       cmp       rbp,1
       jg        short M01_L18
M01_L20:
       vmovd     xmm6,r15d
       vpbroadcastw xmm6,xmm6
       vmovd     xmm7,ecx
       vpbroadcastw xmm7,xmm7
       movsxd    r15,r13d
       add       r15,0FFFFFFFFFFFFFFF8
M01_L21:
       vpcmpeqw  xmm0,xmm6,[rdi+r14*2]
       lea       rcx,[r14+rbp]
       vpcmpeqw  xmm1,xmm7,[rdi+rcx*2]
       vpand     xmm0,xmm0,xmm1
       vptest    xmm0,xmm0
       jne       short M01_L23
M01_L22:
       add       r14,8
       movsxd    rcx,r13d
       cmp       r14,rcx
       je        near ptr M01_L00
       cmp       r14,r15
       jle       short M01_L21
       mov       r14,r15
       jmp       short M01_L21
M01_L23:
       vpmovmskb r12d,xmm0
M01_L24:
       xor       ecx,ecx
       tzcnt     ecx,r12d
       shr       ecx,1
       mov       eax,ecx
       mov       [rsp+20],rax
       cmp       esi,2
       je        short M01_L25
       lea       rcx,[r14+rax]
       lea       rcx,[rdi+rcx*2]
       mov       r8d,esi
       add       r8,r8
       mov       rdx,rbx
       call      qword ptr [7FFBFDAB5068]; System.SpanHelpers.SequenceEqual(Byte ByRef, Byte ByRef, UIntPtr)
       test      eax,eax
       mov       rax,[rsp+20]
       je        short M01_L26
M01_L25:
       add       eax,r14d
       jmp       near ptr M01_L06
M01_L26:
       blsr      eax,r12d
       blsr      r12d,eax
       jne       short M01_L24
       jmp       short M01_L22
; Total bytes of code 825
```

## .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.OrdinalIgnoreCase()
       push      rdi
       push      rsi
       push      rbx
       sub       rsp,40
       vxorps    xmm4,xmm4,xmm4
       vmovdqa   xmmword ptr [rsp+20],xmm4
       vmovdqa   xmmword ptr [rsp+30],xmm4
       mov       rbx,[rcx+8]
       xor       esi,esi
       mov       edi,[rbx+8]
       test      edi,edi
       jle       short M00_L02
M00_L00:
       mov       ecx,esi
       mov       rcx,[rbx+rcx*8+10]
       mov       edx,[rcx+8]
       add       rcx,0C
       mov       rax,26F0020AAB4
       mov       [rsp+30],rcx
       mov       [rsp+38],edx
       mov       [rsp+20],rax
       mov       dword ptr [rsp+28],7
       lea       rcx,[rsp+30]
       lea       rdx,[rsp+20]
       call      qword ptr [7FFBFDE6D410]; System.Globalization.Ordinal.IndexOfOrdinalIgnoreCase(System.ReadOnlySpan`1<Char>, System.ReadOnlySpan`1<Char>)
       test      eax,eax
       jge       short M00_L01
       inc       esi
       cmp       edi,esi
       jle       short M00_L02
       jmp       short M00_L00
M00_L01:
       mov       eax,esi
       add       rsp,40
       pop       rbx
       pop       rsi
       pop       rdi
       ret
M00_L02:
       mov       eax,0FFFFFFFF
       add       rsp,40
       pop       rbx
       pop       rsi
       pop       rdi
       ret
; Total bytes of code 133
```
```assembly
; System.Globalization.Ordinal.IndexOfOrdinalIgnoreCase(System.ReadOnlySpan`1<Char>, System.ReadOnlySpan`1<Char>)
       push      r15
       push      r14
       push      r13
       push      r12
       push      rdi
       push      rsi
       push      rbp
       push      rbx
       sub       rsp,98
       vzeroupper
       vmovaps   [rsp+80],xmm6
       vmovaps   [rsp+70],xmm7
       vmovaps   [rsp+60],xmm8
       vmovaps   [rsp+50],xmm9
       vxorps    xmm4,xmm4,xmm4
       vmovdqa   xmmword ptr [rsp+20],xmm4
       vmovdqa   xmmword ptr [rsp+30],xmm4
       mov       rbx,[rdx]
       mov       esi,[rdx+8]
       mov       rdi,[rcx]
       mov       ebp,[rcx+8]
       test      esi,esi
       je        near ptr M01_L12
       cmp       esi,ebp
       jle       short M01_L03
M01_L00:
       mov       eax,0FFFFFFFF
       vmovaps   xmm6,[rsp+80]
       vmovaps   xmm7,[rsp+70]
       vmovaps   xmm8,[rsp+60]
       vmovaps   xmm9,[rsp+50]
       vzeroupper
       add       rsp,98
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r12
       pop       r13
       pop       r14
       pop       r15
       ret
M01_L01:
       vpmovmskb r13d,ymm0
M01_L02:
       xor       ecx,ecx
       tzcnt     ecx,r13d
       shr       ecx,1
       mov       r15d,ecx
       mov       [rsp+48],rax
       lea       rcx,[rax+r15]
       lea       rcx,[rdi+rcx*2]
       mov       edx,esi
       cmp       edx,8
       jge       near ptr M01_L11
       jmp       near ptr M01_L10
M01_L03:
       mov       r14,rbx
       movzx     r15d,word ptr [r14]
       cmp       r15d,7F
       ja        near ptr M01_L13
       lea       r13d,[rsi-1]
       sub       ebp,r13d
       xor       r12d,r12d
       xor       ebx,ebx
       xor       r10d,r10d
       xor       eax,eax
       test      r13d,r13d
       je        near ptr M01_L14
       cmp       ebp,8
       jl        near ptr M01_L14
       movsxd    r12,r13d
       movzx     ecx,word ptr [r14+r12*2]
       cmp       ecx,7F
       ja        short M01_L06
       or        r15d,20
       movzx     r15d,r15w
       or        ecx,20
       movzx     ecx,cx
       mov       r13d,ecx
       cmp       r13d,r15d
       je        near ptr M01_L25
M01_L04:
       lea       ecx,[rbp-10]
       test      ecx,ecx
       jl        near ptr M01_L28
       vmovd     xmm6,r15d
       vpbroadcastw ymm6,xmm6
       vmovd     xmm7,r13d
       vpbroadcastw ymm7,xmm7
       movsxd    rbx,ebp
       add       rbx,0FFFFFFFFFFFFFFF0
M01_L05:
       vmovups   ymm0,[rdi+rax*2]
       vpor      ymm0,ymm0,[7FFBFDA58540]
       vpcmpeqw  ymm0,ymm6,ymm0
       lea       rcx,[rax+r12]
       vmovups   ymm1,[rdi+rcx*2]
       vpor      ymm1,ymm1,[7FFBFDA58540]
       vpcmpeqw  ymm1,ymm7,ymm1
       vpand     ymm0,ymm0,ymm1
       vptest    ymm0,ymm0
       je        near ptr M01_L26
       jmp       near ptr M01_L01
M01_L06:
       mov       r12d,ecx
       jmp       near ptr M01_L14
M01_L07:
       mov       r13,[rsp+48]
       lea       eax,[r15+r13]
       jmp       short M01_L09
M01_L08:
       test      eax,eax
       je        near ptr M01_L27
       jmp       short M01_L07
M01_L09:
       vmovaps   xmm6,[rsp+80]
       vmovaps   xmm7,[rsp+70]
       vmovaps   xmm8,[rsp+60]
       vmovaps   xmm9,[rsp+50]
       vzeroupper
       add       rsp,98
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r12
       pop       r13
       pop       r14
       pop       r15
       ret
M01_L10:
       mov       rdx,r14
       mov       r8d,esi
       vextractf128 xmm8,ymm6,1
       vextractf128 xmm9,ymm7,1
       call      qword ptr [7FFBFDE6D3E0]; System.Globalization.Ordinal.EqualsIgnoreCase_Scalar(Char ByRef, Char ByRef, Int32)
       vinsertf128 ymm6,ymm6,xmm8,1
       vinsertf128 ymm7,ymm7,xmm9,1
       jmp       short M01_L08
M01_L11:
       mov       rdx,r14
       mov       r8d,esi
       vextractf128 xmm8,ymm6,1
       vextractf128 xmm9,ymm7,1
       call      qword ptr [7FFBFDE6D3B0]
       vinsertf128 ymm6,ymm6,xmm8,1
       vinsertf128 ymm7,ymm7,xmm9,1
       jmp       near ptr M01_L08
M01_L12:
       xor       eax,eax
       vmovaps   xmm6,[rsp+80]
       vmovaps   xmm7,[rsp+70]
       vmovaps   xmm8,[rsp+60]
       vmovaps   xmm9,[rsp+50]
       vzeroupper
       add       rsp,98
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r12
       pop       r13
       pop       r14
       pop       r15
       ret
M01_L13:
       mov       [rsp+30],rdi
       mov       [rsp+38],ebp
       mov       [rsp+20],rbx
       mov       [rsp+28],esi
       lea       rcx,[rsp+30]
       lea       rdx,[rsp+20]
       call      qword ptr [7FFBFDE9C678]
       jmp       near ptr M01_L09
M01_L14:
       mov       edx,r15d
       or        edx,20
       add       edx,0FFFFFF9F
       cmp       edx,19
       ja        short M01_L15
       mov       r10d,r15d
       and       r10d,0FFFFFFDF
       movzx     r12d,r10w
       mov       edx,r15d
       or        edx,20
       movzx     ebx,dx
       mov       r10d,1
M01_L15:
       mov       [rsp+44],r10d
       test      r10d,r10d
       jne       short M01_L18
       mov       [rsp+48],rax
       lea       rcx,[rdi+rax*2]
       movsx     rdx,r15w
       movzx     r8d,dx
       dec       r8d
       cmp       r8d,0FE
       jae       short M01_L16
       movzx     edx,dx
       movsx     rdx,dx
       mov       r8d,ebp
       call      qword ptr [7FFBFDB9DE00]
       jmp       short M01_L17
M01_L16:
       mov       r8d,ebp
       call      qword ptr [7FFBFDE36B98]
M01_L17:
       jmp       short M01_L19
M01_L18:
       mov       [rsp+48],rax
       lea       rcx,[rdi+rax*2]
       movsx     rdx,r12w
       movsx     r8,bx
       mov       r9d,ebp
       call      qword ptr [7FFBFDCBD380]
M01_L19:
       test      eax,eax
       jl        near ptr M01_L00
       mov       rsi,[rsp+48]
       mov       r10d,[rsp+44]
       sub       ebp,eax
       test      ebp,ebp
       mov       [rsp+44],r10d
       jle       near ptr M01_L00
       movsxd    rcx,eax
       add       rsi,rcx
       test      r13d,r13d
       je        short M01_L22
       lea       rcx,[rdi+rsi*2+2]
       lea       rdx,[r14+2]
       cmp       r13d,8
       jge       short M01_L20
       mov       r8d,r13d
       call      qword ptr [7FFBFDE6D3E0]; System.Globalization.Ordinal.EqualsIgnoreCase_Scalar(Char ByRef, Char ByRef, Int32)
       jmp       short M01_L21
M01_L20:
       mov       r8d,r13d
       call      qword ptr [7FFBFDE6D3B0]
M01_L21:
       test      eax,eax
       je        short M01_L23
M01_L22:
       mov       eax,esi
       jmp       near ptr M01_L09
M01_L23:
       dec       ebp
       inc       rsi
       test      ebp,ebp
       mov       rax,rsi
       mov       r10d,[rsp+44]
       jg        near ptr M01_L15
       jmp       near ptr M01_L00
M01_L24:
       movzx     ecx,word ptr [r14+r12*2-2]
       cmp       ecx,7F
       ja        near ptr M01_L04
       dec       r12
       or        ecx,20
       movzx     r13d,cx
       cmp       r13d,r15d
       jne       near ptr M01_L04
M01_L25:
       cmp       r12,1
       jg        short M01_L24
       jmp       near ptr M01_L04
M01_L26:
       add       rax,10
       movsxd    rcx,ebp
       cmp       rax,rcx
       je        near ptr M01_L00
       cmp       rax,rbx
       jle       near ptr M01_L05
       mov       rax,rbx
       jmp       near ptr M01_L05
M01_L27:
       blsr      ecx,r13d
       blsr      r13d,ecx
       mov       rax,[rsp+48]
       jne       near ptr M01_L02
       jmp       short M01_L26
M01_L28:
       vmovd     xmm6,r15d
       vpbroadcastw xmm6,xmm6
       vmovd     xmm7,r13d
       vpbroadcastw xmm7,xmm7
       movsxd    r15,ebp
       add       r15,0FFFFFFFFFFFFFFF8
M01_L29:
       vmovups   xmm0,[rdi+rax*2]
       vpor      xmm0,xmm0,[7FFBFDA58540]
       vpcmpeqw  xmm0,xmm6,xmm0
       lea       rcx,[rax+r12]
       vmovups   xmm1,[rdi+rcx*2]
       vpor      xmm1,xmm1,[7FFBFDA58540]
       vpcmpeqw  xmm1,xmm7,xmm1
       vpand     xmm0,xmm0,xmm1
       vptest    xmm0,xmm0
       jne       short M01_L31
M01_L30:
       add       rax,8
       movsxd    rcx,ebp
       cmp       rax,rcx
       je        near ptr M01_L00
       cmp       rax,r15
       jle       short M01_L29
       mov       rax,r15
       jmp       short M01_L29
M01_L31:
       vpmovmskb r13d,xmm0
M01_L32:
       xor       ecx,ecx
       tzcnt     ecx,r13d
       shr       ecx,1
       mov       ebx,ecx
       mov       [rsp+48],rax
       lea       rcx,[rax+rbx]
       lea       rcx,[rdi+rcx*2]
       mov       edx,esi
       cmp       edx,8
       jge       short M01_L33
       mov       rdx,r14
       mov       r8d,esi
       call      qword ptr [7FFBFDE6D3E0]; System.Globalization.Ordinal.EqualsIgnoreCase_Scalar(Char ByRef, Char ByRef, Int32)
       jmp       short M01_L34
M01_L33:
       mov       rdx,r14
       mov       r8d,esi
       call      qword ptr [7FFBFDE6D3B0]
M01_L34:
       test      eax,eax
       je        short M01_L35
       mov       rsi,[rsp+48]
       lea       eax,[rsi+rbx]
       jmp       near ptr M01_L09
M01_L35:
       blsr      eax,r13d
       blsr      r13d,eax
       mov       rax,[rsp+48]
       jne       short M01_L32
       jmp       short M01_L30
; Total bytes of code 1175
```

## .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.OrdinalLongStrings()
       push      rdi
       push      rsi
       push      rbx
       sub       rsp,20
       mov       rbx,[rcx+10]
       xor       esi,esi
       mov       edi,[rbx+8]
       test      edi,edi
       jle       short M00_L02
M00_L00:
       mov       ecx,esi
       mov       rcx,[rbx+rcx*8+10]
       mov       edx,[rcx+8]
       add       rcx,0C
       mov       r8,28E8020AAB4
       mov       r9d,7
       call      qword ptr [7FFBFDAF51A0]; System.SpanHelpers.IndexOf(Char ByRef, Int32, Char ByRef, Int32)
       test      eax,eax
       jge       short M00_L01
       inc       esi
       cmp       edi,esi
       jle       short M00_L02
       jmp       short M00_L00
M00_L01:
       mov       eax,esi
       add       rsp,20
       pop       rbx
       pop       rsi
       pop       rdi
       ret
M00_L02:
       mov       eax,0FFFFFFFF
       add       rsp,20
       pop       rbx
       pop       rsi
       pop       rdi
       ret
; Total bytes of code 91
```
```assembly
; System.SpanHelpers.IndexOf(Char ByRef, Int32, Char ByRef, Int32)
       push      r15
       push      r14
       push      r13
       push      r12
       push      rdi
       push      rsi
       push      rbp
       push      rbx
       sub       rsp,78
       vzeroupper
       vmovaps   [rsp+60],xmm6
       vmovaps   [rsp+50],xmm7
       vmovaps   [rsp+40],xmm8
       vmovaps   [rsp+30],xmm9
       mov       rbx,rcx
       mov       rdi,r8
       mov       esi,r9d
       mov       r8d,edx
       test      esi,esi
       je        near ptr M01_L08
       lea       ebp,[rsi-1]
       test      ebp,ebp
       je        near ptr M01_L09
       xor       r14d,r14d
       movzx     r15d,word ptr [rdi]
       sub       r8d,ebp
       mov       r13d,r8d
       cmp       r13d,8
       jl        near ptr M01_L12
       lea       ecx,[r13-10]
       test      ecx,ecx
       jl        near ptr M01_L18
       movsxd    r12,ebp
       movzx     eax,word ptr [rdi+r12*2]
       cmp       eax,r15d
       je        near ptr M01_L16
M01_L00:
       vmovd     xmm6,r15d
       vpbroadcastw ymm6,xmm6
       vmovd     xmm7,eax
       vpbroadcastw ymm7,xmm7
       movsxd    rbp,r13d
       lea       r15,[rbp-10]
M01_L01:
       vpcmpeqw  ymm0,ymm6,[rbx+r14*2]
       lea       rcx,[r14+r12]
       vpcmpeqw  ymm1,ymm7,[rbx+rcx*2]
       vpand     ymm0,ymm0,ymm1
       vptest    ymm0,ymm0
       jne       short M01_L04
M01_L02:
       add       r14,10
       cmp       r14,rbp
       je        short M01_L03
       cmp       r14,r15
       jle       short M01_L01
       mov       r14,r15
       jmp       short M01_L01
M01_L03:
       mov       eax,0FFFFFFFF
       vmovaps   xmm6,[rsp+60]
       vmovaps   xmm7,[rsp+50]
       vmovaps   xmm8,[rsp+40]
       vmovaps   xmm9,[rsp+30]
       vzeroupper
       add       rsp,78
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r12
       pop       r13
       pop       r14
       pop       r15
       ret
M01_L04:
       vpmovmskb r13d,ymm0
M01_L05:
       xor       ecx,ecx
       tzcnt     ecx,r13d
       shr       ecx,1
       mov       eax,ecx
       mov       [rsp+28],rax
       cmp       esi,2
       je        short M01_L06
       lea       rcx,[r14+rax]
       lea       rcx,[rbx+rcx*2]
       mov       r8d,esi
       add       r8,r8
       mov       rdx,rdi
       vextractf128 xmm8,ymm6,1
       vextractf128 xmm9,ymm7,1
       call      qword ptr [7FFBFDAF5068]; System.SpanHelpers.SequenceEqual(Byte ByRef, Byte ByRef, UIntPtr)
       test      eax,eax
       vinsertf128 ymm6,ymm6,xmm8,1
       vinsertf128 ymm7,ymm7,xmm9,1
       mov       rax,[rsp+28]
       je        near ptr M01_L17
M01_L06:
       add       eax,r14d
M01_L07:
       vmovaps   xmm6,[rsp+60]
       vmovaps   xmm7,[rsp+50]
       vmovaps   xmm8,[rsp+40]
       vmovaps   xmm9,[rsp+30]
       vzeroupper
       add       rsp,78
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r12
       pop       r13
       pop       r14
       pop       r15
       ret
M01_L08:
       xor       eax,eax
       vmovaps   xmm6,[rsp+60]
       vmovaps   xmm7,[rsp+50]
       vmovaps   xmm8,[rsp+40]
       vmovaps   xmm9,[rsp+30]
       vzeroupper
       add       rsp,78
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r12
       pop       r13
       pop       r14
       pop       r15
       ret
M01_L09:
       movsx     rdx,word ptr [rdi]
       movzx     ecx,dx
       dec       ecx
       cmp       ecx,0FE
       jae       short M01_L10
       movzx     edx,dx
       movsx     rdx,dx
       mov       rcx,rbx
       call      qword ptr [7FFBFDBBDE00]
       jmp       short M01_L11
M01_L10:
       mov       rcx,rbx
       call      qword ptr [7FFBFDE56B98]
M01_L11:
       jmp       near ptr M01_L07
M01_L12:
       add       rdi,2
       test      r13d,r13d
       jle       near ptr M01_L03
M01_L13:
       lea       rcx,[rbx+r14*2]
       movsx     rdx,r15w
       mov       r8d,r13d
       call      qword ptr [7FFBFDE56B98]
       test      eax,eax
       jl        near ptr M01_L03
       sub       r13d,eax
       movsxd    rcx,eax
       add       r14,rcx
       test      r13d,r13d
       jle       near ptr M01_L03
       lea       rcx,[rbx+r14*2+2]
       mov       r8d,ebp
       add       r8,r8
       mov       rdx,rdi
       call      qword ptr [7FFBFDAF5068]; System.SpanHelpers.SequenceEqual(Byte ByRef, Byte ByRef, UIntPtr)
       test      eax,eax
       je        short M01_L14
       mov       eax,r14d
       jmp       near ptr M01_L07
M01_L14:
       dec       r13d
       inc       r14
       test      r13d,r13d
       jg        short M01_L13
       jmp       near ptr M01_L03
M01_L15:
       dec       r12
       movzx     eax,word ptr [rdi+r12*2]
       cmp       eax,r15d
       jne       near ptr M01_L00
M01_L16:
       cmp       r12,1
       jg        short M01_L15
       jmp       near ptr M01_L00
M01_L17:
       blsr      ecx,r13d
       blsr      r13d,ecx
       jne       near ptr M01_L05
       jmp       near ptr M01_L02
M01_L18:
       movsxd    r12,ebp
       movzx     ecx,word ptr [rdi+r12*2]
       mov       rbp,r12
       jmp       short M01_L20
M01_L19:
       dec       rbp
       movzx     ecx,word ptr [rdi+rbp*2]
M01_L20:
       cmp       ecx,r15d
       jne       short M01_L21
       cmp       rbp,1
       jg        short M01_L19
M01_L21:
       vmovd     xmm6,r15d
       vpbroadcastw xmm6,xmm6
       vmovd     xmm7,ecx
       vpbroadcastw xmm7,xmm7
       movsxd    rcx,r13d
       mov       r15,rcx
       lea       r13,[r15-8]
M01_L22:
       vpcmpeqw  xmm0,xmm6,[rbx+r14*2]
       lea       rcx,[r14+rbp]
       vpcmpeqw  xmm1,xmm7,[rbx+rcx*2]
       vpand     xmm0,xmm0,xmm1
       vptest    xmm0,xmm0
       jne       short M01_L24
M01_L23:
       add       r14,8
       cmp       r14,r15
       je        near ptr M01_L03
       mov       rax,rbp
       mov       rbp,r15
       mov       r15,rax
       cmp       r14,r13
       mov       rax,rbp
       mov       rbp,r15
       mov       r15,rax
       jle       short M01_L22
       mov       r14,r13
       jmp       short M01_L22
M01_L24:
       vpmovmskb r12d,xmm0
M01_L25:
       xor       ecx,ecx
       tzcnt     ecx,r12d
       shr       ecx,1
       mov       eax,ecx
       mov       [rsp+20],rax
       cmp       esi,2
       je        short M01_L26
       lea       rcx,[r14+rax]
       lea       rcx,[rbx+rcx*2]
       mov       r8d,esi
       add       r8,r8
       mov       rdx,rdi
       call      qword ptr [7FFBFDAF5068]; System.SpanHelpers.SequenceEqual(Byte ByRef, Byte ByRef, UIntPtr)
       test      eax,eax
       mov       rax,[rsp+20]
       je        short M01_L27
M01_L26:
       add       eax,r14d
       jmp       near ptr M01_L07
M01_L27:
       blsr      eax,r12d
       blsr      r12d,eax
       jne       short M01_L25
       jmp       short M01_L23
; Total bytes of code 832
```

## .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.OrdinalIgnoreCaseLongStrings()
       push      rdi
       push      rsi
       push      rbx
       sub       rsp,40
       vxorps    xmm4,xmm4,xmm4
       vmovdqa   xmmword ptr [rsp+20],xmm4
       vmovdqa   xmmword ptr [rsp+30],xmm4
       mov       rbx,[rcx+10]
       xor       esi,esi
       mov       edi,[rbx+8]
       test      edi,edi
       jle       short M00_L02
M00_L00:
       mov       ecx,esi
       mov       rcx,[rbx+rcx*8+10]
       mov       edx,[rcx+8]
       add       rcx,0C
       mov       rax,2568030AAB4
       mov       [rsp+30],rcx
       mov       [rsp+38],edx
       mov       [rsp+20],rax
       mov       dword ptr [rsp+28],7
       lea       rcx,[rsp+30]
       lea       rdx,[rsp+20]
       call      qword ptr [7FFBFDE8D410]; System.Globalization.Ordinal.IndexOfOrdinalIgnoreCase(System.ReadOnlySpan`1<Char>, System.ReadOnlySpan`1<Char>)
       test      eax,eax
       jge       short M00_L01
       inc       esi
       cmp       edi,esi
       jle       short M00_L02
       jmp       short M00_L00
M00_L01:
       mov       eax,esi
       add       rsp,40
       pop       rbx
       pop       rsi
       pop       rdi
       ret
M00_L02:
       mov       eax,0FFFFFFFF
       add       rsp,40
       pop       rbx
       pop       rsi
       pop       rdi
       ret
; Total bytes of code 133
```
```assembly
; System.Globalization.Ordinal.IndexOfOrdinalIgnoreCase(System.ReadOnlySpan`1<Char>, System.ReadOnlySpan`1<Char>)
       push      r15
       push      r14
       push      r13
       push      r12
       push      rdi
       push      rsi
       push      rbp
       push      rbx
       sub       rsp,98
       vzeroupper
       vmovaps   [rsp+80],xmm6
       vmovaps   [rsp+70],xmm7
       vmovaps   [rsp+60],xmm8
       vmovaps   [rsp+50],xmm9
       vxorps    xmm4,xmm4,xmm4
       vmovdqa   xmmword ptr [rsp+20],xmm4
       vmovdqa   xmmword ptr [rsp+30],xmm4
       mov       rbx,[rdx]
       mov       esi,[rdx+8]
       mov       rdi,[rcx]
       mov       ebp,[rcx+8]
       test      esi,esi
       je        near ptr M01_L09
       cmp       esi,ebp
       jg        near ptr M01_L03
       mov       r14,rbx
       movzx     r15d,word ptr [r14]
       cmp       r15d,7F
       ja        near ptr M01_L10
       lea       r13d,[rsi-1]
       sub       ebp,r13d
       xor       r12d,r12d
       xor       ebx,ebx
       xor       ecx,ecx
       xor       eax,eax
       test      r13d,r13d
       je        near ptr M01_L11
       cmp       ebp,8
       jl        near ptr M01_L11
       movsxd    rdx,r13d
       movzx     r12d,word ptr [r14+rdx*2]
       cmp       r12d,7F
       ja        near ptr M01_L11
       or        r15d,20
       movzx     r15d,r15w
       or        r12d,20
       movzx     r12d,r12w
       movsxd    r13,r13d
       cmp       r12d,r15d
       je        near ptr M01_L22
M01_L00:
       lea       edx,[rbp-10]
       test      edx,edx
       jl        near ptr M01_L24
       vmovd     xmm6,r15d
       vpbroadcastw ymm6,xmm6
       vmovd     xmm7,r12d
       vpbroadcastw ymm7,xmm7
       movsxd    rbp,ebp
       lea       rbx,[rbp-10]
M01_L01:
       vmovups   ymm0,[7FFBFDA78520]
       vpor      ymm1,ymm0,[rdi+rcx*2]
       vpcmpeqw  ymm1,ymm6,ymm1
       lea       rdx,[rcx+r13]
       vpor      ymm0,ymm0,[rdi+rdx*2]
       vpcmpeqw  ymm0,ymm7,ymm0
       vpand     ymm0,ymm1,ymm0
       vptest    ymm0,ymm0
       jne       short M01_L04
M01_L02:
       add       rcx,10
       cmp       rcx,rbp
       je        short M01_L03
       cmp       rcx,rbx
       jle       short M01_L01
       mov       rcx,rbx
       jmp       short M01_L01
M01_L03:
       mov       eax,0FFFFFFFF
       vmovaps   xmm6,[rsp+80]
       vmovaps   xmm7,[rsp+70]
       vmovaps   xmm8,[rsp+60]
       vmovaps   xmm9,[rsp+50]
       vzeroupper
       add       rsp,98
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r12
       pop       r13
       pop       r14
       pop       r15
       ret
M01_L04:
       vpmovmskb r12d,ymm0
M01_L05:
       xor       edx,edx
       tzcnt     edx,r12d
       shr       edx,1
       mov       r15d,edx
       mov       [rsp+48],rcx
       lea       rdx,[rcx+r15]
       lea       rax,[rdi+rdx*2]
       mov       edx,esi
       cmp       edx,8
       jge       short M01_L07
       mov       rcx,rax
       mov       rdx,r14
       mov       r8d,esi
       vextractf128 xmm8,ymm6,1
       vextractf128 xmm9,ymm7,1
       call      qword ptr [7FFBFDE8D3E0]; System.Globalization.Ordinal.EqualsIgnoreCase_Scalar(Char ByRef, Char ByRef, Int32)
       vinsertf128 ymm6,ymm6,xmm8,1
       vinsertf128 ymm7,ymm7,xmm9,1
M01_L06:
       test      eax,eax
       je        near ptr M01_L23
       mov       rbx,[rsp+48]
       lea       eax,[rbx+r15]
       jmp       short M01_L08
M01_L07:
       mov       rcx,rax
       mov       rdx,r14
       mov       r8d,esi
       vextractf128 xmm8,ymm6,1
       vextractf128 xmm9,ymm7,1
       call      qword ptr [7FFBFDE8D3B0]
       vinsertf128 ymm6,ymm6,xmm8,1
       vinsertf128 ymm7,ymm7,xmm9,1
       jmp       short M01_L06
M01_L08:
       vmovaps   xmm6,[rsp+80]
       vmovaps   xmm7,[rsp+70]
       vmovaps   xmm8,[rsp+60]
       vmovaps   xmm9,[rsp+50]
       vzeroupper
       add       rsp,98
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r12
       pop       r13
       pop       r14
       pop       r15
       ret
M01_L09:
       xor       eax,eax
       vmovaps   xmm6,[rsp+80]
       vmovaps   xmm7,[rsp+70]
       vmovaps   xmm8,[rsp+60]
       vmovaps   xmm9,[rsp+50]
       vzeroupper
       add       rsp,98
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r12
       pop       r13
       pop       r14
       pop       r15
       ret
M01_L10:
       mov       [rsp+30],rdi
       mov       [rsp+38],ebp
       mov       [rsp+20],rbx
       mov       [rsp+28],esi
       lea       rcx,[rsp+30]
       lea       rdx,[rsp+20]
       call      qword ptr [7FFBFDEBC678]
       jmp       near ptr M01_L08
M01_L11:
       mov       edx,r15d
       or        edx,20
       add       edx,0FFFFFF9F
       cmp       edx,19
       ja        short M01_L12
       mov       eax,r15d
       and       eax,0FFFFFFDF
       movzx     r12d,ax
       mov       edx,r15d
       or        edx,20
       movzx     ebx,dx
       mov       eax,1
M01_L12:
       mov       [rsp+44],eax
       test      eax,eax
       jne       short M01_L15
       mov       [rsp+48],rcx
       lea       r10,[rdi+rcx*2]
       movsx     rdx,r15w
       movzx     r8d,dx
       dec       r8d
       cmp       r8d,0FE
       jae       short M01_L13
       movzx     edx,dx
       movsx     rdx,dx
       mov       rcx,r10
       mov       r8d,ebp
       call      qword ptr [7FFBFDBBDE00]
       jmp       short M01_L14
M01_L13:
       mov       rcx,r10
       mov       r8d,ebp
       call      qword ptr [7FFBFDE56B98]
M01_L14:
       jmp       short M01_L16
M01_L15:
       mov       [rsp+48],rcx
       lea       rcx,[rdi+rcx*2]
       movsx     rdx,r12w
       movsx     r8,bx
       mov       r9d,ebp
       call      qword ptr [7FFBFDCDD380]
M01_L16:
       test      eax,eax
       jl        near ptr M01_L03
       mov       rcx,[rsp+48]
       mov       esi,[rsp+44]
       sub       ebp,eax
       test      ebp,ebp
       jle       near ptr M01_L03
       movsxd    rdx,eax
       add       rcx,rdx
       test      r13d,r13d
       je        short M01_L19
       mov       [rsp+48],rcx
       lea       rax,[rdi+rcx*2+2]
       lea       rdx,[r14+2]
       cmp       r13d,8
       jge       short M01_L17
       mov       rcx,rax
       mov       r8d,r13d
       call      qword ptr [7FFBFDE8D3E0]; System.Globalization.Ordinal.EqualsIgnoreCase_Scalar(Char ByRef, Char ByRef, Int32)
       jmp       short M01_L18
M01_L17:
       mov       rcx,rax
       mov       r8d,r13d
       call      qword ptr [7FFBFDE8D3B0]
M01_L18:
       test      eax,eax
       mov       rcx,[rsp+48]
       je        short M01_L20
M01_L19:
       mov       eax,ecx
       jmp       near ptr M01_L08
M01_L20:
       dec       ebp
       inc       rcx
       test      ebp,ebp
       mov       eax,esi
       jg        near ptr M01_L12
       jmp       near ptr M01_L03
M01_L21:
       movzx     edx,word ptr [r14+r13*2-2]
       cmp       edx,7F
       ja        near ptr M01_L00
       dec       r13
       or        edx,20
       movzx     r12d,dx
       cmp       r12d,r15d
       jne       near ptr M01_L00
M01_L22:
       cmp       r13,1
       jg        short M01_L21
       jmp       near ptr M01_L00
M01_L23:
       blsr      edx,r12d
       blsr      r12d,edx
       mov       rcx,[rsp+48]
       jne       near ptr M01_L05
       jmp       near ptr M01_L02
M01_L24:
       vmovd     xmm6,r15d
       vpbroadcastw xmm6,xmm6
       vmovd     xmm7,r12d
       vpbroadcastw xmm7,xmm7
       movsxd    rbp,ebp
       lea       r15,[rbp-8]
M01_L25:
       vmovups   xmm0,[rdi+rcx*2]
       vpor      xmm0,xmm0,[7FFBFDA78520]
       vpcmpeqw  xmm0,xmm6,xmm0
       lea       rdx,[rcx+r13]
       vmovups   xmm1,[rdi+rdx*2]
       vpor      xmm1,xmm1,[7FFBFDA78520]
       vpcmpeqw  xmm1,xmm7,xmm1
       vpand     xmm0,xmm0,xmm1
       vptest    xmm0,xmm0
       jne       short M01_L27
M01_L26:
       add       rcx,8
       cmp       rcx,rbp
       je        near ptr M01_L03
       cmp       rcx,r15
       jle       short M01_L25
       mov       rcx,r15
       jmp       short M01_L25
M01_L27:
       vpmovmskb r12d,xmm0
M01_L28:
       xor       edx,edx
       tzcnt     edx,r12d
       shr       edx,1
       mov       ebx,edx
       mov       [rsp+48],rcx
       lea       rdx,[rcx+rbx]
       lea       rax,[rdi+rdx*2]
       mov       edx,esi
       cmp       edx,8
       jge       short M01_L29
       mov       rcx,rax
       mov       rdx,r14
       mov       r8d,esi
       call      qword ptr [7FFBFDE8D3E0]; System.Globalization.Ordinal.EqualsIgnoreCase_Scalar(Char ByRef, Char ByRef, Int32)
       jmp       short M01_L30
M01_L29:
       mov       rcx,rax
       mov       rdx,r14
       mov       r8d,esi
       call      qword ptr [7FFBFDE8D3B0]
M01_L30:
       test      eax,eax
       je        short M01_L31
       mov       rsi,[rsp+48]
       lea       eax,[rsi+rbx]
       jmp       near ptr M01_L08
M01_L31:
       blsr      eax,r12d
       blsr      r12d,eax
       mov       rcx,[rsp+48]
       jne       short M01_L28
       jmp       short M01_L26
; Total bytes of code 1148
```

