using JORM._Extensions;
using Sys.Medical.Dominio.Paciente;
using Sys.Medical.Repositorio.Context;

namespace Sys.Medical.Repositorio.Repositorios.PacienteRepositorio.Consultas
{
    public class PacienteConsultasRepositorio(IDbContext dbContext) : IPacienteConsultasRepositorio
    {
        private readonly IDbContext _dbContext = dbContext;
        public Paciente? ObterPorCod(string codPaciente)
        {
            using var conn = _dbContext.ObterConexao();
            var resultado = conn.Query<Paciente>().WHERE(x => x.CodPaciente == codPaciente).ExecuteQuery().FirstOrDefault();
            return resultado ?? default;
        }

        public Paciente? ObterPorEmailOuCPF(string usuario)
        {
            using var conn = _dbContext.ObterConexao();
            var resultado = conn.Query<Paciente>().WHERE(x => x.CPF == usuario || x.Email == usuario).ExecuteQuery().FirstOrDefault();
            return resultado ?? default;
        }
    }
}
