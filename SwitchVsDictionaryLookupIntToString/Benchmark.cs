namespace Test;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using System;
using System.Collections.Generic;

[MemoryDiagnoser]
public class Benchmark
{
    Dictionary<int, string> intToStringMap = new();
    List<int> availableInts100 = new();
    List<int> availableInts5 = new();

    [GlobalSetup]
    public void GlobalSetup()
    {
        for (int i = 0; i <= 100; i++)
        {
            intToStringMap.Add(i, $"Value_{i}");
        }

        for (int i = 0; i < 5; i++)
        {
            availableInts5.Add(i);
        }

        for (int i = 0; i <= 100; i++)
        {
            availableInts100.Add(i);
        }
    }

    [Benchmark]
    public string LookupIntKeyUsingDictionary100Items()
    {
        var r = new Random(1234);
        string result = "";

        for (int i = 0; i < 100; i++)
        {
            var key = availableInts100[r.Next(0, availableInts100.Count)];
            result = intToStringMap[key];
        }

        return result;
    }

    [Benchmark(Baseline = true)]
    public string LookupIntKeyUsingDictionary5Items()
    {
        var r = new Random(1234);
        string result = "";

        for (int i = 0; i < 100; i++)
        {
            var key = availableInts5[r.Next(0, 5)];
            result = intToStringMap[key];
        }

        return result;
    }

    [Benchmark]
    public string LookupIntKeyUsingSwitchExpression5Items()
    {
        var r = new Random(1234);
        string result = "";

        for (int i = 0; i < 100; i++)
        {
            var key = availableInts5[r.Next(0, 5)];

            result = key switch
            {
                0 => "Value_0",
                1 => "Value_1",
                2 => "Value_2",
                3 => "Value_3",
                4 => "Value_4",
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        return result;
    }

    [Benchmark]
    public string LookupIntKeyUsingSwitchExpression100Items()
    {
        var r = new Random(1234);
        string result = "";

        for (int i = 0; i < 100; i++)
        {
            var key = availableInts100[r.Next(0, availableInts100.Count)];

            result = key switch
            {
                0 => "Value_0",
                1 => "Value_1",
                2 => "Value_2",
                3 => "Value_3",
                4 => "Value_4",
                5 => "Value_5",
                6 => "Value_6",
                7 => "Value_7",
                8 => "Value_8",
                9 => "Value_9",
                10 => "Value_10",
                11 => "Value_11",
                12 => "Value_12",
                13 => "Value_13",
                14 => "Value_14",
                15 => "Value_15",
                16 => "Value_16",
                17 => "Value_17",
                18 => "Value_18",
                19 => "Value_19",
                20 => "Value_20",
                21 => "Value_21",
                22 => "Value_22",
                23 => "Value_23",
                24 => "Value_24",
                25 => "Value_25",
                26 => "Value_26",
                27 => "Value_27",
                28 => "Value_28",
                29 => "Value_29",
                30 => "Value_30",
                31 => "Value_31",
                32 => "Value_32",
                33 => "Value_33",
                34 => "Value_34",
                35 => "Value_35",
                36 => "Value_36",
                37 => "Value_37",
                38 => "Value_38",
                39 => "Value_39",
                40 => "Value_40",
                41 => "Value_41",
                42 => "Value_42",
                43 => "Value_43",
                44 => "Value_44",
                45 => "Value_45",
                46 => "Value_46",
                47 => "Value_47",
                48 => "Value_48",
                49 => "Value_49",
                50 => "Value_50",
                51 => "Value_51",
                52 => "Value_52",
                53 => "Value_53",
                54 => "Value_54",
                55 => "Value_55",
                56 => "Value_56",
                57 => "Value_57",
                58 => "Value_58",
                59 => "Value_59",
                60 => "Value_60",
                61 => "Value_61",
                62 => "Value_62",
                63 => "Value_63",
                64 => "Value_64",
                65 => "Value_65",
                66 => "Value_66",
                67 => "Value_67",
                68 => "Value_68",
                69 => "Value_69",
                70 => "Value_70",
                71 => "Value_71",
                72 => "Value_72",
                73 => "Value_73",
                74 => "Value_74",
                75 => "Value_75",
                76 => "Value_76",
                77 => "Value_77",
                78 => "Value_78",
                79 => "Value_79",
                80 => "Value_80",
                81 => "Value_81",
                82 => "Value_82",
                83 => "Value_83",
                84 => "Value_84",
                85 => "Value_85",
                86 => "Value_86",
                87 => "Value_87",
                88 => "Value_88",
                89 => "Value_89",
                90 => "Value_90",
                91 => "Value_91",
                92 => "Value_92",
                93 => "Value_93",
                94 => "Value_94",
                95 => "Value_95",
                96 => "Value_96",
                97 => "Value_97",
                98 => "Value_98",
                99 => "Value_99",
                100 => "Value_100",
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        return result;
    }

    [Benchmark]
    public string LookupIntKeyUsingSwitchStatement5Items()
    {
        var r = new Random(1234);
        string result = "";

        for (int i = 0; i < 100; i++)
        {
            var key = availableInts5[r.Next(0, 5)];

            switch (key)
            {
                case 0:
                    result = "Value_0";
                    break;
                case 1:
                    result = "Value_1";
                    break;
                case 2:
                    result = "Value_2";
                    break;
                case 3:
                    result = "Value_3";
                    break;
                case 4:
                    result = "Value_4";
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        return result;
    }

    [Benchmark]
    public string LookupIntKeyUsingSwitchStatement100Items()
    {
        var r = new Random(1234);
        string result = "";

        for (int i = 0; i < 100; i++)
        {
            var key = availableInts100[r.Next(0, availableInts100.Count)];

            switch (key)
            {
                case 0: result = "Value_0"; break;
                case 1: result = "Value_1"; break;
                case 2: result = "Value_2"; break;
                case 3: result = "Value_3"; break;
                case 4: result = "Value_4"; break;
                case 5: result = "Value_5"; break;
                case 6: result = "Value_6"; break;
                case 7: result = "Value_7"; break;
                case 8: result = "Value_8"; break;
                case 9: result = "Value_9"; break;
                case 10: result = "Value_10"; break;
                case 11: result = "Value_11"; break;
                case 12: result = "Value_12"; break;
                case 13: result = "Value_13"; break;
                case 14: result = "Value_14"; break;
                case 15: result = "Value_15"; break;
                case 16: result = "Value_16"; break;
                case 17: result = "Value_17"; break;
                case 18: result = "Value_18"; break;
                case 19: result = "Value_19"; break;
                case 20: result = "Value_20"; break;
                case 21: result = "Value_21"; break;
                case 22: result = "Value_22"; break;
                case 23: result = "Value_23"; break;
                case 24: result = "Value_24"; break;
                case 25: result = "Value_25"; break;
                case 26: result = "Value_26"; break;
                case 27: result = "Value_27"; break;
                case 28: result = "Value_28"; break;
                case 29: result = "Value_29"; break;
                case 30: result = "Value_30"; break;
                case 31: result = "Value_31"; break;
                case 32: result = "Value_32"; break;
                case 33: result = "Value_33"; break;
                case 34: result = "Value_34"; break;
                case 35: result = "Value_35"; break;
                case 36: result = "Value_36"; break;
                case 37: result = "Value_37"; break;
                case 38: result = "Value_38"; break;
                case 39: result = "Value_39"; break;
                case 40: result = "Value_40"; break;
                case 41: result = "Value_41"; break;
                case 42: result = "Value_42"; break;
                case 43: result = "Value_43"; break;
                case 44: result = "Value_44"; break;
                case 45: result = "Value_45"; break;
                case 46: result = "Value_46"; break;
                case 47: result = "Value_47"; break;
                case 48: result = "Value_48"; break;
                case 49: result = "Value_49"; break;
                case 50: result = "Value_50"; break;
                case 51: result = "Value_51"; break;
                case 52: result = "Value_52"; break;
                case 53: result = "Value_53"; break;
                case 54: result = "Value_54"; break;
                case 55: result = "Value_55"; break;
                case 56: result = "Value_56"; break;
                case 57: result = "Value_57"; break;
                case 58: result = "Value_58"; break;
                case 59: result = "Value_59"; break;
                case 60: result = "Value_60"; break;
                case 61: result = "Value_61"; break;
                case 62: result = "Value_62"; break;
                case 63: result = "Value_63"; break;
                case 64: result = "Value_64"; break;
                case 65: result = "Value_65"; break;
                case 66: result = "Value_66"; break;
                case 67: result = "Value_67"; break;
                case 68: result = "Value_68"; break;
                case 69: result = "Value_69"; break;
                case 70: result = "Value_70"; break;
                case 71: result = "Value_71"; break;
                case 72: result = "Value_72"; break;
                case 73: result = "Value_73"; break;
                case 74: result = "Value_74"; break;
                case 75: result = "Value_75"; break;
                case 76: result = "Value_76"; break;
                case 77: result = "Value_77"; break;
                case 78: result = "Value_78"; break;
                case 79: result = "Value_79"; break;
                case 80: result = "Value_80"; break;
                case 81: result = "Value_81"; break;
                case 82: result = "Value_82"; break;
                case 83: result = "Value_83"; break;
                case 84: result = "Value_84"; break;
                case 85: result = "Value_85"; break;
                case 86: result = "Value_86"; break;
                case 87: result = "Value_87"; break;
                case 88: result = "Value_88"; break;
                case 89: result = "Value_89"; break;
                case 90: result = "Value_90"; break;
                case 91: result = "Value_91"; break;
                case 92: result = "Value_92"; break;
                case 93: result = "Value_93"; break;
                case 94: result = "Value_94"; break;
                case 95: result = "Value_95"; break;
                case 96: result = "Value_96"; break;
                case 97: result = "Value_97"; break;
                case 98: result = "Value_98"; break;
                case 99: result = "Value_99"; break;
                case 100: result = "Value_100"; break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        return result;
    }
}
