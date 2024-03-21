using System.Text;

namespace Test
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;
    using System;
    using System.Reflection;

    [MemoryDiagnoser]
    public class Benchmark
    {
        [Params(6, 50, 1000)]
        public int HexStringLength { get; set; }

        private string _hexString;

        [GlobalSetup]
        public void GlobalSetup()
        {
            var r = new Random(HexStringLength);
            _hexString = RandomStringCreate(r, "0123456789ABCDEF", HexStringLength);
        }

        [Benchmark(Baseline = true)]
        public byte[] HexStringToBytesUsingConvert()
        {
            var str = _hexString;
            return Convert.FromHexString(str);
        }

        [Benchmark]
        public byte[] HexStringToBytesUsingCustomImplementation()
        {
            var str = _hexString;
            return HexBytesToInMemBytes(str, false);
        }

        static byte[] HexBytesToInMemBytes(string hexBytes, bool checkPrefix)
        {
            if (string.IsNullOrEmpty(hexBytes))
            {
                return new byte[0];
            }
            if (hexBytes.Length % 2 != 0)
            {
                // just return an empty one
                return new byte[0];
            }

            int len = hexBytes.Length;
            int index = 0;
            if (checkPrefix && hexBytes[0] == '0' && (hexBytes[1] == 'x' || hexBytes[1] == 'X'))
            {
                index = 2;

            }
            byte[] result = new byte[(len - index) / 2];
            int count = 0;
            for (int i = index; i < len;)
            {
                //byte value = byte.Parse(hexBytes.Substring(i, 2), System.Globalization.NumberStyles.HexNumber);
                byte value = (byte)(ParseHexChar(hexBytes[i]) << 4 | ParseHexChar(hexBytes[i + 1]));
                result[count++] = value;
                i += 2;
            }
            return result;
        }

        /// <summary>
		/// parse hex char into int. Note should be byte
		/// </summary>
		/// <param name="c"></param>
		/// <returns></returns>
		private static int ParseHexChar(char hexChar)
        {
            if (hexChar >= '0' && hexChar <= '9')
            {
                return hexChar - '0';
            }
            else if (hexChar >= 'A' && hexChar <= 'F')
            {
                return hexChar - 'A' + 10;
            }
            else if (hexChar >= 'a' && hexChar <= 'f')
            {
                return hexChar - 'a' + 10;
            }
            else
            {
                // don't throw, just return
                return -1;
            }
        }

        static string RandomStringCreate(Random random, string alphabet, int fixedLength)
        {
            var len = fixedLength;
            return string.Create(len, random, (buff, str) =>
            {
                for (int i = 0; i < buff.Length; i++)
                {
                    buff[i] = alphabet[random.Next(alphabet.Length)];
                }
            });
        }
    }
}

