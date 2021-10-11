using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

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
                diff += LookupTables.PairCountUshortTable[first[i] ^ second[i]];
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
                diff += LookupTables.PairCountTableSpan[first[i] ^ second[i]];
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
            ref byte table = ref MemoryMarshal.GetReference(LookupTables.PairCountTableSpan);

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
            ref Byte tableRef = ref MemoryMarshal.GetReference(LookupTables.PairCountTableSpan);

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
            ref byte table = ref Unsafe.Add(ref MemoryMarshal.GetReference(LookupTables.PairCountTableSpan), 0);

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

        public static unsafe uint ConfidenceSauceControlUnrolled(ReadOnlySpan<byte> first, ReadOnlySpan<byte> second)
        {
            ref byte f = ref MemoryMarshal.GetReference(first);
            ref byte s = ref MemoryMarshal.GetReference(second);
            ref byte table = ref Unsafe.Add(ref MemoryMarshal.GetReference(LookupTables.PairCountTableSpan), 0);

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
    }
}
