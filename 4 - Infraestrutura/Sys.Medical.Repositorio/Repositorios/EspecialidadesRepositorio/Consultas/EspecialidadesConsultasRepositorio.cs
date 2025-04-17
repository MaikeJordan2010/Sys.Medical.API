using JORM._Extensions;
using Sys.Medical.Dominio.Medico;
using Sys.Medical.Repositorio.Context;

namespace Sys.Medical.Repositorio.Repositorios.EspecialidadesRepositorio.Consultas
{
    public class EspecialidadesConsultasRepositorio(IDbContext dbContext) : IEspecialidadesConsultasRepositorio
    {
        private readonly IDbContext _dbContext = dbContext;
        public IEnumerable<Especialidade> ObterLista()
        {
            using var conn = _dbContext.ObterConexao();
            var resultado = conn.Query<Especialidade>().ExecuteQuery();
            return resultado ?? [];
        }
    }
}
