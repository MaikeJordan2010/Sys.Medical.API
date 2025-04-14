using Sys.Medical.Dominio.Medico;

namespace Sys.Medical.Repositorio.Repositorios.MedicosRepositorio.Comandos
{
    public interface IMedicoComandosRepositorio
    {
        public void Inserir(Medico medico);
        public void Atualizar(Medico medico);
    }
}
