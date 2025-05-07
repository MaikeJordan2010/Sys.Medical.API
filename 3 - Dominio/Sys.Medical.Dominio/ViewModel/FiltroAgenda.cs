namespace Sys.Medical.Dominio.ViewModel
{
    public class FiltroAgenda
    {
        public DateTime? DataInicial { get; set; }
        public DateTime? DataFinal { get; set; }
        public string? CodMedico { get; set; }
        public int? CodStatusConsulta { get; set; }
    }
}
