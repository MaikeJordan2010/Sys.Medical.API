using Sys.Medical.Dominio.Medico;
using Sys.Medical.Repositorio.Repositorios.MedicosRepositorio.Consultas;

namespace Sys.Medical.Aplicacao._Medicos.Consultas
{
    public class MedicoConsultas : IMedicoConsultas
    {
        private readonly IMedicoConsultasRepositorio _medicoConsultasRepositorio;
        public MedicoConsultas(IMedicoConsultasRepositorio medicoConsultasRepositorio)
        {
            _medicoConsultasRepositorio = medicoConsultasRepositorio;
        }
        public IEnumerable<Medico> ObterLista()
        {
            return _medicoConsultasRepositorio.ObterLista();
        }

        public IEnumerable<Medico> ObterLista(int especialidade)
        {
            return _medicoConsultasRepositorio.ObterLista(especialidade);
        }

        public Medico? ObterMedico(string codMedico)
        {
            return _medicoConsultasRepositorio.ObterMedico(codMedico);
        }
    }
}
