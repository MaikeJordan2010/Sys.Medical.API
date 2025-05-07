namespace Sys.Medical.Dominio.TratarDados
{
    public static class VerificaFeriados
    {
        public static bool IsFeriado(DateTime data)
        {
            List<DateTime> feriados = new List<DateTime>
            {
                new DateTime(DateTime.Now.Year, 1, 1), // Ano Novo
                new DateTime(DateTime.Now.Year, 4, 12), // Páscoa
                new DateTime(DateTime.Now.Year, 4, 21), // Tiradentes
                new DateTime(DateTime.Now.Year, 5, 1), // Dia do Trabalho
                new DateTime(DateTime.Now.Year, 6, 16), // Corpus Christi
                new DateTime(DateTime.Now.Year, 9, 7), // Independência
                new DateTime(DateTime.Now.Year, 10, 12), // Nossa Senhora Aparecida
                new DateTime(DateTime.Now.Year, 11, 2), // Finados
                new DateTime(DateTime.Now.Year, 11, 15), // Proclamação da República
                new DateTime(DateTime.Now.Year, 12, 25) // Natal
            };

            return feriados.Contains(data);
        }
    }
}
