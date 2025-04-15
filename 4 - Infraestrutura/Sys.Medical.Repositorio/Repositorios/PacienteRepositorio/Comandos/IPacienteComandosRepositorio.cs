using Sys.Medical.Dominio.Paciente;

namespace Sys.Medical.Repositorio.Repositorios.PacienteRepositorio.Comandos
{
    public interface IPacienteComandosRepositorio
    {
        public void Inserir(Paciente paciente);
        public void Atualizar(Paciente paciente);
    }
}
