
namespace Gießformkonfigurator.WindowsForms.DataAccess
{
    using System.Configuration;
    using System.Data.SqlClient;

    public class DBConnection
    {
        private void connectDB(string database)
        {
            string connectionString = ConfigurationManager.ConnectionStrings[database].ToString();
            using (SqlConnection db = new SqlConnection(connectionString))
            {
                SqlCommand query = new SqlCommand();
                SqlDataReader dataReader;
                string queryString, output = string.Empty;
                queryString = "Select * From Baseplates";
                query = new SqlCommand(queryString, db);
                dataReader = query.ExecuteReader();
                while (dataReader.Read())
                {
                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        output = output + "  " + dataReader.GetValue(i);
                    }
                }
            }
        }
    }
}