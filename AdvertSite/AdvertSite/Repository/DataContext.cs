using System.Data;
using System.Data.SqlClient;

namespace AdvertSite.Repository
{
    public static class DataContext
    {
        private static string _connString = "Data Source=JESSICASLAPTOP\\MSSQLSERVER01;Initial Catalog=AdvertSiteDB;Integrated Security=SSPI;TrustServerCertificate=True;";

        //Select-hantering. Returnerar en DataTable
        public static DataTable ExecuteQueryReturnTable(string sql, List<SqlParameter> parameters)
        {
            using(SqlConnection conn = new SqlConnection(_connString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql, conn);

                foreach (SqlParameter parameter in parameters)
                {
                    cmd.Parameters.Add(parameter);
                }

                DataTable result = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(result);

                return result;
            }
        }

        //Insert-hantering. Returnerar inget.
        public static void ExecuteNonQuery(string sql, List<SqlParameter> parameters)
        {
            using(SqlConnection conn = new SqlConnection(_connString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql, conn);

                foreach (SqlParameter parameter in parameters)
                {
                    cmd.Parameters.Add(parameter);
                }

                cmd.ExecuteNonQuery();
            }
        }
    }
}
