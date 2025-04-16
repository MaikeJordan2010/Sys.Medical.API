using Sys.Medical.Dominio.DTOs;

namespace Sys.Medical.Dominio.ViewModel
{
    public class AgendaSaida : Agenda
    {
        public string? NomeMedico { get; set; }
        public string? NomePaciente { get; set; }

    }
}
