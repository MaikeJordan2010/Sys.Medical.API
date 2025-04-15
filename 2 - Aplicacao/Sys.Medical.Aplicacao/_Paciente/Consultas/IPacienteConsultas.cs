using Sys.Medical.Dominio.Paciente;

namespace Sys.Medical.Aplicacao._Paciente.Consultas
{
    public interface IPacienteConsultas
    {
        public Paciente? ObterPorCod(string codPaciente);
    }
}
