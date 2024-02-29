using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;
using System.Runtime.Intrinsics;

namespace Test
{
    public static class LSHash
    {
        const int THRESHOLD = 90;
        const int HASH_LENGTH = 64;

        public static int ConfidenceNoLookup(ReadOnlySpan<byte> first, ReadOnlySpan<byte> second)
        {
            int diff = 0;

            for (int i = 0; i < first.Length; i++)
            {
                byte v = (byte)(first[i] ^ second[i]);

                diff +=
                      ((v & 0xC0) == 0 ? 1 : 0)  // 11000000
                    + ((v & 0x30) == 0 ? 1 : 0)  // 00110000
                    + ((v & 0x0C) == 0 ? 1 : 0)  // 00001100
                    + ((v & 0x03) == 0 ? 1 : 0); // 00000011
            }

            if (diff > 128 + THRESHOLD)
            {
                return ((diff - 128) * 100) / 128;
            }

            return 0;
        }

        public static int Confidence(ReadOnlySpan<byte> first, ReadOnlySpan<byte> second)
        {
            int diff = 0;
            for (int i = 0; i < HASH_LENGTH; i++)
            {
                diff += LookupTables.PairCountTable[first[i] ^ second[i]];
            }

            if (diff > 128 + THRESHOLD)
            {
                return ((diff - 128) * 100) / 128;
            }

            return 0;
        }

        public static int ConfidenceWithUShortTable(ReadOnlySpan<ushort> first, ReadOnlySpan<ushort> second)
        {
            int diff = 0;
            for (int i = 0; i < HASH_LENGTH / 2; i++)
            {
                diff += LookupTables.PairCountTable16[first[i] ^ second[i]];
            }

            if (diff > 128 + THRESHOLD)
            {
                return ((diff - 128) * 100) / 128;
            }

            return 0;
        }

        public static int ConfidenceWithSpanTable(ReadOnlySpan<byte> first, ReadOnlySpan<byte> second)
        {
            int diff = 0;
            for (int i = 0; i < HASH_LENGTH; i++)
            {
                diff += LookupTables.PairCountTable8[first[i] ^ second[i]];
            }

            if (diff > 128 + THRESHOLD)
            {
                return ((diff - 128) * 100) / 128;
            }

            return 0;
        }

        public static uint ConfidenceWithSpanTableTechPizza(ReadOnlySpan<byte> first, ReadOnlySpan<byte> second)
        {
            ref byte f = ref MemoryMarshal.GetReference(first);
            ref byte s = ref MemoryMarshal.GetReference(second);
            ref byte table = ref MemoryMarshal.GetReference(LookupTables.PairCountTable8);

            uint diff = 0;
            for (nint i = 0; i < HASH_LENGTH; i++)
            {
                diff += Unsafe.Add(ref table, Unsafe.Add(ref f, i) ^ Unsafe.Add(ref s, i));
            }

            if (diff > 128 + THRESHOLD)
            {
                return ((diff - 128) * 100) / 128;
            }

            return 0;
        }

        public static int ConfidenceWithSpanTableKozi(ReadOnlySpan<byte> first, ReadOnlySpan<byte> second)
        {
            int diff = 0;

            ref Byte firstRef = ref MemoryMarshal.GetReference(first);
            ref Byte end = ref Unsafe.Add(ref firstRef, HASH_LENGTH);
            ref Byte secondRef = ref MemoryMarshal.GetReference(second);
            ref Byte tableRef = ref MemoryMarshal.GetReference(LookupTables.PairCountTable8);

            do
            {
                //One iteration
                var xor = firstRef ^ secondRef;
                diff += Unsafe.Add(ref tableRef, xor);
                firstRef = ref Unsafe.Add(ref firstRef, 1);
                secondRef = ref Unsafe.Add(ref secondRef, 1);
            } while (Unsafe.IsAddressLessThan(ref firstRef, ref end));

            if (diff > 128 + THRESHOLD)
            {
                return ((diff - 128) * 100) / 128;
            }

            return 0;
        }

        public static unsafe uint ConfidenceSauceControl(ReadOnlySpan<byte> first, ReadOnlySpan<byte> second)
        {
            ref byte f = ref MemoryMarshal.GetReference(first);
            ref byte s = ref MemoryMarshal.GetReference(second);
            ref byte table = ref Unsafe.Add(ref MemoryMarshal.GetReference(LookupTables.PairCountTable8), 0);

            nuint diff = 0;
            for (nint i = 0; i < HASH_LENGTH; i++)
            {
                diff += Unsafe.Add(ref table, (nint)((nuint)Unsafe.Add(ref f, i) ^ (nuint)Unsafe.Add(ref s, i)));
            }

            if (diff > 128 + THRESHOLD)
            {
                return ((uint)diff - 128) * 100 / 128;
            }

            return 0;
        }

        public static unsafe uint ConfidenceSauceControlUnrolledKozi(ReadOnlySpan<byte> first, ReadOnlySpan<byte> second)
        {
            ref byte f = ref MemoryMarshal.GetReference(first);
            ref byte s = ref MemoryMarshal.GetReference(second);
            ref byte table = ref Unsafe.Add(ref MemoryMarshal.GetReference(LookupTables.PairCountTable8), 0);

            nuint diff = 0;
            for (nint i = 0; i < HASH_LENGTH; i += 4)
            {
                diff += Unsafe.Add(ref table, (nint)((nuint)Unsafe.Add(ref f, i + 0) ^ (nuint)Unsafe.Add(ref s, i + 0)));
                diff += Unsafe.Add(ref table, (nint)((nuint)Unsafe.Add(ref f, i + 1) ^ (nuint)Unsafe.Add(ref s, i + 1)));
                diff += Unsafe.Add(ref table, (nint)((nuint)Unsafe.Add(ref f, i + 2) ^ (nuint)Unsafe.Add(ref s, i + 2)));
                diff += Unsafe.Add(ref table, (nint)((nuint)Unsafe.Add(ref f, i + 3) ^ (nuint)Unsafe.Add(ref s, i + 3)));
            }

            if (diff > 128 + THRESHOLD)
            {
                return ((uint)diff - 128) * 100 / 128;
            }

            return 0;
        }

        public static unsafe int ConfidenceSauceControlUnrolled(ReadOnlySpan<byte> first, ReadOnlySpan<byte> second)
        {
            ref byte f = ref MemoryMarshal.GetReference(first);
            ref byte s = ref MemoryMarshal.GetReference(second);
            ref byte table = ref Unsafe.Add(ref MemoryMarshal.GetReference(LookupTables.PairCountTable8), 0);
            ref byte end = ref Unsafe.Add(ref f, HASH_LENGTH);

            nuint diff1 = 0, diff2 = 0;
            do
            {
                diff1 += Unsafe.Add(ref table, (nint)((nuint)Unsafe.Add(ref f, 0) ^ (nuint)Unsafe.Add(ref s, 0)));
                diff2 += Unsafe.Add(ref table, (nint)((nuint)Unsafe.Add(ref f, 1) ^ (nuint)Unsafe.Add(ref s, 1)));
                diff1 += Unsafe.Add(ref table, (nint)((nuint)Unsafe.Add(ref f, 2) ^ (nuint)Unsafe.Add(ref s, 2)));
                diff2 += Unsafe.Add(ref table, (nint)((nuint)Unsafe.Add(ref f, 3) ^ (nuint)Unsafe.Add(ref s, 3)));

                f = ref Unsafe.Add(ref f, 4);
                s = ref Unsafe.Add(ref s, 4);
            } while (Unsafe.IsAddressLessThan(ref f, ref end));

            diff1 += diff2;
            if (diff1 > 128 + THRESHOLD)
            {
                return ((int)diff1 - 128) * 100 / 128;
            }

            return 0;
        }

        public static unsafe int ConfidenceSauceControlUnrolledHugeLookup(ReadOnlySpan<ushort> first, ReadOnlySpan<ushort> second)
        {
            ref ushort f = ref MemoryMarshal.GetReference(first);
            ref ushort s = ref MemoryMarshal.GetReference(second);
            ref byte table = ref Unsafe.Add(ref MemoryMarshal.GetReference(LookupTables.PairCountTable16), 0);
            ref ushort end = ref Unsafe.Add(ref f, HASH_LENGTH / 2);

            nuint diff1 = 0, diff2 = 0;
            do
            {
                diff1 += Unsafe.Add(ref table, (nint)((nuint)Unsafe.Add(ref f, 0) ^ (nuint)Unsafe.Add(ref s, 0)));
                diff2 += Unsafe.Add(ref table, (nint)((nuint)Unsafe.Add(ref f, 1) ^ (nuint)Unsafe.Add(ref s, 1)));
                diff1 += Unsafe.Add(ref table, (nint)((nuint)Unsafe.Add(ref f, 2) ^ (nuint)Unsafe.Add(ref s, 2)));
                diff2 += Unsafe.Add(ref table, (nint)((nuint)Unsafe.Add(ref f, 3) ^ (nuint)Unsafe.Add(ref s, 3)));

                f = ref Unsafe.Add(ref f, 4);
                s = ref Unsafe.Add(ref s, 4);
            } while (Unsafe.IsAddressLessThan(ref f, ref end));

            diff1 += diff2;
            if (diff1 > 128 + THRESHOLD)
            {
                return ((int)diff1 - 128) * 100 / 128;
            }

            return 0;
        }

        public static int ConfidenceSseKozi(ReadOnlySpan<ushort> first, ReadOnlySpan<ushort> second)
        {
            ref ushort f = ref MemoryMarshal.GetReference(first);
            ref ushort s = ref MemoryMarshal.GetReference(second);
            ref byte table = ref Unsafe.Add(ref MemoryMarshal.GetReference(LookupTables.PairCountTable16), 0);
            ref ushort end = ref Unsafe.Add(ref f, HASH_LENGTH / 2);

            nuint diff1 = 0;
            do
            {

                Vector128<ushort> firstVec = Unsafe.As<ushort, Vector128<ushort>>(ref f);
                Vector128<ushort> secondVec = Unsafe.As<ushort, Vector128<ushort>>(ref s);
                Vector128<ushort> xor = Sse2.Xor(firstVec, secondVec);

                diff1 += Unsafe.Add(ref table, (nint)(nuint)Sse2.Extract(xor, 0));

                diff1 += Unsafe.Add(ref table, (nint)(nuint)Sse2.Extract(xor, 1));

                diff1 += Unsafe.Add(ref table, (nint)(nuint)Sse2.Extract(xor, 2));

                diff1 += Unsafe.Add(ref table, (nint)(nuint)Sse2.Extract(xor, 3));

                diff1 += Unsafe.Add(ref table, (nint)(nuint)Sse2.Extract(xor, 4));

                diff1 += Unsafe.Add(ref table, (nint)(nuint)Sse2.Extract(xor, 5));

                diff1 += Unsafe.Add(ref table, (nint)(nuint)Sse2.Extract(xor, 6));

                diff1 += Unsafe.Add(ref table, (nint)(nuint)Sse2.Extract(xor, 7));

                f = ref Unsafe.Add(ref f, 8);
                s = ref Unsafe.Add(ref s, 8);
            } while (Unsafe.IsAddressLessThan(ref f, ref end));

            if (diff1 > 128 + THRESHOLD)
            {
                return ((int)diff1 - 128) * 100 / 128;
            }

            return 0;
        }

        public static int ConfidenceSauceControlSse2(ReadOnlySpan<byte> first, ReadOnlySpan<byte> second)
        {
            ref byte f = ref MemoryMarshal.GetReference(first);
            ref byte s = ref MemoryMarshal.GetReference(second);
            ref byte end = ref Unsafe.Add(ref f, HASH_LENGTH);

            var vzero = Vector128<byte>.Zero;
            var vmsk0 = Vector128.Create((byte)0b_11_00_00_00);
            var vmsk1 = Vector128.Create((byte)0b_00_11_00_00);
            var vmsk2 = Vector128.Create((byte)0b_00_00_11_00);
            var vmsk3 = Vector128.Create((byte)0b_00_00_00_11);

            nuint diff = 0;
            do
            {
                var vxor = Sse2.Xor(Unsafe.As<byte, Vector128<byte>>(ref f), Unsafe.As<byte, Vector128<byte>>(ref s));
                diff += Popcnt.PopCount((uint)Sse2.MoveMask(Sse2.CompareEqual(Sse2.And(vxor, vmsk0), vzero)));
                diff += Popcnt.PopCount((uint)Sse2.MoveMask(Sse2.CompareEqual(Sse2.And(vxor, vmsk1), vzero)));
                diff += Popcnt.PopCount((uint)Sse2.MoveMask(Sse2.CompareEqual(Sse2.And(vxor, vmsk2), vzero)));
                diff += Popcnt.PopCount((uint)Sse2.MoveMask(Sse2.CompareEqual(Sse2.And(vxor, vmsk3), vzero)));

                f = ref Unsafe.Add(ref f, Vector128<byte>.Count);
                s = ref Unsafe.Add(ref s, Vector128<byte>.Count);
            }
            while (Unsafe.IsAddressLessThan(ref f, ref end));

            if (diff > 128 + THRESHOLD)
            {
                return ((int)diff - 128) * 100 / 128;
            }

            return 0;
        }

        public static int ConfidenceSauceControlFirstAvx2(ReadOnlySpan<byte> first, ReadOnlySpan<byte> second)
        {
            ref byte f = ref MemoryMarshal.GetReference(first);
            ref byte s = ref MemoryMarshal.GetReference(second);

            var vzero = Vector256<byte>.Zero;
            var vmsk0 = Vector256.Create((byte)0b_11_00_00_00);
            var vmsk1 = Vector256.Create((byte)0b_00_11_00_00);
            var vmsk2 = Vector256.Create((byte)0b_00_00_11_00);
            var vmsk3 = Vector256.Create((byte)0b_00_00_00_11);

            nuint diff = 0;

            var vxor = Avx2.Xor(Unsafe.As<byte, Vector256<byte>>(ref f), Unsafe.As<byte, Vector256<byte>>(ref s));
            diff += Popcnt.PopCount((uint)Avx2.MoveMask(Avx2.CompareEqual(Avx2.And(vxor, vmsk0), vzero)));
            diff += Popcnt.PopCount((uint)Avx2.MoveMask(Avx2.CompareEqual(Avx2.And(vxor, vmsk1), vzero)));
            diff += Popcnt.PopCount((uint)Avx2.MoveMask(Avx2.CompareEqual(Avx2.And(vxor, vmsk2), vzero)));
            diff += Popcnt.PopCount((uint)Avx2.MoveMask(Avx2.CompareEqual(Avx2.And(vxor, vmsk3), vzero)));

            vxor = Avx2.Xor(Unsafe.As<byte, Vector256<byte>>(ref Unsafe.Add(ref f, Vector256<byte>.Count)), Unsafe.As<byte, Vector256<byte>>(ref Unsafe.Add(ref s, Vector256<byte>.Count)));
            diff += Popcnt.PopCount((uint)Avx2.MoveMask(Avx2.CompareEqual(Avx2.And(vxor, vmsk0), vzero)));
            diff += Popcnt.PopCount((uint)Avx2.MoveMask(Avx2.CompareEqual(Avx2.And(vxor, vmsk1), vzero)));
            diff += Popcnt.PopCount((uint)Avx2.MoveMask(Avx2.CompareEqual(Avx2.And(vxor, vmsk2), vzero)));
            diff += Popcnt.PopCount((uint)Avx2.MoveMask(Avx2.CompareEqual(Avx2.And(vxor, vmsk3), vzero)));

            if (diff > 128 + THRESHOLD)
            {
                return ((int)diff - 128) * 100 / 128;
            }

            return 0;
        }

        public static int ConfidenceSauceControlSecondAvx2(ReadOnlySpan<byte> first, ReadOnlySpan<byte> second)
        {
            ref byte f = ref MemoryMarshal.GetReference(first);
            ref byte s = ref MemoryMarshal.GetReference(second);

            var vzero = Vector256<byte>.Zero;
            var vmsk0 = Vector256.Create((byte)0b_11_00_00_00);
            var vmsk1 = Vector256.Create((byte)0b_00_11_00_00);
            var vmsk2 = Vector256.Create((byte)0b_00_00_11_00);
            var vmsk3 = Vector256.Create((byte)0b_00_00_00_11);

            var vxor = Avx2.Xor(Unsafe.As<byte, Vector256<byte>>(ref f), Unsafe.As<byte, Vector256<byte>>(ref s));
            var vpe0 = Avx2.CompareEqual(Avx2.And(vxor, vmsk0), vzero);
            var vpe1 = Avx2.CompareEqual(Avx2.And(vxor, vmsk1), vzero);
            var vpe2 = Avx2.CompareEqual(Avx2.And(vxor, vmsk2), vzero);
            var vpe3 = Avx2.CompareEqual(Avx2.And(vxor, vmsk3), vzero);

            uint mpe0 = (uint)Avx2.MoveMask(vpe0);
            uint mpe1 = (uint)Avx2.MoveMask(vpe1);
            uint mpe2 = (uint)Avx2.MoveMask(vpe2);
            uint mpe3 = (uint)Avx2.MoveMask(vpe3);

            uint diff = Popcnt.PopCount(mpe0) + Popcnt.PopCount(mpe1);
            diff += Popcnt.PopCount(mpe2) + Popcnt.PopCount(mpe3);

            vxor = Avx2.Xor(Unsafe.As<byte, Vector256<byte>>(ref Unsafe.Add(ref f, Vector256<byte>.Count)), Unsafe.As<byte, Vector256<byte>>(ref Unsafe.Add(ref s, Vector256<byte>.Count)));
            vpe0 = Avx2.CompareEqual(Avx2.And(vxor, vmsk0), vzero);
            vpe1 = Avx2.CompareEqual(Avx2.And(vxor, vmsk1), vzero);
            vpe2 = Avx2.CompareEqual(Avx2.And(vxor, vmsk2), vzero);
            vpe3 = Avx2.CompareEqual(Avx2.And(vxor, vmsk3), vzero);

            mpe0 = (uint)Avx2.MoveMask(vpe0);
            mpe1 = (uint)Avx2.MoveMask(vpe1);
            mpe2 = (uint)Avx2.MoveMask(vpe2);
            mpe3 = (uint)Avx2.MoveMask(vpe3);

            diff += Popcnt.PopCount(mpe0) + Popcnt.PopCount(mpe1);
            diff += Popcnt.PopCount(mpe2) + Popcnt.PopCount(mpe3);

            if (diff > 128 + THRESHOLD)
            {
                return ((int)diff - 128) * 100 / 128;
            }

            return 0;
        }

        public static int ConfidenceSauceControlThirdAvx2(ReadOnlySpan<byte> first, ReadOnlySpan<byte> second)
        {
            const byte _ = 0x80;

            ref byte f = ref MemoryMarshal.GetReference(first);
            ref byte s = ref MemoryMarshal.GetReference(second);

            var vmsk0 = Vector256.Create((byte)0b_01_01_01_01);
            var vmsk1 = Vector256.Create((byte)0b_00_00_11_11);
            var vlut = Vector256.Create(4, 3, 2, _, 3, 2, 1, _, 2, 1, 0, _, _, _, _, _, 4, 3, 2, _, 3, 2, 1, _, 2, 1, 0, _, _, _, _, _);

            var vxor = Avx2.Xor(Unsafe.As<byte, Vector256<byte>>(ref f), Unsafe.As<byte, Vector256<byte>>(ref s));
            var vpe0 = Avx2.Or(Avx2.And(vxor, vmsk0), Avx2.And(Avx2.ShiftRightLogical(vxor.AsUInt32(), 1).AsByte(), vmsk0));
            vpe0 = Avx2.Shuffle(vlut, Avx2.Add(Avx2.And(vpe0, vmsk1), Avx2.And(Avx2.ShiftRightLogical(vpe0.AsUInt32(), 4).AsByte(), vmsk1)));

            vxor = Avx2.Xor(Unsafe.As<byte, Vector256<byte>>(ref Unsafe.Add(ref f, Vector256<byte>.Count)), Unsafe.As<byte, Vector256<byte>>(ref Unsafe.Add(ref s, Vector256<byte>.Count)));
            var vpe1 = Avx2.Or(Avx2.And(vxor, vmsk0), Avx2.And(Avx2.ShiftRightLogical(vxor.AsUInt32(), 1).AsByte(), vmsk0));
            vpe1 = Avx2.Shuffle(vlut, Avx2.Add(Avx2.And(vpe1, vmsk1), Avx2.And(Avx2.ShiftRightLogical(vpe1.AsUInt32(), 4).AsByte(), vmsk1)));

            var vzero = Vector256<byte>.Zero;
            var vsum = Avx2.Add(Avx2.SumAbsoluteDifferences(vpe0, vzero), Avx2.SumAbsoluteDifferences(vpe1, vzero));

            var v128 = Sse2.Add(vsum.GetLower(), vsum.GetUpper()).AsUInt64();
            uint diff = Sse2.Add(v128, Sse2.UnpackHigh(v128, v128)).AsUInt32().ToScalar();

            if (diff > 128 + THRESHOLD)
            {
                return (int)((diff - 128) * 100 / 128);
            }

            return 0;
        }

        public static int ConfidenceSauceControlFourthAvx2(ReadOnlySpan<byte> first, ReadOnlySpan<byte> second)
        {
            /*
            If we consider that each bit pair is either 00 (match) or not 00, there are only 16 possible combinations
            per byte. We can consolidate these possibilities from the 256 possible single bit combinations by shifting
            any 1s to the lower bit of each pair.  e.g. 0b_00_01_10_11 => 0b_00_01_01_01

            Although this leaves us with only 16 possible combinations, the value of each byte can still be as high
            as 85, meaning we would need a lookup table at least that big. We can collapse the values further by adding
            the high 4 bits to the low 4 bits, which is safe because any overflow will go into a bit that is already
            cleared to 0. This leaves us with a a max possible sum of 10, meaning we can use a lookup table of only 16
            values, of which 9 are actual possible sums. The possible sums out of the 16 combinations are as follows:

            0b_00_00 + 0b_00_00 = 0x0 => 4 match
            0b_00_00 + 0b_00_01 = 0x1 => 3 match
            0b_00_01 + 0b_00_00 = 0x1 => 3 match
            0b_00_01 + 0b_00_01 = 0x2 => 2 match
                                  0x3 (not possible)
            0b_00_00 + 0b_01_00 = 0x4 => 3 match
            0b_01_00 + 0b_00_00 = 0x4 => 3 match
            0b_00_00 + 0b_01_01 = 0x5 => 2 match
            0b_00_01 + 0b_01_00 = 0x5 => 2 match
            0b_01_00 + 0b_00_01 = 0x5 => 2 match
            0b_01_01 + 0b_00_00 = 0x5 => 2 match
            0b_00_01 + 0b_01_01 = 0x6 => 1 match
            0b_01_01 + 0b_00_01 = 0x6 => 1 match
                                  0x7 (not possible)
            0b_01_00 + 0b_01_00 = 0x8 => 2 match
            0b_01_00 + 0b_01_01 = 0x9 => 1 match
            0b_01_01 + 0b_01_00 = 0x9 => 1 match
            0b_01_01 + 0b_01_01 = 0xa => 0 match

            We can store these values in a single 16-byte vector, or double them up in a 32-byte vector,
            allowing for the lookup to be performed by a single byte shuffle (vpshufb).
            */

            // Just a placeholder for impossible lookup positions.
            const byte _ = 0x80;

            ref Vector256<byte> f = ref Unsafe.As<byte, Vector256<byte>>(ref MemoryMarshal.GetReference(first));
            ref Vector256<byte> s = ref Unsafe.As<byte, Vector256<byte>>(ref MemoryMarshal.GetReference(second));

            // Masks for low bit of each bit pair and low 4 bits of byte.
            var vmsk0 = Vector256.Create((byte)0b_01_01_01_01);
            var vmsk1 = Vector256.Create((byte)0b_00_00_11_11);

            // Lookup table for number of matching bit pairs.
            // It only needs 16 entries, but we repeat them for each 16-byte lane in AVX2.
            var vlut = Vector256.Create(4, 3, 2, _, 3, 2, 1, _, 2, 1, 0, _, _, _, _, _,
                                        4, 3, 2, _, 3, 2, 1, _, 2, 1, 0, _, _, _, _, _);

            // Load 32 bytes at a time from the inputs and xor them.
            var vxor0 = Avx2.Xor(f, s);
            var vxor1 = Avx2.Xor(Unsafe.Add(ref f, 1), Unsafe.Add(ref s, 1));

            // Shift either (or both) 1 in each bit pair to the lower bit.
            // Equal pairs will be 00, unequal will be 01.
            var vpe0 = Avx2.Or(Avx2.And(vxor0, vmsk0), Avx2.And(Avx2.ShiftRightLogical(vxor0.AsUInt32(), 1).AsByte(), vmsk0));
            var vpe1 = Avx2.Or(Avx2.And(vxor1, vmsk0), Avx2.And(Avx2.ShiftRightLogical(vxor1.AsUInt32(), 1).AsByte(), vmsk0));

            // Add the upper 4 bits of each byte to the lower 4 bits.
            // Sum will fit into 4 bits and will match the table above.
            vpe0 = Avx2.Add(Avx2.And(vpe0, vmsk1), Avx2.And(Avx2.ShiftRightLogical(vpe0.AsUInt32(), 4).AsByte(), vmsk1));
            vpe1 = Avx2.Add(Avx2.And(vpe1, vmsk1), Avx2.And(Avx2.ShiftRightLogical(vpe1.AsUInt32(), 4).AsByte(), vmsk1));

            // Use the sum to look up the number of matching pairs in each byte.
            vpe0 = Avx2.Shuffle(vlut, vpe0);
            vpe1 = Avx2.Shuffle(vlut, vpe1);

            // SumAbsoluteDifferences (vpsadbw) subtracts vertically (we subtract 0) and then
            // horizontally adds 8 adjacent result bytes into one value, packed in the low 16 bits
            // of 64. We use that to sum the match counts from both lookup results.
            var vsum = Avx2.SumAbsoluteDifferences(Avx2.Add(vpe0, vpe1), Vector256<byte>.Zero);

            // That leaves us with 4 64-bit sums. We add the two 16-byte lanes to make that
            // 2 64-bit sums, then add the upper and lower halves of the remaining 16-byte
            // vector, yielding a single 64-bit horizontal sum of all 32 counts, which we
            // can safely truncate to 32 bits.
            var v128 = Sse2.Add(vsum.GetLower(), vsum.GetUpper()).AsUInt64();
            uint diff = Sse2.Add(v128, Sse2.UnpackHigh(v128, v128)).AsUInt32().ToScalar();

            if (diff > 128 + THRESHOLD)
            {
                return (int)((diff - 128) * 100 / 128);
            }

            return 0;
        }
    }
}
