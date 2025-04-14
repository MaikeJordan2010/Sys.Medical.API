using JORM._Extensions;
using Sys.Medical.Dominio.Medico;
using Sys.Medical.Repositorio.Context;

namespace Sys.Medical.Repositorio.Repositorios.MedicosRepositorio.Comandos
{
    public class MedicoComandosRepositorio(IDbContext dbContext) : IMedicoComandosRepositorio
    {
        private readonly IDbContext _dbContext = dbContext;

        public void Inserir(Medico medico) 
        {
            try
            {
                using var conn = _dbContext.ObterConexao();
                conn.Insert<Medico>().INSERT(medico).ExecuteNoQuery();
            }
            catch (Exception ex) 
            { 
                throw new Exception(ex.Message);
            }
        }

        public void Atualizar(Medico medico)
        {
            try
            {
                using var conn = _dbContext.ObterConexao();
                conn.Update<Medico>().UPDATE(medico).WHERE(x => x.CodMedico == medico.CodMedico).ExecuteNoQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
