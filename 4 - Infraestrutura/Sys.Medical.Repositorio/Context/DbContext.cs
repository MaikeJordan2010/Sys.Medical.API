
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Sys.Medical.Repositorio.Context
{
    public class DbContext : IDbContext
    {
        private readonly IConfiguration _config;

        public DbContext(IConfiguration config)
        {
            _config = config;
        }
        public SqlConnection ObterConexao()
        {
            try
            {
                var sqlClient = new SqlConnection(_config.GetConnectionString("DefaultConnection"));

                sqlClient.Open();

                return sqlClient;
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
