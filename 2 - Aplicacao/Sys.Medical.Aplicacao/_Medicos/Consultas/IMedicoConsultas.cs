using Sys.Medical.Dominio.Medico;

namespace Sys.Medical.Aplicacao._Medicos.Consultas
{
    public interface IMedicoConsultas
    {
        public IEnumerable<Medico> ObterLista();
        public IEnumerable<Medico> ObterLista(int especialidade);
        public Medico? ObterMedico(string codMedico);
    }
}
