using JORM._Extensions;
using Sys.Medical.Dominio.DTOs;
using Sys.Medical.Dominio.ViewModel;
using Sys.Medical.Repositorio.Context;
using Sys.Medical.Repositorio.Filtros;
using System.Text;

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

        public IEnumerable<Agenda> ObterPorPaciente(string codPaciente)
        {
            using var conn = _dbContext.ObterConexao();
            var resultado = conn.Query<Agenda>().WHERE(x => x.CodPaciente == codPaciente).ExecuteQuery();
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
            var resultado = conn.Query<AgendaSaida>().WHERE(x => x.CodAgenda == codAgenda).ExecuteQuery().FirstOrDefault();
            return resultado ?? default;
        }

        public AgendaSaida? ObterAgendaSaida(string codAgenda)
        {
            var query = new StringBuilder();
            query.Append($"SELECT *, TabMedicos.NomeMedico, TabPacientes.NomePaciente ");
            query.Append("FROM TabAgendamentos ");
            query.Append("INNER JOIN TabMedicos ON TabMedicos.CodMedico = TabAgendamento.CodMedico ");
            query.Append("INNER JOIN TabPacientes ON TabPacientes.CodPaciente = TabAgendamento.CodPaciente ");
            query.Append("WHERE TabAgendamento = @codAgenda ");

            using var conn = _dbContext.ObterConexao();
            var resultado = conn.Query<AgendaSaida>().ExecuteQuery(query.ToString(), new {codAgenda = codAgenda}).FirstOrDefault();
            return resultado ?? default;
        }


        public IEnumerable<AgendaSaida> ObterPorFiltro(FiltroAgenda filtro)
        {
            var consulta = MontarFiltroAgenda.ObterConsulta(filtro);

            var query = new StringBuilder();
            query.Append($"SELECT TabAgendamentos.*, TabMedicos.NomeMedico, TabPacientes.NomePaciente, (TabPacientes.CPF) CpfPaciente ");
            query.Append("FROM TabAgendamentos ");
            query.Append("INNER JOIN TabMedicos ON TabMedicos.CodMedico = TabAgendamentos.CodMedico ");
            query.Append("LEFT JOIN TabPacientes ON TabPacientes.CodPaciente = TabAgendamentos.CodPaciente ");

            if (!string.IsNullOrEmpty(consulta))
            {
                query.Append($"WHERE {consulta} ");
                query.Append($"ORDER BY DataInicioConsulta ");
            }

            using var conn = _dbContext.ObterConexao();
            var resultado = conn.Query<AgendaSaida>().ExecuteQuery(query.ToString(), filtro);
            return resultado ?? Enumerable.Empty<AgendaSaida>();
        }
    }
}
