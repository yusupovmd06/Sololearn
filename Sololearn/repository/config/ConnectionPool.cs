using Microsoft.Data.SqlClient;

namespace Sololearn.repository.config
{
    public static class ConnectionPool
    {
        public static SqlConnection GetConnection()
        {

            string connectionString = @"Data Source=.; Initial Catalog=quizappdb; Integrated Security=True; TrustServerCertificate=True";
            try
            {
                return new SqlConnection(connectionString);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }



    }
}
