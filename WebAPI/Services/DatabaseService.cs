using Microsoft.Data.SqlClient;
using System.Data;

namespace WebAPI.Services
{
    public class DatabaseService
    {
        string _connectionString;
        public DatabaseService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
