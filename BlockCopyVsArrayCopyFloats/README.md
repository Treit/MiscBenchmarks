# Copying array of floats using Array.Copy vs. Buffer.BlockCopy


```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method          | Count  | Mean     | Error   | StdDev  | Ratio | RatioSD | Code Size |
|---------------- |------- |---------:|--------:|--------:|------:|--------:|----------:|
| ArrayCopy       | 100000 | 286.1 μs | 3.83 μs | 3.59 μs |  1.00 |    0.02 |   1,634 B |
| BufferBlockCopy | 100000 | 283.7 μs | 4.41 μs | 4.13 μs |  0.99 |    0.02 |     794 B |

## .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.ArrayCopy()
       push      rdi
       push      rsi
       push      rbp
       push      rbx
       sub       rsp,38
       mov       rbx,[rcx+8]
       mov       edx,[rbx+8]
       mov       rcx,offset MT_System.Single[]
       call      CORINFO_HELP_NEWARR_1_VC
       mov       rsi,rax
       mov       rdi,rbx
       mov       ebx,[rbx+8]
       test      rdi,rdi
       je        near ptr M00_L12
       mov       rcx,[rdi]
       cmp       rcx,[rsi]
       jne       near ptr M00_L13
       cmp       dword ptr [rcx+4],18
       jne       near ptr M00_L13
       cmp       ebx,[rdi+8]
       ja        near ptr M00_L13
       cmp       ebx,[rsi+8]
       ja        near ptr M00_L13
       mov       r8d,ebx
       movzx     edx,word ptr [rcx]
       imul      r8,rdx
       lea       rdx,[rdi+10]
       lea       rax,[rsi+10]
       test      dword ptr [rcx],1000000
       jne       short M00_L02
       mov       rcx,rax
       mov       r10,rdx
       mov       r9,r8
       mov       r11,rcx
       sub       r11,r10
       cmp       r11,r9
       jb        near ptr M00_L11
       mov       r11,r10
       sub       r11,rcx
       cmp       r11,r9
       jb        near ptr M00_L11
       lea       r11,[r10+r9]
       lea       rdi,[rcx+r9]
       cmp       r9,10
       jbe       short M00_L04
       cmp       r9,40
       jbe       short M00_L03
       cmp       r9,800
       jbe       near ptr M00_L07
M00_L00:
       cmp       [rax],al
       mov       rcx,rax
       call      qword ptr [7FFA7E0E66E8]; System.Buffer.MemmoveInternal(Byte ByRef, Byte ByRef, UIntPtr)
M00_L01:
       mov       rax,rsi
       vzeroupper
       add       rsp,38
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       ret
M00_L02:
       mov       rcx,rax
       call      qword ptr [7FFA7E0E57A0]; System.Buffer.BulkMoveWithWriteBarrier(Byte ByRef, Byte ByRef, UIntPtr)
       jmp       short M00_L01
M00_L03:
       vmovups   xmm0,[r10]
       vmovups   [rcx],xmm0
       cmp       r9,20
       jbe       near ptr M00_L10
       vmovups   xmm0,[r10+10]
       vmovups   [rcx+10],xmm0
       cmp       r9,30
       jbe       near ptr M00_L10
       vmovups   xmm0,[r10+20]
       vmovups   [rcx+20],xmm0
       jmp       near ptr M00_L10
M00_L04:
       test      r8b,18
       je        short M00_L05
       mov       rdx,[rdx]
       mov       [rax],rdx
       mov       rax,[r11-8]
       mov       [rdi-8],rax
       jmp       short M00_L01
M00_L05:
       test      r8b,4
       je        short M00_L06
       mov       edx,[rdx]
       mov       [rax],edx
       mov       eax,[r11-4]
       mov       [rdi-4],eax
       jmp       short M00_L01
M00_L06:
       test      r8,r8
       je        short M00_L01
       movzx     edx,byte ptr [rdx]
       mov       [rax],dl
       test      r8b,2
       je        near ptr M00_L01
       movsx     rax,word ptr [r11-2]
       mov       [rdi-2],ax
       jmp       near ptr M00_L01
M00_L07:
       cmp       r9,100
       jb        short M00_L08
       mov       r10,rax
       and       r10,3F
       mov       r9,r10
       neg       r9
       add       r9,40
       vmovdqu   ymm0,ymmword ptr [rdx]
       vmovdqu   ymmword ptr [rax],ymm0
       vmovdqu   ymm0,ymmword ptr [rdx+20]
       vmovdqu   ymmword ptr [rax+20],ymm0
       lea       r10,[rdx+r9]
       lea       rcx,[rax+r9]
       sub       r8,r9
       mov       r9,r8
M00_L08:
       mov       rdx,r9
       shr       rdx,6
M00_L09:
       vmovdqu   ymm0,ymmword ptr [r10]
       vmovdqu   ymmword ptr [rcx],ymm0
       vmovdqu   ymm0,ymmword ptr [r10+20]
       vmovdqu   ymmword ptr [rcx+20],ymm0
       add       rcx,40
       add       r10,40
       dec       rdx
       jne       short M00_L09
       and       r9,3F
       cmp       r9,10
       ja        near ptr M00_L03
M00_L10:
       vmovups   xmm0,[r11-10]
       vmovups   [rdi-10],xmm0
       jmp       near ptr M00_L01
M00_L11:
       cmp       rax,rdx
       je        near ptr M00_L01
       jmp       near ptr M00_L00
M00_L12:
       xor       ebp,ebp
       jmp       short M00_L14
M00_L13:
       mov       rcx,rdi
       xor       edx,edx
       call      qword ptr [7FFA7E597D68]; System.Array.GetLowerBound(Int32)
       mov       ebp,eax
M00_L14:
       mov       rcx,rsi
       xor       edx,edx
       call      qword ptr [7FFA7E597D68]; System.Array.GetLowerBound(Int32)
       mov       r9d,eax
       mov       [rsp+20],ebx
       xor       ecx,ecx
       mov       [rsp+28],ecx
       mov       rcx,rdi
       mov       edx,ebp
       mov       r8,rsi
       call      qword ptr [7FFA7E597D08]; System.Array.CopyImpl(System.Array, Int32, System.Array, Int32, Int32, Boolean)
       jmp       near ptr M00_L01
; Total bytes of code 556
```
```assembly
; System.Buffer.MemmoveInternal(Byte ByRef, Byte ByRef, UIntPtr)
       push      rbp
       push      r15
       push      r14
       push      r13
       push      r12
       push      rdi
       push      rsi
       push      rbx
       sub       rsp,68
       vzeroupper
       lea       rbp,[rsp+0A0]
       mov       rbx,rcx
       mov       rsi,rdx
       mov       rdi,r8
       lea       rcx,[rbp-80]
       call      CORINFO_HELP_INIT_PINVOKE_FRAME
       mov       r14,rax
       mov       rcx,rsp
       mov       [rbp-68],rcx
       mov       rcx,rbp
       mov       [rbp-58],rcx
       mov       [rbp-40],rbx
       mov       [rbp-48],rsi
       mov       rcx,rbx
       mov       rdx,rsi
       mov       r8,rdi
       mov       rax,7FFA7E152518
       mov       [rbp-70],rax
       lea       rax,[M01_L00]
       mov       [rbp-60],rax
       lea       rax,[rbp-80]
       mov       [r14+8],rax
       mov       byte ptr [r14+4],0
       mov       rax,7FFADDCC7E70
       call      rax
M01_L00:
       mov       byte ptr [r14+4],1
       cmp       dword ptr [7FFADE00F778],0
       je        short M01_L01
       call      qword ptr [7FFADDFFD608]; CORINFO_HELP_STOP_FOR_GC
M01_L01:
       mov       rax,[rbp-78]
       mov       [r14+8],rax
       xor       eax,eax
       mov       [rbp-48],rax
       mov       [rbp-40],rax
       add       rsp,68
       pop       rbx
       pop       rsi
       pop       rdi
       pop       r12
       pop       r13
       pop       r14
       pop       r15
       pop       rbp
       ret
; Total bytes of code 184
```
```assembly
; System.Buffer.BulkMoveWithWriteBarrier(Byte ByRef, Byte ByRef, UIntPtr)
       sub       rsp,28
       cmp       r8,4000
       jbe       short M02_L00
       lea       rax,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       add       rsp,28
       jmp       qword ptr [rax]
M02_L00:
       call      qword ptr [7FFADDB196A0]
       mov       rax,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       cmp       dword ptr [rax],0
       jne       short M02_L02
M02_L01:
       add       rsp,28
       ret
M02_L02:
       call      qword ptr [7FFADDB08028]; CORINFO_HELP_POLL_GC
       jmp       short M02_L01
; Total bytes of code 58
```
```assembly
; System.Array.GetLowerBound(Int32)
       push      rbx
       sub       rsp,20
       mov       rax,[rcx]
       mov       eax,[rax+4]
       add       eax,0FFFFFFE8
       shr       eax,3
       mov       r8d,eax
       or        r8d,edx
       je        short M03_L00
       cmp       edx,eax
       jae       short M03_L01
       add       eax,edx
       cdqe
       mov       eax,[rcx+rax*4+10]
       add       rsp,20
       pop       rbx
       ret
M03_L00:
       xor       eax,eax
       add       rsp,20
       pop       rbx
       ret
M03_L01:
       call      qword ptr [7FFADDB12710]
       mov       rbx,rax
       call      qword ptr [7FFADDB1D950]
       mov       rdx,rax
       mov       rcx,rbx
       call      qword ptr [7FFADDB1C0E0]
       mov       rcx,rbx
       call      qword ptr [7FFADDB07FA8]; CORINFO_HELP_THROW
       int       3
; Total bytes of code 88
```
```assembly
; System.Array.CopyImpl(System.Array, Int32, System.Array, Int32, Int32, Boolean)
       push      r14
       push      rdi
       push      rsi
       push      rbp
       push      rbx
       sub       rsp,20
       mov       rbx,rcx
       mov       edi,edx
       mov       rsi,r8
       mov       ebp,r9d
       test      rbx,rbx
       je        near ptr M04_L07
       test      rsi,rsi
       je        near ptr M04_L06
       mov       rcx,[rbx]
       cmp       rcx,[rsi]
       je        short M04_L00
       mov       rcx,[rbx]
       mov       ecx,[rcx+4]
       add       ecx,0FFFFFFE8
       shr       ecx,3
       mov       edx,1
       test      ecx,ecx
       cmove     ecx,edx
       mov       rdx,[rsi]
       mov       edx,[rdx+4]
       add       edx,0FFFFFFE8
       shr       edx,3
       mov       eax,1
       test      edx,edx
       cmove     edx,eax
       cmp       ecx,edx
       jne       near ptr M04_L08
M04_L00:
       mov       r14d,[rsp+70]
       test      r14d,r14d
       jl        near ptr M04_L09
       mov       rcx,rbx
       xor       edx,edx
       call      qword ptr [7FFADDB19400]; Precode of System.Array.GetLowerBound(Int32)
       cmp       edi,eax
       jge       short M04_L01
       mov       r8,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       mov       r8,[r8]
       mov       ecx,edi
       mov       edx,eax
       call      qword ptr [7FFADDB309C8]
       int       3
M04_L01:
       sub       edi,eax
       js        near ptr M04_L10
       lea       ecx,[rdi+r14]
       cmp       ecx,[rbx+8]
       ja        near ptr M04_L10
       mov       rcx,rsi
       xor       edx,edx
       call      qword ptr [7FFADDB19400]; Precode of System.Array.GetLowerBound(Int32)
       cmp       ebp,eax
       jge       short M04_L02
       mov       r8,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       mov       r8,[r8]
       mov       ecx,ebp
       mov       edx,eax
       call      qword ptr [7FFADDB309C8]
       int       3
M04_L02:
       sub       ebp,eax
       js        near ptr M04_L11
       lea       ecx,[r14+rbp]
       cmp       ecx,[rsi+8]
       ja        near ptr M04_L11
       mov       rcx,[rbx]
       cmp       rcx,[rsi]
       je        short M04_L03
       mov       rcx,rbx
       mov       rdx,rsi
       call      qword ptr [7FFADDB19320]
       test      eax,eax
       je        short M04_L03
       cmp       byte ptr [rsp+78],0
       jne       near ptr M04_L16
       mov       [rsp+70],r14d
       mov       [rsp+78],eax
       mov       rcx,rbx
       mov       edx,edi
       mov       r8,rsi
       mov       r9d,ebp
       lea       rax,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       add       rsp,20
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r14
       jmp       qword ptr [rax]
M04_L03:
       mov       rcx,[rbx]
       movzx     edx,word ptr [rcx]
       mov       r8d,r14d
       imul      r8,rdx
       lea       rax,[rbx+8]
       mov       r10,[rbx]
       mov       r10d,[r10+4]
       add       r10,0FFFFFFFFFFFFFFF0
       add       rax,r10
       mov       r10d,edi
       imul      r10,rdx
       add       r10,rax
       lea       rax,[rsi+8]
       mov       r9,[rsi]
       mov       r9d,[r9+4]
       add       r9,0FFFFFFFFFFFFFFF0
       add       rax,r9
       mov       r9d,ebp
       imul      rdx,r9
       add       rdx,rax
       test      dword ptr [rcx],1000000
       jne       short M04_L04
       cmp       r8,14
       jne       near ptr M04_L15
       jmp       near ptr M04_L14
M04_L04:
       cmp       r8,4000
       ja        near ptr M04_L13
       jmp       near ptr M04_L12
M04_L05:
       add       rsp,20
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r14
       ret
M04_L06:
       mov       rcx,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       mov       rcx,[rcx]
       call      qword ptr [7FFADDB1B270]
       int       3
M04_L07:
       mov       rcx,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       mov       rcx,[rcx]
       call      qword ptr [7FFADDB1B270]
       int       3
M04_L08:
       call      qword ptr [7FFADDB12830]
       mov       rbx,rax
       call      qword ptr [7FFADDB1DDB8]
       mov       rdx,rax
       mov       rcx,rbx
       call      qword ptr [7FFADDB1C818]
       mov       rcx,rbx
       call      qword ptr [7FFADDB07FA8]; CORINFO_HELP_THROW
       int       3
M04_L09:
       mov       rdx,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       mov       rdx,[rdx]
       mov       ecx,r14d
       call      qword ptr [7FFADDB309B0]
       int       3
M04_L10:
       call      qword ptr [7FFADDB125F8]
       mov       rbx,rax
       call      qword ptr [7FFADDB1CC70]
       mov       rdx,rax
       mov       r8,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       mov       r8,[r8]
       mov       rcx,rbx
       call      qword ptr [7FFADDB1B220]
       mov       rcx,rbx
       call      qword ptr [7FFADDB07FA8]; CORINFO_HELP_THROW
       int       3
M04_L11:
       call      qword ptr [7FFADDB125F8]
       mov       r14,rax
       call      qword ptr [7FFADDB1CC68]
       mov       rdx,rax
       mov       r8,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       mov       r8,[r8]
       mov       rcx,r14
       call      qword ptr [7FFADDB1B220]
       mov       rcx,r14
       call      qword ptr [7FFADDB07FA8]; CORINFO_HELP_THROW
       int       3
M04_L12:
       mov       rcx,rdx
       mov       rdx,r10
       call      qword ptr [7FFADDB196A0]
       mov       rax,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       cmp       dword ptr [rax],0
       je        near ptr M04_L05
       call      qword ptr [7FFADDB08028]; CORINFO_HELP_POLL_GC
       jmp       near ptr M04_L05
M04_L13:
       mov       rcx,rdx
       mov       rdx,r10
       lea       rax,[System.Reflection.CustomAttributeExtensions.GetCustomAttribute[[System.__Canon, System.Private.CoreLib]](System.Reflection.Assembly)]
       add       rsp,20
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r14
       jmp       qword ptr [rax]
M04_L14:
       movups    xmm0,[r10]
       movups    xmm1,[r10+4]
       movups    [rdx],xmm0
       movups    [rdx+4],xmm1
       jmp       near ptr M04_L05
M04_L15:
       mov       rcx,rdx
       mov       rdx,r10
       call      qword ptr [7FFADDB1C988]; Precode of System.SpanHelpers.Memmove(Byte ByRef, Byte ByRef, UIntPtr)
       jmp       near ptr M04_L05
M04_L16:
       call      qword ptr [7FFADDB12620]
       mov       rbx,rax
       call      qword ptr [7FFADDB1D738]
       mov       rdx,rax
       mov       rcx,rbx
       call      qword ptr [7FFADDB1B2A0]
       mov       rcx,rbx
       call      qword ptr [7FFADDB07FA8]; CORINFO_HELP_THROW
       int       3
; Total bytes of code 748
```

## .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.BufferBlockCopy()
       push      r14
       push      rdi
       push      rsi
       push      rbp
       push      rbx
       sub       rsp,20
       mov       rbx,[rcx+8]
       mov       edx,[rbx+8]
       mov       rcx,offset MT_System.Single[]
       call      CORINFO_HELP_NEWARR_1_VC
       mov       rsi,rax
       mov       rdi,rbx
       mov       ebx,[rbx+8]
       shl       ebx,2
       test      rdi,rdi
       je        near ptr M00_L02
       mov       ebp,[rdi+8]
       mov       r14,[rdi]
       mov       rcx,offset MT_System.Byte[]
       cmp       r14,rcx
       je        short M00_L00
       mov       rcx,rdi
       call      00007FFADDC79B60
       mov       ecx,3003FFC
       bt        ecx,eax
       jae       near ptr M00_L03
       movzx     ecx,word ptr [r14]
       imul      rbp,rcx
M00_L00:
       mov       r14,rbp
       cmp       rdi,rsi
       je        short M00_L01
       mov       r14d,[rsi+8]
       mov       rcx,rsi
       call      00007FFADDC79B60
       mov       ecx,3003FFC
       bt        ecx,eax
       jae       near ptr M00_L04
       mov       rcx,[rsi]
       movzx     ecx,word ptr [rcx]
       imul      r14,rcx
M00_L01:
       test      ebx,ebx
       jl        near ptr M00_L05
       mov       r8d,ebx
       cmp       rbp,r8
       jb        near ptr M00_L06
       cmp       r14,r8
       jb        near ptr M00_L06
       lea       rcx,[rsi+10]
       lea       rdx,[rdi+10]
       call      qword ptr [7FFA7E0C5818]; System.SpanHelpers.Memmove(Byte ByRef, Byte ByRef, UIntPtr)
       mov       rax,rsi
       add       rsp,20
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r14
       ret
M00_L02:
       mov       ecx,257
       mov       rdx,7FFA7E004000
       call      qword ptr [7FFA7E347738]
       mov       rcx,rax
       call      qword ptr [7FFA7E577D68]
       int       3
M00_L03:
       mov       rcx,offset MT_System.ArgumentException
       call      CORINFO_HELP_NEWSFAST
       mov       rbp,rax
       call      qword ptr [7FFA7E577D80]
       mov       rsi,rax
       mov       ecx,257
       mov       rdx,7FFA7E004000
       call      qword ptr [7FFA7E347738]
       mov       r8,rax
       mov       rdx,rsi
       mov       rcx,rbp
       call      qword ptr [7FFA7E4958C0]
       mov       rcx,rbp
       call      CORINFO_HELP_THROW
       int       3
M00_L04:
       mov       rcx,offset MT_System.ArgumentException
       call      CORINFO_HELP_NEWSFAST
       mov       rbx,rax
       call      qword ptr [7FFA7E577D80]
       mov       rbp,rax
       mov       ecx,25F
       mov       rdx,7FFA7E004000
       call      qword ptr [7FFA7E347738]
       mov       r8,rax
       mov       rdx,rbp
       mov       rcx,rbx
       call      qword ptr [7FFA7E4958C0]
       mov       rcx,rbx
       call      CORINFO_HELP_THROW
       int       3
M00_L05:
       mov       ecx,28F
       mov       rdx,7FFA7E004000
       call      qword ptr [7FFA7E347738]
       mov       rdx,rax
       mov       ecx,ebx
       call      qword ptr [7FFA7E577D08]
       int       3
M00_L06:
       mov       rcx,offset MT_System.ArgumentException
       call      CORINFO_HELP_NEWSFAST
       mov       rbx,rax
       call      qword ptr [7FFA7E577D98]
       mov       rdx,rax
       mov       rcx,rbx
       call      qword ptr [7FFA7E34F9A8]
       mov       rcx,rbx
       call      CORINFO_HELP_THROW
       int       3
; Total bytes of code 458
```
```assembly
; System.SpanHelpers.Memmove(Byte ByRef, Byte ByRef, UIntPtr)
       mov       rax,rcx
       sub       rax,rdx
       cmp       rax,r8
       jb        near ptr M01_L11
       mov       rax,rdx
       sub       rax,rcx
       cmp       rax,r8
       jb        near ptr M01_L11
       lea       rax,[rdx+r8]
       lea       r10,[rcx+r8]
       cmp       r8,10
       jbe       short M01_L02
       cmp       r8,40
       jbe       short M01_L01
       cmp       r8,800
       jbe       near ptr M01_L07
M01_L00:
       cmp       [rcx],cl
       cmp       [rdx],dl
       vzeroupper
       jmp       qword ptr [7FFA7E0C66E8]; System.Buffer.MemmoveInternal(Byte ByRef, Byte ByRef, UIntPtr)
M01_L01:
       vmovups   xmm0,[rdx]
       vmovups   [rcx],xmm0
       cmp       r8,20
       jbe       near ptr M01_L10
       vmovups   xmm0,[rdx+10]
       vmovups   [rcx+10],xmm0
       cmp       r8,30
       jbe       near ptr M01_L10
       vmovups   xmm0,[rdx+20]
       vmovups   [rcx+20],xmm0
       jmp       near ptr M01_L10
M01_L02:
       test      r8b,18
       je        short M01_L03
       mov       rdx,[rdx]
       mov       [rcx],rdx
       mov       rcx,[rax-8]
       mov       [r10-8],rcx
       jmp       short M01_L05
M01_L03:
       test      r8b,4
       je        short M01_L04
       mov       edx,[rdx]
       mov       [rcx],edx
       mov       ecx,[rax-4]
       mov       [r10-4],ecx
       jmp       short M01_L05
M01_L04:
       test      r8,r8
       jne       short M01_L06
M01_L05:
       vzeroupper
       ret
M01_L06:
       movzx     edx,byte ptr [rdx]
       mov       [rcx],dl
       test      r8b,2
       je        short M01_L05
       movsx     rcx,word ptr [rax-2]
       mov       [r10-2],cx
       jmp       short M01_L05
M01_L07:
       cmp       r8,100
       jb        short M01_L08
       mov       r9,rcx
       and       r9,3F
       neg       r9
       add       r9,40
       vmovdqu   ymm0,ymmword ptr [rdx]
       vmovdqu   ymmword ptr [rcx],ymm0
       vmovdqu   ymm0,ymmword ptr [rdx+20]
       vmovdqu   ymmword ptr [rcx+20],ymm0
       add       rdx,r9
       add       rcx,r9
       sub       r8,r9
M01_L08:
       mov       r9,r8
       shr       r9,6
M01_L09:
       vmovdqu   ymm0,ymmword ptr [rdx]
       vmovdqu   ymmword ptr [rcx],ymm0
       vmovdqu   ymm0,ymmword ptr [rdx+20]
       vmovdqu   ymmword ptr [rcx+20],ymm0
       add       rcx,40
       add       rdx,40
       dec       r9
       jne       short M01_L09
       and       r8,3F
       cmp       r8,10
       ja        near ptr M01_L01
M01_L10:
       vmovups   xmm0,[rax-10]
       vmovups   [r10-10],xmm0
       jmp       near ptr M01_L05
M01_L11:
       cmp       rcx,rdx
       jne       near ptr M01_L00
       cmp       [rdx],dl
       jmp       near ptr M01_L05
; Total bytes of code 336
```

