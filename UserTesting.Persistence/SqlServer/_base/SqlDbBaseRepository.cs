using System.Data;
using System.Data.SqlClient;
using UserTesting.Persistence.Configurations;

namespace UserTesting.Persistence.SqlServer._base
{
    public class SqlDbBaseRepository
    {
        public SqlDbBaseRepository(IDatabaseSettings dbConfig)
        {
          
            _connectionString = dbConfig.CurrentConnection;
        }

        protected string _connectionString { get; set; }



        public IDbConnection Connection => new SqlConnection(_connectionString);
    }
}
