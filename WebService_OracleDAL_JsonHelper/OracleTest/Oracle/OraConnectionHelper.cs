using System;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Data.Common;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            string connString = "DATA SOURCE=192.168.10.254;PERSIST SECURITY INFO=True;USER ID=user_whhdj;Password=123";
            string ProviderName = "Oracle.DataAccess.Client";

            DbProviderFactory factory = DbProviderFactories.GetFactory(ProviderName);

            using (DbConnection conn = factory.CreateConnection())
            {
                conn.ConnectionString = connString;
                conn.Open();

                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "select * from emp";
                cmd.CommandType = CommandType.Text;

                DbDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine("{0}\t{1}", dr[0], dr[1]);
                }
                dr.Close();
            }
            Console.ReadLine();
        }
    }
}