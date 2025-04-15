using Sys.Medical.Dominio.Sistemicas;

namespace Sys.Medical.Dominio.Paciente
{
    public class Paciente
    {
        public string? CodPaciente { get; set; }
        public string? NomePaciente { get; set; }
        public string? CPF { get; set; }
        public string? Email { get; set; }
        public bool? Ativo { get; set; }
        public string? Senha { get; set; }
        public DateTime? DataIns { get; set; }

        public Paciente()
        {
            
        }

        public Paciente(CadastroPaciente cadastroPaciente)
        {
            this.CodPaciente = Guid.NewGuid().ToString();
            this.NomePaciente = cadastroPaciente.NomePaciente;
            this.CPF = cadastroPaciente.CPF;
            this.Senha = GerenciarSenhas.ComputeHash(cadastroPaciente.Senha!);
            this.Ativo = true;
            this.DataIns = DateTime.Now;    
            
        }

    }
}
