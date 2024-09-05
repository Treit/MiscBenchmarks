namespace Test
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    [MemoryDiagnoser]
    public class Benchmark
    {
        private static string _delimitedString = $"A1,B1,C1,D1,E1,F1,G1,H1,I1,J1,K1,L1,M1,N1,O1,P1,Q1,R1,S1,T1,U1,V1,W1,X1,Y1,Z1";
        private static Regex _regex;


        [GlobalSetup]
        public void GlobalSetup()
        {
            _regex = new Regex("^.+,(.+),(.+)$", RegexOptions.Compiled);
        }

        [Benchmark]
        public (string, string) LastTwoTokensWithSplit()
        {
            var tokens = _delimitedString.Split(',');
            var result = (tokens[tokens.Length - 2], tokens[tokens.Length - 1]);

            return result;
        }

        [Benchmark(Baseline = true)]
        public (string, string) LastTwoTokensWithRegex()
        {
            var match = _regex.Match(_delimitedString);
            var result = (match.Groups[1].Value, match.Groups[2].Value);

            return result;
        }

        [Benchmark]
        public (string, string) LastTwoTokensWithReverseAndSubstring()
        {
            var reversed = _delimitedString.Reverse().ToArray();
            var firstDelim = 0;
            var secondDelim = 0;
            var i = 0;
            foreach (var c in reversed)
            {
                if (c == ',')
                {
                    if (firstDelim == 0)
                    {
                        firstDelim = i;
                    }
                    else
                    {
                        secondDelim = i;
                        break;
                    }
                }
                i++;
            }

            var firstSpan = reversed.AsSpan(firstDelim + 1, secondDelim - firstDelim - 1);
            firstSpan.Reverse();
            var first = firstSpan.ToString();

            var secondSpan = reversed.AsSpan(0, firstDelim);
            secondSpan.Reverse();
            var second = secondSpan.ToString();

            return (first, second);
        }

        [Benchmark]
        public (string, string) LastTwoTokensWalkingBackwards()
        {
            var firstDelim = 0;
            var secondDelim = 0;

            for (int i = _delimitedString.Length - 1; i >= 0; i--)
            {
                if (_delimitedString[i] == ',')
                {
                    if (firstDelim == 0)
                    {
                        firstDelim = i;
                    }
                    else
                    {
                        secondDelim = i;
                        break;
                    }
                }
            }

            var first = _delimitedString.Substring(secondDelim + 1, firstDelim - secondDelim - 1);
            var second = _delimitedString.Substring(firstDelim + 1);
            return (first, second);

        }
    }
}
