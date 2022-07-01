namespace Test
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;
    using Microsoft.Data.SqlClient;
    using System.Collections.Generic;
    using System.Data;

    [MemoryDiagnoser]
    public class Benchmark
    {
        private SqlConnection _conn;

        public int Count { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            _conn = new SqlConnection("Server=.; Integrated Security=sspi; Initial Catalog=AdventureWorks2019;Encrypt=false");
            _conn.Open();
        }

        [Benchmark(Baseline = true)]
        public List<short> ReadDataUsingDataReader()
        {
            var sql = "select * from Sales.SalesOrderDetail";
            using var cmd = new SqlCommand(sql, _conn);
            using var reader = cmd.ExecuteReader();

            var result = new List<short>();
            var ordinal = reader.GetOrdinal("OrderQty");

            while (reader.Read())
            {
                result.Add(reader.GetInt16(ordinal));
            }

            return result;
        }

        [Benchmark]
        public List<short> ReadDataUsingDataSet()
        {
            var sql = "select * from Sales.SalesOrderDetail";
            using var cmd = new SqlCommand(sql, _conn);

            var ds = new DataSet();
            var adapter = new SqlDataAdapter(sql, _conn);
            adapter.Fill(ds);

            var result = new List<short>();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                result.Add((short)row["OrderQty"]);
            }

            return result;
        }
    }
}
