using Sys.Medical.Dominio.Paciente;

namespace Sys.Medical.Repositorio.Repositorios.PacienteRepositorio.Consultas
{
    public interface IPacienteConsultasRepositorio
    {
        public Paciente? ObterPorCod(string codPaciente);
        public Paciente? ObterPorEmailOuCPF(string codPaciente);

    }
}
