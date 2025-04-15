using FluentValidation;
using Sys.Medical.Dominio.Paciente;

namespace Sys.Medical.Aplicacao._Paciente.Validadores
{
    public class ValidarCriarUsuarioPaciente : AbstractValidator<CadastroPaciente>
    {
        public ValidarCriarUsuarioPaciente()
        {
            RuleFor(x => x.CPF).NotEmpty();
            RuleFor(x => x.NomePaciente).NotEmpty();
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Senha).NotEmpty();
        }
    }
}
