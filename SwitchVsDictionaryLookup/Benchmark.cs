namespace Test
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;
    using System;
    using System.Collections.Generic;

    [MemoryDiagnoser]
    public class Benchmark
    {
        Dictionary<Type, int> typeMap = new();
        List<object> availableObjects100 = new();
        List<object> availableObjects5 = new();

        [GlobalSetup]
        public void GlobalSetup()
        {
            typeMap.Add(typeof(TestClass0), 0);
            typeMap.Add(typeof(TestClass1), 1);
            typeMap.Add(typeof(TestClass2), 2);
            typeMap.Add(typeof(TestClass3), 3);
            typeMap.Add(typeof(TestClass4), 4);
            typeMap.Add(typeof(TestClass5), 5);
            typeMap.Add(typeof(TestClass6), 6);
            typeMap.Add(typeof(TestClass7), 7);
            typeMap.Add(typeof(TestClass8), 8);
            typeMap.Add(typeof(TestClass9), 9);
            typeMap.Add(typeof(TestClass10), 10);
            typeMap.Add(typeof(TestClass11), 11);
            typeMap.Add(typeof(TestClass12), 12);
            typeMap.Add(typeof(TestClass13), 13);
            typeMap.Add(typeof(TestClass14), 14);
            typeMap.Add(typeof(TestClass15), 15);
            typeMap.Add(typeof(TestClass16), 16);
            typeMap.Add(typeof(TestClass17), 17);
            typeMap.Add(typeof(TestClass18), 18);
            typeMap.Add(typeof(TestClass19), 19);
            typeMap.Add(typeof(TestClass20), 20);
            typeMap.Add(typeof(TestClass21), 21);
            typeMap.Add(typeof(TestClass22), 22);
            typeMap.Add(typeof(TestClass23), 23);
            typeMap.Add(typeof(TestClass24), 24);
            typeMap.Add(typeof(TestClass25), 25);
            typeMap.Add(typeof(TestClass26), 26);
            typeMap.Add(typeof(TestClass27), 27);
            typeMap.Add(typeof(TestClass28), 28);
            typeMap.Add(typeof(TestClass29), 29);
            typeMap.Add(typeof(TestClass30), 30);
            typeMap.Add(typeof(TestClass31), 31);
            typeMap.Add(typeof(TestClass32), 32);
            typeMap.Add(typeof(TestClass33), 33);
            typeMap.Add(typeof(TestClass34), 34);
            typeMap.Add(typeof(TestClass35), 35);
            typeMap.Add(typeof(TestClass36), 36);
            typeMap.Add(typeof(TestClass37), 37);
            typeMap.Add(typeof(TestClass38), 38);
            typeMap.Add(typeof(TestClass39), 39);
            typeMap.Add(typeof(TestClass40), 40);
            typeMap.Add(typeof(TestClass41), 41);
            typeMap.Add(typeof(TestClass42), 42);
            typeMap.Add(typeof(TestClass43), 43);
            typeMap.Add(typeof(TestClass44), 44);
            typeMap.Add(typeof(TestClass45), 45);
            typeMap.Add(typeof(TestClass46), 46);
            typeMap.Add(typeof(TestClass47), 47);
            typeMap.Add(typeof(TestClass48), 48);
            typeMap.Add(typeof(TestClass49), 49);
            typeMap.Add(typeof(TestClass50), 50);
            typeMap.Add(typeof(TestClass51), 51);
            typeMap.Add(typeof(TestClass52), 52);
            typeMap.Add(typeof(TestClass53), 53);
            typeMap.Add(typeof(TestClass54), 54);
            typeMap.Add(typeof(TestClass55), 55);
            typeMap.Add(typeof(TestClass56), 56);
            typeMap.Add(typeof(TestClass57), 57);
            typeMap.Add(typeof(TestClass58), 58);
            typeMap.Add(typeof(TestClass59), 59);
            typeMap.Add(typeof(TestClass60), 60);
            typeMap.Add(typeof(TestClass61), 61);
            typeMap.Add(typeof(TestClass62), 62);
            typeMap.Add(typeof(TestClass63), 63);
            typeMap.Add(typeof(TestClass64), 64);
            typeMap.Add(typeof(TestClass65), 65);
            typeMap.Add(typeof(TestClass66), 66);
            typeMap.Add(typeof(TestClass67), 67);
            typeMap.Add(typeof(TestClass68), 68);
            typeMap.Add(typeof(TestClass69), 69);
            typeMap.Add(typeof(TestClass70), 70);
            typeMap.Add(typeof(TestClass71), 71);
            typeMap.Add(typeof(TestClass72), 72);
            typeMap.Add(typeof(TestClass73), 73);
            typeMap.Add(typeof(TestClass74), 74);
            typeMap.Add(typeof(TestClass75), 75);
            typeMap.Add(typeof(TestClass76), 76);
            typeMap.Add(typeof(TestClass77), 77);
            typeMap.Add(typeof(TestClass78), 78);
            typeMap.Add(typeof(TestClass79), 79);
            typeMap.Add(typeof(TestClass80), 80);
            typeMap.Add(typeof(TestClass81), 81);
            typeMap.Add(typeof(TestClass82), 82);
            typeMap.Add(typeof(TestClass83), 83);
            typeMap.Add(typeof(TestClass84), 84);
            typeMap.Add(typeof(TestClass85), 85);
            typeMap.Add(typeof(TestClass86), 86);
            typeMap.Add(typeof(TestClass87), 87);
            typeMap.Add(typeof(TestClass88), 88);
            typeMap.Add(typeof(TestClass89), 89);
            typeMap.Add(typeof(TestClass90), 90);
            typeMap.Add(typeof(TestClass91), 91);
            typeMap.Add(typeof(TestClass92), 92);
            typeMap.Add(typeof(TestClass93), 93);
            typeMap.Add(typeof(TestClass94), 94);
            typeMap.Add(typeof(TestClass95), 95);
            typeMap.Add(typeof(TestClass96), 96);
            typeMap.Add(typeof(TestClass97), 97);
            typeMap.Add(typeof(TestClass98), 98);
            typeMap.Add(typeof(TestClass99), 99);
            typeMap.Add(typeof(TestClass100), 100);

            availableObjects5.Add(new TestClass0());
            availableObjects5.Add(new TestClass1());
            availableObjects5.Add(new TestClass2());
            availableObjects5.Add(new TestClass3());
            availableObjects5.Add(new TestClass4());

            availableObjects100.Add(new TestClass0());
            availableObjects100.Add(new TestClass1());
            availableObjects100.Add(new TestClass2());
            availableObjects100.Add(new TestClass3());
            availableObjects100.Add(new TestClass4());
            availableObjects100.Add(new TestClass5());
            availableObjects100.Add(new TestClass6());
            availableObjects100.Add(new TestClass7());
            availableObjects100.Add(new TestClass8());
            availableObjects100.Add(new TestClass9());
            availableObjects100.Add(new TestClass10());
            availableObjects100.Add(new TestClass11());
            availableObjects100.Add(new TestClass12());
            availableObjects100.Add(new TestClass13());
            availableObjects100.Add(new TestClass14());
            availableObjects100.Add(new TestClass15());
            availableObjects100.Add(new TestClass16());
            availableObjects100.Add(new TestClass17());
            availableObjects100.Add(new TestClass18());
            availableObjects100.Add(new TestClass19());
            availableObjects100.Add(new TestClass20());
            availableObjects100.Add(new TestClass21());
            availableObjects100.Add(new TestClass22());
            availableObjects100.Add(new TestClass23());
            availableObjects100.Add(new TestClass24());
            availableObjects100.Add(new TestClass25());
            availableObjects100.Add(new TestClass26());
            availableObjects100.Add(new TestClass27());
            availableObjects100.Add(new TestClass28());
            availableObjects100.Add(new TestClass29());
            availableObjects100.Add(new TestClass30());
            availableObjects100.Add(new TestClass31());
            availableObjects100.Add(new TestClass32());
            availableObjects100.Add(new TestClass33());
            availableObjects100.Add(new TestClass34());
            availableObjects100.Add(new TestClass35());
            availableObjects100.Add(new TestClass36());
            availableObjects100.Add(new TestClass37());
            availableObjects100.Add(new TestClass38());
            availableObjects100.Add(new TestClass39());
            availableObjects100.Add(new TestClass40());
            availableObjects100.Add(new TestClass41());
            availableObjects100.Add(new TestClass42());
            availableObjects100.Add(new TestClass43());
            availableObjects100.Add(new TestClass44());
            availableObjects100.Add(new TestClass45());
            availableObjects100.Add(new TestClass46());
            availableObjects100.Add(new TestClass47());
            availableObjects100.Add(new TestClass48());
            availableObjects100.Add(new TestClass49());
            availableObjects100.Add(new TestClass50());
            availableObjects100.Add(new TestClass51());
            availableObjects100.Add(new TestClass52());
            availableObjects100.Add(new TestClass53());
            availableObjects100.Add(new TestClass54());
            availableObjects100.Add(new TestClass55());
            availableObjects100.Add(new TestClass56());
            availableObjects100.Add(new TestClass57());
            availableObjects100.Add(new TestClass58());
            availableObjects100.Add(new TestClass59());
            availableObjects100.Add(new TestClass60());
            availableObjects100.Add(new TestClass61());
            availableObjects100.Add(new TestClass62());
            availableObjects100.Add(new TestClass63());
            availableObjects100.Add(new TestClass64());
            availableObjects100.Add(new TestClass65());
            availableObjects100.Add(new TestClass66());
            availableObjects100.Add(new TestClass67());
            availableObjects100.Add(new TestClass68());
            availableObjects100.Add(new TestClass69());
            availableObjects100.Add(new TestClass70());
            availableObjects100.Add(new TestClass71());
            availableObjects100.Add(new TestClass72());
            availableObjects100.Add(new TestClass73());
            availableObjects100.Add(new TestClass74());
            availableObjects100.Add(new TestClass75());
            availableObjects100.Add(new TestClass76());
            availableObjects100.Add(new TestClass77());
            availableObjects100.Add(new TestClass78());
            availableObjects100.Add(new TestClass79());
            availableObjects100.Add(new TestClass80());
            availableObjects100.Add(new TestClass81());
            availableObjects100.Add(new TestClass82());
            availableObjects100.Add(new TestClass83());
            availableObjects100.Add(new TestClass84());
            availableObjects100.Add(new TestClass85());
            availableObjects100.Add(new TestClass86());
            availableObjects100.Add(new TestClass87());
            availableObjects100.Add(new TestClass88());
            availableObjects100.Add(new TestClass89());
            availableObjects100.Add(new TestClass90());
            availableObjects100.Add(new TestClass91());
            availableObjects100.Add(new TestClass92());
            availableObjects100.Add(new TestClass93());
            availableObjects100.Add(new TestClass94());
            availableObjects100.Add(new TestClass95());
            availableObjects100.Add(new TestClass96());
            availableObjects100.Add(new TestClass97());
            availableObjects100.Add(new TestClass98());
            availableObjects100.Add(new TestClass99());
            availableObjects100.Add(new TestClass100());
        }

        [Benchmark]
        public long LookupTypeUsingDictionary100Items()
        {
            var r = new Random(1234);
            long result = 0;

            for (int i = 0; i < 100; i++)
            {
                var o = availableObjects100[r.Next(0, availableObjects100.Count)];
                result += typeMap[o.GetType()];
            }

            return result;
        }

        [Benchmark]
        public long LookupTypeUsingDictionary5Items()
        {
            var r = new Random(1234);
            long result = 0;

            for (int i = 0; i < 100; i++)
            {
                var o = availableObjects100[r.Next(0, availableObjects5.Count)];
                result += typeMap[o.GetType()];
            }

            return result;
        }

        [Benchmark]
        public long LookupTypeUsingSwitch5Items()
        {
            var r = new Random(1234);
            long result = 0;

            for (int i = 0; i < 100; i++)
            {
                var t = availableObjects5[r.Next(0, 5)];

                result += t switch
                {
                    TestClass0 => 0,
                    TestClass1 => 1,
                    TestClass2 => 2,
                    TestClass3 => 3,
                    TestClass4 => 4,
                    _ => throw new ArgumentOutOfRangeException()
                };
            }

            return result;
        }

        [Benchmark]
        public long LookupTypeUsingSwitch100Items()
        {
            var r = new Random(1234);
            long result = 0;

            for (int i = 0; i < 100; i++)
            {
                var t = availableObjects100[r.Next(0, availableObjects100.Count)];

                result += t switch
                {
                    TestClass0 => 0,
                    TestClass1 => 1,
                    TestClass2 => 2,
                    TestClass3 => 3,
                    TestClass4 => 4,
                    TestClass5 => 5,
                    TestClass6 => 6,
                    TestClass7 => 7,
                    TestClass8 => 8,
                    TestClass9 => 9,
                    TestClass10 => 10,
                    TestClass11 => 11,
                    TestClass12 => 12,
                    TestClass13 => 13,
                    TestClass14 => 14,
                    TestClass15 => 15,
                    TestClass16 => 16,
                    TestClass17 => 17,
                    TestClass18 => 18,
                    TestClass19 => 19,
                    TestClass20 => 20,
                    TestClass21 => 21,
                    TestClass22 => 22,
                    TestClass23 => 23,
                    TestClass24 => 24,
                    TestClass25 => 25,
                    TestClass26 => 26,
                    TestClass27 => 27,
                    TestClass28 => 28,
                    TestClass29 => 29,
                    TestClass30 => 30,
                    TestClass31 => 31,
                    TestClass32 => 32,
                    TestClass33 => 33,
                    TestClass34 => 34,
                    TestClass35 => 35,
                    TestClass36 => 36,
                    TestClass37 => 37,
                    TestClass38 => 38,
                    TestClass39 => 39,
                    TestClass40 => 40,
                    TestClass41 => 41,
                    TestClass42 => 42,
                    TestClass43 => 43,
                    TestClass44 => 44,
                    TestClass45 => 45,
                    TestClass46 => 46,
                    TestClass47 => 47,
                    TestClass48 => 48,
                    TestClass49 => 49,
                    TestClass50 => 50,
                    TestClass51 => 51,
                    TestClass52 => 52,
                    TestClass53 => 53,
                    TestClass54 => 54,
                    TestClass55 => 55,
                    TestClass56 => 56,
                    TestClass57 => 57,
                    TestClass58 => 58,
                    TestClass59 => 59,
                    TestClass60 => 60,
                    TestClass61 => 61,
                    TestClass62 => 62,
                    TestClass63 => 63,
                    TestClass64 => 64,
                    TestClass65 => 65,
                    TestClass66 => 66,
                    TestClass67 => 67,
                    TestClass68 => 68,
                    TestClass69 => 69,
                    TestClass70 => 70,
                    TestClass71 => 71,
                    TestClass72 => 72,
                    TestClass73 => 73,
                    TestClass74 => 74,
                    TestClass75 => 75,
                    TestClass76 => 76,
                    TestClass77 => 77,
                    TestClass78 => 78,
                    TestClass79 => 79,
                    TestClass80 => 80,
                    TestClass81 => 81,
                    TestClass82 => 82,
                    TestClass83 => 83,
                    TestClass84 => 84,
                    TestClass85 => 85,
                    TestClass86 => 86,
                    TestClass87 => 87,
                    TestClass88 => 88,
                    TestClass89 => 89,
                    TestClass90 => 90,
                    TestClass91 => 91,
                    TestClass92 => 92,
                    TestClass93 => 93,
                    TestClass94 => 94,
                    TestClass95 => 95,
                    TestClass96 => 96,
                    TestClass97 => 97,
                    TestClass98 => 98,
                    TestClass99 => 99,
                    TestClass100 => 100,
                    _ => throw new ArgumentOutOfRangeException()
                };
            }

            return result;
        }
    }
}
