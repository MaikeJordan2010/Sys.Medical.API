using JORM.Models.DataAnotations;

namespace Sys.Medical.Dominio.Medico
{
    [TableName("TabEspecialidades")]
    public class Especialidade
    {
        public int CodEspecialidade { get; set; }
        public string? NomeEspecialidade { get; set; }

    }
}
