
//  Microsoft (R) .NET Framework IL Disassembler.  Version 4.8.3928.0
//  Copyright (c) Microsoft Corporation.  All rights reserved.



// Metadata version: v4.0.30319
.assembly extern System.Runtime
{
  .publickeytoken = (B0 3F 5F 7F 11 D5 0A 3A )                         // .?_....:
  .ver 8:0:0:0
}
.assembly extern BenchmarkDotNet.Annotations
{
  .publickeytoken = (AA 0C A2 F9 09 2C EF C4 )                         // .....,..
  .ver 0:13:12:0
}
.assembly extern System.Console
{
  .publickeytoken = (B0 3F 5F 7F 11 D5 0A 3A )                         // .?_....:
  .ver 8:0:0:0
}
.assembly Benchmark
{
  .custom instance void [System.Runtime]System.Runtime.CompilerServices.CompilationRelaxationsAttribute::.ctor(int32) = ( 01 00 08 00 00 00 00 00 ) 
  .custom instance void [System.Runtime]System.Runtime.CompilerServices.RuntimeCompatibilityAttribute::.ctor() = ( 01 00 01 00 54 02 16 57 72 61 70 4E 6F 6E 45 78   // ....T..WrapNonEx
                                                                                                                   63 65 70 74 69 6F 6E 54 68 72 6F 77 73 01 )       // ceptionThrows.

  // --- The following custom attribute is added automatically, do not uncomment -------
  //  .custom instance void [System.Runtime]System.Diagnostics.DebuggableAttribute::.ctor(valuetype [System.Runtime]System.Diagnostics.DebuggableAttribute/DebuggingModes) = ( 01 00 07 01 00 00 00 00 ) 

  .custom instance void [System.Runtime]System.Runtime.Versioning.TargetFrameworkAttribute::.ctor(string) = ( 01 00 18 2E 4E 45 54 43 6F 72 65 41 70 70 2C 56   // ....NETCoreApp,V
                                                                                                              65 72 73 69 6F 6E 3D 76 38 2E 30 01 00 54 0E 14   // ersion=v8.0..T..
                                                                                                              46 72 61 6D 65 77 6F 72 6B 44 69 73 70 6C 61 79   // FrameworkDisplay
                                                                                                              4E 61 6D 65 08 2E 4E 45 54 20 38 2E 30 )          // Name..NET 8.0
  .custom instance void [System.Runtime]System.Reflection.AssemblyCompanyAttribute::.ctor(string) = ( 01 00 09 42 65 6E 63 68 6D 61 72 6B 00 00 )       // ...Benchmark..
  .custom instance void [System.Runtime]System.Reflection.AssemblyConfigurationAttribute::.ctor(string) = ( 01 00 05 44 65 62 75 67 00 00 )                   // ...Debug..
  .custom instance void [System.Runtime]System.Reflection.AssemblyFileVersionAttribute::.ctor(string) = ( 01 00 07 31 2E 30 2E 30 2E 30 00 00 )             // ...1.0.0.0..
  .custom instance void [System.Runtime]System.Reflection.AssemblyInformationalVersionAttribute::.ctor(string) = ( 01 00 2E 31 2E 30 2E 30 2B 30 36 66 39 39 39 66   // ...1.0.0+06f999f
                                                                                                                   38 37 32 30 61 61 62 36 33 62 30 34 62 38 31 62   // 8720aab63b04b81b
                                                                                                                   32 31 62 31 37 62 39 36 64 34 36 38 30 65 63 61   // 21b17b96d4680eca
                                                                                                                   36 00 00 )                                        // 6..
  .custom instance void [System.Runtime]System.Reflection.AssemblyProductAttribute::.ctor(string) = ( 01 00 09 42 65 6E 63 68 6D 61 72 6B 00 00 )       // ...Benchmark..
  .custom instance void [System.Runtime]System.Reflection.AssemblyTitleAttribute::.ctor(string) = ( 01 00 09 42 65 6E 63 68 6D 61 72 6B 00 00 )       // ...Benchmark..
  .hash algorithm 0x00008004
  .ver 1:0:0:0
}
.module Benchmark.dll
// MVID: {4ADCD05A-96D4-48C7-B81B-C1B08FB98815}
.custom instance void [System.Runtime]System.Runtime.CompilerServices.RefSafetyRulesAttribute::.ctor(int32) = ( 01 00 0B 00 00 00 00 00 ) 
.imagebase 0x00400000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00000001    //  ILONLY
// Image base: 0x07470000


// =============== CLASS MEMBERS DECLARATION ===================

.class public auto ansi beforefieldinit Test.Benchmark
       extends [System.Runtime]System.Object
{
  .field private bool[] _bools
  .field private int32 '<Count>k__BackingField'
  .custom instance void [System.Runtime]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
  .custom instance void [System.Runtime]System.Diagnostics.DebuggerBrowsableAttribute::.ctor(valuetype [System.Runtime]System.Diagnostics.DebuggerBrowsableState) = ( 01 00 00 00 00 00 00 00 ) 
  .method public hidebysig specialname instance int32 
          get_Count() cil managed
  {
    .custom instance void [System.Runtime]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      int32 Test.Benchmark::'<Count>k__BackingField'
    IL_0006:  ret
  } // end of method Benchmark::get_Count

  .method public hidebysig specialname instance void 
          set_Count(int32 'value') cil managed
  {
    .custom instance void [System.Runtime]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  stfld      int32 Test.Benchmark::'<Count>k__BackingField'
    IL_0007:  ret
  } // end of method Benchmark::set_Count

  .method public hidebysig instance void 
          GlobalSetup() cil managed
  {
    .custom instance void [BenchmarkDotNet.Annotations]BenchmarkDotNet.Attributes.GlobalSetupAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       73 (0x49)
    .maxstack  5
    .locals init (class [System.Runtime]System.Random V_0,
             int32 V_1,
             bool V_2)
    IL_0000:  nop
    IL_0001:  ldarg.0
    IL_0002:  ldarg.0
    IL_0003:  call       instance int32 Test.Benchmark::get_Count()
    IL_0008:  newarr     [System.Runtime]System.Boolean
    IL_000d:  stfld      bool[] Test.Benchmark::_bools
    IL_0012:  ldarg.0
    IL_0013:  call       instance int32 Test.Benchmark::get_Count()
    IL_0018:  newobj     instance void [System.Runtime]System.Random::.ctor(int32)
    IL_001d:  stloc.0
    IL_001e:  ldc.i4.0
    IL_001f:  stloc.1
    IL_0020:  br.s       IL_003b

    IL_0022:  nop
    IL_0023:  ldarg.0
    IL_0024:  ldfld      bool[] Test.Benchmark::_bools
    IL_0029:  ldloc.1
    IL_002a:  ldloc.0
    IL_002b:  ldc.i4.0
    IL_002c:  ldc.i4.2
    IL_002d:  callvirt   instance int32 [System.Runtime]System.Random::Next(int32,
                                                                            int32)
    IL_0032:  ldc.i4.0
    IL_0033:  ceq
    IL_0035:  stelem.i1
    IL_0036:  nop
    IL_0037:  ldloc.1
    IL_0038:  ldc.i4.1
    IL_0039:  add
    IL_003a:  stloc.1
    IL_003b:  ldloc.1
    IL_003c:  ldarg.0
    IL_003d:  call       instance int32 Test.Benchmark::get_Count()
    IL_0042:  clt
    IL_0044:  stloc.2
    IL_0045:  ldloc.2
    IL_0046:  brtrue.s   IL_0022

    IL_0048:  ret
  } // end of method Benchmark::GlobalSetup

  .method public hidebysig instance int32 
          ToggleUsingNegation() cil managed
  {
    .custom instance void [BenchmarkDotNet.Annotations]BenchmarkDotNet.Attributes.BenchmarkAttribute::.ctor(int32,
                                                                                                            string) = ( 01 00 1A 00 00 00 3D 43 3A 5C 73 72 63 5C 67 69   // ......=C:\src\gi
                                                                                                                        74 68 75 62 5C 54 72 65 69 74 5C 4D 69 73 63 42   // thub\Treit\MiscB
                                                                                                                        65 6E 63 68 6D 61 72 6B 73 5C 54 6F 67 67 6C 65   // enchmarks\Toggle
                                                                                                                        42 6F 6F 6C 65 61 6E 5C 42 65 6E 63 68 6D 61 72   // Boolean\Benchmar
                                                                                                                        6B 2E 63 73 01 00 54 02 08 42 61 73 65 6C 69 6E   // k.cs..T..Baselin
                                                                                                                        65 01 )                                           // e.
    // Code size       45 (0x2d)
    .maxstack  4
    .locals init (bool[] V_0,
             int32 V_1,
             bool V_2,
             int32 V_3)
    IL_0000:  nop
    IL_0001:  ldarg.0
    IL_0002:  ldfld      bool[] Test.Benchmark::_bools
    IL_0007:  stloc.0
    IL_0008:  ldc.i4.0
    IL_0009:  stloc.1
    IL_000a:  br.s       IL_001b

    IL_000c:  nop
    IL_000d:  ldloc.0
    IL_000e:  ldloc.1
    IL_000f:  ldloc.0
    IL_0010:  ldloc.1
    IL_0011:  ldelem.u1
    IL_0012:  ldc.i4.0
    IL_0013:  ceq
    IL_0015:  stelem.i1
    IL_0016:  nop
    IL_0017:  ldloc.1
    IL_0018:  ldc.i4.1
    IL_0019:  add
    IL_001a:  stloc.1
    IL_001b:  ldloc.1
    IL_001c:  ldloc.0
    IL_001d:  ldlen
    IL_001e:  conv.i4
    IL_001f:  clt
    IL_0021:  stloc.2
    IL_0022:  ldloc.2
    IL_0023:  brtrue.s   IL_000c

    IL_0025:  ldloc.0
    IL_0026:  ldlen
    IL_0027:  conv.i4
    IL_0028:  stloc.3
    IL_0029:  br.s       IL_002b

    IL_002b:  ldloc.3
    IL_002c:  ret
  } // end of method Benchmark::ToggleUsingNegation

  .method public hidebysig instance int32 
          ToggleUsingXor() cil managed
  {
    .custom instance void [BenchmarkDotNet.Annotations]BenchmarkDotNet.Attributes.BenchmarkAttribute::.ctor(int32,
                                                                                                            string) = ( 01 00 26 00 00 00 3D 43 3A 5C 73 72 63 5C 67 69   // ..&...=C:\src\gi
                                                                                                                        74 68 75 62 5C 54 72 65 69 74 5C 4D 69 73 63 42   // thub\Treit\MiscB
                                                                                                                        65 6E 63 68 6D 61 72 6B 73 5C 54 6F 67 67 6C 65   // enchmarks\Toggle
                                                                                                                        42 6F 6F 6C 65 61 6E 5C 42 65 6E 63 68 6D 61 72   // Boolean\Benchmar
                                                                                                                        6B 2E 63 73 00 00 )                               // k.cs..
    // Code size       49 (0x31)
    .maxstack  3
    .locals init (bool[] V_0,
             int32 V_1,
             bool V_2,
             int32 V_3)
    IL_0000:  nop
    IL_0001:  ldarg.0
    IL_0002:  ldfld      bool[] Test.Benchmark::_bools
    IL_0007:  stloc.0
    IL_0008:  ldc.i4.0
    IL_0009:  stloc.1
    IL_000a:  br.s       IL_001f

    IL_000c:  nop
    IL_000d:  ldloc.0
    IL_000e:  ldloc.1
    IL_000f:  ldelema    [System.Runtime]System.Boolean
    IL_0014:  dup
    IL_0015:  ldind.u1
    IL_0016:  ldc.i4.0
    IL_0017:  ceq
    IL_0019:  stind.i1
    IL_001a:  nop
    IL_001b:  ldloc.1
    IL_001c:  ldc.i4.1
    IL_001d:  add
    IL_001e:  stloc.1
    IL_001f:  ldloc.1
    IL_0020:  ldloc.0
    IL_0021:  ldlen
    IL_0022:  conv.i4
    IL_0023:  clt
    IL_0025:  stloc.2
    IL_0026:  ldloc.2
    IL_0027:  brtrue.s   IL_000c

    IL_0029:  ldloc.0
    IL_002a:  ldlen
    IL_002b:  conv.i4
    IL_002c:  stloc.3
    IL_002d:  br.s       IL_002f

    IL_002f:  ldloc.3
    IL_0030:  ret
  } // end of method Benchmark::ToggleUsingXor

  .method public hidebysig instance int32 
          ToggleUsingTernary() cil managed
  {
    .custom instance void [BenchmarkDotNet.Annotations]BenchmarkDotNet.Attributes.BenchmarkAttribute::.ctor(int32,
                                                                                                            string) = ( 01 00 32 00 00 00 3D 43 3A 5C 73 72 63 5C 67 69   // ..2...=C:\src\gi
                                                                                                                        74 68 75 62 5C 54 72 65 69 74 5C 4D 69 73 63 42   // thub\Treit\MiscB
                                                                                                                        65 6E 63 68 6D 61 72 6B 73 5C 54 6F 67 67 6C 65   // enchmarks\Toggle
                                                                                                                        42 6F 6F 6C 65 61 6E 5C 42 65 6E 63 68 6D 61 72   // Boolean\Benchmar
                                                                                                                        6B 2E 63 73 00 00 )                               // k.cs..
    // Code size       65 (0x41)
    .maxstack  4
    .locals init (bool[] V_0,
             int32 V_1,
             bool V_2,
             int32 V_3)
    IL_0000:  nop
    IL_0001:  ldarg.0
    IL_0002:  ldfld      bool[] Test.Benchmark::_bools
    IL_0007:  stloc.0
    IL_0008:  ldc.i4.0
    IL_0009:  stloc.1
    IL_000a:  br.s       IL_001e

    IL_000c:  nop
    IL_000d:  ldloc.0
    IL_000e:  ldloc.1
    IL_000f:  ldloc.0
    IL_0010:  ldloc.1
    IL_0011:  ldelem.u1
    IL_0012:  brtrue.s   IL_0017

    IL_0014:  ldc.i4.1
    IL_0015:  br.s       IL_0018

    IL_0017:  ldc.i4.0
    IL_0018:  stelem.i1
    IL_0019:  nop
    IL_001a:  ldloc.1
    IL_001b:  ldc.i4.1
    IL_001c:  add
    IL_001d:  stloc.1
    IL_001e:  ldloc.1
    IL_001f:  ldloc.0
    IL_0020:  ldlen
    IL_0021:  conv.i4
    IL_0022:  clt
    IL_0024:  stloc.2
    IL_0025:  ldloc.2
    IL_0026:  brtrue.s   IL_000c

    IL_0028:  ldstr      bytearray (3E D8 14 DD )                                     // >...
    IL_002d:  call       void [System.Console]System.Console::WriteLine(string)
    IL_0032:  nop
    IL_0033:  ldloc.0
    IL_0034:  ldlen
    IL_0035:  conv.i4
    IL_0036:  ldc.i4     0x12c
    IL_003b:  add
    IL_003c:  stloc.3
    IL_003d:  br.s       IL_003f

    IL_003f:  ldloc.3
    IL_0040:  ret
  } // end of method Benchmark::ToggleUsingTernary

  .method public hidebysig instance int32 
          ToggleUsingSwitchExpression() cil managed
  {
    .custom instance void [BenchmarkDotNet.Annotations]BenchmarkDotNet.Attributes.BenchmarkAttribute::.ctor(int32,
                                                                                                            string) = ( 01 00 40 00 00 00 3D 43 3A 5C 73 72 63 5C 67 69   // ..@...=C:\src\gi
                                                                                                                        74 68 75 62 5C 54 72 65 69 74 5C 4D 69 73 63 42   // thub\Treit\MiscB
                                                                                                                        65 6E 63 68 6D 61 72 6B 73 5C 54 6F 67 67 6C 65   // enchmarks\Toggle
                                                                                                                        42 6F 6F 6C 65 61 6E 5C 42 65 6E 63 68 6D 61 72   // Boolean\Benchmar
                                                                                                                        6B 2E 63 73 00 00 )                               // k.cs..
    // Code size       78 (0x4e)
    .maxstack  3
    .locals init (bool[] V_0,
             int32 V_1,
             bool[] V_2,
             int32 V_3,
             bool V_4,
             bool V_5,
             bool V_6,
             int32 V_7)
    IL_0000:  nop
    IL_0001:  ldarg.0
    IL_0002:  ldfld      bool[] Test.Benchmark::_bools
    IL_0007:  stloc.0
    IL_0008:  ldc.i4.0
    IL_0009:  stloc.1
    IL_000a:  br.s       IL_0038

    IL_000c:  nop
    IL_000d:  ldloc.0
    IL_000e:  stloc.2
    IL_000f:  ldloc.1
    IL_0010:  stloc.3
    IL_0011:  ldloc.0
    IL_0012:  ldloc.1
    IL_0013:  ldelem.u1
    IL_0014:  stloc.s    V_5
    IL_0016:  ldc.i4.1
    IL_0017:  brtrue.s   IL_001a

    IL_0019:  nop
    IL_001a:  ldloc.s    V_5
    IL_001c:  brtrue.s   IL_0020

    IL_001e:  br.s       IL_0025

    IL_0020:  ldc.i4.0
    IL_0021:  stloc.s    V_4
    IL_0023:  br.s       IL_002a

    IL_0025:  ldc.i4.1
    IL_0026:  stloc.s    V_4
    IL_0028:  br.s       IL_002a

    IL_002a:  ldc.i4.1
    IL_002b:  brtrue.s   IL_002e

    IL_002d:  nop
    IL_002e:  ldloc.2
    IL_002f:  ldloc.3
    IL_0030:  ldloc.s    V_4
    IL_0032:  stelem.i1
    IL_0033:  nop
    IL_0034:  ldloc.1
    IL_0035:  ldc.i4.1
    IL_0036:  add
    IL_0037:  stloc.1
    IL_0038:  ldloc.1
    IL_0039:  ldloc.0
    IL_003a:  ldlen
    IL_003b:  conv.i4
    IL_003c:  clt
    IL_003e:  stloc.s    V_6
    IL_0040:  ldloc.s    V_6
    IL_0042:  brtrue.s   IL_000c

    IL_0044:  ldloc.0
    IL_0045:  ldlen
    IL_0046:  conv.i4
    IL_0047:  stloc.s    V_7
    IL_0049:  br.s       IL_004b

    IL_004b:  ldloc.s    V_7
    IL_004d:  ret
  } // end of method Benchmark::ToggleUsingSwitchExpression

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [System.Runtime]System.Object::.ctor()
    IL_0006:  nop
    IL_0007:  ret
  } // end of method Benchmark::.ctor

  .property instance int32 Count()
  {
    .custom instance void [BenchmarkDotNet.Annotations]BenchmarkDotNet.Attributes.ParamsAttribute::.ctor(object[]) = ( 01 00 01 00 00 00 08 40 42 0F 00 00 00 )          // .......@B....
    .get instance int32 Test.Benchmark::get_Count()
    .set instance void Test.Benchmark::set_Count(int32)
  } // end of property Benchmark::Count
} // end of class Test.Benchmark

.class private auto ansi beforefieldinit Test.Program
       extends [System.Runtime]System.Object
{
  .method private hidebysig static void  Main(string[] args) cil managed
  {
    .entrypoint
    // Code size       39 (0x27)
    .maxstack  2
    .locals init (class Test.Benchmark V_0)
    IL_0000:  nop
    IL_0001:  newobj     instance void Test.Benchmark::.ctor()
    IL_0006:  stloc.0
    IL_0007:  ldloc.0
    IL_0008:  ldc.i4     0x188bf
    IL_000d:  callvirt   instance void Test.Benchmark::set_Count(int32)
    IL_0012:  nop
    IL_0013:  ldloc.0
    IL_0014:  callvirt   instance void Test.Benchmark::GlobalSetup()
    IL_0019:  nop
    IL_001a:  ldloc.0
    IL_001b:  callvirt   instance int32 Test.Benchmark::ToggleUsingNegation()
    IL_0020:  call       void [System.Console]System.Console::WriteLine(int32)
    IL_0025:  nop
    IL_0026:  ret
  } // end of method Program::Main

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [System.Runtime]System.Object::.ctor()
    IL_0006:  nop
    IL_0007:  ret
  } // end of method Program::.ctor

} // end of class Test.Program


// =============================================================

// *********** DISASSEMBLY COMPLETE ***********************
// WARNING: Created Win32 resource file second.res
