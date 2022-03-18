using System;

namespace Test
{
    /*
    Assume a bitset is an array of words.
    To retrieve a particular bit:
    1. Get the word in which the bit is set: word <- i / BITS_PER_WORD]
    2. Get the bit position in the word: index <- i mod BITS_PER_WORD
    3. To see if the bit is set: bit <- word & (1 lsh (BITS_PER_WORD - index - 1))

    0 1 2 3 4 5 6 7 | 8 9 10 11 12 13 14 15 | 16 17 18 19 20 21 22 23 | 24 25 26 27 28 29 30 31
    ---------------------------------------------------------------------------------------------
    1 0 1 0 0 0 1 0   1 0 1  0  1  0  1  0    1  0  1  1  0  0  0  0    0  1  0  0  0  0  0  1
      0xA2 (162)    |   0xAA (170)          |    0xB0 (176)           |    0x41 (65)
    ---------------------------------------------------------------------------------------------
    */
    public class BitSet
    {
        const int BITS_PER_WORD = 32;
        readonly int[] _words;
        readonly int _maxBits;

        public BitSet(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentOutOfRangeException("size");
            }

            _maxBits = size;

            var wordcount = (int)Math.Ceiling((double)_maxBits / BITS_PER_WORD);
            _words = new int[wordcount];
        }

        public bool this[int index]
        {
            get => Get(index);
            set => Set(index, value);
        }

        private bool Get(int index)
        {
            if (index > _maxBits - 1)
            {
                throw new ArgumentOutOfRangeException("index");
            }

            var wordIndex = index / BITS_PER_WORD;
            var word = _words[wordIndex];
            var bitpos = index % BITS_PER_WORD;
            var mask = 1 << (BITS_PER_WORD - bitpos - 1);
            return (word & mask) switch
            {
                0 => false,
                _ => true
            };
        }

        private void Set(int index, bool value)
        {
            if (index > _maxBits - 1)
            {
                throw new ArgumentOutOfRangeException("index");
            }

            var wordIndex = index / BITS_PER_WORD;
            var word = _words[wordIndex];
            var bitpos = index % BITS_PER_WORD;
            var mask = 1 << (BITS_PER_WORD - bitpos - 1);
            _words[wordIndex] = value switch
            {
                true => word | mask,
                false => word & ~mask
            };
        }
    }
}