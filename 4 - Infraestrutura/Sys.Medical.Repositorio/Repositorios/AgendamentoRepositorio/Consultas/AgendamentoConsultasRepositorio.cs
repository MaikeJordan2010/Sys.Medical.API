using JORM._Extensions;
using Sys.Medical.Dominio.DTOs;
using Sys.Medical.Repositorio.Context;

namespace Sys.Medical.Repositorio.Repositorios.AgendamentoRepositorio.Consultas
{
    public class AgendamentoConsultasRepositorio(IDbContext dbContext) : IAgendamentoConsultasRepositorio
    {   
        private readonly IDbContext _dbContext = dbContext;
        public IEnumerable<Agenda> ObterPorMedico(string codMedico)
        {
            using var conn = _dbContext.ObterConexao();
            var resultado = conn.Query<Agenda>().WHERE(x => x.CodMedico == codMedico).ExecuteQuery();
            return resultado ?? [];
        }
       
        public IEnumerable<Agenda> ObterLista()
        {
            using var conn = _dbContext.ObterConexao();
            var resultado = conn.Query<Agenda>().ExecuteQuery();
            return resultado ?? [];
        }

        public Agenda? ObterAgenda(string codAgenda)
        {
            using var conn = _dbContext.ObterConexao();
            var resultado = conn.Query<Agenda>().WHERE(x => x.CodAgenda == codAgenda).ExecuteQuery().FirstOrDefault();
            return resultado ?? default;
        }
    }
}
