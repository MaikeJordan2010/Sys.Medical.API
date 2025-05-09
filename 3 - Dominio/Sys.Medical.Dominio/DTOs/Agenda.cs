﻿using JORM.Models.DataAnotations;

namespace Sys.Medical.Dominio.DTOs
{
    [TableName("TabAgendamentos")]
    public class Agenda
    {
        public string? CodAgenda { get; set; }
        public string? CodMedico { get; set; }
        public string? CodPaciente { get; set; }
        public DateTime? DataInicioConsulta { get; set; }
        public DateTime? DataFinalConsulta { get; set; }
        public int TempoConsulta { get; set; }
        public int StatusConsulta { get; set; }
        public float? Valor { get; set; }


    }
}
