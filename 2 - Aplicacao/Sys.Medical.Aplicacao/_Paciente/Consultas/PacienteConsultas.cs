using Sys.Medical.Dominio.Paciente;
using Sys.Medical.Repositorio.Repositorios.PacienteRepositorio.Consultas;

namespace Sys.Medical.Aplicacao._Paciente.Consultas
{
    public class PacienteConsultas : IPacienteConsultas
    {
        private readonly IPacienteConsultasRepositorio _pacienteConsultasRepositorio;

        public PacienteConsultas(IPacienteConsultasRepositorio pacienteConsultasRepositorio)
        {
            _pacienteConsultasRepositorio = pacienteConsultasRepositorio;
        }
        public Paciente? ObterPorCod(string codPaciente)
        {
            if(string.IsNullOrEmpty(codPaciente))
                return default;

            return _pacienteConsultasRepositorio.ObterPorCod(codPaciente);
        }
    }
}
