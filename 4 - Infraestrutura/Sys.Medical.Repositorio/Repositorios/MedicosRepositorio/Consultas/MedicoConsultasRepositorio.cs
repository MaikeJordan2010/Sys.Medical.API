using JORM._Extensions;
using Sys.Medical.Dominio.Medico;
using Sys.Medical.Repositorio.Context;

namespace Sys.Medical.Repositorio.Repositorios.MedicosRepositorio.Consultas
{
    public class MedicoConsultasRepositorio(IDbContext dbContext) : IMedicoConsultasRepositorio
    {
        private readonly IDbContext _dbContext = dbContext;

        public IEnumerable<Medico> ObterLista()
        {
            try
            {
                using var conn = _dbContext.ObterConexao();
                var resultado = conn.Query<Medico>().ExecuteQuery();
                return resultado ?? [];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message); 
            }
        }
        public IEnumerable<Medico> ObterLista(int codEspecialidade)
        {
            try
            {
                using var conn = _dbContext.ObterConexao();
                var resultado = conn.Query<Medico>().WHERE(x => x.CodEspecialidade == codEspecialidade).ExecuteQuery();
                return resultado ?? [];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Medico? ObterMedico(string codMedico)
        {
            try
            {
                using var conn = _dbContext.ObterConexao();
                var resultado = conn.Query<Medico>().WHERE(x => x.CodMedico == codMedico).ExecuteQuery().FirstOrDefault();
                return resultado ?? default;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Medico? ObterPorUsuario(string usuario)
        {
            try
            {
                using var conn = _dbContext.ObterConexao();
                var resultado = conn.Query<Medico>().WHERE(x => x.CRM == usuario || x.CPF == usuario).ExecuteQuery().FirstOrDefault();
                return resultado ?? default;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
