using JORM.Models.DataAnotations;

namespace Sys.Medical.Dominio.DTOs
{
    [TableName("TabAgendamento")]
    public class Agenda
    {
        public string? CodAgenda { get; set; }
        public string? CodMedico { get; set; }
        public string? CodPaciente { get; set; }
        public DateTime DataInicioConsulta { get; set; }
        public DateTime DataFinalConsulta { get; set; }
        public int TempoConsulta { get; set; }
        public int TipoConsulta { get; set; }

    }
}
