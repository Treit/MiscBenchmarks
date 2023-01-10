namespace Test
{
    using BenchmarkDotNet.Attributes;
    using System;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [MemoryDiagnoser]
    public class Benchmark
    {

        [GlobalSetup]
        public void GlobalSetup()
        {
        }

        [Benchmark(Baseline = true)]
        public string DecodeString()
        {
            var enc = "灩捯䍔䙻ㄶ形楴獟楮獴㌴摟潦弸彥ㄴㅡて㝽";
            var sb = new StringBuilder(enc.Length);

            foreach (var ch in enc)
            {
                sb.Append((char)(ch >> 8));
                sb.Append((char)(ch & 0xFF));
            }

            return sb.ToString();
        }

        [Benchmark]
        public string DecodeStringChatGPTRecursive()
        {
            string enc = "灩捯䍔䙻ㄶ形楴獟楮獴㌴摟潦弸彥ㄴㅡて㝽";
            return DecodeString(enc);
        }

        [Benchmark]
        public string DecodeStringChatGPTLinq()
        {
            string enc = "灩捯䍔䙻ㄶ形楴獟楮獴㌴摟潦弸彥ㄴㅡて㝽";
            string r = string.Join("", enc.SelectMany(x => Encoding.BigEndianUnicode.GetBytes(x.ToString()).Select(b => (char)b)));
            return r;
        }

        static string DecodeString(string enc)
        {
            if (string.IsNullOrEmpty(enc))
            {
                return "";
            }

            byte[] b = Encoding.BigEndianUnicode.GetBytes(enc.Substring(0, 1));
            return Encoding.ASCII.GetString(new byte[] { b[0] }) +
                    Encoding.ASCII.GetString(new byte[] { b[1] }) +
                    DecodeString(enc.Substring(1));
        }
    }
}

