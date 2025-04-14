using Sys.Medical.Dominio.DTOs;

namespace Sys.Medical.Repositorio.Repositorios.AgendamentoRepositorio.Comandos
{
    public interface IAgendamentoComandosRepositorio
    {
        public void Inserir(Agenda agendamento);
        public void Atualizar(Agenda agendamento);

    }
}
