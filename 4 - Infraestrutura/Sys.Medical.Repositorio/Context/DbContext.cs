
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
                var sqlClient = new SqlConnection("Server=localhost\\SQLEXPRESS01;Database=FIAP_Atividade03;User Id=sa;password=123456;Encrypt=False");

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
