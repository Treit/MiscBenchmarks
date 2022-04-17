using System.Text;

namespace Test
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.Json;

    [MemoryDiagnoser]
    public class Benchmark
    {
        [Params(10, 1000, 100_000)]
        public int Count { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
        }

        [Benchmark(Baseline = true)]
        public List<TestClassNullableProperties> NullablePropertiesCreeateAndSet50Properties()
        {
            var result = new List<TestClassNullableProperties>(Count);

            for (int i = 0; i < Count; i++)
            {
                var tc = new TestClassNullableProperties();
                tc.Property0 = 0.0;
                tc.Property1 = 1.1;
                tc.Property2 = 2.2;
                tc.Property3 = 3.3;
                tc.Property4 = 4.4;
                tc.Property5 = 5.5;
                tc.Property6 = 6.6;
                tc.Property7 = 7.7;
                tc.Property8 = 8.8;
                tc.Property9 = 9.9;
                tc.Property10 = 10.10;
                tc.Property11 = 11.11;
                tc.Property12 = 12.12;
                tc.Property13 = 13.13;
                tc.Property14 = 14.14;
                tc.Property15 = 15.15;
                tc.Property16 = 16.16;
                tc.Property17 = 17.17;
                tc.Property18 = 18.18;
                tc.Property19 = 19.19;
                tc.Property20 = 20.20;
                tc.Property21 = 21.21;
                tc.Property22 = 22.22;
                tc.Property23 = 23.23;
                tc.Property24 = 24.24;
                tc.Property25 = 25.25;
                tc.Property26 = 26.26;
                tc.Property27 = 27.27;
                tc.Property28 = 28.28;
                tc.Property29 = 29.29;
                tc.Property30 = 30.30;
                tc.Property31 = 31.31;
                tc.Property32 = 32.32;
                tc.Property33 = 33.33;
                tc.Property34 = 34.34;
                tc.Property35 = 35.35;
                tc.Property36 = 36.36;
                tc.Property37 = 37.37;
                tc.Property38 = 38.38;
                tc.Property39 = 39.39;
                tc.Property40 = 40.40;
                tc.Property41 = 41.41;
                tc.Property42 = 42.42;
                tc.Property43 = 43.43;
                tc.Property44 = 44.44;
                tc.Property45 = 45.45;
                tc.Property46 = 46.46;
                tc.Property47 = 47.47;
                tc.Property48 = 48.48;
                tc.Property49 = 49.49;

                result.Add(tc);
            }

            return result;
        }

        [Benchmark]
        public List<TestClassSentinelValues> SentinelValuesCreeateAndSet50Properties()
        {
            var result = new List<TestClassSentinelValues>(Count);

            for (int i = 0; i < Count; i++)
            {
                var tc = new TestClassSentinelValues();
                tc.Property0 = 0.0;
                tc.Property1 = 1.1;
                tc.Property2 = 2.2;
                tc.Property3 = 3.3;
                tc.Property4 = 4.4;
                tc.Property5 = 5.5;
                tc.Property6 = 6.6;
                tc.Property7 = 7.7;
                tc.Property8 = 8.8;
                tc.Property9 = 9.9;
                tc.Property10 = 10.10;
                tc.Property11 = 11.11;
                tc.Property12 = 12.12;
                tc.Property13 = 13.13;
                tc.Property14 = 14.14;
                tc.Property15 = 15.15;
                tc.Property16 = 16.16;
                tc.Property17 = 17.17;
                tc.Property18 = 18.18;
                tc.Property19 = 19.19;
                tc.Property20 = 20.20;
                tc.Property21 = 21.21;
                tc.Property22 = 22.22;
                tc.Property23 = 23.23;
                tc.Property24 = 24.24;
                tc.Property25 = 25.25;
                tc.Property26 = 26.26;
                tc.Property27 = 27.27;
                tc.Property28 = 28.28;
                tc.Property29 = 29.29;
                tc.Property30 = 30.30;
                tc.Property31 = 31.31;
                tc.Property32 = 32.32;
                tc.Property33 = 33.33;
                tc.Property34 = 34.34;
                tc.Property35 = 35.35;
                tc.Property36 = 36.36;
                tc.Property37 = 37.37;
                tc.Property38 = 38.38;
                tc.Property39 = 39.39;
                tc.Property40 = 40.40;
                tc.Property41 = 41.41;
                tc.Property42 = 42.42;
                tc.Property43 = 43.43;
                tc.Property44 = 44.44;
                tc.Property45 = 45.45;
                tc.Property46 = 46.46;
                tc.Property47 = 47.47;
                tc.Property48 = 48.48;
                tc.Property49 = 49.49;

                result.Add(tc);
            }

            return result;
        }

        [Benchmark]
        public List<TestClassBitArray> BitArrayCreeateAndSet50Properties()
        {
            var result = new List<TestClassBitArray>(Count);

            for (int i = 0; i < Count; i++)
            {
                var tc = new TestClassBitArray();
                tc.Property0 = 0.0;
                tc.Property1 = 1.1;
                tc.Property2 = 2.2;
                tc.Property3 = 3.3;
                tc.Property4 = 4.4;
                tc.Property5 = 5.5;
                tc.Property6 = 6.6;
                tc.Property7 = 7.7;
                tc.Property8 = 8.8;
                tc.Property9 = 9.9;
                tc.Property10 = 10.10;
                tc.Property11 = 11.11;
                tc.Property12 = 12.12;
                tc.Property13 = 13.13;
                tc.Property14 = 14.14;
                tc.Property15 = 15.15;
                tc.Property16 = 16.16;
                tc.Property17 = 17.17;
                tc.Property18 = 18.18;
                tc.Property19 = 19.19;
                tc.Property20 = 20.20;
                tc.Property21 = 21.21;
                tc.Property22 = 22.22;
                tc.Property23 = 23.23;
                tc.Property24 = 24.24;
                tc.Property25 = 25.25;
                tc.Property26 = 26.26;
                tc.Property27 = 27.27;
                tc.Property28 = 28.28;
                tc.Property29 = 29.29;
                tc.Property30 = 30.30;
                tc.Property31 = 31.31;
                tc.Property32 = 32.32;
                tc.Property33 = 33.33;
                tc.Property34 = 34.34;
                tc.Property35 = 35.35;
                tc.Property36 = 36.36;
                tc.Property37 = 37.37;
                tc.Property38 = 38.38;
                tc.Property39 = 39.39;
                tc.Property40 = 40.40;
                tc.Property41 = 41.41;
                tc.Property42 = 42.42;
                tc.Property43 = 43.43;
                tc.Property44 = 44.44;
                tc.Property45 = 45.45;
                tc.Property46 = 46.46;
                tc.Property47 = 47.47;
                tc.Property48 = 48.48;
                tc.Property49 = 49.49;

                result.Add(tc);
            }

            return result;
        }
    }
}


