using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Test
{
    public static class LSHash
    {
        const int THRESHOLD = 90;
        const int HASH_LENGTH = 64;

        static readonly byte[] PairCountTable = new byte[256]
        {
            4, 3, 3, 3, 3, 2, 2, 2, 3, 2, 2, 2, 3, 2, 2, 2,
            3, 2, 2, 2, 2, 1, 1, 1, 2, 1, 1, 1, 2, 1, 1, 1,
            3, 2, 2, 2, 2, 1, 1, 1, 2, 1, 1, 1, 2, 1, 1, 1,
            3, 2, 2, 2, 2, 1, 1, 1, 2, 1, 1, 1, 2, 1, 1, 1,
            3, 2, 2, 2, 2, 1, 1, 1, 2, 1, 1, 1, 2, 1, 1, 1,
            2, 1, 1, 1, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0,
            2, 1, 1, 1, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0,
            2, 1, 1, 1, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0,
            3, 2, 2, 2, 2, 1, 1, 1, 2, 1, 1, 1, 2, 1, 1, 1,
            2, 1, 1, 1, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0,
            2, 1, 1, 1, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0,
            2, 1, 1, 1, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0,
            3, 2, 2, 2, 2, 1, 1, 1, 2, 1, 1, 1, 2, 1, 1, 1,
            2, 1, 1, 1, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0,
            2, 1, 1, 1, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0,
            2, 1, 1, 1, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0
        };

        static ReadOnlySpan<byte> PairCountTableSpan => new byte[256]
        {
            4, 3, 3, 3, 3, 2, 2, 2, 3, 2, 2, 2, 3, 2, 2, 2,
            3, 2, 2, 2, 2, 1, 1, 1, 2, 1, 1, 1, 2, 1, 1, 1,
            3, 2, 2, 2, 2, 1, 1, 1, 2, 1, 1, 1, 2, 1, 1, 1,
            3, 2, 2, 2, 2, 1, 1, 1, 2, 1, 1, 1, 2, 1, 1, 1,
            3, 2, 2, 2, 2, 1, 1, 1, 2, 1, 1, 1, 2, 1, 1, 1,
            2, 1, 1, 1, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0,
            2, 1, 1, 1, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0,
            2, 1, 1, 1, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0,
            3, 2, 2, 2, 2, 1, 1, 1, 2, 1, 1, 1, 2, 1, 1, 1,
            2, 1, 1, 1, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0,
            2, 1, 1, 1, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0,
            2, 1, 1, 1, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0,
            3, 2, 2, 2, 2, 1, 1, 1, 2, 1, 1, 1, 2, 1, 1, 1,
            2, 1, 1, 1, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0,
            2, 1, 1, 1, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0,
            2, 1, 1, 1, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0
        };

        public static int Confidence(ReadOnlySpan<byte> first, ReadOnlySpan<byte> second)
        {
            int diff = 0;
            for (int i = 0; i < HASH_LENGTH; i++)
            {
                diff += PairCountTable[first[i] ^ second[i]];
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
                diff += PairCountTableSpan[first[i] ^ second[i]];
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
            ref byte table = ref MemoryMarshal.GetReference(PairCountTableSpan);

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
            ref Byte tableRef = ref MemoryMarshal.GetReference(PairCountTableSpan);

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
    }
}
