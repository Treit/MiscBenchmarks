namespace Test
{
    using BenchmarkDotNet.Attributes;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Benchmark
    {
        [Params(10, 10_000)]
        public int Count { get; set; }

        private List<string> _data;

        [GlobalSetup]
        public void GlobalSetup()
        {
            _data = new List<string>(Count);

            var r = new Random(Count);
            var sb = new StringBuilder();

            for (int i = 0; i < Count; i++)
            {
                sb.Clear();

                for (int j = 0; j < 10; j++)
                {
                    var x = r.Next(6);

                    if (x == 0)
                    {
                        sb.Append("L");
                    }
                    else if (x == 1)
                    {
                        sb.Append("A");
                    }
                    else
                    {
                        sb.Append("P");
                    }
                }

                _data.Add(sb.ToString());
            }

            foreach (var str in _data)
            {
                Console.WriteLine(str);
            }
        }

        [Benchmark]
        public bool TestVersionA()
        {
            bool ret = false;

            foreach (var str in _data)
            {
                ret = VersionA(str);
            }

            return ret;
        }

        [Benchmark]
        public bool TestVersionB()
        {
            bool ret = false;

            foreach (var str in _data)
            {
                ret = VersionB(str);
            }

            return ret;
        }

        private bool VersionA(string s)
        {
            int a = 0, l = 0;
            bool notLate3 = true;
            foreach (char ch in s)
            {
                if (ch == 'A')
                {
                    a++;
                    l = 0;
                }
                else if (ch == 'L')
                {
                    l++;
                    if (l >= 3)
                    {
                        notLate3 = false;
                    }
                }
                else
                {
                    l = 0;
                }
            }

            if (notLate3 && a < 2)
            {
                return true;
            }

            return false;
        }

        private bool VersionB(string s)
        {
            int a = 0, l = 0; //no bool to store
            foreach (char ch in s)
            {
                if (ch == 'A')
                {
                    a++;
                    l = 0;
                }
                else if (ch == 'L')
                {
                    l++;
                    if (l >= 3)
                    {
                        return false; //Quick escape here
                    }
                }
                else
                {
                    l = 0;
                }
            }

            if (a < 2) //less check
            {
                return true;
            }

            return false;
        }

    }
}
