using Microsoft.Data.SqlClient;

namespace Sys.Medical.Repositorio.Context
{
    public interface IDbContext
    {
        public SqlConnection ObterConexao();
    }
}
