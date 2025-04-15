using JORM._Extensions;
using Sys.Medical.Dominio.Paciente;
using Sys.Medical.Repositorio.Context;

namespace Sys.Medical.Repositorio.Repositorios.PacienteRepositorio.Comandos
{
    public class PacienteComandosRepositorio(IDbContext dbContext) : IPacienteComandosRepositorio
    {
        private readonly IDbContext _dbContext = dbContext;
        public void Atualizar(Paciente paciente)
        {
            try
            {
                using var conn = _dbContext.ObterConexao();
                conn.Update<Paciente>().UPDATE(paciente).WHERE(x => x.CodPaciente == paciente.CodPaciente ).ExecuteNoQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Inserir(Paciente paciente)
        {
            try
            {
                using var conn = _dbContext.ObterConexao();
                conn.Insert<Paciente>().INSERT(paciente).ExecuteNoQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
