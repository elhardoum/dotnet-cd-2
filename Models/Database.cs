using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DotnetCd.Models
{
    public class Database
    {
        private static readonly Database _instance = new Database();
        public delegate Task QueryCallback<SqlConnection>(SqlConnection conn);

        private Database()
        {
        }

        public static Database Instance()
        {
            return _instance;
        }

        public string getConnectionString()
        {
            return String.Format("Server={0},{1};Database={2};User Id={3};Password={4}",
                Util.getEnv("DB_HOST", "mssql"),
                Util.getEnv("DB_PORT", "1433"),
                Util.getEnv("DB_NAME", "DotnetCd"),
                Util.getEnv("SA_USER", "SA"),
                Util.getEnv("SA_PASSWORD"));
        }

        public static async Task Query(QueryCallback<SqlConnection> callback)
        {
            using (var conn = new SqlConnection(Instance().getConnectionString()))
            {
                try
                {
                    conn.Open();
                    await Task.Run(() => callback(conn));

                    try
                    {
                        conn.Close();
                    } catch (Exception) {}
                }
                catch (SqlException e)
                {
                    Console.WriteLine("Database connection error: {0}, {1}", e.ToString(), e.Message);
                }
            }
        }
    }
}
