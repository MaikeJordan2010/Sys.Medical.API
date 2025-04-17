using Sys.Medical.Dominio.Medico;

namespace Sys.Medical.Aplicacao._Especialidades.Consultas
{
    public interface IEspecialidadeConsultas
    {
        public IEnumerable<Especialidade> ObterLista();
    }
}
