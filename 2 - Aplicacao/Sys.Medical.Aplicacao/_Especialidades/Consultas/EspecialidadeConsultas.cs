using Sys.Medical.Dominio.Medico;
using Sys.Medical.Repositorio.Repositorios.EspecialidadesRepositorio.Consultas;

namespace Sys.Medical.Aplicacao._Especialidades.Consultas
{
    public class EspecialidadeConsultas(IEspecialidadesConsultasRepositorio especialidadesConsultasRepositorio) : IEspecialidadeConsultas
    {
        private readonly IEspecialidadesConsultasRepositorio _especialidadesConsultasRepositorio = especialidadesConsultasRepositorio;
        public IEnumerable<Especialidade> ObterLista()
        {
            return _especialidadesConsultasRepositorio.ObterLista();
        }
    }
}
