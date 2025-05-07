using Sys.Medical.Dominio.ViewModel;
using System.Text;

namespace Sys.Medical.Repositorio.Filtros
{
    public static class MontarFiltroAgenda
    {
        public static string ObterConsulta(FiltroAgenda filtroAgenda)
        {
            var consulta = new StringBuilder();

            if (filtroAgenda.DataInicial != null && filtroAgenda.DataFinal != null)
            {
                consulta.Append($" ( TabAgendamentos.DataInicioConsulta BETWEEN @DataInicial AND @DataFinal ) AND ");
            }

            if (filtroAgenda.CodStatusConsulta != null)
            {
                consulta.Append($" TabAgendamentos.StatusConsulta = @CodStatusConsulta AND ");
            }

            if (filtroAgenda.CodMedico != null)
            {
                consulta.Append($" TabAgendamentos.CodMedico = @CodMedico AND ");
            }

            if(consulta.Length > 0) 
                return consulta.ToString().Substring(0, consulta.Length - 4);

            return string.Empty;
        }
    }
}
