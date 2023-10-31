namespace Test
{
    using BenchmarkDotNet.Attributes;
    using Classes;
    using Records;
    using System.Collections.Generic;

    public class Benchmark
    {
        [GlobalSetup]
        public void GlobalSetup()
        {
        }

        [Benchmark]
        public int Classes()
        {
            var l = new List<object>();

            l.Add(new Class0());
            l.Add(new Class1());
            l.Add(new Class2());
            l.Add(new Class3());
            l.Add(new Class4());
            l.Add(new Class5());
            l.Add(new Class6());
            l.Add(new Class7());
            l.Add(new Class8());
            l.Add(new Class9());
            l.Add(new Class10());
            l.Add(new Class11());
            l.Add(new Class12());
            l.Add(new Class13());
            l.Add(new Class14());
            l.Add(new Class15());
            l.Add(new Class16());
            l.Add(new Class17());
            l.Add(new Class18());
            l.Add(new Class19());
            l.Add(new Class20());
            l.Add(new Class21());
            l.Add(new Class22());
            l.Add(new Class23());
            l.Add(new Class24());
            l.Add(new Class25());
            l.Add(new Class26());
            l.Add(new Class27());
            l.Add(new Class28());
            l.Add(new Class29());
            l.Add(new Class30());
            l.Add(new Class31());
            l.Add(new Class32());
            l.Add(new Class33());
            l.Add(new Class34());
            l.Add(new Class35());
            l.Add(new Class36());
            l.Add(new Class37());
            l.Add(new Class38());
            l.Add(new Class39());
            l.Add(new Class40());
            l.Add(new Class41());
            l.Add(new Class42());
            l.Add(new Class43());
            l.Add(new Class44());
            l.Add(new Class45());
            l.Add(new Class46());
            l.Add(new Class47());
            l.Add(new Class48());
            l.Add(new Class49());
            l.Add(new Class50());
            l.Add(new Class51());
            l.Add(new Class52());
            l.Add(new Class53());
            l.Add(new Class54());
            l.Add(new Class55());
            l.Add(new Class56());
            l.Add(new Class57());
            l.Add(new Class58());
            l.Add(new Class59());
            l.Add(new Class60());
            l.Add(new Class61());
            l.Add(new Class62());
            l.Add(new Class63());
            l.Add(new Class64());
            l.Add(new Class65());
            l.Add(new Class66());
            l.Add(new Class67());
            l.Add(new Class68());
            l.Add(new Class69());
            l.Add(new Class70());
            l.Add(new Class71());
            l.Add(new Class72());
            l.Add(new Class73());
            l.Add(new Class74());
            l.Add(new Class75());
            l.Add(new Class76());
            l.Add(new Class77());
            l.Add(new Class78());
            l.Add(new Class79());
            l.Add(new Class80());
            l.Add(new Class81());
            l.Add(new Class82());
            l.Add(new Class83());
            l.Add(new Class84());
            l.Add(new Class85());
            l.Add(new Class86());
            l.Add(new Class87());
            l.Add(new Class88());
            l.Add(new Class89());
            l.Add(new Class90());
            l.Add(new Class91());
            l.Add(new Class92());
            l.Add(new Class93());
            l.Add(new Class94());
            l.Add(new Class95());
            l.Add(new Class96());
            l.Add(new Class97());
            l.Add(new Class98());
            l.Add(new Class99());

            return l.Count;
        }

        [Benchmark]
        public int Records()
        {
            var l = new List<object>();

            l.Add(new Record0());
            l.Add(new Record1());
            l.Add(new Record2());
            l.Add(new Record3());
            l.Add(new Record4());
            l.Add(new Record5());
            l.Add(new Record6());
            l.Add(new Record7());
            l.Add(new Record8());
            l.Add(new Record9());
            l.Add(new Record10());
            l.Add(new Record11());
            l.Add(new Record12());
            l.Add(new Record13());
            l.Add(new Record14());
            l.Add(new Record15());
            l.Add(new Record16());
            l.Add(new Record17());
            l.Add(new Record18());
            l.Add(new Record19());
            l.Add(new Record20());
            l.Add(new Record21());
            l.Add(new Record22());
            l.Add(new Record23());
            l.Add(new Record24());
            l.Add(new Record25());
            l.Add(new Record26());
            l.Add(new Record27());
            l.Add(new Record28());
            l.Add(new Record29());
            l.Add(new Record30());
            l.Add(new Record31());
            l.Add(new Record32());
            l.Add(new Record33());
            l.Add(new Record34());
            l.Add(new Record35());
            l.Add(new Record36());
            l.Add(new Record37());
            l.Add(new Record38());
            l.Add(new Record39());
            l.Add(new Record40());
            l.Add(new Record41());
            l.Add(new Record42());
            l.Add(new Record43());
            l.Add(new Record44());
            l.Add(new Record45());
            l.Add(new Record46());
            l.Add(new Record47());
            l.Add(new Record48());
            l.Add(new Record49());
            l.Add(new Record50());
            l.Add(new Record51());
            l.Add(new Record52());
            l.Add(new Record53());
            l.Add(new Record54());
            l.Add(new Record55());
            l.Add(new Record56());
            l.Add(new Record57());
            l.Add(new Record58());
            l.Add(new Record59());
            l.Add(new Record60());
            l.Add(new Record61());
            l.Add(new Record62());
            l.Add(new Record63());
            l.Add(new Record64());
            l.Add(new Record65());
            l.Add(new Record66());
            l.Add(new Record67());
            l.Add(new Record68());
            l.Add(new Record69());
            l.Add(new Record70());
            l.Add(new Record71());
            l.Add(new Record72());
            l.Add(new Record73());
            l.Add(new Record74());
            l.Add(new Record75());
            l.Add(new Record76());
            l.Add(new Record77());
            l.Add(new Record78());
            l.Add(new Record79());
            l.Add(new Record80());
            l.Add(new Record81());
            l.Add(new Record82());
            l.Add(new Record83());
            l.Add(new Record84());
            l.Add(new Record85());
            l.Add(new Record86());
            l.Add(new Record87());
            l.Add(new Record88());
            l.Add(new Record89());
            l.Add(new Record90());
            l.Add(new Record91());
            l.Add(new Record92());
            l.Add(new Record93());
            l.Add(new Record94());
            l.Add(new Record95());
            l.Add(new Record96());
            l.Add(new Record97());
            l.Add(new Record98());
            l.Add(new Record99());

            return l.Count;
        }
    }
}
