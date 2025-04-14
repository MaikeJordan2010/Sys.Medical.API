using JORM.Models.DataAnotations;
using Sys.Medical.Dominio.Sistemicas;

namespace Sys.Medical.Dominio.Medico
{
    [TableName("TabMedicos")]
    public class Medico
    {
        public string? CodMedico { get; set; }
        public string? NomeMedico { get; set; }
        public string? Email { get; set; }
        public string? CRM { get; set; }
        public string? CPF { get; set; }
        public string? Senha { get; set; }
        public DateTime DataIns { get; set; }
        public int? Especialidade { get; set; }
        public bool? Ativo { get; set; }

        public Medico()
        {

        }
        public Medico(CadastroUsuario usuario)
        {
            CodMedico = Guid.NewGuid().ToString();
            NomeMedico = usuario.Nome;
            CRM = usuario.CRM;
            CPF = usuario.CPF;
            Senha = GerenciarSenhas.ComputeHash(usuario.Senha!);
            Email = usuario.Email;
            DataIns = DateTime.Now;
            Especialidade = usuario?.Especialidade;
            Ativo = true;
        }
    }
}
