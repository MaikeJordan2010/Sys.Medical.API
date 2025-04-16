using Sys.Medical.Dominio.Medico;

namespace Sys.Medical.Repositorio.Repositorios.EspecialidadesRepositorio.Consultas
{
    public interface IEspecialidadesConsultasRepositorio
    {
        public IEnumerable<Especialidade> ObterLista();
    }
}
