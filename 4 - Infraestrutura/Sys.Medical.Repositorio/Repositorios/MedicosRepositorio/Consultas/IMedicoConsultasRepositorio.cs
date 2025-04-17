using Sys.Medical.Dominio.Medico;

namespace Sys.Medical.Repositorio.Repositorios.MedicosRepositorio.Consultas
{
    public interface IMedicoConsultasRepositorio
    {
        public IEnumerable<Medico> ObterLista();
        public IEnumerable<Medico> ObterLista(int codEspecialidade);
        public Medico? ObterMedico(string codMedico);
        public Medico? ObterPorUsuario(string usuario);

    }
}
