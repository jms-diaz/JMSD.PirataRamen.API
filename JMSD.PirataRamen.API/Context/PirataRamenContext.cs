using Microsoft.Data.SqlClient;
using System.Data;

namespace JMSD.PirataRamen.API.Context
{
    public class PirataRamenContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public PirataRamenContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public IDbConnection CreateConnection()
            => new SqlConnection(_connectionString);
    }
}
