namespace Sys.Medical.Dominio.ViewModel
{
    public class AgendaMensal
    {
        public string? CodMedico { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
        public bool Domingo { get; set; }
        public bool Segunda { get; set; }
        public bool Terca { get; set; }
        public bool Quarta { get; set; }
        public bool Quinta { get; set; }
        public bool Sexta { get; set; }
        public bool Sabado { get; set; }
        public bool DesconsiderarFeriados { get; set; }
        public string? HoraInicioTurno { get; set; }
        public string? HoraFimTurno { get; set; }
        public int TempoMedioAtendimento { get; set; }
        public float? Valor { get; set; }


        public bool DiaValido(DateTime dataInicial)
        {

            return (dataInicial.DayOfWeek) switch
            {
                DayOfWeek.Sunday => this.Domingo,
                DayOfWeek.Monday => this.Segunda,
                DayOfWeek.Tuesday => this.Terca,
                DayOfWeek.Wednesday => this.Quarta,
                DayOfWeek.Thursday => this.Quinta,
                DayOfWeek.Friday => this.Sexta,
                DayOfWeek.Saturday => this.Sabado,
                _ => false
            };

        }


    }
}
