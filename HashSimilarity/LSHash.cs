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
    }
}
