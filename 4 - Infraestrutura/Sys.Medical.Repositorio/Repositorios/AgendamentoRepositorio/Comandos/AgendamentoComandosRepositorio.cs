using JORM._Extensions;
using Sys.Medical.Dominio.DTOs;
using Sys.Medical.Repositorio.Context;

namespace Sys.Medical.Repositorio.Repositorios.AgendamentoRepositorio.Comandos
{
    public class AgendamentoComandosRepositorio(IDbContext dbContext) : IAgendamentoComandosRepositorio
    {
        private readonly IDbContext _dbContext = dbContext;
        public void Inserir(Agenda agendamento)
        {
            try
            {
                using var conn = _dbContext.ObterConexao();
                conn.Insert<Agenda>().INSERT(agendamento).ExecuteNoQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Atualizar(Agenda agendamento)
        {
            try
            {
                using var conn = _dbContext.ObterConexao();
                conn.Update<Agenda>().UPDATE(agendamento).WHERE(x => x.CodAgenda == agendamento.CodAgenda).ExecuteNoQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
